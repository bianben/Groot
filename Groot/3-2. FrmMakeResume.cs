using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groot
{
    public partial class FrmMakeResume : Form
    {
        DB_GamingFormEntities1 db = new DB_GamingFormEntities1();
        string currentID;
        public FrmMakeResume()
        {
            InitializeComponent();

            

            LoadID();
            LoadEmail();
            LoadName();

            LoadSkills();
            LoadED();
            LoadArticle();
            LoadMyResume();
        }
        private void LoadEmail()
        {
            var q = from p in this.db.Members.AsEnumerable()
                    where p.MemberID == int.Parse(this.linkLabel1.Text.Remove(this.linkLabel1.Text.Count() - 3, 3))
                    select new { email = p.Email };

            this.textBox8.Text = q.FirstOrDefault().email.ToString();
        }
        private void LoadName()
        {
            var q = from p in this.db.Resumes.AsEnumerable()
                    select p;
            if (q.Any(n => n.MemberID == int.Parse(this.linkLabel1.Text.Remove(this.linkLabel1.Text.Count() - 3, 3))))
            {
                this.textBox3.Text = q.FirstOrDefault().FullName;
                this.textBox3.Enabled = false;
                this.textBox1.Text = q.FirstOrDefault().IdentityID;
                this.textBox1.Enabled = false;
                this.textBox2.Text = q.FirstOrDefault().PhoneNumber;
                this.textBox2.Enabled = false;
            }
        }

        private void LoadID()
        {
            currentID = this.linkLabel1.Text.Remove(this.linkLabel1.Text.Count() - 3, 3);
            this.textBox6.Text = currentID;
        }

        private void LoadMyResume()
        {
            var q = from p in this.db.Resumes.AsEnumerable()
                    where p.MemberID == int.Parse(currentID)
                    select new
                    {
                        履歷編號 = p.ResumeID,
                        會員編號 = p.MemberID,
                        姓名 = p.FullName,
                        身份證字號 = p.IdentityID,
                        手機號碼 = p.PhoneNumber,
                        工作經驗 = p.WorkExp
                    };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void LoadArticle()
        {
            var q = from p in db.Articles
                    select p;
            foreach (var item in q)
            {
                this.checkedListBox1.Items.Add(item.Title);
            }
        }

        private void LoadED()
        {
            var q = from p in this.db.Educations
                    select p;
            foreach (var item in q)
            {
                this.comboBox1.Items.Add(item.Name);
            }
        }

        private void LoadSkills()
        {
            var q = from p in db.SkillClasses
                    select p;
            foreach (var i in q)
            {
                this.listBox1.Items.Add(i.Name);
            }
        }




        private void button4_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex += 1;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex += 1;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex += 1;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex += 1;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex -= 1;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex -= 1;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex -= 1;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex -= 1;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = System.Drawing.Image.FromFile(this.openFileDialog1.FileName);
            }
        }
        ListBox llb = new ListBox();
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                this.llb.Items.Clear();
                this.listBox2.Items.Clear();
                //===========================
                var id = from p in this.db.SkillClasses
                         select p;

                var q = from p in db.Skills.AsEnumerable()
                        where p.SkillClassID == id.ToList()[this.listBox1.SelectedIndex].SkillClassID
                        select p;

                foreach (var item in q)
                {
                    this.llb.Items.Add(item.Name);
                }
                foreach (var item in llb.Items)
                {
                    this.listBox2.Items.Add(item);
                }

            }
            else { }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //=========================
            //基本資料

            //大頭照

            byte[] bytes;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            this.pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            bytes = ms.GetBuffer();

            //linq-insertImage

            Image i = new Image { Name = "resume", Image1 = bytes };

            this.db.Images.Add(i);
            this.db.SaveChanges();
            //=========================

            var q = from p in this.db.Educations
                    select p;

            Resume f = new Resume
            {
                MemberID = int.Parse(this.linkLabel1.Text.Remove(this.linkLabel1.Text.Count() - 3, 3)),
                FullName = this.textBox3.Text,
                IdentityID = this.textBox1.Text,
                PhoneNumber = this.textBox2.Text,
                ResumeContent = this.richTextBox1.Text,
                WorkExp = this.textBox5.Text,
                FormID = 1,
                StatusID = 1,
                EDID = q.ToList()[this.comboBox1.SelectedIndex].EDID,
                ImageID = i.ImageID,
            };


            this.db.Resumes.Add(f);
            this.db.SaveChanges();
            //=========================
            //個人經歷


            //=========================
            //求職條件

            //=========================
            //技能專長
            //todo
            int lb3Length = this.listBox3.Items.Count;
            string[] lb3items = new string[lb3Length];

            for (var l = 0; l < lb3Length; l++)
            {
                lb3items[l] = this.listBox3.Items[l].ToString();
            }

            for (var o = 0; o < lb3items.Length; o++)
            {
                string[] skillskill = lb3items[o].Split('-');
                var s = this.db.Skills.AsEnumerable().Where(p => p.Name == skillskill[1]).Select(p => p.SkillID);

                int skillid = s.SingleOrDefault();
                ResumeSkill resumeskill = new ResumeSkill
                {
                    ResumeID = f.ResumeID,
                    SkillID = skillid
                };
                this.db.ResumeSkills.Add(resumeskill);
            }
            this.db.SaveChanges();
            //=========================
            //自傳附件

            



            //=========================
            MessageBox.Show("新增成功");
            this.tabControl2.SelectedIndex = 0;
            LoadMyResume();


        }

        TreeNode saving;//沒用到

        ListBox lb = new ListBox();

        int[] mySkills;

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            //=================================
            //treeview
            //todo 點listbox在treeview加入當下點選的大類及小類，點多少加多少

            //this.treeView1.Nodes.Clear();

            //var q = from p in this.db.Skills
            //        where p.Name.Equals(this.listBox2.Text)
            //        group p by p.SkillClass into g
            //        select new { skillclass = g.Key.Name, mygroup = g };

            //foreach(var s in q)
            //{
            //    //saving = this.treeView1.Nodes.Add(s.skillclass.ToString());
            //    saving = this.treeView1.Nodes.Add(s.skillclass);
            //    foreach (var items in s.mygroup)
            //    {
            //        saving.Nodes.Add(items.Name);
            //    }
            //    saving.Toggle();
            //}

            //===============================
            //listbox
            this.listBox3.Items.Clear();

            var x = from p in this.db.Skills
                    where p.Name == this.listBox2.Text
                    select p;

            foreach (var g in x)
            {
                this.lb.Items.Add($"{g.SkillClass.Name}-{g.Name}");

            }

            foreach (var j in lb.Items)
            {
                this.listBox3.Items.Add(j);
            }

            this.listBox2.Items.Remove(this.listBox2.SelectedItem);

            //var q = this.db.Skills.Where(s => s.SkillClassID == this.listBox1.SelectedIndex).Select(s => s.SkillID);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var q = (from p in this.db.Resumes.AsEnumerable()
                     where p.ResumeID == int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString())
                     select p).FirstOrDefault();

            if (q == null) { return; }

            this.db.Resumes.Remove(q);
            this.db.SaveChanges();
            LoadMyResume();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.button8.Enabled = true;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
