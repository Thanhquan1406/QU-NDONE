using System.Windows.Forms;

namespace Bida
{
    partial class frmOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvThucDon = new System.Windows.Forms.DataGridView();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.mudSLMua = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textGiaTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnDat = new System.Windows.Forms.Button();
            this.comboLoaiNuoc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudSLMua)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu Thức Uống";
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDon.Location = new System.Drawing.Point(348, 75);
            this.dgvThucDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.RowHeadersWidth = 51;
            this.dgvThucDon.RowTemplate.Height = 24;
            this.dgvThucDon.Size = new System.Drawing.Size(555, 303);
            this.dgvThucDon.TabIndex = 4;
            
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(708, 434);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(193, 22);
            this.txtTongTien.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Bida.Properties.Resources.back;
            this.button2.Location = new System.Drawing.Point(1, -2);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 53);
            this.button2.TabIndex = 32;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mudSLMua
            // 
            this.mudSLMua.Location = new System.Drawing.Point(135, 139);
            this.mudSLMua.Margin = new System.Windows.Forms.Padding(4);
            this.mudSLMua.Name = "mudSLMua";
            this.mudSLMua.Size = new System.Drawing.Size(143, 22);
            this.mudSLMua.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Số lượng mua";
            // 
            // textGiaTien
            // 
            this.textGiaTien.Location = new System.Drawing.Point(135, 92);
            this.textGiaTien.Margin = new System.Windows.Forms.Padding(4);
            this.textGiaTien.Name = "textGiaTien";
            this.textGiaTien.Size = new System.Drawing.Size(141, 22);
            this.textGiaTien.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Giá Tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Tên nước";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboLoaiNuoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mudSLMua);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textGiaTien);
            this.groupBox1.Location = new System.Drawing.Point(16, 138);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(304, 218);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 438);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "Tổng tiền dịch vụ";
            // 
            // btnDat
            // 
            this.btnDat.Location = new System.Drawing.Point(45, 389);
            this.btnDat.Margin = new System.Windows.Forms.Padding(4);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(163, 28);
            this.btnDat.TabIndex = 42;
            this.btnDat.Text = "Đặt";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // comboLoaiNuoc
            // 
            this.comboLoaiNuoc.FormattingEnabled = true;
            this.comboLoaiNuoc.Location = new System.Drawing.Point(135, 40);
            this.comboLoaiNuoc.Name = "comboLoaiNuoc";
            this.comboLoaiNuoc.Size = new System.Drawing.Size(121, 24);
            this.comboLoaiNuoc.TabIndex = 43;
            this.comboLoaiNuoc.SelectedIndexChanged += new System.EventHandler(this.comboLoaiNuoc_SelectedIndexChanged);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 495);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.dgvThucDon);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmOrder";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudSLMua)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvThucDon;
        private System.Windows.Forms.TextBox txtTongTien;
        private Button button2;
        private NumericUpDown mudSLMua;
        private Label label2;
        private TextBox textGiaTien;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private Label label5;
        private Button btnDat;
        private ComboBox comboLoaiNuoc;
    }
}