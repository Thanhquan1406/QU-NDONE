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
        public int TongTienOrder { get; set; }
        public BAN ban;
        public NHANVIEN nhanvien;
        public frmBan(BAN a, NHANVIEN nv)
        {
            InitializeComponent();
            this.ban = a;
            this.nhanvien = nv;
        }
        public void SetTongTien(int tongTien)
        {
            this.TongTienOrder = tongTien;
            txtTienOrder.Text = TongTienOrder.ToString();
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
                if (ban.GIOBD.HasValue) 
                {
                    var date = ban.GIOBD.Value;
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
            if (ban == null)
            {
                MessageBox.Show("Bàn object is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (nhanvien == null)
            {
                MessageBox.Show("Nhân viên object is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            
            var date1 = DateTime.Now;
            lblDate.Text = date1.ToString("dd/MM/yyyy");
            this.lblBan.Text = "Bàn " + ban.MABAN;

            comKH.DataSource = new KhachHangBUS().GetListKH();
            if (ban.KHACHHANG != null)
            {
                comKH.SelectedIndex = ban.KHACHHANG.MAKH - 1;
            }
            else
            {
                MessageBox.Show("Khách hàng chưa được khởi tạo cho bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comKH.SelectedIndex = -1;
            }


            if (ban.TINHTRANG == false)
            {
                btnEnd.Enabled = false;
                btnStart.Enabled = true;
                btnChange.Enabled = false;
                picBan.Image = ban.LOAIBAN == false ? global::Bida.Properties.Resources.bidafrace : global::Bida.Properties.Resources.bida;
            }
            else
            {
                btnChange.Enabled = true;
                if (ban.GIOBD.HasValue)
                {
                    var date = ban.GIOBD.Value;
                    txtTimeStart.Text = date.Hour + ":" + date.Minute;
                }
                txtTimeStart.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = true;
                picBan.Image = ban.LOAIBAN == false ? global::Bida.Properties.Resources.bidafrance_s : global::Bida.Properties.Resources.bida_s;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var date2 = ban.GIOBD;
            int h = date.Hour;
            int m = date.Minute;
            txtTimeStart.Text = h + ":" + m;
            txtTimeEnd.Text = "";
            ban.TINHTRANG = true;
            ban.GIOBD = date;
            btnTinh.Enabled = false;


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
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (ban.GIOBD.HasValue && ban.GIOKT.HasValue) 
            {
                DateTime date = ban.GIOBD.Value;
                DateTime date2 = ban.GIOKT.Value;
                double m = (date2 - date).TotalMinutes;

                int hour = (int)(m / 60);
                int minute = (int)(m % 60);

                txtGio.Text = hour + " giờ " + minute + " phút";

                int tiengio = (int)(m * 20) / 60 *1000;
                int tongTienOrder = TongTienOrder;
                int Total = tiengio + tongTienOrder;
                txtTienOrder.Text = tongTienOrder.ToString();
                txtGia.Text = Total.ToString();            

                btnPay.Enabled = true;
            }
            else
            {
                txtGio.Text = "Không có thời gian";
                txtGia.Text = " VND";
                txtTienOrder.Text = " VND";
                btnPay.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int makh = comKH.SelectedValue.GetHashCode();
            new BanBUS().updatemakh(ban, makh);

            MessageBox.Show(this, "Đã thêm khách hàng vào Bàn " + ban.MABAN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd a = new frmAdd(ban, nhanvien);
            a.Show();
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            using (var context = new Model())
            {
                var ordersToDelete = context.ORDERs.Where(o => o.MABAN == ban.MABAN).ToList();

                if (ordersToDelete.Count > 0)
                {
                    context.ORDERs.RemoveRange(ordersToDelete);

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Đã thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Refesh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Đã thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            int makh = comKH.SelectedValue.GetHashCode();
            KHACHHANG kh = new KhachHangBUS().GetKhachHangbyID(makh);

            String thoigian = txtGio.Text;
            String gia = txtGia.Text;

            BIENLAI a = new BIENLAI(nhanvien, ban, kh, ban.GIOBD, ban.GIOKT, thoigian, gia);

            new BienLaiBUS().addBienLai(a);
            frmBienLai bl = new frmBienLai(a);
            bl.Show();
            this.Close();

        }
        private void btnOder_Click(object sender, EventArgs e)
        {
            frmOrder a = new frmOrder(ban, nhanvien);
            a.Show();
            this.Hide();
        }
    }
}