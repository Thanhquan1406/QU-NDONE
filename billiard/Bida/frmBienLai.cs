using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bida.DTO;
using MetroFramework;
using MetroFramework.Forms;

namespace Bida
{
    public partial class frmBienLai : MetroForm
    {
        public BIENLAI bienlai;
        
        public frmBienLai(BIENLAI bl)
        {
            this.bienlai = bl;
            InitializeComponent();
        }

        private void frmBienLai_Load(object sender, EventArgs e)
        {
            lblBan.Text = "" + bienlai.BAN.MABAN;

            lblGiobd.Text = bienlai.GioBD.HasValue
                ? bienlai.GioBD.Value.ToString("HH:mm:ss dd/MM/yyyy")
                : "N/A";  // Hoặc giá trị mặc định bạn muốn hiển thị nếu null

            lblGiokt.Text = bienlai.GioKT.HasValue
                ? bienlai.GioKT.Value.ToString("HH:mm:ss dd/MM/yyyy")
                : "N/A";  // Hoặc giá trị mặc định nếu null

            lblKH.Text = "" + bienlai.KHACHHANG.TENKH;

            lblTongTien.Text = bienlai.TONGTIEN.ToString();  // Đảm bảo rằng TONGTIEN là số hoặc kiểu chuỗi
            lblthoigan.Text = bienlai.ThoiGian.ToString();   // Đảm bảo rằng ThoiGian là số hoặc kiểu chuỗi
        }


        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "In thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Question);
            frmMain a = new frmMain(bienlai.NHANVIEN);
            a.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain a = new frmMain(bienlai.NHANVIEN);
            a.Show();
            this.Close();
        }
    }
}
