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
    public partial class DersProgramı : Form
    {
        public DersProgramı()
        {
            InitializeComponent();
        }

        private void DersProgramı_Load(object sender, EventArgs e)
        {
            using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
            {
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select * from DersProgrami", baglanti);
                OleDbDataAdapter da = new OleDbDataAdapter(sorgu);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        private void VerileriGoster()
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
            baglanti.Open();
            // Öğrenci ve ders programı bilgilerini birleştirip DataGridView'e yükle
            string sorgu = "SELECT OGRENCİ.Ad AS OgrenciAdi, OGRENCİ.Soyad AS OgrenciSoyadi, DersProgrami.Gun, DersProgrami.Saat, DersProgrami.DersAdi " +
                           "FROM Ogrenci " +
                           "INNER JOIN DersProgrami ON OGRENCİ.Id = DersProgrami.OgrenciId";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sorgu, baglanti);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void VeritabaniOlustur()
        {
            try
            {
                // Öğrenci tablosu
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                string ogrenciTablosuOlustur = "CREATE TABLE OGRENCI (Id COUNTER, Ad TEXT, Soyad TEXT, TcNo TEXT, TelNo TEXT, Email TEXT, PRIMARY KEY (Id))";
                OleDbCommand sorgu1 = new OleDbCommand(ogrenciTablosuOlustur, baglanti);
                sorgu1.ExecuteNonQuery();

                // Ders Programı tablosu
                string dersProgramiTablosuOlustur = "CREATE TABLE DersProgrami (Id COUNTER PRIMARY KEY, OgrenciId INT, Gun TEXT, Saat TEXT, DersAdi TEXT FOREIGN KEY (OgrenciId) REFERENCES OGRENCI(Id))";
                OleDbCommand sorgu2 = new OleDbCommand(dersProgramiTablosuOlustur, baglanti);
                sorgu2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        //OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
        //baglanti.Open();
        //OleDbCommand sorgu = new OleDbCommand("insert into OGRENCİ values(@id,@ad,@soyad,@tc,@telno,@email)", baglanti);
        //sorgu.Parameters.AddWithValue("@id", textId.Text);
        //sorgu.Parameters.AddWithValue("@ad", textAd.Text);
        //sorgu.Parameters.AddWithValue("@soyad", textSoyad.Text);
        //sorgu.Parameters.AddWithValue("@tc", textTc.Text);
        //sorgu.Parameters.AddWithValue("@telno", textTel.Text);
        //sorgu.Parameters.AddWithValue("@email", textMail.Text);

        //sorgu.ExecuteNonQuery();

        //// Eklenen öğrencinin ID'sini al
        //string ogrenciIdSorgu = "SELECT @@Identity";
        //OleDbCommand komut4 = new OleDbCommand(ogrenciIdSorgu, baglanti);
        //int ogrenciId = (int)komut4.ExecuteScalar();

        //// Ders programı ekleme
        //string dersProgramiEkle = "INSERT INTO DersProgrami (OgrenciId, Gun, Saat, DersAdi) VALUES (@OgrenciId, @Gun, @Saat, @DersAdi)";
        //OleDbCommand komut5 = new OleDbCommand(dersProgramiEkle, baglanti);
        //komut5.Parameters.AddWithValue("@OgrenciId", ogrenciId);
        //komut5.Parameters.AddWithValue("@Gun", cmbGun.SelectedItem.ToString());
        //komut5.Parameters.AddWithValue("@Saat", txtSaat.Text);
        //komut5.Parameters.AddWithValue("@DersAdi", txtDersAdi.Text);
        //komut5.ExecuteNonQuery();

        //baglanti.Close();
        //MessageBox.Show("Öğrenci ve ders programı başarıyla eklendi.");
    }
}
