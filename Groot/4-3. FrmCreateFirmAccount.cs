using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groot
{
    public partial class FrmCreateFirmAccount : Form
    {
        DB_GamingFormEntities db = new DB_GamingFormEntities();
        public FrmCreateFirmAccount()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Firm f = new Firm
            {
                FirmName = $"{this.textBox4.Text}",
                Email = $"{this.textBox3.Text}",
                TaxID = int.Parse(this.textBox1.Text),
                Password = $"{this.textBox2.Text}",
                FirmScale = $"{this.textBox10.Text}",
                FirmAddress = $"{this.textBox8.Text}",
                FirmIntro = $"{this.richTextBox1.Text}",
                Contact = $"{this.textBox7.Text}",
                StatusID = 1
            };
            this.db.Firms.Add(f);
            this.db.SaveChanges();
        }
    }
}
