using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estate
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();        
            
        }            
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddList form2 = new AddList();
           
            form2.Show();
            
            this.Hide();   
        }
 
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Gray;
        }     
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Gainsboro;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Gray;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Gainsboro;
        }

        
    }
}
