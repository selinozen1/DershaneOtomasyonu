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
    public partial class EtutAlma : Form
    {
        public EtutAlma()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textSaat.Text = button10.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textSaat.Text = button12.Text;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from OGRENCİ", baglanti);
            OleDbDataAdapter da = new OleDbDataAdapter(sorgu);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();

            OleDbConnection baglanti2 = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
            baglanti2.Open();
            OleDbCommand sorgu2 = new OleDbCommand("select * from OGRETMEN", baglanti2);
            OleDbDataAdapter da2 = new OleDbDataAdapter(sorgu2);
            DataTable table2 = new DataTable();
            da2.Fill(table2);
            dataGridView2.DataSource = table2;
            baglanti2.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(textTarih.Text) || string.IsNullOrWhiteSpace(textSaat.Text) || string.IsNullOrWhiteSpace(textOgrAd.Text) || string.IsNullOrWhiteSpace(textOgrSoyad.Text) || string.IsNullOrWhiteSpace(textDers.Text) || string.IsNullOrWhiteSpace(textOgrenciAd.Text) || string.IsNullOrWhiteSpace(textOgrenciSoyad.Text))
                {
                    MessageBox.Show("Boş bırakmayınız!!");
                }
                else if (!OgrenciAdiDogrula(textOgrenciAd.Text))
                {
                    MessageBox.Show("Geçersiz! Lütfen doğru bir şekilde girin.");
                }
                else if (!OgrenciAdiDogrula(textOgrenciSoyad.Text))
                {
                    MessageBox.Show("Geçersiz! Lütfen doğru bir şekilde girin.");
                }
                else if (!OgretmenAdiDogrula(textOgrAd.Text))
                {
                    MessageBox.Show("Geçersiz! Lütfen doğru bir şekilde girin.");
                }
                else if (!OgretmenAdiDogrula(textOgrSoyad.Text))
                {
                    MessageBox.Show("Geçersiz! Lütfen doğru bir şekilde girin.");
                }
                else if(!AyniSaatteEtutAlindiMi(textOgrenciAd.Text, textOgrAd.Text, textTarih.Text, textSaat.Text))
                {
                    MessageBox.Show("Bu tarih ve saatte etüt dolu. Başka bir tarih ve saat seçin.");
                }
                else
                {
                    OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("insert into KAYIT values(@tarih,@saat,@ogretmenadi,@ogretmensoyadi,@ders,@ogrenciadi,@ogrencisoyadi)", baglanti);
                    sorgu.Parameters.AddWithValue("@tarih", textTarih.Text);
                    sorgu.Parameters.AddWithValue("@saat", textSaat.Text);
                    sorgu.Parameters.AddWithValue("@ogretmenadi", textOgrAd.Text);
                    sorgu.Parameters.AddWithValue("@ogretmensoyadi", textOgrSoyad.Text);
                    sorgu.Parameters.AddWithValue("@ders", textDers.Text);
                    sorgu.Parameters.AddWithValue("@ogrenciadi", textOgrenciAd.Text);
                    sorgu.Parameters.AddWithValue("@ogrencisoyadi", textOgrenciSoyad.Text);

                    sorgu.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Etüt alındı.");

                    Cikis çıkış = new Cikis();
                    çıkış.Show();
                    this.Hide();

                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textTarih.Clear();
                textSaat.Clear();
                textOgrAd.Clear();
                textOgrSoyad.Clear();
                textDers.Clear();
                textOgrenciAd.Clear();
                textOgrenciSoyad.Clear();
            }

        }

        private bool OgrenciAdiDogrula(string ogrenciAdi)
        {
            using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
            {
                baglanti.Open();

                string sorgu = "SELECT COUNT(*) FROM OGRENCİ WHERE ad = @ogrenciadi AND soyad = @ogrencisoyadi";
                using (OleDbCommand komut = new OleDbCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@ogrenciadi", textOgrenciAd.Text);
                    komut.Parameters.AddWithValue("@ogrencisoyadi", textOgrenciSoyad.Text);
                    int ogrenciSayisi = (int)komut.ExecuteScalar();

                   
                    return ogrenciSayisi > 0;
                }
            }
        }

        private bool OgretmenAdiDogrula(string ogretmenAdi)
        {
            using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
            {
                baglanti.Open();

                string sorgu = "SELECT COUNT(*) FROM OGRETMEN WHERE ad = @ogretmenadi AND soyad = @ogretmensoyadi";
                using (OleDbCommand komut = new OleDbCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@ogretmenadi", textOgrAd.Text);
                    komut.Parameters.AddWithValue("@ogretmensoyadi", textOgrSoyad.Text);

                    int ogretmenSayisi = (int)komut.ExecuteScalar();

                    
                    return ogretmenSayisi > 0;
                }
            }
        }

        private bool AyniSaatteEtutAlindiMi(string ogrenciAdi, string ogretmenAdi, string tarih, string saat)
        {
            using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
            {
                baglanti.Open();

                // Aynı gün ve saatte etüt alınmış mı kontrolü
                string kontrolSorgu = "SELECT COUNT(*) FROM KAYIT WHERE tarih = @tarih AND saat = @saat";
                using (OleDbCommand kontrolKomut = new OleDbCommand(kontrolSorgu, baglanti))
                {
                   
                    kontrolKomut.Parameters.AddWithValue("@tarih", tarih);
                    kontrolKomut.Parameters.AddWithValue("@saat", saat);

                    int etutSayisi = (int)kontrolKomut.ExecuteScalar();
                    if (etutSayisi > 0)
                    {
                        return false;
                    }

                    // Aynı gün ve saatte etüt alınmamışsa true, alınmışsa false döndür
                    return true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textSaat.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textSaat.Text = button2.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textSaat.Text = button3.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textSaat.Text = button4.Text;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textSaat.Text = button5.Text;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textSaat.Text = button6.Text;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textSaat.Text = button7.Text;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textSaat.Text = button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textSaat.Text = button9.Text;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textSaat.Text = button11.Text;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("delete from KAYIT where tarih=@tarih and saat=@saat ", baglanti);
                sorgu.Parameters.AddWithValue("@tarih", textTarih.Text);
                sorgu.Parameters.AddWithValue("@saat", textSaat.Text);


                sorgu.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Veriler silindi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textTarih.Clear();
                textSaat.Clear();
                textOgrAd.Clear();
                textOgrSoyad.Clear();
                textDers.Clear();
                textOgrenciAd.Clear();
                textOgrenciSoyad.Clear();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textTarih.Text = dateTimePicker1.Text;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView2.CurrentRow;

            textOgrAd.Text = satir.Cells["Ad"].Value.ToString();
            textOgrSoyad.Text = satir.Cells["Soyad"].Value.ToString();
           textDers.Text = satir.Cells["Branş"].Value.ToString();

        }

        private void textTarih_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; // datagridwiev nesnesi olusturuldu. currrentrow, kullanıcının şu anki satırda bulunduğu satırı belirledi

            textOgrenciAd.Text = satir.Cells["Ad"].Value.ToString();
            textOgrenciSoyad.Text = satir.Cells["Soyad"].Value.ToString();
           
        }
    }
}
