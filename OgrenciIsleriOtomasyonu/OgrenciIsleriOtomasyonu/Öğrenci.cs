using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OgrenciIsleriOtomasyonu
{
    public partial class Öğrenci : Form
    {
        public Öğrenci()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("delete from OGRENCİ where id=@id ", baglanti);
                sorgu.Parameters.AddWithValue("@id", textId.Text);

                sorgu.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Veriler silindi");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textId.Clear();
                textAd.Clear();
                textSoyad.Clear();
                textTc.Clear();
                textTel.Clear();
                textMail.Clear();
            }

        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("insert into OGRENCİ values(@id,@ad,@soyad,@tc,@telno,@email)", baglanti);
                sorgu.Parameters.AddWithValue("@id", textId.Text);
                sorgu.Parameters.AddWithValue("@ad", textAd.Text);
                sorgu.Parameters.AddWithValue("@soyad", textSoyad.Text);
                sorgu.Parameters.AddWithValue("@tc", textTc.Text);
                sorgu.Parameters.AddWithValue("@telno", textTel.Text);
                sorgu.Parameters.AddWithValue("@email", textMail.Text);

                sorgu.ExecuteNonQuery();
                baglanti.Close();


                MessageBox.Show("Veriler kaydedildi");

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                textId.Clear();
                textAd.Clear();
                textSoyad.Clear();
                textTc.Clear();
                textTel.Clear();
                textMail.Clear();
            }


        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
                {
                    baglanti.Open();

                    OleDbCommand sorgu = new OleDbCommand("update OGRENCİ set ad= '" + textAd.Text + "' , soyad= '" + textSoyad.Text + "' , tc= '" + textTc.Text + "' , telno= '" + textTel.Text + "' , email= '" + textMail.Text + "' where id= '" + textId.Text + "'", baglanti);

                    sorgu.Parameters.AddWithValue("@ad", textAd.Text);
                    sorgu.Parameters.AddWithValue("@soyad", textSoyad.Text);
                    sorgu.Parameters.AddWithValue("@tc", textTc.Text);
                    sorgu.Parameters.AddWithValue("@telno", textTel.Text);
                    sorgu.Parameters.AddWithValue("@email", textMail.Text);
                    sorgu.Parameters.AddWithValue("@id", int.Parse(textId.Text));



                    sorgu.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Veriler güncellendi");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textId.Clear();
                textAd.Clear();
                textSoyad.Clear();
                textTc.Clear();
                textTel.Clear();
                textMail.Clear();
            }
        }

        private void Öğrenci_Load(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
