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
    public partial class AddList : Form
    {


        /***********************************************************************************************************
         *                                                                                                         *
         *                                                                                                         *
         *                                       DATABASE CONNECTION                                               *
         *                                                                                                         *
         *                                              MSSQL                                                      *
         *                                                                                                         *
         ***********************************************************************************************************/


        SqlConnection connection = new SqlConnection("    ADD DATABASE HERE   ");

           


        public static int kayitsayisi = 0;
        public AddList()
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
                if (metrekare.Text != "")
                {
                    metre = Convert.ToInt32(metrekare.Text);
                }     
            }
            catch
            {
                metrekare.Text = "111";
                MessageBox.Show("Please check your value!");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu form1 = new Menu();
            form1.Show();
        }       
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
                    kayitsayisi++;

                    SqlCommand command = new SqlCommand("INSERT INTO estate(Type,HomeType,SquareMeters,LivingRoom,Rooms,Balcony,Bathroom,Price,Name,TelNo,ID) VALUES (@Type,@HomeType,@SquareMeters,@LivingRoom,@Rooms,@Balcony,@Bathroom,@Price,@Name,@TelNo,@id)", connection);

                    command.Parameters.AddWithValue("@Type", tur.Text);
                    command.Parameters.AddWithValue("@HomeType", emlak.Text);
                    command.Parameters.AddWithValue("@SquareMeters", Convert.ToInt32(metrekare.Text));
                    command.Parameters.AddWithValue("@LivingRoom", Convert.ToInt32(salon.Value));
                    command.Parameters.AddWithValue("@Rooms", Convert.ToInt32(odasayisi.Value));
                    command.Parameters.AddWithValue("@Balcony", Convert.ToInt32(balkonsayisi.Value));
                    command.Parameters.AddWithValue("@Bathroom", Convert.ToString(tuvalet.Text));
                    command.Parameters.AddWithValue("@Price", Convert.ToInt32(fiyat.Text));
                    command.Parameters.AddWithValue("@Name", adsoyad.Text);
                    command.Parameters.AddWithValue("@TelNo", telno.Text);
                    command.Parameters.AddWithValue("@id", kayitsayisi);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Added Successfully");       
                }
                catch
                {
                    MessageBox.Show("Something went wrong!! Please check your values.");
                }
            }
              
            else if (emlak.SelectedIndex == 1)
            {
                try
                {                 
                    kayitsayisi++;

                    SqlCommand command = new SqlCommand("INSERT INTO estate(Type,HomeType,SquareMeters,LivingRoom,Rooms,Balcony,Floor,Price,Name,TelNo,ID) VALUES (@Type,@HomeType,@SquareMeters,@LivingRoom,@Rooms,@Balcony,@Floor,@Price,@Name,@TelNo,@id)", connection);

                    command.Parameters.AddWithValue("@Type", tur.Text);
                    command.Parameters.AddWithValue("@HomeType", emlak.Text);
                    command.Parameters.AddWithValue("@SquareMeters", Convert.ToInt32(metrekare.Text));
                    command.Parameters.AddWithValue("@LivingRoom", Convert.ToInt32(salon.Value));
                    command.Parameters.AddWithValue("@Rooms", Convert.ToInt32(odasayisi.Value));
                    command.Parameters.AddWithValue("@Balcony", Convert.ToInt32(balkonsayisi.Value));
                    command.Parameters.AddWithValue("@Floor", Convert.ToInt32(katsayisi.Value));
                    command.Parameters.AddWithValue("@Price", Convert.ToInt32(fiyat.Text));
                    command.Parameters.AddWithValue("@Name", adsoyad.Text);
                    command.Parameters.AddWithValue("@TelNo", telno.Text);
                    command.Parameters.AddWithValue("@id", kayitsayisi);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Added Successfully");
                }
                catch
                {
                    MessageBox.Show("Something went wrong!! Please check your values.");
                }
            }

            else if (emlak.SelectedIndex == 2)
            {
                try
                {                 
                    kayitsayisi++;

                    SqlCommand command = new SqlCommand("INSERT INTO estate(Type,HomeType,SquareMeters,LivingRoom,Rooms,Balcony,Apartments,Price,Name,TelNo,ID) VALUES (@Type,@HomeType,@SquareMeters,@LivingRoom,@Rooms,@Balcony,@Apartments,@Price,@Name,@TelNo,@id)", connection);

                    command.Parameters.AddWithValue("@Type", tur.Text);
                    command.Parameters.AddWithValue("@HomeType", emlak.Text);
                    command.Parameters.AddWithValue("@SquareMeters", Convert.ToInt32(metrekare.Text));
                    command.Parameters.AddWithValue("@LivingRoom", Convert.ToInt32(salon.Value));
                    command.Parameters.AddWithValue("@Rooms", Convert.ToInt32(odasayisi.Value));
                    command.Parameters.AddWithValue("@Balcony", Convert.ToInt32(balkonsayisi.Value));
                    command.Parameters.AddWithValue("@Apartments", Convert.ToInt32(dairesayisi.Value));
                    command.Parameters.AddWithValue("@Price", Convert.ToInt32(fiyat.Text));
                    command.Parameters.AddWithValue("@Name", adsoyad.Text);
                    command.Parameters.AddWithValue("@TelNo", telno.Text);
                    command.Parameters.AddWithValue("@id", kayitsayisi);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Added Successfully");
                }
                catch
                {
                    MessageBox.Show("Something went wrong!! Please check your values.");
                }
            }

            else if (emlak.SelectedIndex == 3)
            {
                try
                {                 
                    kayitsayisi++;

                    SqlCommand command = new SqlCommand("INSERT INTO estate(Type,HomeType,SquareMeters,Price,Name,TelNo,ID) VALUES (@Type,@HomeType,@SquareMeters,@Price,@Name,@TelNo,@id)", connection);

                    command.Parameters.AddWithValue("@Type", tur.Text);
                    command.Parameters.AddWithValue("@HomeType", emlak.Text);
                    command.Parameters.AddWithValue("@SquareMeters", Convert.ToInt32(metrekare.Text));
                    command.Parameters.AddWithValue("@Price", Convert.ToInt32(fiyat.Text));
                    command.Parameters.AddWithValue("@Name", adsoyad.Text);
                    command.Parameters.AddWithValue("@TelNo", telno.Text);
                    command.Parameters.AddWithValue("@id", kayitsayisi);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Added Successfully");
                }
                catch
                {
                    MessageBox.Show("Something went wrong!! Please check your values.");
                }
            }                 
        }
        private void fiyat_TextChanged(object sender, EventArgs e)
        {          
                try
                {
                    if (fiyat.Text != "")
                    {
                        int fiyatt = Convert.ToInt32(fiyat.Text);
                    }                  
                }
                catch
                {
                    MessageBox.Show("Please check your value!");
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
            if (emlaklist.SelectedIndex == 3)// LAND
            {
                SqlCommand command = new SqlCommand("SELECT * FROM estate WHERE Type = @type AND HomeType = @hometype AND SquareMeters <= @squareMeters AND Price <= @price", connection);
                command.Parameters.AddWithValue("@squareMeters", Convert.ToInt32(metrekarelist.Text));
                command.Parameters.AddWithValue("@price", Convert.ToInt32(fiyatlist.Text));
                command.Parameters.AddWithValue("@type", turlist.Text);
                command.Parameters.AddWithValue("@hometype", emlaklist.Text);
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
            else if (emlaklist.SelectedIndex == 0)// APARTMENT
            {             
                SqlCommand command = new SqlCommand("SELECT * FROM estate WHERE Type = @type AND HomeType = @hometype AND SquareMeters <= @squareMeters AND Price <= @price AND LivingRoom <= @livingroom AND Rooms <= @rooms AND Balcony <= @balcony", connection);
                command.Parameters.AddWithValue("@squareMeters", Convert.ToInt32(metrekarelist.Text));
                command.Parameters.AddWithValue("@price", Convert.ToInt32(fiyatlist.Text));
                command.Parameters.AddWithValue("@type", turlist.Text);
                command.Parameters.AddWithValue("@hometype", emlaklist.Text);
                command.Parameters.AddWithValue("@livingroom", Convert.ToInt32(salonlist.Value));
                command.Parameters.AddWithValue("@rooms", Convert.ToInt32(odasayisilist.Value));
                command.Parameters.AddWithValue("@balcony", Convert.ToInt32(balkonsayisilist.Value));
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
            else if (emlaklist.SelectedIndex == 1)// HOUSE
            {            
                SqlCommand command = new SqlCommand("SELECT * FROM estate WHERE Type = @type AND HomeType = @hometype AND SquareMeters <= @squareMeters AND Price <= @price AND LivingRoom <= @livingroom AND Rooms <= @rooms AND Balcony <= @balcony AND Floor <= @floor", connection);
                command.Parameters.AddWithValue("@squareMeters", Convert.ToInt32(metrekarelist.Text));
                command.Parameters.AddWithValue("@price", Convert.ToInt32(fiyatlist.Text));
                command.Parameters.AddWithValue("@type", turlist.Text);
                command.Parameters.AddWithValue("@hometype", emlaklist.Text);
                command.Parameters.AddWithValue("@livingroom", Convert.ToInt32(salonlist.Value));
                command.Parameters.AddWithValue("@rooms", Convert.ToInt32(odasayisilist.Value));
                command.Parameters.AddWithValue("@balcony", Convert.ToInt32(balkonsayisilist.Value));
                command.Parameters.AddWithValue("@floor", Convert.ToInt32(katsayisilist.Value));
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;           
            }
            else if (emlaklist.SelectedIndex == 2)// BUILDING
            {
                SqlCommand command = new SqlCommand("SELECT * FROM estate WHERE Type = @type AND HomeType = @hometype AND SquareMeters <= @squareMeters AND Price <= @price AND LivingRoom <= @livingroom AND Rooms <= @rooms AND Balcony <= @balcony AND Apartments <= @apartments", connection);
                command.Parameters.AddWithValue("@squareMeters", Convert.ToInt32(metrekarelist.Text));
                command.Parameters.AddWithValue("@price", Convert.ToInt32(fiyatlist.Text));
                command.Parameters.AddWithValue("@type", turlist.Text);
                command.Parameters.AddWithValue("@hometype", emlaklist.Text);
                command.Parameters.AddWithValue("@livingroom", Convert.ToInt32(salonlist.Value));
                command.Parameters.AddWithValue("@rooms", Convert.ToInt32(odasayisilist.Value));
                command.Parameters.AddWithValue("@balcony", Convert.ToInt32(balkonsayisilist.Value));
                command.Parameters.AddWithValue("@apartments", Convert.ToInt32(dairesayisilist.Value));
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;                       
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

        private void telno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (telno.Text != "")
                {
                    double telNo = Convert.ToDouble(telno.Text);
                }
            }
            catch
            {
                telno.Text = "111";
                MessageBox.Show("Please check your value!");
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Gray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Gainsboro;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int deleteID = Convert.ToInt32(tb_ID.Text);
                
                SqlCommand command = new SqlCommand("DELETE FROM estate WHERE Price = @price AND Name = @name AND SquareMeters = @squaremeters AND ID = @id", connection);
                command.Parameters.AddWithValue("@price", Convert.ToInt32(tb_Price.Text));
                command.Parameters.AddWithValue("@name", tb_Name.Text);
                command.Parameters.AddWithValue("@squaremeters", Convert.ToInt32(tb_Squaremeter.Text));
                command.Parameters.AddWithValue("@id", Convert.ToInt32(tb_ID.Text));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Deleted Successfully!");
            }
            catch
            {
                MessageBox.Show("Something went wrong!! Please check your values.");
            }
        }  
    }
}
