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
using Bida.BUS;
using MetroFramework;
using MetroFramework.Forms;

namespace Bida
{

    public partial class frmBan : MetroForm
    {
        public BAN ban;
        public NHANVIEN nhanvien;
        public frmBan(BAN a, NHANVIEN nv)
        {
            InitializeComponent();
            this.ban = a;
            this.nhanvien = nv;
        }

        public void Refesh()
        {
            this.lblBan.Text = "Bàn " + ban.MABAN;
            if (ban.TINHTRANG == false)
            {
                btnEnd.Enabled = false;
                btnChange.Enabled = false;
                if (ban.LOAIBAN == false)
                {
                    picBan.Image = global::Bida.Properties.Resources.bidafrace;
                }
                else
                {
                    picBan.Image = global::Bida.Properties.Resources.bida;
                }
            }
            else
            {
                btnChange.Enabled = true;
                if (ban.GIOBD.HasValue) // Check if GIOBD has a value
                {
                    var date = ban.GIOBD.Value; // Get the value of GIOBD
                    int h = date.Hour;
                    int m = date.Minute;
                    txtTimeStart.Text = h + ":" + m;
                }
                txtTimeStart.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = true;
                if (ban.LOAIBAN == false)
                {
                    picBan.Image = global::Bida.Properties.Resources.bidafrance_s;
                }
                else
                {
                    picBan.Image = global::Bida.Properties.Resources.bida_s;
                }
            }
        }
        private void frmBan_Load(object sender, EventArgs e)
        {
            
            lblnv.Text = nhanvien.TenNhanVien;
            var date1 = DateTime.Now;
            lblDate.Text = date1.ToString("dd/MM/yyyy");
            this.lblBan.Text = "Bàn " + ban.MABAN;
            
            comKH.DataSource = new KhachHangBUS().GetListKH();

            comKH.SelectedIndex = ban.KHACHHANG.MAKH -1;
          
            if (ban.TINHTRANG == false)
            {
                 btnEnd.Enabled = false;
                 btnStart.Enabled = true;
                btnChange.Enabled = false;
                if (ban.LOAIBAN == false)
                {
                    picBan.Image = global::Bida.Properties.Resources.bidafrace;
                }
                else
                {
                    picBan.Image = global::Bida.Properties.Resources.bida;
                }
            }
            else
            {
                btnChange.Enabled = true;
                if (ban.GIOBD.HasValue) // Check if GIOBD has a value
                {
                    var date = ban.GIOBD.Value; // Get the value of GIOBD
                    int h = date.Hour;
                    int m = date.Minute;
                    txtTimeStart.Text = h + ":" + m;
                }
                txtTimeStart.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = true;
                if (ban.LOAIBAN == false)
                {
                    picBan.Image = global::Bida.Properties.Resources.bidafrance_s;
                }
                else
                {
                    picBan.Image = global::Bida.Properties.Resources.bida_s;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;//Convert.ToDateTime("11/19/2017 8:30:00.000"); 
            var date2 = ban.GIOBD;
            int h= date.Hour;
            int m = date.Minute;
            txtTimeStart.Text = h + ":" + m;
            txtTimeEnd.Text = "";
            ban.TINHTRANG = true;
            ban.GIOBD = date;
            btnTinh.Enabled = false;
            //var hours = (date - date2).TotalMinutes;
            //txtTimeStart.Text = hours.ToString();
            ////  txtTimeEnd.Text = date2.ToString();


            //ban.GioBd = date;
            

           new BanBUS().updateBan(ban);

           this.Refesh();


        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            

            var date = DateTime.Now;
            int h = date.Hour;
            int m = date.Minute;
            txtTimeEnd.Text = h + ":" + m;
            ban.GIOKT = date;
            ban.TINHTRANG = false;
            new BanBUS().updateBan(ban);
            this.Refesh();
            txtTimeEnd.Enabled = false;
            btnTinh.Enabled = true;


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain a = new frmMain(nhanvien);
            a.Show();
            this.Close();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChuyen a = new frmChuyen(nhanvien, ban);
            a.Show();
            this.Close();
            //if (comKH.Text == "")
            //{
            //    lblBan.Text = "test" + comKH.Text;
            //}
            //else
            //{
            //    lblBan.Text = "k fai" + comKH.Text;

            //}
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (ban.GIOBD.HasValue && ban.GIOKT.HasValue) // Check if both GIOBD and GIOKT have values
            {
                DateTime date = ban.GIOBD.Value; // Get the value of GIOBD
                DateTime date2 = ban.GIOKT.Value; // Get the value of GIOKT
                double m = (date2 - date).TotalMinutes;

                int hour = (int)(m / 60);
                int minute = (int)(m % 60);

                txtGio.Text = hour + " giờ " + minute + " phút";

                int gia = (int)(m * 20) / 60;
                txtGia.Text = gia + ".000 VND";

                btnPay.Enabled = true;
            }
            else
            {
                // Handle the case where GIOBD or GIOKT is null
                txtGio.Text = "Không có thời gian";
                txtGia.Text = "0.000 VND";
                btnPay.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            int makh = comKH.SelectedValue.GetHashCode();
            new BanBUS().updatemakh(ban,makh);

            MetroMessageBox.Show(this, "Đã thêm khách hàng vào Bàn " + ban.MABAN, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd a= new frmAdd(ban, nhanvien);
            a.Show();
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int makh = comKH.SelectedValue.GetHashCode();
            KHACHHANG kh = new KhachHangBUS().GetKhachHangbyID(makh);

            String thoigian = txtGio.Text;
            String gia = txtGia.Text;

            BIENLAI a = new BIENLAI(nhanvien,ban,kh,ban.GIOBD,ban.GIOKT,thoigian,gia);

            new BienLaiBUS().addBienLai(a);
            frmBienLai bl = new frmBienLai(a);
            bl.Show();
            this.Close();


        }
    }
}
