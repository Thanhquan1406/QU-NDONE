using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Bida.BUS;
using Bida.DTO;
using MetroFramework;
using System.Data.SqlClient;
using System.Reflection;

namespace Bida
{
    public partial class frmOrder : Form
    {
        private BAN ban;
        private NHANVIEN nhanvien;
        private List<ORDER> orders;
        private Dictionary<int, List<ORDER>> ordersByTable = new Dictionary<int, List<ORDER>>();
        private List<NUOC> listNuoc;


        public frmOrder(BAN b, NHANVIEN n)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = n;
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            LoadLoaiNuocToComboBox();
            LoadDataByBan(ban.MABAN);
        }
        private void LoadDataByBan(int maBan)
        {
            using (var context = new Model())
            {

                var orders = context.ORDERs
                                    .Where(o => o.MABAN == maBan)
                                    .Select(o => new
                                    {
                                        TenNuoc = o.NUOC.TENNUOC,
                                        SoLuong = o.SOLUONGKHACHMUA,
                                        GiaTien = o.SOLUONGKHACHMUA * o.NUOC.PRICE
                                    })
                                    .ToList();

                dgvThucDon.Rows.Clear();

                foreach (var order in orders)
                {
                    dgvThucDon.Rows.Add(order.TenNuoc, order.SoLuong, order.GiaTien);
                    UpdateTotalPrice();
                }
            }
        }
        private void LoadLoaiNuocToComboBox()
        {
            var listNuoc = FetchDataFromDatabase();

            comboLoaiNuoc.DataSource = listNuoc;
            comboLoaiNuoc.DisplayMember = "TENNUOC";
            comboLoaiNuoc.ValueMember = "MANUOC";  
        }

        private List<NUOC> FetchDataFromDatabase()
        {
            using (var context = new Model())
            {
                return context.NUOCs.ToList();
            }
        }
        private void LoadDataToDataGridView()
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            if (string.IsNullOrWhiteSpace(txtTongTien.Text) || !int.TryParse(txtTongTien.Text, out tongTien))
            {
                tongTien = 0;
            }

            frmBan frm = new frmBan(ban, nhanvien);
            frm.SetTongTien(tongTien);
            frm.Show();
            this.Close();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            var selectedNuoc = comboLoaiNuoc.SelectedItem as NUOC;

            if (selectedNuoc != null)
            {
                int soLuong = (int)numSoLuong.Value;

                int giaTien = soLuong * (selectedNuoc.PRICE.HasValue ? selectedNuoc.PRICE.Value : 0);

                bool found = false;
                foreach (DataGridViewRow row in dgvThucDon.Rows)
                {
                    if (row.Cells["Column1"].Value != null && row.Cells["Column1"].Value.ToString() == selectedNuoc.TENNUOC)
                    {
                        int currentQuantity = Convert.ToInt32(row.Cells["Column2"].Value);
                        int newQuantity = currentQuantity + soLuong;
                        row.Cells["Column2"].Value = newQuantity;

                        int newPrice = newQuantity * (selectedNuoc.PRICE.HasValue ? selectedNuoc.PRICE.Value : 0);
                        row.Cells["Column3"].Value = newPrice;

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dgvThucDon.Rows.Add(selectedNuoc.TENNUOC, soLuong, giaTien);
                }

                UpdateTotalPrice();
                LuuDonHangVaoCSDL(selectedNuoc.MANUOC, soLuong, giaTien);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại nước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LuuDonHangVaoCSDL(int maNuoc, int soLuong, int giaTien)
        {
            using (var context = new Model())
            {
                int nextMADV = context.ORDERs.Any() ? context.ORDERs.Max(o => o.MADV) + 1 : 1;
                ORDER newOrder = new ORDER
                {
                    MADV = nextMADV,
                    MANUOC = maNuoc,
                    SOLUONGKHACHMUA = soLuong,
                     MABAN = this.ban.MABAN,
                };

                context.ORDERs.Add(newOrder);

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Đơn hàng đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateTotalPrice()
        {
            int totalPrice = 0;

            if (dgvThucDon.Columns.Contains("Column3"))
            {
                foreach (DataGridViewRow row in dgvThucDon.Rows)
                {
                    if (row.Cells["Column3"].Value != null && !row.IsNewRow)
                    {
                        int price;
                        if (int.TryParse(row.Cells["Column3"].Value.ToString(), out price))
                        {
                            totalPrice += price;
                        }
                    }
                }
                txtTongTien.Text = totalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Cột 'Giá Tiền' không tồn tại trong DataGridView.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboLoaiNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNuoc = comboLoaiNuoc.SelectedItem as NUOC;

            if (selectedNuoc != null)
            {
                txtGiaTien.Text = selectedNuoc.PRICE.HasValue ? selectedNuoc.PRICE.Value.ToString() : "0";
            }
        }
    }
}
