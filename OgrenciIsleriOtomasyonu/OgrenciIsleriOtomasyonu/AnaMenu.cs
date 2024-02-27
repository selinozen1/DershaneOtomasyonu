using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciIsleriOtomasyonu
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }
        
        private void öğrenciEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void öğretmenEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void etütAlmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EtutAlma form = new EtutAlma();
            form.Show();
        }

        private void boşDoluEtütToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boş_DoluEtüt etut = new Boş_DoluEtüt();
            etut.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void öğrenciEklemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Öğrenci ogr = new Öğrenci();
            ogr.Show();
        }

        private void öğretmenEklemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Öğretmen ogrt = new Öğretmen();
            ogrt.Show();
        }

        private void öğrenciBilgileriniGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciBilgileri bilgi = new OgrenciBilgileri();
            bilgi.Show();
        }

        private void veliBilgileriniGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veli veli = new Veli();
            veli.Show();
        }

        private void öğretmenBilgileriniGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenBilgileri bilgi = new OgretmenBilgileri();
            bilgi.Show();
        }


        private void çıkışToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void veliEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeliGirisi veli = new VeliGirisi();
            veli.Show();
        }
    }
}
