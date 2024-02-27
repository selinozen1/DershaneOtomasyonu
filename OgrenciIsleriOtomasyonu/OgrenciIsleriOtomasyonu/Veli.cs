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
    public partial class Veli : Form
    {
        public Veli()
        {
            InitializeComponent();
        }

        private void Veli_Load(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
                {
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("SELECT OGRENCİ.id, OGRENCİ.ad AS ÖğrenciAd, OGRENCİ.soyad AS ÖğrenciSoyad, OGRENCİ.tc AS ÖğrenciTC, OGRENCİ.telno AS ÖğrenciTelno, VELİ.ad AS VeliAd, VELİ.soyad AS VeliSoyad, VELİ.adres AS VeliAdres, VELİ.telno AS VeliTelno FROM OGRENCİ INNER JOIN VELİ ON OGRENCİ.id = VELİ.id", baglanti);
                    OleDbDataAdapter da = new OleDbDataAdapter(sorgu);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
