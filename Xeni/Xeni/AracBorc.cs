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
    public partial class AracBorc : Form
    {
        public AracBorc()
        {
            InitializeComponent();

            
        }
        
        SqlConnection con = new SqlConnection(File.ReadAllText("yol.txt"));

        private void GirdiB_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into AracHesabiKredi (No,Plaka,Kactaksit,KartNo,Tarih,Aciklama,Ocak,Subat,Mart,Nisan,Mayis,Haziran,Temmuz,Agustos,Eylul,Ekim,Kasim,Aralik) " +
                "Values(@No,@Plaka,@Kactaksit,@KartNo,@Tarih,@Aciklama,@Ocak,@Subat,@Mart,@Nisan,@Mayis,@Haziran,@Temmuz,@Agustos,@Eylul,@Ekim,@Kasim,@Aralik)";
            SqlCommand cmd = new SqlCommand(query,con);
            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiKredi", con);
                int sayii = Convert.ToInt32(cmd2.ExecuteScalar());

                cmd.Parameters.AddWithValue("@No", sayii + 1);
            }
            catch (Exception ex)
            {
                cmd.Parameters.AddWithValue("@No", 1);
                MessageBox.Show(ex.Message);
                MessageBox.Show("BOŞVER KNK HATA DEĞİL MERAK ETME");
            }
            
            cmd.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
            //cmd.Parameters.AddWithValue("@No", NoTB.Text);
            cmd.Parameters.AddWithValue("@Kactaksit", KacTaksitTB.Text);
            cmd.Parameters.AddWithValue("@KartNo", KartNoTB.Text);
            cmd.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Aciklama", AciklamaTB.Text);
           
            if (AyCB.Text == "Ocak")
            {
                cmd.Parameters.AddWithValue("@Ocak", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Şubat")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }         
            if (AyCB.Text == "Mart")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Nisan")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Mayıs")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Haziran")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Temmuz")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Ağustos")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Eylül")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Ekim")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Kasım")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", AyParaTB.Text);
                cmd.Parameters.AddWithValue("@Aralik", 0);
            }
            if (AyCB.Text == "Aralık")
            {
                cmd.Parameters.AddWithValue("@Ocak", 0);
                cmd.Parameters.AddWithValue("@Subat", 0);
                cmd.Parameters.AddWithValue("@Mart", 0);
                cmd.Parameters.AddWithValue("@Nisan", 0);
                cmd.Parameters.AddWithValue("@Mayis", 0);
                cmd.Parameters.AddWithValue("@Haziran", 0);
                cmd.Parameters.AddWithValue("@Temmuz", 0);
                cmd.Parameters.AddWithValue("@Agustos", 0);
                cmd.Parameters.AddWithValue("@Eylul", 0);
                cmd.Parameters.AddWithValue("@Ekim", 0);
                cmd.Parameters.AddWithValue("@Kasim", 0);
                cmd.Parameters.AddWithValue("@Aralik", AyParaTB.Text);
            }
            cmd.ExecuteNonQuery();



            con.Close();
            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("Select* From AracHesabiKredi", con);
            con.Open();
            da1.Fill(ds, "AracHesabiKredi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "AracHesabiKredi";

            AyParaTB.Text = string.Empty;
            AciklamaTB.Text = string.Empty;
            KacTaksitTB.Text = string.Empty;
            KartNoTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            AyCB.Text = string.Empty;

        }

        private void AracBorc_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Plaka from AracPlakalari", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            PlakaCB.DataSource = dt;
            PlakaCB.DisplayMember = "Plaka";
            //------------------------------------------------------------------------------------
            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("Select* From AracHesabiKredi", con);
            con.Open();
            da1.Fill(ds, "AracHesabiKredi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "AracHesabiKredi";
            //------------------------------------------------------------------------------------
            #region Boyutlandırma
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[1].Width = 85;
            dataGridView1.Columns[2].Width = 35;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[6].Width = 60;
            dataGridView1.Columns[7].Width = 60;
            dataGridView1.Columns[8].Width = 60;
            dataGridView1.Columns[9].Width = 60;
            dataGridView1.Columns[10].Width = 60;
            dataGridView1.Columns[11].Width = 60;
            dataGridView1.Columns[12].Width = 60;
            dataGridView1.Columns[13].Width = 60;
            dataGridView1.Columns[14].Width = 60;
            dataGridView1.Columns[15].Width = 60;
            dataGridView1.Columns[16].Width = 60;
            dataGridView1.Columns[17].Width = 60;
            #endregion
            //------------------------------------------------------------------------------------
            #region Tasarım
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            #endregion
            //------------------------------------------------------------------------------------

        }

        private void AyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AyCB.Text == "Ocak")
            {
                dataGridView1.Columns[6].Visible = true;
            }
            else
            {
                dataGridView1.Columns[6].Visible = false;
            }
            if (AyCB.Text == "Şubat")
            {
                dataGridView1.Columns[7].Visible = true;
            }
            else
            {
                dataGridView1.Columns[7].Visible = false;

            }
            if (AyCB.Text == "Mart")
            {
                dataGridView1.Columns[8].Visible = true;
            }
            else
            {
                dataGridView1.Columns[8].Visible = false;

            }
            if (AyCB.Text == "Nisan")
            {
                dataGridView1.Columns[9].Visible = true;
            }
            else
            {
                dataGridView1.Columns[9].Visible = false;

            }
            if (AyCB.Text == "Mayıs")
            {
                dataGridView1.Columns[10].Visible = true;
            }
            else
            {
                dataGridView1.Columns[10].Visible = false;

            }
            if (AyCB.Text == "Haziran")
            {
                dataGridView1.Columns[11].Visible = true;
            }
            else
            {
                dataGridView1.Columns[11].Visible = false;

            }
            if (AyCB.Text == "Temmuz")
            {
                dataGridView1.Columns[12].Visible = true;
            }
            else
            {
                dataGridView1.Columns[12].Visible = false;

            }
            if (AyCB.Text == "Ağustos")
            {
                dataGridView1.Columns[13].Visible = true;
            }
            else
            {
                dataGridView1.Columns[13].Visible = false;

            }
            if (AyCB.Text == "Eylül")
            {
                dataGridView1.Columns[14].Visible = true;
            }
            else
            {
                dataGridView1.Columns[14].Visible = false;

            }
            if (AyCB.Text == "Ekim")
            {
                dataGridView1.Columns[15].Visible = true;
            }
            else
            {
                dataGridView1.Columns[15].Visible = false;

            }
            if (AyCB.Text == "Kasım")
            {
                dataGridView1.Columns[16].Visible = true;
            }
            else
            {
                dataGridView1.Columns[16].Visible = false;

            }
            if (AyCB.Text == "Aralık")
            {
                dataGridView1.Columns[17].Visible = true;
            }
            else
            {
                dataGridView1.Columns[17].Visible = false;

            }
        }
        private void HepsiniacRB_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void ButunAyCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ButunAyCB.Checked == true)
            {
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[9].Visible = true;
                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[12].Visible = true;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[15].Visible = true;
                dataGridView1.Columns[16].Visible = true;
                dataGridView1.Columns[17].Visible = true;
            }
            else
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
            }
        }

        private void DuzenlemeBTN_Click(object sender, EventArgs e)
        {
            if (KartNoTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiKredi Set KartNo = '" + KartNoTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            if (KacTaksitTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiKredi Set Kactaksit = '" + KacTaksitTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            if (AciklamaTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiKredi Set Aciklama = '" + AciklamaTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            if (AyCB.Text != "")
            {
                if (AyCB.Text == "Ocak")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Ocak = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Şubat")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Şubat = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Mart")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Mart = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Nisan")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Nisan = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Mayıs")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Mayıs = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Haziran")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Haziran = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Temmuz")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Temmuz = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Ağustos")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Ağustos = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Eylül")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Eylül = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Ekim")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Ekim = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Kasım")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Kasım = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (AyCB.Text == "Aralık")
                {
                    con.Open();
                    string query = "update AracHesabiKredi Set Aralık = '" + AyParaTB.Text + "' where No = '" + NoTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("Select* From AracHesabiKredi where Plaka = '"+PlakaCB.Text+"'", con);
            con.Open();
            da1.Fill(ds, "AracHesabiKredi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "AracHesabiKredi";

            AyParaTB.Text = string.Empty;
            AciklamaTB.Text = string.Empty;
            KacTaksitTB.Text = string.Empty;
            KartNoTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            AyCB.Text = string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            NoTB.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
        }

        private void HesapAraBTN_Click(object sender, EventArgs e)
        {
            string query = "Select * From AracHesabiKredi where Plaka = '" + PlakaCB.Text + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            da.Fill(ds, "AracHesabiKredi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "AracHesabiKredi";
        }

        private void BorcSilmeBTN_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Delete From AracHesabiKredi where No = '" + NoTB.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiKredi where Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiKredi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "AracHesabiKredi";
        }
    }
}
