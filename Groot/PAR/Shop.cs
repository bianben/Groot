using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 其中專題
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }
        
        public void FromLoadData()
        {
            pictureBox1.BackColor = Color.Purple;
            pictureBox2.BackColor = Color.Yellow;
            pictureBox3.BackColor = Color.Black;
            pictureBox4.BackColor = Color.Blue;
            pictureBox5.BackColor = Color.Red;
         
        }
    

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { 
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            FromLoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
