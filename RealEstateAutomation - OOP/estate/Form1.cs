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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        
            
        }            
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Kayit form2 = new Kayit();
           
            form2.Show();
            
            this.Hide();

            
        }
    }
}
