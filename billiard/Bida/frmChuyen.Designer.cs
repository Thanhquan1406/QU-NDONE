namespace Bida
{
    partial class frmChuyen
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNV = new MetroFramework.Controls.MetroLabel();
            this.btnBack = new System.Windows.Forms.Button();
            this.Tab1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Turquoise;
            this.label1.Location = new System.Drawing.Point(92, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Chọn bàn cần chuyển";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bida.Properties.Resources.user11;
            this.pictureBox1.Location = new System.Drawing.Point(831, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNV.Location = new System.Drawing.Point(868, 25);
            this.lblNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(93, 25);
            this.lblNV.Style = MetroFramework.MetroColorStyle.Green;
            this.lblNV.TabIndex = 24;
            this.lblNV.Text = "Nhân Viên";
            this.lblNV.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::Bida.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(13, 16);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 53);
            this.btnBack.TabIndex = 27;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Tab1
            // 
            this.Tab1.AutoScroll = true;
            this.Tab1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Tab1.ForeColor = System.Drawing.Color.Black;
            this.Tab1.HorizontalScrollbar = true;
            this.Tab1.HorizontalScrollbarBarColor = true;
            this.Tab1.HorizontalScrollbarHighlightOnWheel = false;
            this.Tab1.HorizontalScrollbarSize = 37;
            this.Tab1.Location = new System.Drawing.Point(4, 44);
            this.Tab1.Margin = new System.Windows.Forms.Padding(4);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(988, 581);
            this.Tab1.Style = MetroFramework.MetroColorStyle.Red;
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "Khu vực 1";
            this.Tab1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Tab1.VerticalScrollbar = true;
            this.Tab1.VerticalScrollbarBarColor = true;
            this.Tab1.VerticalScrollbarHighlightOnWheel = false;
            this.Tab1.VerticalScrollbarSize = 13;
            this.Tab1.Click += new System.EventHandler(this.metroTabPage1_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.Tab1);
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.metroTabControl1.Location = new System.Drawing.Point(13, 110);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(996, 629);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.UseSelectable = true;
            // 
            // frmChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 770);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNV);
            this.Controls.Add(this.metroTabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChuyen";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.frmChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblNV;
        private System.Windows.Forms.Button btnBack;
        private MetroFramework.Controls.MetroTabPage Tab1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
    }
}