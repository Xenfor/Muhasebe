using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xeni
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(File.ReadAllText("yol.txt"));

        private void AracEkleB_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "insert into AracPlakalari (Plaka) Values('"+ AracEkleTB.Text+"')";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            
            
            
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd1 = new SqlCommand("Select Plaka from AracPlakalari", con);
            SqlDataAdapter da1 = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AracEkleLB.DataSource = dt;
            AracEkleLB.DisplayMember = "Plaka";
            AracEkleTB.Text = string.Empty;
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            //Araçlar
            SqlCommand cmd = new SqlCommand("Select Plaka from AracPlakalari", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AracEkleLB.DataSource = dt;
            AracEkleLB.DisplayMember = "Plaka";
            //Hesaplar
            cmd = new SqlCommand("Select Hesap_ismi from Hesaplar", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            HesapEkleLB.DataSource = dt;
            HesapEkleLB.DisplayMember = "Hesap_ismi";
            

        }

        private void AracSilmeB_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "DELETE From AracPlakalari where Plaka ='" + AracEkleLB.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);

            

            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd1 = new SqlCommand("Select Plaka from AracPlakalari", con);
            SqlDataAdapter da1 = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AracEkleLB.DataSource = dt;
            AracEkleLB.DisplayMember = "Plaka";
            
        }

        private void HesapSilB_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "DELETE From Hesaplar where Hesap_ismi ='" + HesapEkleLB.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand("Select Hesap_ismi from Hesaplar", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AracEkleLB.DataSource = dt;
            AracEkleLB.DisplayMember = "Hesap_ismi";
            
        }

        private void HesapEkleB_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "insert into Hesaplar (Hesap_ismi) Values('" + HesapEkleTB.Text + "')";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand("Select Hesap_ismi from Hesaplar", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            HesapEkleLB.DataSource = dt;
            HesapEkleLB.DisplayMember = "Hesap_ismi";
            HesapEkleTB.Text = string.Empty;
        }
    }
}
