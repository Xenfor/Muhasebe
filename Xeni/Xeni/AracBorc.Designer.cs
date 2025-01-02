namespace Xeni
{
    partial class AracBorc
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
            this.GirdiB = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AyCB = new System.Windows.Forms.ComboBox();
            this.AyParaTB = new System.Windows.Forms.TextBox();
            this.KacTaksitTB = new System.Windows.Forms.TextBox();
            this.PlakaCB = new System.Windows.Forms.ComboBox();
            this.KartNoTB = new System.Windows.Forms.TextBox();
            this.AciklamaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.ButunAyCB = new System.Windows.Forms.CheckBox();
            this.DuzenlemeBTN = new System.Windows.Forms.Button();
            this.NoTB = new System.Windows.Forms.TextBox();
            this.HesapAraBTN = new System.Windows.Forms.Button();
            this.BorcSilmeBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GirdiB
            // 
            this.GirdiB.Location = new System.Drawing.Point(851, 442);
            this.GirdiB.Name = "GirdiB";
            this.GirdiB.Size = new System.Drawing.Size(76, 257);
            this.GirdiB.TabIndex = 0;
            this.GirdiB.Text = "Gir";
            this.GirdiB.UseVisualStyleBackColor = true;
            this.GirdiB.Click += new System.EventHandler(this.GirdiB_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(820, 543);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // AyCB
            // 
            this.AyCB.FormattingEnabled = true;
            this.AyCB.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"});
            this.AyCB.Location = new System.Drawing.Point(711, 60);
            this.AyCB.Name = "AyCB";
            this.AyCB.Size = new System.Drawing.Size(121, 21);
            this.AyCB.TabIndex = 2;
            this.AyCB.SelectedIndexChanged += new System.EventHandler(this.AyCB_SelectedIndexChanged);
            // 
            // AyParaTB
            // 
            this.AyParaTB.Location = new System.Drawing.Point(721, 87);
            this.AyParaTB.Name = "AyParaTB";
            this.AyParaTB.Size = new System.Drawing.Size(100, 20);
            this.AyParaTB.TabIndex = 3;
            // 
            // KacTaksitTB
            // 
            this.KacTaksitTB.Location = new System.Drawing.Point(395, 61);
            this.KacTaksitTB.Name = "KacTaksitTB";
            this.KacTaksitTB.Size = new System.Drawing.Size(100, 20);
            this.KacTaksitTB.TabIndex = 3;
            // 
            // PlakaCB
            // 
            this.PlakaCB.FormattingEnabled = true;
            this.PlakaCB.Location = new System.Drawing.Point(261, 61);
            this.PlakaCB.Name = "PlakaCB";
            this.PlakaCB.Size = new System.Drawing.Size(121, 21);
            this.PlakaCB.TabIndex = 4;
            // 
            // KartNoTB
            // 
            this.KartNoTB.Location = new System.Drawing.Point(501, 62);
            this.KartNoTB.Name = "KartNoTB";
            this.KartNoTB.Size = new System.Drawing.Size(100, 20);
            this.KartNoTB.TabIndex = 3;
            // 
            // AciklamaTB
            // 
            this.AciklamaTB.Location = new System.Drawing.Point(607, 62);
            this.AciklamaTB.Name = "AciklamaTB";
            this.AciklamaTB.Size = new System.Drawing.Size(100, 20);
            this.AciklamaTB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(708, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kaç Taksit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kart No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Açıklama";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Plaka";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(33, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tarih";
            // 
            // ButunAyCB
            // 
            this.ButunAyCB.AutoSize = true;
            this.ButunAyCB.Location = new System.Drawing.Point(839, 60);
            this.ButunAyCB.Name = "ButunAyCB";
            this.ButunAyCB.Size = new System.Drawing.Size(98, 17);
            this.ButunAyCB.TabIndex = 8;
            this.ButunAyCB.Text = "Bütün Ayları Aç";
            this.ButunAyCB.UseVisualStyleBackColor = true;
            this.ButunAyCB.CheckedChanged += new System.EventHandler(this.ButunAyCB_CheckedChanged);
            // 
            // DuzenlemeBTN
            // 
            this.DuzenlemeBTN.Location = new System.Drawing.Point(851, 156);
            this.DuzenlemeBTN.Name = "DuzenlemeBTN";
            this.DuzenlemeBTN.Size = new System.Drawing.Size(76, 254);
            this.DuzenlemeBTN.TabIndex = 0;
            this.DuzenlemeBTN.Text = "Düzenle";
            this.DuzenlemeBTN.UseVisualStyleBackColor = true;
            this.DuzenlemeBTN.Click += new System.EventHandler(this.DuzenlemeBTN_Click);
            // 
            // NoTB
            // 
            this.NoTB.Location = new System.Drawing.Point(862, 416);
            this.NoTB.Name = "NoTB";
            this.NoTB.Size = new System.Drawing.Size(100, 20);
            this.NoTB.TabIndex = 9;
            // 
            // HesapAraBTN
            // 
            this.HesapAraBTN.Location = new System.Drawing.Point(25, 112);
            this.HesapAraBTN.Name = "HesapAraBTN";
            this.HesapAraBTN.Size = new System.Drawing.Size(820, 38);
            this.HesapAraBTN.TabIndex = 10;
            this.HesapAraBTN.Text = "Ara(Plaka)";
            this.HesapAraBTN.UseVisualStyleBackColor = true;
            this.HesapAraBTN.Click += new System.EventHandler(this.HesapAraBTN_Click);
            // 
            // BorcSilmeBTN
            // 
            this.BorcSilmeBTN.Location = new System.Drawing.Point(953, 243);
            this.BorcSilmeBTN.Name = "BorcSilmeBTN";
            this.BorcSilmeBTN.Size = new System.Drawing.Size(65, 63);
            this.BorcSilmeBTN.TabIndex = 11;
            this.BorcSilmeBTN.Text = "SilmeBTN";
            this.BorcSilmeBTN.UseVisualStyleBackColor = true;
            this.BorcSilmeBTN.Click += new System.EventHandler(this.BorcSilmeBTN_Click);
            // 
            // AracBorc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1105, 782);
            this.Controls.Add(this.BorcSilmeBTN);
            this.Controls.Add(this.HesapAraBTN);
            this.Controls.Add(this.NoTB);
            this.Controls.Add(this.ButunAyCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlakaCB);
            this.Controls.Add(this.AciklamaTB);
            this.Controls.Add(this.KartNoTB);
            this.Controls.Add(this.KacTaksitTB);
            this.Controls.Add(this.AyParaTB);
            this.Controls.Add(this.AyCB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DuzenlemeBTN);
            this.Controls.Add(this.GirdiB);
            this.Name = "AracBorc";
            this.Text = "AracBorc";
            this.Load += new System.EventHandler(this.AracBorc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GirdiB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox AyCB;
        private System.Windows.Forms.TextBox AyParaTB;
        private System.Windows.Forms.TextBox KacTaksitTB;
        private System.Windows.Forms.ComboBox PlakaCB;
        private System.Windows.Forms.TextBox KartNoTB;
        private System.Windows.Forms.TextBox AciklamaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ButunAyCB;
        private System.Windows.Forms.Button DuzenlemeBTN;
        private System.Windows.Forms.TextBox NoTB;
        private System.Windows.Forms.Button HesapAraBTN;
        private System.Windows.Forms.Button BorcSilmeBTN;
    }
}