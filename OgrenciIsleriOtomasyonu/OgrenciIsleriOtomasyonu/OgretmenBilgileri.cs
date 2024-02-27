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
    public partial class OgretmenBilgileri : Form
    {
        public OgretmenBilgileri()
        {
            InitializeComponent();
        }

        private void OgretmenBilgileri_Load(object sender, EventArgs e)
        {
            using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
            {
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select * from OGRETMEN", baglanti);
                OleDbDataAdapter da = new OleDbDataAdapter(sorgu);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
    }
}
