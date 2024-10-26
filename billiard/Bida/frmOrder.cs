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
        private Dictionary<int, List<ORDER>> ordersByTable = new Dictionary<int, List<ORDER>>();

        public frmOrder(BAN b, NHANVIEN n)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = n;
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-PEH7GUJ\\SQLEXPRESS;Initial Catalog=Bida;Integrated Security=True";
            string query = "SELECT MADV, TENNUOC, PRICE, MABAN FROM [ORDER]"; // Include MABAN in the query

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Kết nối thành công!");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Add a new column for the row number
                    dataTable.Columns.Add("STT", typeof(int));

                    // Add a new column for SLMUA with default value 0
                    dataTable.Columns.Add("SLMUA", typeof(int));

                    // Lấy danh sách đơn hàng đã lưu cho bàn hiện tại nếu có
                    int currentTableID = this.ban.MABAN; // Bàn hiện tại
                    if (ordersByTable.ContainsKey(currentTableID))
                    {
                        var ordersForCurrentTable = ordersByTable[currentTableID];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var order = ordersForCurrentTable.FirstOrDefault(o => o.TENNUOC == row["TENNUOC"].ToString());
                            // Nếu có đơn hàng cho sản phẩm này, cập nhật SLMUA
                            if (order != null)
                            {
                                row["SLMUA"] = order.SOLUONG;
                            }
                            else
                            {
                                row["SLMUA"] = 0; // Nếu không có đơn hàng, đặt mặc định là 0
                            }
                        }
                    }
                    else
                    {
                        // Nếu không có đơn hàng nào cho bàn này, đặt SLMUA mặc định là 0
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["SLMUA"] = 0;
                        }
                    }

                    // Assign row numbers
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["STT"] = i + 1;
                    }

                    // Ensure the DataGridView columns are correctly mapped
                    dataGridView1.AutoGenerateColumns = false; // Ensure columns are manually mapped
                    dataGridView1.Columns["colSTT"].DataPropertyName = "STT";
                    dataGridView1.Columns["colTenNuoc"].DataPropertyName = "TENNUOC";
                    dataGridView1.Columns["colGiaTien"].DataPropertyName = "PRICE";
                    dataGridView1.Columns["colSLMUA"].DataPropertyName = "SLMUA"; // Map the new column
                                                                                  //dataGridView1.Columns["colMABAN"].DataPropertyName = "MABAN"; // Map the MABAN column

                    dataGridView1.DataSource = dataTable;

                    // Add event handler for DataGridView cell click
                    dataGridView1.CellClick += DataGridView1_CellClick;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the click is on a valid row
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtTenNuoc.Text = selectedRow.Cells["colTenNuoc"].Value.ToString();
                textGiaTien.Text = selectedRow.Cells["colGiaTien"].Value.ToString();
                mudSLMua.Value = 0; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(ban, nhanvien);
            frm.Show();
            this.Close();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                int maBan = this.ban.MABAN; // Mã bàn hiện tại

                // Tạo đối tượng ORDER mới và cập nhật số lượng
                ORDER order = new ORDER
                {
                    TENNUOC = selectedRow.Cells["colTenNuoc"].Value.ToString(),
                    PRICE = Convert.ToInt32(Convert.ToDecimal(selectedRow.Cells["colGiaTien"].Value)), // Chuyển đổi sang int
                    SOLUONG = (int)mudSLMua.Value, // Ensure this is an integer value
                    MABAN = maBan
                };

                // Kiểm tra nếu danh sách của bàn này đã tồn tại
                if (!ordersByTable.ContainsKey(maBan))
                {
                    ordersByTable[maBan] = new List<ORDER>();
                }

                // Thêm hoặc cập nhật đơn hàng trong danh sách cho bàn hiện tại
                var existingOrder = ordersByTable[maBan].FirstOrDefault(o => o.TENNUOC == order.TENNUOC);
                if (existingOrder != null)
                {
                    existingOrder.SOLUONG = (int)order.SOLUONG; // Explicitly cast to int
                }
                else
                {
                    ordersByTable[maBan].Add(order); // Thêm đơn hàng mới
                }

                // Cập nhật giá trị SLMUA trong DataTable
                foreach (DataRow row in ((DataTable)dataGridView1.DataSource).Rows)
                {
                    if (row["TENNUOC"].ToString() == order.TENNUOC)
                    {
                        row["SLMUA"] = order.SOLUONG; // Cập nhật SLMUA
                        break; // Thoát khỏi vòng lặp sau khi cập nhật
                    }
                }

                dataGridView1.Refresh(); // Refresh DataGridView
            }
        }

    }
}
