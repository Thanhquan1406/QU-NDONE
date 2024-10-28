using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bida.BUS;
using Bida.DTO;
using MetroFramework;
using MetroFramework.Forms;

namespace Bida
{
    public partial class frmAdd : MetroForm
    {
        private BAN ban;
        private NHANVIEN nhanvien; 
        public frmAdd(BAN b, NHANVIEN n)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = n;
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtName.Text.Equals(""))
            {
                MessageBox.Show(this, "Chưa điền thông tin đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);


            }
            else
            {
                string tenkh = txtName.Text;
                string sdt = txtsdt.Text;
                KHACHHANG kh = new KHACHHANG(); 
                kh.TENKH = tenkh; 
                kh.SDT = sdt; 
                new KhachHangBUS().addKH(kh);
                MessageBox.Show(this, "Thêm Khách hàng thành công ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Question);
                frmBan a = new frmBan(ban, nhanvien);
                a.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(ban, nhanvien);
            frm.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
