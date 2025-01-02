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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Xeni
{
    public partial class AracHesap : Form
    {
        public AracHesap()
        {
            InitializeComponent();
        }
        bool goruntule = false;
        int rowindex = 0;
        int sayii;
        SqlConnection con = new SqlConnection(File.ReadAllText("yol.txt"));
        //Girişler
        private void SeferHesapB_Click(object sender, EventArgs e)
        {
            if (SeferNoTB.Text != "" && PlakaCB.Text != "")
            {
                if (GonderenFirmaTB.Text != "" || AliciFirmaTB.Text != "")
                {
                    #region Arac Giris
                    con.Open();                   
                    string query = "INSERT INTO AracHesabiYuk (SeferNo,No,Plaka,YuklemeTarihi,GonderenFirma,AliciFirma,Cinsi,Guzergah,BrutNavlun,Komisyon,SoforTahsil,HizmetBedeli,Kdv) " +
                    "VALUES (@SeferNo,@No,@Plaka,@YuklemeTarihi,@GonderenFirma,@AliciFirma,@Cinsi,@Guzergah,@BrutNavlun,@Komisyon,@SoforTahsil,@HizmetBedeli,@Kdv)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //----------------------------------------------------------------------
                    //SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiYuk ", con);
                    //int sayii = Convert.ToInt32(cmd2.ExecuteScalar());
                    //cmd.Parameters.AddWithValue("@No", sayii + 1);
                    cmd.Parameters.AddWithValue("@SeferNo", SeferNoTB.Text);
                    SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiYuk Where SeferNo='" + SeferNoTB.Text + "'", con);
                    
                    try
                    {
                        sayii = Convert.ToInt32(cmd2.ExecuteScalar());
                        cmd.Parameters.AddWithValue("@No", sayii + 1);
                    }
                    catch (Exception ex)
                    {
                        cmd.Parameters.AddWithValue("@No", 1);
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("BOŞVER KNK HATA DEĞİL MERAK ETME");
                    }
                    if (HizmetBedeliTB.Text == "Var")
                    {
                        HizmetBedeliTB.Text = (Convert.ToDouble(BrutNavlunTB.Text) * 0.06).ToString();
                    }
                    else
                    {
                        HizmetBedeliTB.Text = "0";
                    }
                    
                    //cmd.Parameters.AddWithValue("@No", NoTB.Text);
                    cmd.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
                    cmd.Parameters.AddWithValue("@YuklemeTarihi", YuklemeTarihDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@GonderenFirma", GonderenFirmaTB.Text);
                    cmd.Parameters.AddWithValue("@AliciFirma", AliciFirmaTB.Text);
                    cmd.Parameters.AddWithValue("@Cinsi", CinsiTB.Text);
                    cmd.Parameters.AddWithValue("@Guzergah", GuzergahTB.Text);
                    cmd.Parameters.AddWithValue("@BrutNavlun", BrutNavlunTB.Text);
                    cmd.Parameters.AddWithValue("@Komisyon", KomisyonTB.Text);
                    cmd.Parameters.AddWithValue("@SoforTahsil", SoforTahsilatTB.Text);
                    cmd.Parameters.AddWithValue("@HizmetBedeli", HizmetBedeliTB.Text);
                    cmd.Parameters.AddWithValue("@Kdv", KdvTB.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //-------------------------ALINAN PARA GÖZÜKMEK ZORUNDA MI YOKSA DEĞİL Mİ--------------------------Zorundaymış Aga---------
                    con.Open();
                    string queryAlacak1 = "select count(GonderenFirma) from AracHesabiYuk where GonderenFirma = '"+GonderenFirmaTB.Text+"' ";
                    string queryAlacak2 = "INSERT INTO AracHesabiAlacak (No,Plaka,YuklemeTarihi,GonderenFirma,AliciFirma,Guzergah,KalanAlacak) " +
                        "VALUES (@No,@Plaka,@YuklemeTarihi,@GonderenFirma,@AliciFirma,@Guzergah,@KalanAlacak)";
                    SqlCommand cmdAlacak1 = new SqlCommand(queryAlacak2, con);
                    SqlCommand cmdAlacak2 = new SqlCommand(queryAlacak1, con);
                    cmdAlacak2.ExecuteNonQuery();
                    SqlDataReader sqdata = cmdAlacak2.ExecuteReader();
                    while (sqdata.Read())
                    {
                        GonderenFirmaTB.Text += sqdata[0].ToString();
                    }
                    con.Close();
                    con.Open();
                    
                    
                    int sofortah = Convert.ToInt32(BrutNavlunTB.Text) - Convert.ToInt32(SoforTahsilatTB.Text);
                    if (sofortah == 0)
                    {
                        
                    }
                    else
                    {
                        cmdAlacak1.Parameters.AddWithValue("@No", sayii + 1);
                        cmdAlacak1.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
                        cmdAlacak1.Parameters.AddWithValue("@YuklemeTarihi", YuklemeTarihDTP.Value.Date);
                        cmdAlacak1.Parameters.AddWithValue("@GonderenFirma", GonderenFirmaTB.Text);
                        cmdAlacak1.Parameters.AddWithValue("@AliciFirma", AliciFirmaTB.Text);
                        cmdAlacak1.Parameters.AddWithValue("@Guzergah", GuzergahTB.Text);
                        cmdAlacak1.Parameters.AddWithValue("@KalanAlacak", sofortah);                      
                    }
                    // no plak yüklemet gonderenf alicif güzergah kalanalacak tarih nereye gelenpara


                    cmdAlacak1.ExecuteNonQuery();
                    //------------------------------------------------------------------------
                    string queryfatura = "INSERT INTO AracHesabiFatura (No,Plaka,Ay,Tarih,Firma,Miktari,KDV,Tevkifat) " +
                    "VALUES (@No,@Plaka,@Ay,@Tarih,@Firma,@Miktari,@KDV,@Tevkifat)";
                    SqlCommand cmdfatura = new SqlCommand(queryfatura, con);
                    
                    
                    try
                    {
                        cmdfatura.Parameters.AddWithValue("@No", sayii + 1);
                    }
                    catch (Exception ex)
                    {
                        cmdfatura.Parameters.AddWithValue("@No", 1);
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("BOŞVER KNK HATA DEĞİL MERAK ETME");
                    }

                    //cmd.Parameters.AddWithValue("@No", NoTB.Text);
                    cmdfatura.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
                    cmdfatura.Parameters.AddWithValue("@Ay", YuklemeTarihDTP.Value.ToString("MMMM"));
                    cmdfatura.Parameters.AddWithValue("@Tarih", YuklemeTarihDTP.Value.Date);
                    cmdfatura.Parameters.AddWithValue("@Firma", AliciFirmaTB.Text);
                    cmdfatura.Parameters.AddWithValue("@Miktari", BrutNavlunTB.Text);
                    if (Convert.ToInt32(BrutNavlunTB.Text) >= 2000)
                    {
                        cmdfatura.Parameters.AddWithValue("@KDV", Convert.ToInt32(BrutNavlunTB.Text) * 0.16);
                        cmdfatura.Parameters.AddWithValue("@Tevkifat", Convert.ToInt32(BrutNavlunTB.Text) * 0.04);
                    }
                    else
                    {
                        cmdfatura.Parameters.AddWithValue("@KDV", Convert.ToInt32(BrutNavlunTB.Text) * 0.20);
                    }

                    
                    
                    
                    cmdfatura.ExecuteNonQuery();
                    con.Close();
                    #endregion
                    //----------------------------------------------------------------------
                    #region Görünütüle

                    query = "Select * From AracHesabiAlacak where Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    da1.Fill(ds, "AracHesabiAlacak");
                    con.Close();
                    TahsilEdilenlerData.DataSource = ds;
                    TahsilEdilenlerData.DataMember = "AracHesabiAlacak";
                    //----------------------------------------------------------------------
                    query = "Select * From AracHesabiYuk where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                     ds = new DataSet();
                     da1 = new SqlDataAdapter(query, con);
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    da1.Fill(ds, "AracHesabiYuk");
                    con.Close();
                    AracYukData.DataSource = ds;
                    AracYukData.DataMember = "AracHesabiYuk";
                    #endregion
                    //----------------------------------------------------------------------
                    #region Tasarım
                    SeferNoTB.Text = "";
                    PlakaCB.Text = "";
                    GonderenFirmaTB.Text = "";
                    AliciFirmaTB.Text = "";
                    CinsiTB.Text = "";
                    GuzergahTB.Text = "";
                    BrutNavlunTB.Text = "";
                    KomisyonTB.Text = "";
                    SoforTahsilatTB.Text = "";
                    HizmetBedeliTB.Text = "";
                    KdvTB.Text = "";
                    #endregion
                }
                else if (MazotTB.Text != "" || AlinanMazotTB.Text != "")
                {
                    #region Arac Giris
                    con.Open();
                    string query = "insert into AracHesabiMazot (SeferNo, No, Plaka, Mazot, MazotPara) Values(@SeferNo, @No, @Plaka, @Mazot, @MazotPara)";

                    DataSet ds = new DataSet();
                    DataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SeferNo", SeferNoTB.Text);
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiMazot Where SeferNo='" + SeferNoTB.Text + "'", con);
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
                    cmd.Parameters.AddWithValue("@Mazot", MazotTB.Text);
                    cmd.Parameters.AddWithValue("@MazotPara", AlinanMazotTB.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                    //----------------------------------------------------------------------
                    #region Görünütüle
                    query = "Select * From AracHesabiMazot where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                    ds = new DataSet();
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    da1.Fill(ds, "AracHesabiMazot");
                    con.Close();
                    MazotHesabiData.DataSource = ds;
                    MazotHesabiData.DataMember = "AracHesabiMazot";
                    #endregion
                    //----------------------------------------------------------------------
                    #region Tasarım
                    SeferNoTB.Text = string.Empty;
                    PlakaCB.Text = string.Empty;
                    MazotTB.Text = string.Empty;
                    AlinanMazotTB.Text = string.Empty;
                    #endregion
                }
                else if (CikisKmTB.Text != "" || GelisKmTB.Text != "" || DepodaKalanMazotTB.Text != "" || GidisYolAvansTB.Text != "")
                {
                    #region Arac Giris
                    con.Open();
                    string query = "insert into AracHesabiTeklik (SeferNo, Plaka, No , CikisKm, GelisKm, DepodaKalanMazot, GidisYolAvansi) Values(@SeferNo, @Plaka, @No , @CikisKm, @GelisKm, @DepodaKalanMazot, @GidisYolAvansi)";

                    DataSet ds = new DataSet();
                    DataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SeferNo", SeferNoTB.Text);
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiTeklik Where SeferNo='" + SeferNoTB.Text + "'", con);
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
                    cmd.Parameters.AddWithValue("@CikisKm", CikisKmTB.Text);
                    cmd.Parameters.AddWithValue("@GelisKm", GelisKmTB.Text);
                    cmd.Parameters.AddWithValue("@DepodaKalanMazot", DepodaKalanMazotTB.Text);
                    cmd.Parameters.AddWithValue("@GidisYolAvansi", GidisYolAvansTB.Text);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                     query = "insert into AracHesabiTeklik (SeferNo, Plaka, No , CikisKm, DepodaKalanMazot) Values(@SeferNo, @Plaka, @No , @CikisKm, @DepodaKalanMazot)";

                    ds = new DataSet();
                    da = new SqlDataAdapter(query, con);
                    cmd = new SqlCommand(query, con);
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiTeklik Where SeferNo='" + SeferNoTB.Text + "'", con);
                        int sayii = Convert.ToInt32(cmd2.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@No", sayii + 1);
                    }
                    catch (Exception ex)
                    {
                        cmd.Parameters.AddWithValue("@No", 1);
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("BOŞVER KNK HATA DEĞİL MERAK ETME");
                    }

                    cmd.Parameters.AddWithValue("@SeferNo", Convert.ToInt32(SeferNoTB.Text) + 1);
                    cmd.Parameters.AddWithValue("@Plaka", PlakaCB.Text);
                    cmd.Parameters.AddWithValue("@CikisKm", GelisKmTB.Text);
                    cmd.Parameters.AddWithValue("@DepodaKalanMazot", 0);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                    //----------------------------------------------------------------------
                    #region Görünütüle
                    query = "Select * From AracHesabiTeklik where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                    ds = new DataSet();
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    da1.Fill(ds, "AracHesabiTeklik");
                    con.Close();
                    TekliklerData.DataSource = ds;
                    TekliklerData.DataMember = "AracHesabiTeklik";
                    #endregion
                    //----------------------------------------------------------------------
                    #region Tasarım
                    SeferNoTB.Text = string.Empty;
                    PlakaCB.Text = string.Empty;
                    CikisKmTB.Text = string.Empty;
                    GelisKmTB.Text = string.Empty;
                    DepodaKalanMazotTB.Text = string.Empty;
                    GidisYolAvansTB.Text = string.Empty;
                    #endregion
                }
                else if (SeferHarcamalariTB.Text != "" || SeferHarcamalariParaTB.Text != "")
                {
                    #region Arac Giris
                    con.Open();
                    string query = "insert into AracHesabiSefer (SeferNo, No, Plaka, SeferHarcamalari, SeferHParalari) Values(@SeferNo, @No, @Plaka, @SeferHarcamalari, @SeferHParalari)";

                    DataSet ds = new DataSet();
                    DataAdapter da = new SqlDataAdapter(query, con);
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SeferNo", SeferNoTB.Text);
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiSefer Where SeferNo='" + SeferNoTB.Text + "'", con);
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
                    cmd.Parameters.AddWithValue("@SeferHarcamalari", SeferHarcamalariTB.Text);
                    cmd.Parameters.AddWithValue("@SeferHParalari", SeferHarcamalariParaTB.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    #endregion
                    //----------------------------------------------------------------------
                    #region Görünütüle
                    query = "Select * From AracHesabiSefer where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                    ds = new DataSet();
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    da1.Fill(ds, "AracHesabiSefer");
                    con.Close();
                    MazotHesabiData.DataSource = ds;
                    MazotHesabiData.DataMember = "AracHesabiSefer";
                    #endregion
                    //----------------------------------------------------------------------
                    #region Tasarım
                    SeferNoTB.Text = string.Empty;
                    PlakaCB.Text = string.Empty;
                    MazotTB.Text = string.Empty;
                    AlinanMazotTB.Text = string.Empty;
                    #endregion
                }
            }
        }
        //Görüntülemeler
        private void GoruntuleB_Click(object sender, EventArgs e)
        {
            #region Aramak
            goruntule = true;
            string query = "Select * From AracHesabiYuk where SeferNo = '"+SeferNoTB.Text+"' and Plaka = '"+PlakaCB.Text+ "' ORDER BY No";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            da.Fill(ds, "AracHesabiYuk");
            con.Close();
            AracYukData.DataSource = ds;
            AracYukData.DataMember = "AracHesabiYuk";
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiMazot where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiMazot");
            con.Close();
            MazotHesabiData.DataSource = ds;
            MazotHesabiData.DataMember = "AracHesabiMazot";
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiTeklik where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiTeklik");
            con.Close();
            TekliklerData.DataSource = ds;
            TekliklerData.DataMember = "AracHesabiTeklik";
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiSefer where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiSefer");
            con.Close();
            SeferHesabiData.DataSource = ds;
            SeferHesabiData.DataMember = "AracHesabiSefer";
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiAlacak where Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiAlacak");
            con.Close();
            TahsilEdilenlerData.DataSource = ds;
            TahsilEdilenlerData.DataMember = "AracHesabiAlacak";
            #endregion
            //----------------------------------------------------------------------
            #region NetNavlun
            int b = AracYukData.RowCount;
            int a5 = SeferHesabiData.RowCount;
            double c1 = 0;
            double c = 0;
            double zarar1 = 0.0;
            double zarar2 = 0.0;
            
            for (int i = 1; i < b - 1; i++)
            {
                //dataGridView1.Rows[i].Cells[7].Value = (Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) - Convert.ToInt32( dataGridView1.Rows[i].Cells[5].Value)).ToString();
                try
                {

                    c += Convert.ToDouble(AracYukData.Rows[i].Cells[8].Value);
                    zarar1 += Convert.ToDouble(AracYukData.Rows[i].Cells[9].Value);
                    zarar2 += Convert.ToDouble(AracYukData.Rows[i].Cells[11].Value);

                    //HizmetBedelilbl.Text = "Hizmet Bedeli: " + c;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }


            }
            for (int i = 1; i < a5 - 1; i++)
            {
                c1 += Convert.ToDouble(SeferHesabiData.Rows[i].Cells[4].Value);
            }
            c += Convert.ToDouble(AracYukData.Rows[0].Cells[8].Value);
            c = c -  Convert.ToDouble(AracYukData.Rows[0].Cells[11].Value) - Convert.ToInt32(AracYukData.Rows[0].Cells[9].Value)- Convert.ToDouble(SeferHesabiData.Rows[0].Cells[4].Value) - zarar1 - zarar2 - c1;

            NetNavlunlbl.Text = "Net Navlun: " + c;
            #endregion
            //----------------------------------------------------------------------
            #region Ortalama mazot Birimi
            int satirsayisi = MazotHesabiData.RowCount;
            double ortalama1 = 0;
            double ortalama2 = 0.0;
            for (int i = 1; i < satirsayisi - 1; i++)
            {
                //dataGridView1.Rows[i].Cells[7].Value = (Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) - Convert.ToInt32( dataGridView1.Rows[i].Cells[5].Value)).ToString();
                try
                {

                    ortalama1 += Convert.ToDouble(MazotHesabiData.Rows[i].Cells[3].Value);
                    ortalama2 += Convert.ToDouble(MazotHesabiData.Rows[i].Cells[4].Value);
                    

                    //HizmetBedelilbl.Text = "Hizmet Bedeli: " + c;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

                ortalama1 += Convert.ToDouble(MazotHesabiData.Rows[0].Cells[3].Value);
                ortalama2 += Convert.ToDouble(MazotHesabiData.Rows[0].Cells[4].Value);
                double ortalama = ortalama1/ ortalama2;

                OrtalamaMlbl.Text = ortalama.ToString();


            }
            #endregion
            //----------------------------------------------------------------------
            #region Yüzde Hesaplama
            int b2 = TekliklerData.RowCount;
            for (int i = 1; i < b2 - 1; i++)
            {
                //dataGridView1.Rows[i].Cells[7].Value = (Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) - Convert.ToInt32( dataGridView1.Rows[i].Cells[5].Value)).ToString();
                try
                {                   
                    zarar1 += Convert.ToDouble(MazotHesabiData.Rows[i].Cells[4].Value);
                    //HizmetBedelilbl.Text = "Hizmet Bedeli: " + c;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            double depodakm;
            zarar1 += Convert.ToDouble(MazotHesabiData.Rows[0].Cells[4].Value);
            try
            {
                depodakm = Convert.ToDouble(TekliklerData.Rows[0].Cells[5].Value);

            }
            catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
                depodakm = 0;
                throw ex;
                
            }
            SeferdeYMlbl.Text = "Seferden Toplam Alınan Mazot: " +  zarar1;
            if (depodakm != 0)
            {
              
                
                    double yakilanmazot = zarar1 - depodakm;
                    double toplamkm = Convert.ToDouble(TekliklerData.Rows[0].Cells[4].Value) - Convert.ToDouble(TekliklerData.Rows[0].Cells[3].Value);
                    YuzdeHesabi.Text = "Yüzde : " + yakilanmazot / toplamkm;
                    ToplamKmlbl.Text = toplamkm.ToString();
                    ToplamdaYMlbl.Text = "Seferden Toplam Yakılan Mazot: " + yakilanmazot.ToString();
                
            }
            
            #endregion
        }
        //Silmeler
        private void SeferHesapSilmeB_Click(object sender, EventArgs e)
        {
            string query;
            if (YuklerRB.Checked)
            {
                con.Open();
                query = "Delete From AracHesabiYuk where No = '" + NoTB.Text + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
                //----------------------------------------------------------------------

                query = "Select * From AracHesabiYuk where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                 ds = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                cmd = new SqlCommand(query, con);
                con.Open();
                da1.Fill(ds, "AracHesabiYuk");
                con.Close();
                AracYukData.DataSource = ds;
                AracYukData.DataMember = "AracHesabiYuk";
            }
            //----------------------------------------------------------------------
            if (MazotRB.Checked)
            {
                con.Open();
                query = "Delete From AracHesabiMazot where No = '" + NoTB.Text + "'";
                //DELETE From MahsupHesabi where No 
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
                //----------------------------------------------------------------------

                query = "Select * From AracHesabiMazot where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                ds = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                cmd = new SqlCommand(query, con);
                con.Open();
                da1.Fill(ds, "AracHesabiMazot");
                con.Close();
                MazotHesabiData.DataSource = ds;
                MazotHesabiData.DataMember = "AracHesabiMazot";
            }
            //----------------------------------------------------------------------
            if (TekliklerRB.Checked)
            {
                con.Open();
                query = "Delete From AracHesabiTeklik where No = '" + NoTB.Text + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
                //----------------------------------------------------------------------

                query = "Select * From AracHesabiTeklik where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                ds = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                cmd = new SqlCommand(query, con);
                con.Open();
                da1.Fill(ds, "AracHesabiTeklik");
                con.Close();
                TekliklerData.DataSource = ds;
                TekliklerData.DataMember = "AracHesabiTeklik";
            }
            //----------------------------------------------------------------------
            if (AracSeferRB.Checked)
            {
                con.Open();
                query = "Delete From AracHesabiSefer where No = '" + NoTB.Text + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
                //----------------------------------------------------------------------

                query = "Select * From AracHesabiSefer where SeferNo = '" + SeferNoTB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
                ds = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                cmd = new SqlCommand(query, con);
                con.Open();
                da1.Fill(ds, "AracHesabiSefer");
                con.Close();
                SeferHesabiData.DataSource = ds;
                SeferHesabiData.DataMember = "AracHesabiSefer";

            }
        }
        //İlk Başta Yükleme
        private void AracHesap_Load(object sender, EventArgs e)
        {
            #region Tabloları Görüntüleme
            SqlCommand cmd = new SqlCommand("Select Plaka from AracPlakalari ", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            PlakaCB.DataSource = dt;
            PlakaCB.DisplayMember = "Plaka";
            //----------------------------------------------------------------------
            cmd = new SqlCommand("Select Plaka from AracPlakalari ", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            AlacaklarPlakaCB.DataSource = dt;
            AlacaklarPlakaCB.DisplayMember = "Plaka";
            //----------------------------------------------------------------------
            cmd = new SqlCommand("Select Plaka from AracPlakalari ", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            PlakaFCB.DataSource = dt;
            PlakaFCB.DisplayMember = "Plaka";
            //----------------------------------------------------------------------
            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("Select* From AracHesabiYuk ORDER BY No", con);
            con.Open();
            da1.Fill(ds, "AracHesabiYuk");
            con.Close();
            AracYukData.DataSource = ds;
            AracYukData.DataMember = "AracHesabiYuk";
            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from AracHesabiMazot ORDER BY No", con);
            con.Open();
            da2.Fill(ds, "AracHesabiMazot");
            con.Close();
            MazotHesabiData.DataSource = ds;
            MazotHesabiData.DataMember = "AracHesabiMazot";

            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from AracHesabiTeklik ORDER BY No", con);
            con.Open();
            da3.Fill(ds, "AracHesabiTeklik");
            con.Close();
            TekliklerData.DataSource = ds;
            TekliklerData.DataMember = "AracHesabiTeklik";
            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter("select * from AracHesabiSefer ORDER BY No", con);
            con.Open();
            da4.Fill(ds, "AracHesabiSefer");
            con.Close();
            SeferHesabiData.DataSource = ds;
            SeferHesabiData.DataMember = "AracHesabiSefer";
            //----------------------------------------------------------------------           
            ds = new DataSet();
            SqlDataAdapter da5 = new SqlDataAdapter("Select * From AracHesabiAlacak ORDER BY No", con);
            con.Open();
            da5.Fill(ds, "AracHesabiAlacak");
            con.Close();
            TahsilEdilenlerData.DataSource = ds;
            TahsilEdilenlerData.DataMember = "AracHesabiAlacak";
            //----------------------------------------------------------------------           
            ds = new DataSet();
            SqlDataAdapter da6 = new SqlDataAdapter("Select * From AracHesabiAlacak ORDER BY No", con);
            con.Open();
            da6.Fill(ds, "AracHesabiAlacak");
            con.Close();
            AlacaklarData.DataSource = ds;
            AlacaklarData.DataMember = "AracHesabiAlacak";
            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da7 = new SqlDataAdapter("Select * From AracHesabiFatura ORDER BY No", con);
            con.Open();
            da7.Fill(ds, "AracHesabiFatura");
            con.Close();
            FaturaDGW.DataSource = ds;
            FaturaDGW.DataMember = "AracHesabiFatura";
            #endregion
            //----------------------------------------------------------------------
            #region Tasarım
            //Tasarımm
            AracYukData.Columns[0].Width = 30;
            AracYukData.Columns[1].Width = 30;
            AracYukData.Columns[2].Width = 80;
            AracYukData.Columns[3].Width = 80;
            AracYukData.Columns[4].Width = 120;
            AracYukData.Columns[5].Width = 120;
            AracYukData.Columns[6].Width = 40;
            AracYukData.Columns[7].Width = 80;
            AracYukData.Columns[8].Width = 70;
            AracYukData.Columns[9].Width = 70;
            AracYukData.Columns[10].Width = 80;
            AracYukData.Columns[11].Width = 80;
            AracYukData.Columns[12].Width = 40;
            //-----------------------------------------------------
            MazotHesabiData.Columns[0].Width = 5;
            MazotHesabiData.Columns[1].Width = 5;
            MazotHesabiData.Columns[2].Width = 5;
            MazotHesabiData.Columns[3].Width = 80;
            MazotHesabiData.Columns[4].Width = 80;
            //-----------------------------------------------------
            SeferHesabiData.Columns[0].Width = 5;
            SeferHesabiData.Columns[1].Width = 5;
            SeferHesabiData.Columns[2].Width = 5;
            SeferHesabiData.Columns[3].Width = 105;
            SeferHesabiData.Columns[4].Width = 80;
            //-------------------------------------------------------
            TekliklerData.Columns[2].Width = 0;
            NoTB.Text = string.Empty;
            //-------------------------------------------------------
            TahsilEdilenlerData.Columns[0].Width = 25;
            TahsilEdilenlerData.Columns[6].Width = 75;
            TahsilEdilenlerData.Columns[1].Visible = false;
            TahsilEdilenlerData.Columns[2].Visible = false;
            TahsilEdilenlerData.Columns[3].Visible = false;
            TahsilEdilenlerData.Columns[4].Visible = false;
            TahsilEdilenlerData.Columns[5].Visible = false;
            TahsilEdilenlerData.Columns[7].Visible = false;
            TahsilEdilenlerData.Columns[8].Visible = false;
            TahsilEdilenlerData.Columns[9].Visible = false;
            #endregion
            //----------------------------------------------------------------------
            #region Net Navlun
            int c = 0;
            int b = AracYukData.RowCount;
            for (int i = 1; i < b - 1; i++)
            {
                //dataGridView1.Rows[i].Cells[7].Value = (Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) - Convert.ToInt32( dataGridView1.Rows[i].Cells[5].Value)).ToString();
                try
                {

                    c = c + Convert.ToInt32(AracYukData.Rows[i].Cells[8].Value);
                    NetNavlunlbl.Text = "Net Navlun: " + c;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            #endregion
        }
        #region MAZOT VE KM AYARLAMA TEXTBOXLARI
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (MazotTB.Text != "" && AlinanMazotTB.Text != "")
            {
                MazotBirimlbl.Text = Convert.ToString(Convert.ToInt32(AlinanMazotTB.Text) / Convert.ToInt32(MazotTB.Text));
            }
        }
        private void MazotTB_TextChanged(object sender, EventArgs e)
        {
            if (MazotTB.Text != "" && AlinanMazotTB.Text != "")
            {
                MazotBirimlbl.Text = Convert.ToString(Convert.ToInt32(AlinanMazotTB.Text) / Convert.ToInt32(MazotTB.Text));
            }

        }
        private void GelisKmTB_TextChanged(object sender, EventArgs e)
        {
            if (GelisKmTB.Text != "" && CikisKmTB.Text != "")
            {
                ToplamKmlbl.Text = Convert.ToString(Convert.ToInt32(GelisKmTB.Text) - Convert.ToInt32(CikisKmTB.Text));
            }
        }
        private void CikisKmTB_TextChanged(object sender, EventArgs e)
        {
            if (GelisKmTB.Text != "" && CikisKmTB.Text != "")
            {
                ToplamKmlbl.Text = Convert.ToString(Convert.ToInt32(GelisKmTB.Text) - Convert.ToInt32(CikisKmTB.Text));
            }
        }
        #endregion
        //----------------------------------------------------------------------
        #region NO TEXTBOX AYARLAMA      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = AracYukData.CurrentRow.Index;
            NoTB.Text = AracYukData.Rows[rowindex].Cells[1].Value.ToString();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = TekliklerData.CurrentRow.Index;
            NoTB.Text = TekliklerData.Rows[rowindex].Cells[2].Value.ToString();
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = MazotHesabiData.CurrentRow.Index;
            NoTB.Text = MazotHesabiData.Rows[rowindex].Cells[2].Value.ToString();
            if (MazotHesabiData.Rows[rowindex].Cells[3].Value.ToString() != "" && MazotHesabiData.Rows[rowindex].Cells[4].Value.ToString() != "")
            {
                MazotBirimlbl.Text = Convert.ToString(Convert.ToDouble(MazotHesabiData.Rows[rowindex].Cells[3].Value) / Convert.ToDouble(MazotHesabiData.Rows[rowindex].Cells[4].Value));
            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = SeferHesabiData.CurrentRow.Index;
            NoTB.Text = SeferHesabiData.Rows[rowindex].Cells[2].Value.ToString();
        }
        private void AlacaklarData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = AlacaklarData.CurrentRow.Index;
            AlacaklarNoLbl.Text = AlacaklarData.Rows[rowindex].Cells[0].Value.ToString();
        }
        private void FaturaDGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = FaturaDGW.CurrentRow.Index;
            NoFaturaLbl.Text = FaturaDGW.Rows[rowindex].Cells[0].Value.ToString();
        }
        #endregion
        //----------------------------------------------------------------------
        #region BOŞ
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {


        }
        private void YuklerSekmesiGB_Enter(object sender, EventArgs e)
        {


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void GidisYolAvansTB_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        //Hesap Bitirme
        private void MazotHesabiBCB_CheckedChanged(object sender, EventArgs e)
        {
            if (goruntule)
            {
                if (MazotHesabiBCB.Checked)
                {
                    if (TekliklerData.Rows[0].Cells[5].Value != null)
                    {
                        double sonmazottl = 0.00;
                        sonmazottl =  Convert.ToDouble(OrtalamaMlbl.Text) * Convert.ToDouble(TekliklerData.Rows[0].Cells[5].Value);
                        #region GİRİŞ-YAPMA
                        con.Open();
                        string query = "insert into AracHesabiMazot (SeferNo, No, Plaka, Mazot, MazotPara) Values(@SeferNo, @No, @Plaka, @Mazot, @MazotPara)";

                        DataSet ds = new DataSet();
                        DataAdapter da = new SqlDataAdapter(query, con);
                        SqlCommand cmd = new SqlCommand(query, con);
                        try
                        {
                            SqlCommand cmd2 = new SqlCommand("SELECT max(No) from AracHesabiMazot Where SeferNo='" + SeferNoTB.Text + "'", con);
                            int sayii = Convert.ToInt32(cmd2.ExecuteScalar());

                            cmd.Parameters.AddWithValue("@No", sayii + 1);
                        }
                        catch (Exception ex)
                        {
                            cmd.Parameters.AddWithValue("@No", 1);
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("BOŞVER KNK HATA DEĞİL MERAK ETME");
                        }

                        cmd.Parameters.AddWithValue("@SeferNo", Convert.ToInt32(TekliklerData.Rows[0].Cells[0].Value)+1);
                        cmd.Parameters.AddWithValue("@Plaka", (TekliklerData.Rows[0].Cells[1].Value).ToString());
                        cmd.Parameters.AddWithValue("@MazotPara", sonmazottl);
                        cmd.Parameters.AddWithValue("@Mazot", Convert.ToDouble(OrtalamaMlbl.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("ama depoda kalanı girmemişsiiiiin \n olmaz kiii");
                    }
                }

            }
            else
            {
                MessageBox.Show("Hocam yani niye ki \n niye görüntülemeden yapıyon \n olmaz ama böyle");
            }
            

        }
        private void DuzenleBtn_Click(object sender, EventArgs e)
        {
            #region Araç Hesap Yük
            if (GonderenFirmaTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set GonderenFirma = '"+GonderenFirmaTB.Text+"' where No = '"+NoTB.Text+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;

            }
            if (AliciFirmaTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set AliciFirma = '" + AliciFirmaTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            if (CinsiTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set Cinsi = '" + CinsiTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            if (GuzergahTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set Guzergah = '" + GuzergahTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            if (BrutNavlunTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set BrutNavlun = '" + BrutNavlunTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            if (KomisyonTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set Komisyon = '" + KomisyonTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            if (SoforTahsilatTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set SoforTahsil = '" + SoforTahsilatTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            if (KdvTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiYuk Set Kdv = '" + KdvTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            #endregion
            //----------------------------------------------------------------------
            #region Araç Hesap Teklik
            if (GelisKmTB.Text != "")
            {
                con.Open();
                string query = "update AracHesabiTeklik Set GelisKm = '" + GelisKmTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            #endregion
            //----------------------------------------------------------------------
            #region Sefer Harcamaları
            if (SeferHarcamalariTB.Text != "")//açıklama
            {
                con.Open();
                string query = "update AracHesabiSefer Set SeferHarcamalari = '" + SeferHarcamalariTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            if (SeferHarcamalariParaTB.Text!= "")//para
            {
                con.Open();
                string query = "update AracHesabiSefer Set SeferHParalari = '" + SeferHarcamalariParaTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            #endregion
            //----------------------------------------------------------------------
            #region Araç Hesabı Mazot
            if (AlinanMazotTB.Text != "")//parası
            {
                con.Open();
                string query = "update AracHesabiMazot Set MazotPara = '" + AlinanMazotTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close() ;
            }
            if (MazotTB.Text!= "")//MazotPara
            {
                con.Open();
                string query = "update AracHesabiMazot Set Mazot = '" + MazotTB.Text + "' where No = '" + NoTB.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            #endregion
            //----------------------------------------------------------------------
            #region Tabloları Görüntüleme
            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from AracHesabiYuk ORDER BY No", con);
            con.Open();
            da1.Fill(ds, "AracHesabiYuk");
            con.Close();
            AracYukData.DataSource = ds;
            AracYukData.DataMember = "AracHesabiYuk";
            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from AracHesabiMazot ORDER BY No", con);
            con.Open();
            da2.Fill(ds, "AracHesabiMazot");
            con.Close();
            MazotHesabiData.DataSource = ds;
            MazotHesabiData.DataMember = "AracHesabiMazot";

            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from AracHesabiTeklik ORDER BY No ", con);
            con.Open();
            da3.Fill(ds, "AracHesabiTeklik");
            con.Close();
            TekliklerData.DataSource = ds;
            TekliklerData.DataMember = "AracHesabiTeklik";
            //----------------------------------------------------------------------
            ds = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter("select * from AracHesabiSefer ORDER BY No", con);
            con.Open();
            da4.Fill(ds, "AracHesabiSefer");
            con.Close();
            SeferHesabiData.DataSource = ds;
            SeferHesabiData.DataMember = "AracHesabiSefer";
            #endregion
            //----------------------------------------------------------------------
            #region Tasarım
            SeferNoTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            MazotTB.Text = string.Empty;
            AlinanMazotTB.Text = string.Empty;
            
            SeferNoTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            CikisKmTB.Text = string.Empty;
            GelisKmTB.Text = string.Empty;
            DepodaKalanMazotTB.Text = string.Empty;
            GidisYolAvansTB.Text = string.Empty;
            
            SeferNoTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            MazotTB.Text = string.Empty;
            AlinanMazotTB.Text = string.Empty;
            
            SeferNoTB.Text = string.Empty;
            PlakaCB.Text = string.Empty;
            GonderenFirmaTB.Text = string.Empty;
            AliciFirmaTB.Text = string.Empty;
            CinsiTB.Text = string.Empty; 
            GuzergahTB.Text = string.Empty;
            BrutNavlunTB.Text = string.Empty;
            KomisyonTB.Text = string.Empty;
            SoforTahsilatTB.Text = string.Empty; 
            HizmetBedeliTB.Text = string.Empty;
            KdvTB.Text = string.Empty;
            #endregion
        }
        private void GoruntuleBTN2_Click(object sender, EventArgs e)
        {
            string query = "Select * From AracHesabiAlacak where Plaka = '" + AlacaklarPlakaCB.Text + "' ORDER BY No";
            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiAlacak");
            con.Close();
            AlacaklarData.DataSource = ds;
            AlacaklarData.DataMember = "AracHesabiAlacak";
        }
        #region Geçişler
        private void AlacaklarBTN_Click(object sender, EventArgs e)
        {
            YuklerSekmesiGB.Visible = false;
            AlacaklarGB.Visible = true;
            FaturaGB.Visible = false;
        }
        private void YuklerSekmeBTN_Click(object sender, EventArgs e)
        {
            YuklerSekmesiGB.Visible = true;
            AlacaklarGB.Visible = false;
            FaturaGB.Visible = false;
        }
        private void FaturaGecisBT_Click(object sender, EventArgs e)
        {
            FaturaGB.Visible = true;
            AlacaklarGB.Visible = false;
            YuklerSekmesiGB.Visible = false;
        }
        #endregion     
        //Fatura
        private void FaturaAraBTN_Click(object sender, EventArgs e)
        {
            string query = "Select * From AracHesabiFatura where Ay = '" + AyCB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            da.Fill(ds, "AracHesabiFatura");
            con.Close();
            FaturaDGW.DataSource = ds;
            FaturaDGW.DataMember = "AracHesabiFatura";
        }
        private void SonuclandirFatura_Click(object sender, EventArgs e)
        {
            if (KesildimiCB.Checked)
            {
                con.Open();
                string query = "update AracHesabiFatura Set KesildiMi = '" + "Kesildi" + "' where No = '" + NoFaturaLbl.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {

            }
        }
        private void SilFaturaBTN_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Delete From AracHesabiFatura where No = '" + NoTB.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiFatura where Ay = '" + AyCB.Text + "' and Plaka = '" + PlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiFatura");
            con.Close();
            FaturaDGW.DataSource = ds;
            FaturaDGW.DataMember = "AracHesabiFatura";
        }
        private void AlacaklarSilBTN_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Delete From AracHesabiAlacak where No = '" + AlacaklarNoLbl.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //----------------------------------------------------------------------
            query = "Select * From AracHesabiAlacak where Plaka = '" + AlacaklarPlakaCB.Text + "' ORDER BY No";
            ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            cmd = new SqlCommand(query, con);
            con.Open();
            da1.Fill(ds, "AracHesabiAlacak");
            con.Close();
            AlacaklarData.DataSource = ds;
            AlacaklarData.DataMember = "AracHesabiAlacak";
        }

        private void GelmeyenlerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (GelmeyenlerCB.Checked)
            {
                string query = "select * from AracHesabiAlacak where KalanAlacak > 1";
                DataSet ds = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                da1.Fill(ds, "AracHesabiAlacak");
                con.Close();
                AlacaklarData.DataSource = ds;
                AlacaklarData.DataMember = "AracHesabiAlacak";
            }
        }
    }
}
