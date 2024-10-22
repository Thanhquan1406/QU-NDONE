using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
    public partial class frmChuyen : MetroForm
    {
        private NHANVIEN nhanvien;
        private BAN ban;
       
        public frmChuyen(NHANVIEN nv, BAN b)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = nv;
        }

        private void frmChuyen_Load(object sender, EventArgs e)
        {
            getTable1();
            getTable2();
            lblNV.Text = nhanvien.TenNhanVien;

        }
        private void getTable1()
        {
            List<BAN> a = new List<BAN>(new BanBUS().GetListBan());

            int d = 0;
            int c = 0;
            int r = 6;

            for (int i = 0; i < a.Count; i++)
            {
                BAN ban2 = a[i];
                if (ban2.KHUVUC == 1)
                {

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

                    this.Tab1.Controls.Add(btn);


                    btn.BackColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    btn.Size = new System.Drawing.Size(83, 147);
                    btn.TabIndex = 2;
                    btn.Text = "Bàn " + a[i].MABAN;
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    btn.UseVisualStyleBackColor = false;
                    if (a[i].TINHTRANG == false)
                    {
                        if (a[i].LOAIBAN == false)
                        {
                            btn.Image = global::Bida.Properties.Resources.bidafrace;
                        }
                        else
                        {
                            btn.Image = global::Bida.Properties.Resources.bida;
                        }
                    }
                    else
                    {
                        if (a[i].LOAIBAN == false)
                        {
                            btn.Image = global::Bida.Properties.Resources.bidafrance_s;
                        }
                        else
                        {
                            btn.Image = global::Bida.Properties.Resources.bida_s;
                        }
                    }


                    btn.Click += (s, e) =>
                    {
                        //Thread t = new Thread(() => showFormBan(ban,nhanvien));
                        //t.Start();
                        //t.Join();

                        if (ban2.TINHTRANG == true)
                        {
                            MetroMessageBox.Show(this, "Bàn " + ban2.MABAN + " đang được người khác chơi vui lòng chọn bàn khác ! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            new BanBUS().chuyenban(ban, ban2);

                            DialogResult dialogResult = MetroMessageBox.Show(this, "Bạn đã chuyễn bàn thành công ! ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Question);

                            frmBan frm = new frmBan(ban2, nhanvien);
                            frm.Show();
                            this.Close();

                        }
                    };
                    if (r > 0)
                    {
                        btn.Left = c * 120;
                        c = c + 1;
                        btn.Top = d * 150;
                        r--;
                    }
                    else
                    {

                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c * 120;
                        c++;
                        btn.Top = d * 150;
                        r--;
                    }

                }
            }
        }

        private void getTable2()
        {
            List<BAN> a = new List<BAN>(new BanBUS().GetListBan());

            int d = 0;
            int c = 0;
            int r = 6;

            for (int i = 0; i < a.Count; i++)
            {
                BAN ban2 = a[i];
                if (ban2.KHUVUC == 2)
                {

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

                    this.Tab2.Controls.Add(btn);


                    btn.BackColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    btn.Size = new System.Drawing.Size(83, 147);
                    btn.TabIndex = 2;
                    btn.Text = "Bàn " + a[i].MABAN;
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    btn.UseVisualStyleBackColor = false;
                    if (a[i].TINHTRANG == false)
                    {
                        if (a[i].LOAIBAN == false)
                        {
                            btn.Image = global::Bida.Properties.Resources.bidafrace;
                        }
                        else
                        {
                            btn.Image = global::Bida.Properties.Resources.bida;
                        }
                    }
                    else
                    {
                        if (a[i].LOAIBAN == false)
                        {
                            btn.Image = global::Bida.Properties.Resources.bidafrance_s;
                        }
                        else
                        {
                            btn.Image = global::Bida.Properties.Resources.bida_s;
                        }
                    }


                    btn.Click += (s, e) =>
                    {
                        //Thread t = new Thread(() => showFormBan(ban,nhanvien));
                        //t.Start();
                        //t.Join();

                        if (ban2.TINHTRANG == true)
                        {
                            MetroMessageBox.Show(this, "Bàn " + ban2.MABAN + " đang được người khác chơi vui lòng chọn bàn khác ! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            new BanBUS().chuyenban(ban, ban2);

                            DialogResult dialogResult = MetroMessageBox.Show(this, "Bạn đã chuyễn bàn thành công ! ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Question);

                            frmBan frm = new frmBan(ban2, nhanvien);
                            frm.Show();
                            this.Close();

                        }
                    };
                    if (r > 0)
                    {
                        btn.Left = c * 120;
                        c = c + 1;
                        btn.Top = d * 150;
                        r--;
                    }
                    else
                    {

                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c * 120;
                        c++;
                        btn.Top = d * 150;
                        r--;
                    }

                }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(ban, nhanvien);
            frm.Show();
            this.Close();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
