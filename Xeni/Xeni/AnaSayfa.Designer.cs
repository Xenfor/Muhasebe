namespace Xeni
{
    partial class Ana_Sayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.MahsupB = new System.Windows.Forms.Button();
            this.AracHesapB = new System.Windows.Forms.Button();
            this.AyarlarB = new System.Windows.Forms.Button();
            this.AracBorcBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // MahsupB
            // 
            this.MahsupB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MahsupB.AutoSize = true;
            this.MahsupB.Font = new System.Drawing.Font("OCR A Extended", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MahsupB.Location = new System.Drawing.Point(16, 24);
            this.MahsupB.Margin = new System.Windows.Forms.Padding(2);
            this.MahsupB.Name = "MahsupB";
            this.MahsupB.Size = new System.Drawing.Size(353, 266);
            this.MahsupB.TabIndex = 0;
            this.MahsupB.Text = "Mahsup";
            this.MahsupB.UseVisualStyleBackColor = true;
            this.MahsupB.Click += new System.EventHandler(this.MahsupB_Click);
            // 
            // AracHesapB
            // 
            this.AracHesapB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AracHesapB.Font = new System.Drawing.Font("OCR A Extended", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AracHesapB.Location = new System.Drawing.Point(16, 337);
            this.AracHesapB.Margin = new System.Windows.Forms.Padding(2);
            this.AracHesapB.Name = "AracHesapB";
            this.AracHesapB.Size = new System.Drawing.Size(353, 264);
            this.AracHesapB.TabIndex = 1;
            this.AracHesapB.Text = "Araç Hesap";
            this.AracHesapB.UseVisualStyleBackColor = true;
            this.AracHesapB.Click += new System.EventHandler(this.AracHesapB_Click);
            // 
            // AyarlarB
            // 
            this.AyarlarB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AyarlarB.Font = new System.Drawing.Font("OCR A Extended", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AyarlarB.Location = new System.Drawing.Point(610, 24);
            this.AyarlarB.Margin = new System.Windows.Forms.Padding(2);
            this.AyarlarB.Name = "AyarlarB";
            this.AyarlarB.Size = new System.Drawing.Size(384, 261);
            this.AyarlarB.TabIndex = 2;
            this.AyarlarB.Text = "Ayarlar";
            this.AyarlarB.UseVisualStyleBackColor = true;
            this.AyarlarB.Click += new System.EventHandler(this.AyarlarB_Click);
            // 
            // AracBorcBTN
            // 
            this.AracBorcBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AracBorcBTN.Font = new System.Drawing.Font("OCR A Extended", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AracBorcBTN.Location = new System.Drawing.Point(610, 337);
            this.AracBorcBTN.Name = "AracBorcBTN";
            this.AracBorcBTN.Size = new System.Drawing.Size(384, 264);
            this.AracBorcBTN.TabIndex = 3;
            this.AracBorcBTN.Text = "Araç Borç";
            this.AracBorcBTN.UseVisualStyleBackColor = true;
            this.AracBorcBTN.Click += new System.EventHandler(this.AracBorcBTN_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Magenta;
            this.button1.Location = new System.Drawing.Point(374, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 577);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Location = new System.Drawing.Point(16, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(977, 41);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 631);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // Ana_Sayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 610);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AracBorcBTN);
            this.Controls.Add(this.AyarlarB);
            this.Controls.Add(this.AracHesapB);
            this.Controls.Add(this.MahsupB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ana_Sayfa";
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.Ana_Sayfa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MahsupB;
        private System.Windows.Forms.Button AracHesapB;
        private System.Windows.Forms.Button AyarlarB;
        private System.Windows.Forms.Button AracBorcBTN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

