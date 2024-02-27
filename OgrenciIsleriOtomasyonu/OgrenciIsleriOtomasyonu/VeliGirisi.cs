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
    public partial class VeliGirisi : Form
    {
        public VeliGirisi()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("insert into VELİ values(@ad,@soyad,@adres,@telno,@id)", baglanti);
             
                sorgu.Parameters.AddWithValue("@ad", textBoxAd.Text);
                sorgu.Parameters.AddWithValue("@soyad", textBoxSoyad.Text);
                sorgu.Parameters.AddWithValue("@adres", textBoxAdres.Text);
                sorgu.Parameters.AddWithValue("@telno", textBoxTelno.Text);
                sorgu.Parameters.AddWithValue("@id", textBoxId.Text);

                sorgu.ExecuteNonQuery();
                baglanti.Close();


                MessageBox.Show("Veriler kaydedildi");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
                {
                    baglanti.Open();

                    OleDbCommand sorgu = new OleDbCommand("update VELİ set ad= '" + textBoxAd.Text + "' , soyad= '" + textBoxSoyad.Text + "' , adres= '" + textBoxAdres.Text + "' , telno= '" + textBoxTelno.Text +  "' where id= '" + textBoxId.Text + "'", baglanti);

                    sorgu.Parameters.AddWithValue("@ad", textBoxAd.Text);
                    sorgu.Parameters.AddWithValue("@soyad", textBoxSoyad.Text);
                    sorgu.Parameters.AddWithValue("@adres", textBoxAdres.Text);
                    sorgu.Parameters.AddWithValue("@telno", textBoxTelno.Text);
                    sorgu.Parameters.AddWithValue("@id", int.Parse(textBoxId.Text));



                    sorgu.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Veriler güncellendi");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("delete from VELİ where id=@id ", baglanti);
                sorgu.Parameters.AddWithValue("@id", textBoxId.Text);

                sorgu.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Veriler silindi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VeliGirisi_Load(object sender, EventArgs e)
        {

        }
    }
}
