using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciIsleriOtomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textKulAd.Text == "") || (textSifre.Text == ""))
            {
                MessageBox.Show("Boş bırakmayınız!!!");
            }
            else
            {
                try
                {
                    OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("select ad,sifre from PROJE where ad=@ad and sifre=@sifre", baglanti);
                    sorgu.Parameters.AddWithValue("@ad", textKulAd.Text);
                    sorgu.Parameters.AddWithValue("@sifre", textSifre.Text);
                    OleDbDataReader dr;
                    dr = sorgu.ExecuteReader();


                    if (dr.Read())
                    {
                        AnaMenu form = new AnaMenu();
                        form.Show();
                        this.Visible = false;
                        linkLabel1.LinkVisited = true;
                        MessageBox.Show("Giriş başarılı.");

                    }
                    else
                    {
                        baglanti.Close();
                        MessageBox.Show("Yanlış kullanıcı adı veya parola. Tekrar deneyin");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    textKulAd.Text = "";
                    textSifre.Clear();
                }
            }
           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sifre sifre = new Sifre();
            sifre.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=C:\\Users\\Selin\\source\\repos\\OgrenciIsleriOtomasyonu\\OgrenciIsleriOtomasyonu\\PROJE.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select ad,sifre from SECİM where ad=@ad and sifre=@sifre", baglanti);
                sorgu.Parameters.AddWithValue("@ad", textKulAd.Text);
                sorgu.Parameters.AddWithValue("@sifre", textSifre.Text);
                OleDbDataReader dr;
                dr = sorgu.ExecuteReader();


                if (dr.Read())
                {
                    Menu form = new Menu();
                    form.Show();
                    this.Visible = false;
                    MessageBox.Show("Giriş başarılı.");

                }
                else
                {
                    baglanti.Close();
                    MessageBox.Show("Yanlış kullanıcı adı veya parola. Tekrar deneyin");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textKulAd.Text = "";
                textSifre.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.AcceptButton = buttonYönetici;
            this.AcceptButton = buttonÖğretmen;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.CheckState == CheckState.Checked)
            {
                textSifre.UseSystemPasswordChar = true;
                checkBox2.Text = "Gizle";
            }
            else if(checkBox2.CheckState == CheckState.Unchecked)
            {
                textSifre.UseSystemPasswordChar = false;
                checkBox2.Text = "Göster";

            }
        }
        }
    }
    

