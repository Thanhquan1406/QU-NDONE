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
                : "N/A";

            lblGiokt.Text = bienlai.GioKT.HasValue
                ? bienlai.GioKT.Value.ToString("HH:mm:ss dd/MM/yyyy")
                : "N/A"; 

            lblKH.Text = "" + bienlai.KHACHHANG.TENKH;

            lblTongTien.Text = bienlai.TONGTIEN.ToString();
            lblthoigan.Text = bienlai.ThoiGian.ToString();
        }


        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "In thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
