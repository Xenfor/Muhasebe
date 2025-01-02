using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Xeni
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }

        private void MahsupB_Click(object sender, EventArgs e)
        {
            Mahsup mahsup = new Mahsup();
            mahsup.Show();
            
        }

        private void AracHesapB_Click(object sender, EventArgs e)
        {
            AracHesap aracHesap = new AracHesap();  
            aracHesap.Show();   
        }

        private void AyarlarB_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
        }

        private void AracBorcBTN_Click(object sender, EventArgs e)
        {
            AracBorc aracBorc = new AracBorc();
            aracBorc.Show();
        }

        private void Ana_Sayfa_Load(object sender, EventArgs e)
        {
            button2.Text = Application.ProductVersion.ToString();
        }
    }
}   

//SqlConnection con = new SqlConnection("Server=XENFOR;Database=Xenis;Trusted_Connection=True;");
//DataSet ds = new DataSet();
//DataAdapter da = new SqlDataAdapter();
