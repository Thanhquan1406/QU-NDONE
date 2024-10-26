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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSLMUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.mudSLMua = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textGiaTien = new System.Windows.Forms.TextBox();
            this.txtTenNuoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnDat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudSLMua)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(59, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu Thức Uống";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenNuoc,
            this.colGiaTien,
            this.colSLMUA});
            this.dataGridView1.Location = new System.Drawing.Point(261, 61);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(416, 246);
            this.dataGridView1.TabIndex = 4;
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "colSTT";
            this.colSTT.HeaderText = "Số Thứ Tự";
            this.colSTT.Name = "colSTT";
            // 
            // colTenNuoc
            // 
            this.colTenNuoc.DataPropertyName = "colTenNuoc";
            this.colTenNuoc.HeaderText = "Tên Nước";
            this.colTenNuoc.Name = "colTenNuoc";
            // 
            // colGiaTien
            // 
            this.colGiaTien.DataPropertyName = "colGiaTien";
            this.colGiaTien.HeaderText = "Giá Tiền";
            this.colGiaTien.Name = "colGiaTien";
            // 
            // colSLMUA
            // 
            this.colSLMUA.DataPropertyName = "colSLMUA";
            this.colSLMUA.HeaderText = "Số Lượng Mua";
            this.colSLMUA.Name = "colSLMUA";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(531, 353);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(146, 20);
            this.txtTongTien.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Bida.Properties.Resources.back;
            this.button2.Location = new System.Drawing.Point(1, -2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 43);
            this.button2.TabIndex = 32;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mudSLMua
            // 
            this.mudSLMua.Location = new System.Drawing.Point(101, 113);
            this.mudSLMua.Name = "mudSLMua";
            this.mudSLMua.Size = new System.Drawing.Size(107, 20);
            this.mudSLMua.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Số lượng mua";
            // 
            // textGiaTien
            // 
            this.textGiaTien.Location = new System.Drawing.Point(101, 75);
            this.textGiaTien.Name = "textGiaTien";
            this.textGiaTien.Size = new System.Drawing.Size(107, 20);
            this.textGiaTien.TabIndex = 35;
            // 
            // txtTenNuoc
            // 
            this.txtTenNuoc.Location = new System.Drawing.Point(101, 32);
            this.txtTenNuoc.Name = "txtTenNuoc";
            this.txtTenNuoc.Size = new System.Drawing.Size(107, 20);
            this.txtTenNuoc.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Giá Tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Tên nước";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenNuoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mudSLMua);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textGiaTien);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 177);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Tổng tiền dịch vụ";
            // 
            // btnDat
            // 
            this.btnDat.Location = new System.Drawing.Point(34, 316);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(122, 23);
            this.btnDat.TabIndex = 42;
            this.btnDat.Text = "Đặt";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 402);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmOrder";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudSLMua)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTongTien;
        private Button button2;
        private NumericUpDown mudSLMua;
        private Label label2;
        private TextBox textGiaTien;
        private TextBox txtTenNuoc;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private Label label5;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTenNuoc;
        private DataGridViewTextBoxColumn colGiaTien;
        private DataGridViewTextBoxColumn colSLMUA;
        private Button btnDat;
    }
}