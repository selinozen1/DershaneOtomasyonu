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
    public partial class Sifre : Form
    {
        public Sifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider = microsoft.jet.oledb.4.0; data source =C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE PROJE SET sifre = '" + textSifre.Text + "' WHERE ad = '" + textKulAd.Text + "'";
                komut.ExecuteNonQuery(); // sql sorgularını yürütmek için kullanılır

                if (textSifre.Text == textTekrarSifre.Text)
                {
                    MessageBox.Show("Şifreniz güncellendi.");
                    this.Hide();
                }

                else
                {
                    baglanti.Close();
                    MessageBox.Show("Girmis oldugunuz sifreler farklı tekrar giriniz.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textKulAd.Text = "";
                textSifre.Clear();
                textTekrarSifre.Text = "";
            }
            }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }

