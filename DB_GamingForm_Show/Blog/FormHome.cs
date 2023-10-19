using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using DB_GamingForm_Show;
using Gaming_Forum;

namespace DBGaming
{
    public partial class FormHome : Form
    {
        public FormHome(int memberid)
        {
            InitializeComponent();
            LoadBlog();            
        }
        //DB_GamingFormEntities1 db = new DB_GamingFormEntities1();
        DB_GamingFormEntities db = new DB_GamingFormEntities();
        private void LoadBlog()
        {
            this.menuBlog.Items.Clear();
            var q = db.SubTags.AsEnumerable()
                .Where(s => s.TagID == 4 && s.SubTagID != 14)
                .Select(s => s.Name);
            foreach (var s in q)
            {
                this.menuBlog.Items.Add(s);
                this.cbmBlog.Items.Add(s);
            }
            var q2 = db.Blogs
                .Where(s => s.BlogID != 17)
                .Select(s => s.Title);
            foreach (var s in q2)
            {
                this.cbmBlogselect.Items.Add(s);
            }
        }
        private void ALLClear()
        {
            this.menuSubblog.Items.Clear();
            this.txbNew.Text = null;
            this.dataGridView2.DataSource = null;
            this.subBlogImg.Image = null;
            this.txbBlog.Text = null;
            this.cbmBlogselect.Text = null;
            this.txbSubBlog.Text = null;
            this.txbSubBlogNew.Text = null;
            this.txbBlognew.Text = null;
        }

        private void menuBlog_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ALLClear();
            this.cbmBlog.Text = e.ClickedItem.Text;
            var q = db.Blogs.AsEnumerable()
                .Where(b => b.SubTag.Name == e.ClickedItem.Text)
                .Select(s => new
                {
                    進版圖 = s.Image.Image1,
                    版名 = s.Title
                });

            this.dataGridView1.DataSource = q.ToList();
            this.txbTag.Text = e.ClickedItem.Text;
        }
        private void btnTagInsert_Click(object sender, EventArgs e)
        {
            var q = db.SubTags
                .Where(s => s.TagID == 4)
                   .Select(s => s.Name);
            if (q.Contains(this.txbTag.Text))
            {
                MessageBox.Show("已有此分類");
            }
            else
            {
                SubTag sub = new SubTag()
                {
                    TagID = 4,
                    Name = this.txbTag.Text
                };
                db.SubTags.Add(sub);
                db.SaveChanges();
                ALLClear();
                LoadBlog();
                
            }

        }

        private void btnTagUpdate_Click(object sender, EventArgs e)
        {
            var sub = db.SubTags
                 .Where(s => s.Name == this.txbTag.Text && s.TagID == 4)
                 .Select(s => s).FirstOrDefault();

            var q = db.SubTags
                .Where(s => s.TagID == 4)
                .Select(s => s.Name);

            if (q.Contains(this.txbTag.Text))
            {
                sub.Name = this.txbNew.Text;
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("沒有此分類");
            }
            ALLClear();
            LoadBlog();
        }

        private void btnTagDelete_Click(object sender, EventArgs e)
        {
            var delRe = db.Replies.AsEnumerable()
                .Where(r => r.Article.SubBlog.Blog.SubTag.Name == this.txbTag.Text && r.Article.SubBlog.Blog.SubTag.TagID == 4)
                .Select(r => r);
            if (delRe == null) return;
            foreach (var item in delRe)
            {
                db.Replies.Remove(item);
            };
            var delArt=db.Articles.AsEnumerable()
                .Where(a=>a.SubBlog.Blog.SubTag.Name==this.txbTag.Text&&a.SubBlog.Blog.SubTag.TagID==4)
                .Select(a=>a);
            if(delArt == null) return;
            foreach (var item in delArt)
            {
                db.Articles.Remove(item);
            }
            var delSubBlog = db.SubBlogs.AsEnumerable()
                .Where(s => s.Blog.SubTag.Name == this.txbTag.Text && s.Blog.SubTag.TagID == 4)
                .Select(s => s);
            if (delSubBlog == null) return;
            foreach (var item in delSubBlog)
            {
                db.SubBlogs.Remove(item);
            }
            var delBlog=db.Blogs.AsEnumerable()
                .Where(b=>b.SubTag.Name==this.txbTag.Text&&b.SubTag.TagID==4)
                .Select(b=>b);
            if (delBlog == null) return;
            foreach (var item in delBlog)
            {
                db.Blogs.Remove(item);
            }
            var sub = db.SubTags
                .Where(s => s.Name == this.txbTag.Text&&s.TagID==4)
                .Select(s => s).FirstOrDefault();
            if (sub == null) return; 
            db.SubTags.Remove(sub);
            db.SaveChanges();
            ALLClear();
            LoadBlog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.menuSubblog.Items.Clear();
            var q = db.SubBlogs.AsEnumerable()
                   .Where(s => s.Blog.Title == this.dataGridView1.CurrentRow.Cells["版名"].Value.ToString())
                   .Select(s => s.Title);

            foreach (var s in q)
            {
                this.menuSubblog.Items.Add(s);
            }
            this.dataGridView2.DataSource = null;
            this.txbBlog.Text = this.dataGridView1.CurrentRow.Cells["版名"].Value.ToString();
            this.cbmBlogselect.Text = this.dataGridView1.CurrentRow.Cells["版名"].Value.ToString();
            var q2 = db.Blogs.AsEnumerable()
                  .Where(s => s.Title == this.dataGridView1.CurrentRow.Cells["版名"].Value.ToString())
                  .Select(s => s.Image.Image1);
            byte[] bytes = q2.FirstOrDefault();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            this.subBlogImg.Image = System.Drawing.Image.FromStream(ms);
        }
        private void InsertImg()
        {

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.subBlogImg.Image = System.Drawing.Image.FromFile(this.openFileDialog1.FileName);
            }
            else
            {
                this.subBlogImg.Image = null;
            }
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            InsertImg();
        }
        private void btnBlogInsert_Click(object sender, EventArgs e)
        {
            var q = db.Blogs.AsEnumerable()
                .Where(b => b.SubTag.Name == this.cbmBlog.Text)
                .Select(b => b.BlogID).FirstOrDefault();
            var q2 = db.SubTags.AsEnumerable()
                .Where(s => s.Name == this.cbmBlog.Text)
                .Select(s => s.SubTagID).FirstOrDefault();
            var q3 = db.Blogs.AsEnumerable()
                    .Where(b => b.SubTag.Name == this.cbmBlog.Text)
                    .Select(b => b.Title);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (q3.Contains(this.txbBlog.Text))
            {
                MessageBox.Show("已有此討論版");
            }
            else
            {

                if (this.subBlogImg.Image == null)
                {
                    Blog blog = new Blog()
                    {
                        ImageID = 2,
                        BlogID = q,
                        Title = this.txbBlog.Text,
                        SubTagID = q2
                    };
                    db.Blogs.Add(blog);
                    //db.SaveChanges();
                }
                else
                {
                    this.subBlogImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();
                    DB_GamingForm_Show.Image img = new DB_GamingForm_Show.Image()
                    {
                        Name = "img",
                        Image1 = bytes
                    };
                    db.Images.Add(img);
                    db.SaveChanges();
                    Blog blog = new Blog()
                    {
                        ImageID = img.ImageID,
                        BlogID = q,
                        Title = this.txbBlog.Text,
                        SubTagID = q2
                    };
                    db.Blogs.Add(blog);

                }
                db.SaveChanges();
                dataGridView1.DataSource = null;
            }

        }

        private void BtnBlogUpdate_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            var updateBlog = db.Blogs.AsEnumerable()
                .Where(b => b.Title == this.txbBlog.Text && b.SubTag.Name == this.cbmBlog.Text)
                .Select(b => b).FirstOrDefault();

            var compareBlog = db.Blogs.AsEnumerable()
                .Where(b => b.SubTag.Name == this.cbmBlog.Text)
                .Select(b => b.Title);

            if (compareBlog.Contains(this.txbBlog.Text))
            {

                if (this.subBlogImg.Image == null)
                {
                    updateBlog.Title = this.txbBlognew.Text;
                    updateBlog.ImageID=2;
                    MessageBox.Show("沒上傳圖片，設為預設圖");
                }
                else
                {
                this.subBlogImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.GetBuffer();

                updateBlog.Title = this.txbBlognew.Text;
                updateBlog.Image.Image1 = bytes;                
                }
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("沒有此討論版");
            }
            dataGridView1.DataSource = null;


        }

        private void btnBlogDelete_Click(object sender, EventArgs e)
        {
            var delRe = db.Replies
                .Where(r => r.Article.SubBlog.Blog.Title == this.txbBlog.Text && r.Article.SubBlog.Blog.SubTag.Name == this.cbmBlog.Text)
                .Select(r => r);
            if (delRe == null) return;
            foreach (var item in delRe)
            {
              db.Replies.Remove(item);  
            };            
            var delArt = db.Articles
                .Where(a => a.SubBlog.Blog.Title == this.txbBlog.Text && a.SubBlog.Blog.SubTag.Name == this.cbmBlog.Text)
                .Select(a => a);
            if (delArt == null) return;
            foreach (var item in delArt) 
            {
                db.Articles.Remove(item);
            }
            var delSubBlog=db.SubBlogs
                .Where(s=>s.Blog.Title == this.txbBlog.Text&&s.Blog.SubTag.Name == this.cbmBlog.Text)
                .Select(s => s);
            if (delSubBlog == null) return;
            foreach (var item in delSubBlog)
            {
                db.SubBlogs.Remove(item);
            }            
            var delBlog = db.Blogs.AsEnumerable()
                .Where(b => b.Title == this.txbBlog.Text)
                .Select(b => b).FirstOrDefault();
            if (delBlog == null) return;           
            db.Blogs.Remove(delBlog);
            db.SaveChanges();
            dataGridView1.DataSource = null;
        }

        private void LoadArticle(string Name)
        {
            var q = db.Articles.AsEnumerable()
                .Where(a => a.SubBlog.Title == Name)
                .Select(s => new
                {
                    文章編號 = s.ArticleID,
                    標題 = s.Title,
                    內文預覽 = s.ArticleContent
                });
            this.dataGridView2.DataSource = q.ToList();
            this.txbSubBlog.Text = Name;
        }
        private void menuSubblog_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadArticle(e.ClickedItem.Text);
        }


        private void btnSubBlogInsert_Click(object sender, EventArgs e)
        {
            var q = db.Blogs.AsEnumerable()
                  .Where(s => s.Title == this.cbmBlogselect.Text)
                  .Select(s => s.BlogID).FirstOrDefault();

            var q2 = db.SubBlogs.AsEnumerable()
                .Where(s => s.Blog.Title == this.cbmBlogselect.Text)
                .Select(s => s.Title);
            if (q2.Contains(this.txbSubBlog.Text))
            {
                MessageBox.Show("已有此版子分類");
            }
            else
            {

                SubBlog subBlog = new SubBlog()
                {
                    BlogID = q,
                    Title = this.txbSubBlog.Text,
                };
                db.SubBlogs.Add(subBlog);
                db.SaveChanges();

            }
        }

        private void btnSubUpdate_Click(object sender, EventArgs e)
        {
            var updateSubBlog = db.SubBlogs.AsEnumerable()
                .Where(s => s.Title == this.txbSubBlog.Text)
                .Select(s => s).FirstOrDefault();

            var compare=db.SubBlogs.AsEnumerable()
                .Where(s => s.Blog.Title==this.cbmBlogselect.Text)
                .Select(s => s.Title);
            if (compare.Contains(this.txbSubBlog.Text))
            {
            updateSubBlog.Title = this.txbSubBlogNew.Text;
            this.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("沒有此版的子分類");
            }




        }

        private void btnSubDelete_Click(object sender, EventArgs e)
        {

            var delRe = db.Replies.AsEnumerable()
                .Where(x => x.Article.SubBlog.Title == this.txbSubBlog.Text&&x.Article.SubBlog.Blog.Title==this.cbmBlogselect.Text)
                .Select(x => x);
            if (delRe == null) return;
            foreach (var x in delRe)
            {
                db.Replies.Remove(x);
            }
            db.SaveChanges();

            var delArt = db.Articles.AsEnumerable()
                .Where(b => b.SubBlog.Title == this.txbSubBlog.Text && b.SubBlog.Blog.Title == this.cbmBlogselect.Text)
                .Select(b => b);
            if (delArt == null) return;
            foreach (var x in delArt)
            {
                db.Articles.Remove(x);
            }
            db.SaveChanges();

            var delSubBlog = db.SubBlogs.AsEnumerable()
                .Where(s => s.Title == this.txbSubBlog.Text && s.Blog.Title == this.cbmBlogselect.Text)
                .Select(s => s).FirstOrDefault();
            if (delSubBlog == null) return;
            db.SubBlogs.Remove(delSubBlog);
            db.SaveChanges();
            this.dataGridView2.DataSource = null;
            MessageBox.Show("Successful");
        }

        private void btnArticleInsert_Click(object sender, EventArgs e)
        {
            NewART aRT = new NewART();
            aRT.ShowDialog();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 獲取選取數據
            string selectedTitle = dataGridView2.Rows[e.RowIndex].Cells["標題"].Value.ToString();
            string selectedContent = dataGridView2.Rows[e.RowIndex].Cells["內文預覽"].Value.ToString();
            int articleID = (int)dataGridView2.Rows[e.RowIndex].Cells["文章編號"].Value;
            //int memberID = (int)dataGridView3.Rows[e.RowIndex].Cells["會員編號"].Value;

            //int memberID = Class1.memberid2;

            ClassUtility.aid = articleID;

            // 數據傳遞到下一個視窗
            Art_Reply artReplyForm = new Art_Reply(selectedTitle, selectedContent, articleID);
            artReplyForm.ShowDialog();

        }
    }
}
