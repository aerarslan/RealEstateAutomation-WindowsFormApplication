using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace estate
{
    public partial class Kayit : Form
    {
        List<Arsa> arsalar = new List<Arsa>();
        List<Daire> daireler = new List<Daire>();
        List<Konut> konutlar = new List<Konut>();
        List<Apartman> apartmanlar = new List<Apartman>();
        public static int kayitsayisi = 0;
        public Kayit()
        {
            InitializeComponent();
            tur.SelectedIndex = 0;
            emlak.SelectedIndex = 3;
            tuvalet.SelectedIndex = 0;

            turlist.SelectedIndex = 0;
            emlaklist.SelectedIndex = 3;
            tuvaletlist.SelectedIndex = 0;           
        }      
        public int metre = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (emlak.SelectedIndex == 0)
            {
                salon.Value = 1;
                salontxt.Text = "Living Room*";
                odasayisi.Value = 1;
                odasayisitxt.Text = "Rooms*";
                balkonsayisi.Value = 1;
                balkonsayisitxt.Text = "Balcony*";
                katsayisi.Value = 0;
                katsayisitxt.Text = "Floor";
                dairesayisi.Value = 0;
                dairesayisitxt.Text = "Apartments";
                tuvalet.SelectedIndex = 0;
                tuvalettxt.Text = "Bathroom*";
                salon.Enabled = true;
                odasayisi.Enabled = true;
                balkonsayisi.Enabled = true;
                tuvalet.Enabled = true;
                katsayisi.Enabled = false;
                dairesayisi.Enabled = false;
            }
            else if (emlak.SelectedIndex == 1)
            {
                salontxt.Text = "Living Room*";
                odasayisitxt.Text = "Rooms*";
                balkonsayisitxt.Text = "Balcony*";
                katsayisitxt.Text = "Floor*";
                dairesayisitxt.Text = "Apartments";
                tuvalettxt.Text = "Bathroom";
                salon.Value = 1;
                odasayisi.Value = 1;
                balkonsayisi.Value = 1;
                katsayisi.Value = 1;
                dairesayisi.Value = 0;
                tuvalet.SelectedIndex = 1;
                salon.Enabled = true;
                odasayisi.Enabled = true;
                balkonsayisi.Enabled = true;
                tuvalet.Enabled = false;
                katsayisi.Enabled = true;
                dairesayisi.Enabled = false;
            }
            else if (emlak.SelectedIndex == 2)
            {
                salontxt.Text = "Living Room*";
                odasayisitxt.Text = "Rooms*";
                balkonsayisitxt.Text = "Balcony*";
                katsayisitxt.Text = "Floor";
                dairesayisitxt.Text = "Apartments*";
                tuvalettxt.Text = "Bathroom";
                salon.Value = 1;
                odasayisi.Value = 1;
                balkonsayisi.Value = 1;
                dairesayisi.Value = 1;
                katsayisi.Value = 0;
                tuvalet.SelectedIndex = 1;
                salon.Enabled = true;
                odasayisi.Enabled = true;
                balkonsayisi.Enabled = true;
                tuvalet.Enabled = false;
                katsayisi.Enabled = false;
                dairesayisi.Enabled = true;
            }
            else if (emlak.SelectedIndex == 3)
            {
                salontxt.Text = "Living Room";
                odasayisitxt.Text = "Rooms";
                balkonsayisitxt.Text = "Balcony";
                katsayisitxt.Text = "Floor";
                dairesayisitxt.Text = "Apartments";
                tuvalettxt.Text = "Bathroom";
                salon.Value = 0;
                odasayisi.Value = 0;
                balkonsayisi.Value = 0;
                dairesayisi.Value = 0;
                katsayisi.Value = 0;
                tuvalet.SelectedIndex = 0;
                salon.Enabled = false;
                odasayisi.Enabled = false;
                balkonsayisi.Enabled = false;
                tuvalet.Enabled = false;
                katsayisi.Enabled = false;
                dairesayisi.Enabled = false;
            }
        }    
        private void tur_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (tur.SelectedIndex == 0)
            {
                emlak.Enabled = true;
                emlak.Items.Clear();               
                emlak.Items.Add("Apartment");
                emlak.Items.Add("House");
                emlak.Items.Add("Building");
                emlak.Items.Add("Land");
                emlak.SelectedIndex = 0;
            }
            else if (tur.SelectedIndex == 1)
            {
                
                emlak.Enabled = true;
                emlak.Items.Clear();             
                emlak.Items.Add("Apartment");
                emlak.Items.Add("House");
                emlak.Items.Add("Building");
                emlak.SelectedIndex = 0;
            }
        }
        private void metrekare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metre = Convert.ToInt32(metrekare.Text);
            }
            catch
            {
                MessageBox.Show("Lütfen Bir Sayı Değeri Giriniz.");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        static public int arsasayisikayit = 0;
        static public int dairesayisikayit = 0;
        static public int konutsayisikayit = 0;
        static public int apartmansayisikayit = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (fiyat.Text == "0")
            {
                fiyat.Text = "";
            }  

            if (emlak.SelectedIndex == 0)
            {
                try
                {
                    Daire daire = new Daire();
                    daire.SatilikKiralik = tur.Text;
                    daire.Emlakk = emlak.Text;
                    daire.MetreKare = Convert.ToInt32(metrekare.Text);
                    daire.MusteriAdi = adsoyad.Text;
                    daire.TelNo = telno.Text;
                    daire.Fiyat = Convert.ToInt32(fiyat.Text);
                    daire.Salon = Convert.ToInt32(salon.Value);
                    daire.OdaSayisi = Convert.ToInt32(odasayisi.Value);
                    daire.BalkonSayisi = Convert.ToInt32(balkonsayisi.Value);
                    daire.Tuvalet = Convert.ToString(tuvalet.Text);
                    daireler.Add(daire);

                    kayitsayisi++;
                    dairesayisikayit++;                  
                    MessageBox.Show("Kayit Basari ile Eklenmistir");            
                }
                catch(Exception hata)
                {
                    MessageBox.Show("Hatali Giriş. Lütfen Girdiğiniz Değerleri Kontrol Ediniz" + hata);
                }
            }             
            else if (emlak.SelectedIndex == 1)
            {
                try
                {
                    Konut konut = new Konut();
                    konut.SatilikKiralik = tur.Text;
                    konut.Emlakk = emlak.Text;
                    konut.MetreKare = Convert.ToInt32(metrekare.Text);
                    konut.MusteriAdi = adsoyad.Text;
                    konut.TelNo = telno.Text;
                    konut.Fiyat = Convert.ToInt32(fiyat.Text);
                    konut.Salon = Convert.ToInt32(salon.Value);
                    konut.OdaSayisi = Convert.ToInt32(odasayisi.Value);
                    konut.BalkonSayisi = Convert.ToInt32(balkonsayisi.Value);
                    konut.KatSayisi = Convert.ToInt32(katsayisi.Value);
                    konutlar.Add(konut);

                    kayitsayisi++;
                    konutsayisikayit++;
                    MessageBox.Show("Kayit Basari ile Eklenmistir");
                }
                catch
                {
                    MessageBox.Show("Hatali Giriş. Lütfen Girdiğiniz Değerleri Kontrol Ediniz");
                }
            }
            else if (emlak.SelectedIndex == 2)
            {
                try
                {
                    Apartman apartman = new Apartman();
                    apartman.SatilikKiralik = tur.Text;
                    apartman.Emlakk = emlak.Text;
                    apartman.MetreKare = Convert.ToInt32(metrekare.Text);
                    apartman.MusteriAdi = adsoyad.Text;
                    apartman.TelNo = telno.Text;
                    apartman.Fiyat = Convert.ToInt32(fiyat.Text);
                    apartman.Salon = Convert.ToInt32(salon.Value);
                    apartman.OdaSayisi = Convert.ToInt32(odasayisi.Value);
                    apartman.BalkonSayisi = Convert.ToInt32(balkonsayisi.Value);
                    apartman.DaireSayisi = Convert.ToInt32(dairesayisi.Value);
                    apartmanlar.Add(apartman);

                    kayitsayisi++;
                    apartmansayisikayit++;
                    MessageBox.Show("Kayit Basari ile Eklenmistir");
                }
                catch
                {
                    MessageBox.Show("Hatali Giriş. Lütfen Girdiğiniz Değerleri Kontrol Ediniz");
                }
            }
            else if (emlak.SelectedIndex == 3)
            {
                try
                {
                    Arsa arsa = new Arsa();
                    arsa.SatilikKiralik = tur.Text;
                    arsa.Emlakk = emlak.Text;
                    arsa.MetreKare = Convert.ToInt32(metrekare.Text);
                    arsa.MusteriAdi = adsoyad.Text;
                    arsa.TelNo = telno.Text;
                    arsa.Fiyat = Convert.ToInt32(fiyat.Text);
                    arsalar.Add(arsa);

                    kayitsayisi++;
                    arsasayisikayit++;
                    MessageBox.Show("Kayit Basari ile Eklenmistir");
                }
                catch
                {
                    MessageBox.Show("Hatali Giriş. Lütfen Girdiğiniz Değerleri Kontrol Ediniz");
                }
            }                    
        }
        private void fiyat_TextChanged(object sender, EventArgs e)
        {          
                try
                {
                    int fiyatt = Convert.ToInt32(fiyat.Text);
                }
                catch
                {
                    MessageBox.Show("Lütfen Bir Sayı Değeri Giriniz.");
                }
            }
        private void turlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turlist.SelectedIndex == 0)
            {
                emlaklist.Enabled = true;
                emlaklist.Items.Clear();
                emlaklist.Items.Add("Apartment");
                emlaklist.Items.Add("House");
                emlaklist.Items.Add("Building");
                emlaklist.Items.Add("Land");
                emlaklist.SelectedIndex = 0;
            }
            else if (turlist.SelectedIndex == 1)
            {             
                emlaklist.Enabled = true;
                emlaklist.Items.Clear();
                emlaklist.Items.Add("Apartment");
                emlaklist.Items.Add("House");
                emlaklist.Items.Add("Building");
                emlaklist.SelectedIndex = 0;
            }
        }

        private void emlaklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (emlaklist.SelectedIndex == 0)
            {
                salonlist.Value = 1;
                salontxtlist.Text = "Living Room*";
                odasayisilist.Value = 1;
                odasayisitxtlist.Text = "Rooms*";
                balkonsayisilist.Value = 1;
                balkonsayisitxtlist.Text = "Balcony*";
                katsayisilist.Value = 0;
                katsayisitxtlist.Text = "Floor";
                dairesayisilist.Value = 0;
                dairesayisitxtlist.Text = "Apartments";
                tuvaletlist.SelectedIndex = 0;
                tuvalettxtlist.Text = "Bathroom";
                salonlist.Enabled = true;
                odasayisilist.Enabled = true;
                balkonsayisilist.Enabled = true;
                tuvaletlist.Enabled = false;
                katsayisilist.Enabled = false;
                dairesayisilist.Enabled = false;
            }
            else if (emlaklist.SelectedIndex == 1)
            {
                salontxtlist.Text = "Living Room*";
                odasayisitxtlist.Text = "Rooms*";
                balkonsayisitxtlist.Text = "Balcony*";
                katsayisitxtlist.Text = "Floor*";
                dairesayisitxtlist.Text = "Apartments";
                tuvalettxtlist.Text = "Bathroom";
                salonlist.Value = 1;
                odasayisilist.Value = 1;
                balkonsayisilist.Value = 1;
                katsayisilist.Value = 1;
                dairesayisilist.Value = 0;
                tuvaletlist.SelectedIndex = 0;
                salonlist.Enabled = true;
                odasayisilist.Enabled = true;
                balkonsayisilist.Enabled = true;
                tuvaletlist.Enabled = false;
                katsayisilist.Enabled = true;
                dairesayisilist.Enabled = false;
            }
            else if (emlaklist.SelectedIndex == 2)
            {
                salontxtlist.Text = "Living Room*";
                odasayisitxtlist.Text = "Rooms*";
                balkonsayisitxtlist.Text = "Balcony*";
                katsayisitxtlist.Text = "Floor";
                dairesayisitxtlist.Text = "Apartments*";
                tuvalettxtlist.Text = "Bathroom";
                salonlist.Value = 1;
                odasayisilist.Value = 1;
                balkonsayisilist.Value = 1;
                dairesayisilist.Value = 1;
                katsayisilist.Value = 0;
                tuvaletlist.SelectedIndex = 0;
                salonlist.Enabled = true;
                odasayisilist.Enabled = true;
                balkonsayisilist.Enabled = true;
                tuvaletlist.Enabled = false;
                katsayisilist.Enabled = false;
                dairesayisilist.Enabled = true;
            }
            else if (emlaklist.SelectedIndex == 3)
            {
                salontxtlist.Text = "Living Room";
                odasayisitxtlist.Text = "Rooms";
                balkonsayisitxtlist.Text = "Balcony";
                katsayisitxtlist.Text = "Floor";
                dairesayisitxtlist.Text = "Apartments";
                tuvalettxtlist.Text = "Bathroom";
                salonlist.Value = 0;
                odasayisilist.Value = 0;
                balkonsayisilist.Value = 0;
                dairesayisilist.Value = 0;
                katsayisilist.Value = 0;
                tuvaletlist.SelectedIndex = 0;
                salonlist.Enabled = false;
                odasayisilist.Enabled = false;
                balkonsayisilist.Enabled = false;
                tuvaletlist.Enabled = false;
                katsayisilist.Enabled = false;
                dairesayisilist.Enabled = false;
            }
        }

        private void salon_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(salon.Value) == 0)
                salon.Value = 1;
        }

        private void odasayisi_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(odasayisi.Value) == 0)
                odasayisi.Value = 1;
        }

        private void balkonsayisi_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(odasayisi.Value) == 0)
                balkonsayisi.Value = 1;
        }

        private void katsayisi_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(katsayisi.Value) == 0)
                katsayisi.Value = 1;
        }

        private void dairesayisi_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dairesayisi.Value) == 0)
               dairesayisi.Value = 1;
        }

        private void salonlist_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(salonlist.Value) == 0)
                salonlist.Value = 1;
        }

        private void odasayisilist_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(odasayisilist.Value) == 0)
                odasayisilist.Value = 1;
        }

        private void katsayisilist_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(katsayisilist.Value) == 0)
                katsayisilist.Value = 1;
        }

        private void dairesayisilist_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dairesayisilist.Value) == 0)
                dairesayisilist.Value = 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int satirsayisi = 0;
            dataGridView1.Rows.Add(20);
           
                if (emlaklist.SelectedIndex == 3)//arsaysa
                {
                    for (int i = 0; i <= (arsasayisikayit-1); i++)
                    {
                        if (Convert.ToInt32(metrekarelist.Text) >= arsalar[i].MetreKare && Convert.ToInt32(fiyatlist.Text) >= arsalar[i].Fiyat)
                        {
                            dataGridView1.Rows[satirsayisi].Cells[0].Value = arsalar[i].SatilikKiralik;
                            dataGridView1.Rows[satirsayisi].Cells[1].Value = arsalar[i].Emlakk;
                            dataGridView1.Rows[satirsayisi].Cells[2].Value = arsalar[i].MetreKare;
                            dataGridView1.Rows[satirsayisi].Cells[3].Value = "-";//salon
                            dataGridView1.Rows[satirsayisi].Cells[4].Value = "-";//oda
                            dataGridView1.Rows[satirsayisi].Cells[5].Value = "-";//balkon
                            dataGridView1.Rows[satirsayisi].Cells[6].Value = "-";//tuvalet
                            dataGridView1.Rows[satirsayisi].Cells[7].Value = "-";//kat
                            dataGridView1.Rows[satirsayisi].Cells[8].Value = "-";//daire
                            dataGridView1.Rows[satirsayisi].Cells[9].Value = arsalar[i].Fiyat;//fiyat
                            dataGridView1.Rows[satirsayisi].Cells[10].Value = arsalar[i].MusteriAdi;//adi
                            dataGridView1.Rows[satirsayisi].Cells[11].Value = arsalar[i].TelNo;//telno

                            satirsayisi++;
                        }
                    }
                }
                else if (emlaklist.SelectedIndex == 0)//daireyse
                {
                    for (int i = 0; i <= (dairesayisikayit - 1); i++)
                    {
                        if (turlist.Text==daireler[i].SatilikKiralik && Convert.ToInt32(metrekarelist.Text) >= daireler[i].MetreKare && Convert.ToInt32(salonlist.Value) >= daireler[i].Salon && Convert.ToInt32(odasayisilist.Value) <= daireler[i].OdaSayisi && Convert.ToInt32(balkonsayisilist.Value) <= daireler[i].BalkonSayisi && Convert.ToInt32(fiyatlist.Text) <= daireler[i].Fiyat)
                        {
                            dataGridView1.Rows[satirsayisi].Cells[0].Value = daireler[i].SatilikKiralik;
                            dataGridView1.Rows[satirsayisi].Cells[1].Value = daireler[i].Emlakk;
                            dataGridView1.Rows[satirsayisi].Cells[2].Value = daireler[i].MetreKare;
                            dataGridView1.Rows[satirsayisi].Cells[3].Value = daireler[i].Salon;//salon
                            dataGridView1.Rows[satirsayisi].Cells[4].Value = daireler[i].OdaSayisi;//oda
                            dataGridView1.Rows[satirsayisi].Cells[5].Value = daireler[i].BalkonSayisi;//balkon
                            dataGridView1.Rows[satirsayisi].Cells[6].Value = daireler[i].Tuvalet;//tuvalet
                            dataGridView1.Rows[satirsayisi].Cells[7].Value = "-";//kat
                            dataGridView1.Rows[satirsayisi].Cells[8].Value = "-";//daire
                            dataGridView1.Rows[satirsayisi].Cells[9].Value = daireler[i].Fiyat;//fiyat
                            dataGridView1.Rows[satirsayisi].Cells[10].Value = daireler[i].MusteriAdi;//adi
                            dataGridView1.Rows[satirsayisi].Cells[11].Value = daireler[i].TelNo;//telno

                            satirsayisi++;
                        }
                    }
                }
                else if (emlaklist.SelectedIndex == 1)//konutsa
                {
                    for (int i = 0; i <= (konutsayisikayit - 1); i++)
                    {
                        if (turlist.Text == konutlar[i].SatilikKiralik && Convert.ToInt32(metrekarelist.Text) >= konutlar[i].MetreKare && Convert.ToInt32(salonlist.Value) <= konutlar[i].Salon && Convert.ToInt32(odasayisilist.Value) >= konutlar[i].OdaSayisi && Convert.ToInt32(balkonsayisilist.Value) <= konutlar[i].BalkonSayisi && Convert.ToInt32(fiyatlist.Text) <= konutlar[i].Fiyat && Convert.ToInt32(katsayisilist.Value) <= konutlar[i].KatSayisi )
                        {
                            dataGridView1.Rows[satirsayisi].Cells[0].Value = konutlar[i].SatilikKiralik;
                            dataGridView1.Rows[satirsayisi].Cells[1].Value = konutlar[i].Emlakk;
                            dataGridView1.Rows[satirsayisi].Cells[2].Value = konutlar[i].MetreKare;
                            dataGridView1.Rows[satirsayisi].Cells[3].Value = konutlar[i].Salon;//salon
                            dataGridView1.Rows[satirsayisi].Cells[4].Value = konutlar[i].OdaSayisi;//oda
                            dataGridView1.Rows[satirsayisi].Cells[5].Value = konutlar[i].BalkonSayisi;//balkon
                            dataGridView1.Rows[satirsayisi].Cells[6].Value = "-";//tuvalet
                            dataGridView1.Rows[satirsayisi].Cells[7].Value = konutlar[i].KatSayisi;//kat
                            dataGridView1.Rows[satirsayisi].Cells[8].Value = "-";//daire
                            dataGridView1.Rows[satirsayisi].Cells[9].Value = konutlar[i].Fiyat;//fiyat
                            dataGridView1.Rows[satirsayisi].Cells[10].Value = konutlar[i].MusteriAdi;//adi
                            dataGridView1.Rows[satirsayisi].Cells[11].Value = konutlar[i].TelNo;//telno

                            satirsayisi++;
                        }                     
                    }
                }
                else if (emlaklist.SelectedIndex == 2)//apartmansa
                {
                    for (int i = 0; i <= (apartmansayisikayit - 1); i++)
                    {
                        if (turlist.Text == apartmanlar[i].SatilikKiralik && Convert.ToInt32(metrekarelist.Text) >= apartmanlar[i].MetreKare && Convert.ToInt32(salonlist.Value) >= apartmanlar[i].Salon && Convert.ToInt32(odasayisilist.Value) >= apartmanlar[i].OdaSayisi && Convert.ToInt32(balkonsayisilist.Value) >= apartmanlar[i].BalkonSayisi && Convert.ToInt32(fiyatlist.Text) >= apartmanlar[i].Fiyat && Convert.ToInt32(dairesayisilist.Value) >= apartmanlar[i].DaireSayisi)
                        {
                            dataGridView1.Rows[satirsayisi].Cells[0].Value = apartmanlar[i].SatilikKiralik;
                            dataGridView1.Rows[satirsayisi].Cells[1].Value = apartmanlar[i].Emlakk;
                            dataGridView1.Rows[satirsayisi].Cells[2].Value = apartmanlar[i].MetreKare;
                            dataGridView1.Rows[satirsayisi].Cells[3].Value = apartmanlar[i].Salon;//salon
                            dataGridView1.Rows[satirsayisi].Cells[4].Value = apartmanlar[i].OdaSayisi;//oda
                            dataGridView1.Rows[satirsayisi].Cells[5].Value = apartmanlar[i].BalkonSayisi;//balkon
                            dataGridView1.Rows[satirsayisi].Cells[6].Value = "-";//tuvalet
                            dataGridView1.Rows[satirsayisi].Cells[7].Value = "-";//kat
                            dataGridView1.Rows[satirsayisi].Cells[8].Value = apartmanlar;//daire
                            dataGridView1.Rows[satirsayisi].Cells[9].Value = apartmanlar[i].Fiyat;//fiyat
                            dataGridView1.Rows[satirsayisi].Cells[10].Value = apartmanlar[i].MusteriAdi;//adi
                            dataGridView1.Rows[satirsayisi].Cells[11].Value = apartmanlar[i].TelNo;//telno
                            satirsayisi++;
                        }
                    }
                }         
        }
        private void pb_addData_MouseHover(object sender, EventArgs e)
        {
            pb_addData.BackColor = Color.Gray;
        }
        private void pb_addData_MouseLeave(object sender, EventArgs e)
        {
            pb_addData.BackColor = Color.Gainsboro;
        }

        private void pb_menu_MouseHover(object sender, EventArgs e)
        {
            pb_menu.BackColor = Color.Gray;
        }
        private void pb_menu_MouseLeave(object sender, EventArgs e)
        {
            pb_menu.BackColor = Color.Gainsboro;
        }
        private void pb_listData_MouseHover(object sender, EventArgs e)
        {
            pb_listData.BackColor = Color.Gray;
        }

        private void pb_listData_MouseLeave(object sender, EventArgs e)
        {
            pb_listData.BackColor = Color.Gainsboro;
        }   
    }
}
