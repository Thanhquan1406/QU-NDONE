﻿using System;
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
                // Lấy danh sách các đơn hàng theo mã bàn từ CSDL
                var orders = context.ORDERs
                                    .Where(o => o.MABAN == maBan)
                                    .Select(o => new
                                    {
                                        TenNuoc = o.NUOC.TENNUOC,
                                        SoLuong = o.SOLUONGKHACHMUA,
                                        GiaTien = o.SOLUONGKHACHMUA * o.NUOC.PRICE
                                    })
                                    .ToList();

                // Xóa các dòng cũ trong DataGridView trước khi thêm dữ liệu mới
                dgvThucDon.Rows.Clear();

                // Thêm dữ liệu vào DataGridView
                foreach (var order in orders)
                {
                    dgvThucDon.Rows.Add(order.TenNuoc, order.SoLuong, order.GiaTien);
                    UpdateTotalPrice();
                }
            }
        }
        private void LoadLoaiNuocToComboBox()
        {
            // Lấy dữ liệu từ cơ sở dữ liệu
            var listNuoc = FetchDataFromDatabase();

            // Gán dữ liệu cho ComboBox
            comboLoaiNuoc.DataSource = listNuoc;
            comboLoaiNuoc.DisplayMember = "TENNUOC"; // Hiển thị tên nước
            comboLoaiNuoc.ValueMember = "MANUOC";    // Giá trị thực tế là mã nước (nếu cần dùng)
        }

        private List<NUOC> FetchDataFromDatabase()
        {
            using (var context = new Model()) // Thay Model1 bằng DbContext thực tế của bạn
            {
                // Lấy tất cả các bản ghi từ bảng NUOC và chuyển thành danh sách
                return context.NUOCs.ToList();
            }
        }


        private void LoadDataToDataGridView()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            // Kiểm tra nếu TextBox trống hoặc giá trị không thể chuyển đổi thành số
            if (string.IsNullOrWhiteSpace(txtTongTien.Text) || !int.TryParse(txtTongTien.Text, out tongTien))
            {
                tongTien = 0; // Gán giá trị tổng tiền là 0 nếu TextBox trống hoặc không hợp lệ
            }

            // Tiếp tục thoát và mở frmBan bất kể giá trị của tongTien
            frmBan frm = new frmBan(ban, nhanvien);
            frm.SetTongTien(tongTien);
            frm.Show();
            this.Close();
        }




        private void btnDat_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng nước hiện tại được chọn từ ComboBox
            var selectedNuoc = comboLoaiNuoc.SelectedItem as NUOC;

            if (selectedNuoc != null)
            {
                // Lấy số lượng từ NumericUpDown
                int soLuong = (int)numSoLuong.Value;

                // Tính giá tiền dựa trên số lượng và giá của loại nước
                int giaTien = soLuong * (selectedNuoc.PRICE.HasValue ? selectedNuoc.PRICE.Value : 0);

                // Kiểm tra xem loại nước đã tồn tại trong DataGridView chưa
                bool found = false;
                foreach (DataGridViewRow row in dgvThucDon.Rows)
                {
                    if (row.Cells["Column1"].Value != null && row.Cells["Column1"].Value.ToString() == selectedNuoc.TENNUOC)
                    {
                        // Nếu tìm thấy món đã tồn tại, cộng dồn số lượng và tính lại tổng giá tiền
                        int currentQuantity = Convert.ToInt32(row.Cells["Column2"].Value);
                        int newQuantity = currentQuantity + soLuong;
                        row.Cells["Column2"].Value = newQuantity;

                        int newPrice = newQuantity * (selectedNuoc.PRICE.HasValue ? selectedNuoc.PRICE.Value : 0);
                        row.Cells["Column3"].Value = newPrice;

                        found = true;
                        break;
                    }
                }

                // Nếu món chưa tồn tại, thêm dòng mới
                if (!found)
                {
                    dgvThucDon.Rows.Add(selectedNuoc.TENNUOC, soLuong, giaTien);
                }

                // Cập nhật tổng tiền
                UpdateTotalPrice();

                // Lưu vào CSDL
                LuuDonHangVaoCSDL(selectedNuoc.MANUOC, soLuong, giaTien);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại nước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LuuDonHangVaoCSDL(int maNuoc, int soLuong, int giaTien)
        {
            using (var context = new Model()) // Thay Model1 bằng DbContext thực tế của bạn
            {
                // Lấy giá trị MADV tiếp theo (giả sử bạn có logic để lấy giá trị này)
                int nextMADV = context.ORDERs.Any() ? context.ORDERs.Max(o => o.MADV) + 1 : 1;

                // Tạo một đối tượng ORDER mới để lưu vào CSDL
                ORDER newOrder = new ORDER
                {
                    MADV = nextMADV,
                    MANUOC = maNuoc,
                    SOLUONGKHACHMUA = soLuong,
                    // Bạn có thể thêm mã bàn và mã biên lai nếu cần
                     MABAN = this.ban.MABAN,
                    // MABIENLAI = <giá trị tương ứng>,
                };

                // Thêm đối tượng mới vào context
                context.ORDERs.Add(newOrder);

                try
                {
                    // Lưu các thay đổi vào CSDL
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

            // Kiểm tra nếu DataGridView có cột "Column3" hay không
            if (dgvThucDon.Columns.Contains("Column3"))
            {
                // Duyệt qua tất cả các dòng trong DataGridView để tính tổng giá tiền
                foreach (DataGridViewRow row in dgvThucDon.Rows)
                {
                    // Kiểm tra nếu ô trong cột "Column3" có giá trị hợp lệ và không phải là dòng mới
                    if (row.Cells["Column3"].Value != null && !row.IsNewRow)
                    {
                        int price;
                        // Kiểm tra nếu giá trị có thể chuyển đổi thành số nguyên
                        if (int.TryParse(row.Cells["Column3"].Value.ToString(), out price))
                        {
                            totalPrice += price;
                        }
                    }
                }

                // Hiển thị tổng giá tiền trong TextBox
                txtTongTien.Text = totalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Cột 'Giá Tiền' không tồn tại trong DataGridView.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void comboLoaiNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy đối tượng nước hiện tại được chọn từ ComboBox
            var selectedNuoc = comboLoaiNuoc.SelectedItem as NUOC;

            if (selectedNuoc != null)
            {
                // Hiển thị giá tiền của loại nước được chọn vào txtGiaTien
                txtGiaTien.Text = selectedNuoc.PRICE.HasValue ? selectedNuoc.PRICE.Value.ToString() : "0";
            }
        }
    }
}
