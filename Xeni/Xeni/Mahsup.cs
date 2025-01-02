using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xeni
{
    public partial class Mahsup : Form
    {
        public Mahsup()
        {
            InitializeComponent();
            //TabloAl();
        }
        SqlConnection con = new SqlConnection(File.ReadAllText("yol.txt"));
        //SqlCommandBuilder cmdBuild;
        //SqlDataAdapter sqlda;
        //DataTable tbl = new DataTable();
        private void IslemB_Click(object sender, EventArgs e)
        {
            #region blokla giriş
            string query = "Select * From MahsupHesabi ";

            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            
            con.Open();
            da1.Fill(ds, "MahsupHesabi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MahsupHesabi";
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "MahsupHesabi";

            //---------------------------------------------------------
            con.Open();
            query = "INSERT INTO MahsupHesabi (No,Tarih,Hesap,Aciklama,Borc,Alacak,Plaka) VALUES (@No,@Tarih,@Hesap,@Aciklama,@Borc,@Alacak,@Plaka)";
            ds = new DataSet();
            DataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);

            SqlCommand cmd2 = new SqlCommand("SELECT max(No) from MahsupHesabi", con);
            int a = Convert.ToInt32(cmd2.ExecuteScalar());
            BorcTB.Text = BorcTB.Text.Replace(",", ".");
            AlacakTB.Text =  AlacakTB.Text.Replace(',', '.');
            cmd.Parameters.AddWithValue("@No", a + 1);
            cmd.Parameters.AddWithValue("@Tarih", TarihDTP.Value.Date);
            cmd.Parameters.AddWithValue("@Hesap", listBox1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Aciklama", AciklamaTB.Text);
            cmd.Parameters.AddWithValue("@Borc", BorcTB.Text);
            cmd.Parameters.AddWithValue("@Alacak", AlacakTB.Text);
            cmd.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
            


            cmd.ExecuteNonQuery();
            con.Close();
            //-------------------------------------------------------------------
            if (checkBox1.Checked)
            {
                con.Open();
                query = "INSERT INTO MahsupHesabi (No,Tarih,Hesap,Aciklama,Borc,Alacak,Plaka) VALUES (@No,@Tarih,@Hesap,@Aciklama,@Borc,@Alacak,@Plaka)";
                cmd = new SqlCommand(query, con);

                cmd2 = new SqlCommand("SELECT max(No) from MahsupHesabi", con);
                a = Convert.ToInt32(cmd2.ExecuteScalar());

                cmd.Parameters.AddWithValue("@No", a + 1);
                cmd.Parameters.AddWithValue("@Tarih", TarihDTP.Value.Date);
                cmd.Parameters.AddWithValue("@Hesap", listBox2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Aciklama", AciklamaTB.Text);
                cmd.Parameters.AddWithValue("@Borc", AlacakTB.Text);
                cmd.Parameters.AddWithValue("@Alacak", BorcTB.Text);
                cmd.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //-----------------------------------------------------------------
            query = "Select * From MahsupHesabi ORDER BY No";
            ds = new DataSet();
            da1 = new SqlDataAdapter(query, con);
            con.Open();
            da1.Fill(ds, "MahsupHesabi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MahsupHesabi";
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "MahsupHesabi";
            //------------------------------------------------------------------
            
            AciklamaTB.Text = string.Empty;
            BorcTB.Text = string.Empty;
            AlacakTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            AlacakSaptamasiCB.Text = string.Empty;
            AramaCB.Text = string.Empty;
            AramakTB.Text = string.Empty;


            #endregion
            #region tablo giriş

            //if (DegisimCB.Checked) {
            //    cmdBuild = new SqlCommandBuilder(sqlda);
            //    sqlda.Update(tbl);
            //TabloAl();

            //    //con.Open();
            //String query = "INSERT INTO MahsupHesabi (No,Tarih,Hesap,Aciklama,Borc,Alacak,Plaka) VALUES (@No,@Tarih,@Hesap,@Aciklama,@Borc,@Alacak,@Plaka)";
            //DataSet ds = new DataSet();
            //DataAdapter da = new SqlDataAdapter(query, con);
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@Tarih", TarihDTP.Value.Date);
            //cmd.Parameters.AddWithValue("@Hesap", HesapCB.Text);
            //cmd.Parameters.AddWithValue("@Aciklama", AciklamaTB.Text);
            //cmd.Parameters.AddWithValue("@Borc", BorcTB.Text);
            //cmd.Parameters.AddWithValue("@Alacak", AlacakTB.Text);
            //cmd.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
            //SqlCommand cmd2 = new SqlCommand("SELECT max(no) from MahsupHesabi", con);
            //int a = Convert.ToInt32(cmd2.ExecuteScalar());
            //cmd.Parameters.AddWithValue("@No", a + 1);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //}
            #endregion
            #region ALACAK
            if (PlakaCB.Text != "")
            {//tarih hesap açıklama borç plaka
                con.Open();
                query = "update AracHesabiAlacak Set Tarih = @T1 , Nereye = '" + listBox1.SelectedItem+"' , GelenPara = '"+BorcTB.Text+"' , KalanAlacak = KalanAlacak - GelenPara " +
                    "where Plaka = '" + PlakaCB.Text+ "' and GonderenFirma = '" + AciklamaTB.Text+"'";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@T1", TarihDTP.Value.Date);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            #endregion
        }
        //DataTable TabloAl()
        //{
        //    tbl.Clear();
        //    sqlda = new SqlDataAdapter("select * from MahsupHesabi", con);
        //    sqlda.Fill(tbl);
        //    dataGridView2.DataSource = tbl;
        //    return tbl;
        //}
        private void Mahsup_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Plaka from AracPlakalari", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            PlakaCB.DataSource = dt;
            PlakaCB.DisplayMember = "Plaka";
            //Hesap2CB.DataSource = dt;
            //Hesap2CB.DisplayMember = "Plaka";
            //HesapCB.DataSource = dt;
            //HesapCB.DisplayMember = "Plaka";

            //__________________________________________
            cmd = new SqlCommand("Select Hesap_ismi from Hesaplar ", con);

            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "Hesap_ismi";
            listBox1.ValueMember = "Hesap_ismi";

            //___________________________________________2
            ////cmd = new SqlCommand("Select Hesap_ismi from Hesaplar ", con);

            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            listBox2.DataSource = dt;
            listBox2.DisplayMember = "Hesap_ismi";
            listBox2.ValueMember = "Hesap_ismi";
            //__________________________________________

            string query = "Select * From MahsupHesabi ORDER BY No";
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da.Fill(ds, "MahsupHesabi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MahsupHesabi";
            //------------------------------------------------
            
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "MahsupHesabi";
            //------------------------------------------------
            TarihDTP.CustomFormat = "dd - MM - yyyy";
            //------------------------------------------------
            
            dataGridView2.Columns.Add("bakiye", "BAKİYE");
            
            dataGridView2.Columns[7].ValueType = typeof(int);
            //dataGridView2.Columns[8].Name = "";
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            dataGridView2.FirstDisplayedScrollingColumnIndex = 7;
        }
        private void HesapAra_Click(object sender, EventArgs e)
        {
            #region dgw
            string query = "Select * From MahsupHesabi where Hesap = '" + listBox1.SelectedValue.ToString() + "' ORDER BY No";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            da.Fill(ds, "MahsupHesabi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MahsupHesabi";
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "MahsupHesabi";
            #endregion
            #region Toplam
            int a = dataGridView2.RowCount;
            for (int i = 1; i < a - 1; i++)
            {
                //dataGridView1.Rows[i].Cells[7].Value = (Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) - Convert.ToInt32( dataGridView1.Rows[i].Cells[5].Value)).ToString();
                try
                {
                    dataGridView2.Rows[0].Cells[7].Value = Convert.ToString(0 - Convert.ToInt64(dataGridView2.Rows[0].Cells[6].Value));
                    dataGridView2.Rows[i].Cells[7].Value = Convert.ToString(Convert.ToInt64(dataGridView2.Rows[i - 1].Cells[7].Value) + Convert.ToInt64(dataGridView2.Rows[i].Cells[5].Value) - Convert.ToInt64(dataGridView2.Rows[i].Cells[6].Value));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            dataGridView2.FirstDisplayedScrollingColumnIndex = 7;
            #endregion
        }
        private void SilmeB_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE From MahsupHesabi where No ='" + NoTB.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //---------------------------------------------
            query = "Select * From MahsupHesabi ORDER BY No";
            ds = new DataSet();
            da = new SqlDataAdapter(query, con);
            con.Open();
            da.Fill(ds, "MahsupHesabi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MahsupHesabi";
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "MahsupHesabi";
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                listBox2.Enabled = true;
                label8.Enabled = true;
            //    label3.Text = "Borç";

            //    Hesap2CB.Enabled = true;
            //    label8.Enabled = true;
            }
            else
            {
                listBox2.Enabled= false;
                label8.Enabled= false;  
            //    label3.Text = "Hesap";
            //    Hesap2CB.Text = "";
            //    Hesap2CB.Enabled = false;
            //    label8.Enabled = false;
            }


        }
        #region Enter
        private void IslemB_Enter(object sender, EventArgs e)
        {
        }
        private void HesapCB_Enter(object sender, EventArgs e)
        {
        }
        private void Hesap2CB_Enter(object sender, EventArgs e)
        {
        }
        private void AciklamaTB_Enter(object sender, EventArgs e)
        {
        }
        private void AlacakTB_Enter(object sender, EventArgs e)
        {
        }
        private void BorcTB_Enter(object sender, EventArgs e)
        {
        }
        private void PlakaCB_Enter(object sender, EventArgs e)
        {


        }
        #endregion
        #region Keydown
        private void TarihDTP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                listBox1.Focus();
            }
        }
        private void Hesap2CB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                AciklamaTB.Focus();
            }
        }
        private void HesapCB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && checkBox1.Enabled)
            {
                listBox2.Focus();
            }
            else if ((e.KeyCode == Keys.Enter) && !checkBox1.Enabled)
            {
                AciklamaTB.Focus();
            }
        }
        private void AciklamaTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                BorcTB.Focus();
            }
        }
        private void BorcTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                AlacakTB.Focus();
            }
            
        }
        private void AlacakTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                PlakaCB.Focus();
            }

            
        }
        private void PlakaCB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                IslemB.Focus();
            }
        }
        private void Mahsup_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void IslemB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                TarihDTP.Focus();
            }
        }
        #endregion
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            NoTB.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

        }
        #region Boş
        private void DegisimCB_CheckedChanged(object sender, EventArgs e)
        {
            //if(DegisimCB.Checked)
            //{
            //    BorcTB.Enabled = false;
            //    AlacakTB.Enabled = false;
            //    AciklamaTB.Enabled = false;
            //    Hesap2CB.Enabled = false;
            //    HesapCB.Enabled = false;
            //    PlakaCB.Enabled = false;
            //    TarihDTP.Enabled = false;
            //    checkBox1.Enabled = false;
            //    dataGridView1.Visible = false;
            //    dataGridView1.Enabled = false;
            //    dataGridView2.Enabled = true;
            //    dataGridView2.Visible = true;
            //}
            //else
            //{
            //    BorcTB.Enabled = true;
            //    AlacakTB.Enabled = true;
            //    AciklamaTB.Enabled = true;

            //    HesapCB.Enabled = true;
            //    PlakaCB.Enabled = true;
            //    TarihDTP.Enabled = true;
            //    checkBox1 .Enabled = true;
            //    dataGridView1.Visible = true;
            //    dataGridView1.Enabled = true;
            //    dataGridView2.Enabled = false;
            //    dataGridView2.Visible = false;
            //}

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void AramaCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            dataGridView2.FirstDisplayedScrollingColumnIndex =7;
        }
        private void PlakaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select GonderenFirma from AracHesabiAlacak where Plaka = '"+PlakaCB.Text+"'", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AlacakSaptamasiCB.DataSource = dt;
            AlacakSaptamasiCB.DisplayMember = "GonderenFirma";
        }
        private void AramakTB_TextChanged(object sender, EventArgs e)
        {
            if (AramaCB.Text == "Tarih")
            {
                AzmiCokmu.Visible = false;
                string query = "Select * From MahsupHesabi where Tarih > '" + AramakTB.Text + "' ORDER BY No";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                da.Fill(ds, "MahsupHesabi");
                con.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "MahsupHesabi";
            }
            else if (AramaCB.Text == "Açıklama")
            {
                AzmiCokmu.Visible = false;
                string query = "Select * From MahsupHesabi where Aciklama > '" + AramakTB.Text + "' ORDER BY No";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                da.Fill(ds, "MahsupHesabi");
                con.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "MahsupHesabi";
            }
            else if (AramaCB.Text == "Borç")
            {
                AzmiCokmu.Visible = true;
                if (AzmiCokmu.Visible)
                {
                    string query = "Select * From MahsupHesabi where Borc > '" + AramakTB.Text + "' ORDER BY No";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    da.Fill(ds, "MahsupHesabi");
                    con.Close();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "MahsupHesabi";
                }
                else
                {
                    string query = "Select * From MahsupHesabi where Borc < '" + AramakTB.Text + "' ORDER BY No";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    da.Fill(ds, "MahsupHesabi");
                    con.Close();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "MahsupHesabi";
                }
                
            }
            else if (AramaCB.Text == "Alacak")
            {
                AzmiCokmu.Visible = true;
                if (AzmiCokmu.Checked)
                {
                    string query = "Select * From MahsupHesabi where Alacak > '" + AramakTB.Text + "' ORDER BY No";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    da.Fill(ds, "MahsupHesabi");
                    con.Close();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "MahsupHesabi";
                }
                else
                {
                    string query = "Select * From MahsupHesabi where Alacak < '" + AramakTB.Text + "' ORDER BY No";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    da.Fill(ds, "MahsupHesabi");
                    con.Close();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "MahsupHesabi";
                }
                
            }

        }

        private void AzmiCokmu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HesapCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HesapCB_TextUpdate(object sender, EventArgs e)
        {

            
            //HesapCB.FindString(HesapCB.Text);
        }
        
        private void donbtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From MahsupHesabi ORDER BY No";
            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            con.Open();
            da1.Fill(ds, "MahsupHesabi");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MahsupHesabi";
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "MahsupHesabi";
        }

        private void HesapCB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BorcTB_TextChanged(object sender, EventArgs e)
        {
            //if (BorcTB.Text.Contains(','))
            //{
            //    BorcTB.Text = BorcTB.Text.Substring(0, (BorcTB.Text.Length - 1));
                
            //}
        }
    }
}
