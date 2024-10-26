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

namespace Bida
{
    public partial class frmOrder : Form
    {
        private BAN ban;
        private NHANVIEN nhanvien;
        private List<ORDER> orders;
        private ORDER oRDER;
        private Dictionary<int, List<ORDER>> ordersByTable = new Dictionary<int, List<ORDER>>();

        public frmOrder(BAN b, NHANVIEN n)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = n;
        }
        private void LoadDataToDataGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS01;Initial Catalog=Bida;Integrated Security=True;"))
                {
                    conn.Open();
                    // Sử dụng câu lệnh SQL để lấy dữ liệu từ bảng Order dựa trên MABAN của bàn đã chọn
                    string query = "SELECT TENNUOC, PRICE, SOLUONGKHACHMUA FROM [Order] WHERE MABAN = @MABAN";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MABAN", ban.MABAN); // Thêm tham số MABAN vào câu truy vấn

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable vào DataGridView
                    dgvThucDon.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi không thể kết nối hoặc truy vấn dữ liệu
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadLoaiNuocToComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS01;Initial Catalog=Bida;Integrated Security=True;"))
                {
                    conn.Open();
                    string query = "SELECT TENNUOC, PRICE FROM [ORDER]"; // Giả sử bảng Loại Nước có tên là LoaiNuoc
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    comboLoaiNuoc.DataSource = dataTable;
                    comboLoaiNuoc.DisplayMember = "TENNUOC"; // Hiển thị tên nước
                    comboLoaiNuoc.ValueMember = "PRICE"; // Giá nước được gán vào giá trị
                    comboLoaiNuoc.SelectedIndex = -1; // Không chọn loại nước nào khi load form
                    textGiaTien.Text = "0";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu loại nước: " + ex.Message);
            }
        }


        private void frmOrder_Load(object sender, EventArgs e)
        {

            LoadDataToDataGridView();
            LoadLoaiNuocToComboBox();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmBan frmBan = new frmBan(this.ban, this.nhanvien);
            frmBan.Show();
            this.Close(); // Đóng frmOrder sau khi frmBan được mở
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ ComboBox và NumericUpDown
                string tenNuoc = comboLoaiNuoc.Text;
                if (comboLoaiNuoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn loại nước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal giaTien = Convert.ToDecimal(comboLoaiNuoc.SelectedValue);
                int soLuongMua = (int)mudSLMua.Value;

                // Tính tổng tiền
                decimal tongTien = giaTien * soLuongMua;

                // Tạo đối tượng ORDER để lưu thông tin đơn hàng
                ORDER newOrder = new ORDER
                {
                    TENNUOC = tenNuoc,
                    PRICE = (int)giaTien,
                    SOLUONGKHACHMUA = soLuongMua,
                    MABAN = ban.MABAN,
                    M
                };

                // Lưu đơn hàng vào cơ sở dữ liệu
                LuuDonHangVaoCSDL(newOrder);

                // Thông báo thành công
                MessageBox.Show("Đơn hàng đã được lưu thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message);
            }
        }


        private void LuuDonHangVaoCSDL(ORDER order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS01;Initial Catalog=Bida;Integrated Security=True;"))
                {
                    conn.Open();
                    // Câu lệnh SQL để thêm đơn hàng vào cơ sở dữ liệu
                    string query = "INSERT INTO [Order] (TENNUOC, PRICE, SOLUONGKHACHMUA, MABAN) VALUES (@TENNUOC, @PRICE, @SOLUONGKHACHMUA, @MABAN)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Thêm các tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@TENNUOC", order.TENNUOC);
                    cmd.Parameters.AddWithValue("@PRICE", order.PRICE);
                    cmd.Parameters.AddWithValue("@SOLUONGKHACHMUA", order.SOLUONGKHACHMUA);
                    cmd.Parameters.AddWithValue("@MABAN", order.MABAN);

                    // Thực thi câu lệnh
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi khi lưu đơn hàng vào cơ sở dữ liệu: " + errorMessage);
            }
        }


        private void comboLoaiNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLoaiNuoc.SelectedValue != null)
            {
                textGiaTien.Text = comboLoaiNuoc.SelectedValue.ToString(); // Cập nhật giá tiền dựa trên loại nước đã chọn
            }
        }
    }
}
