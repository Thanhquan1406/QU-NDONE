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

namespace Bida
{
    public partial class frmLogin : MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        public static void showFormMain(NHANVIEN nv)
        {
            frmMain frm = new frmMain(nv);
            frm.ShowDialog();
        }
      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            Boolean kt = new NhanVienBUS().ValidateNv(user, pass);
            if (kt == true)
            {
                NHANVIEN nv = new NhanVienBUS().GetNhanVienbyID(user);

                frmMain a = new frmMain(nv);
                a.Show();
                this.Hide();
            }
            else
            {
                DialogResult dialogResult = MetroMessageBox.Show(this, "Bạn đã nhập sai tài khoản và mật khảu bạn có muốn tiếp tục", "Đăng nhập lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                txtUser.Text = "";
                txtPass.Text = "";
                if (dialogResult == DialogResult.Yes)
                {
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}