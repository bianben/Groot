using Groot.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groot
{
    public partial class Index : Form
    {
        DB_GamingFormEntities db = new DB_GamingFormEntities();
        public Index()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.comboBox1.SelectedIndex = 0;
        }
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSelectRegion f = new FrmSelectRegion();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                FrmFindJob f = new FrmFindJob();
                f.Show();
            }
            else
            {
                FrmFindTalent f = new FrmFindTalent();
                f.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmMakeResume f = new FrmMakeResume();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmMakeJobRequire f = new FrmMakeJobRequire();
            f.Show();
        }
    }
}
