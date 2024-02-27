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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
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


       

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
