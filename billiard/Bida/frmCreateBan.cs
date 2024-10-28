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
    public partial class frmCreateBan : MetroForm
    {
        private NHANVIEN nhanvien;
        public frmCreateBan(NHANVIEN nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
        }

        private void frmCreateBan_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool loaiban = true;
            
            if (comtype.Text.Equals("Bida France"))
            {
                loaiban = false;
            }
            else
            {
                loaiban = true;
            }
            int re = 0;
            if (comRe.Text.Equals("Khu vực 1"))
            {
                re = 1;
            }
            else
            {
                re = 2;
            }
            string bd = "2016-04-17 00:00:00";

            
            if (comRe.Text.Equals("") || comtype.Text.Equals(""))
            {
                MessageBox.Show(this, "Chưa chọn loại bàn hoặc khu vực bàn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);


            }
            else
            {
                DateTime batdau = DateTime.Parse(bd);
                DateTime kt = DateTime.Parse(bd);

                BAN a = new BAN(loaiban, re, false, batdau, kt);
              
                new BanBUS().AddBan(a);
                
                MessageBox.Show(this, "Thêm bàn thành công ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Question);
                frmMain frm = new frmMain(nhanvien);
                frm.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain a = new frmMain(nhanvien);
            a.Show();
            this.Close();
        }

        private void comRe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
