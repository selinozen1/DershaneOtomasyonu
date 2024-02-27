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
    public partial class Boş_DoluEtüt : Form
    {
        public Boş_DoluEtüt()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            

        }

        private void Boş_DoluEtüt_Load(object sender, EventArgs e)
        {
            using (OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb"))
            {
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select * from KAYIT", baglanti);
                OleDbDataAdapter da = new OleDbDataAdapter(sorgu);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

       
    }
}
