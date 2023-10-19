using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DB_GamingForm_Show;
using Gaming_Forum;
using 其中專題;

namespace Shopping
{
    public partial class FrmMemberShop : Form
    {
        DB_GamingFormEntities db = new DB_GamingFormEntities();
        public int ID { get; set; }
        public bool IsFirm { get; set; }

        private void MemberFirm()
        {
            if (ClassUtility.FirmID != 0)
            {
                ID = ClassUtility.FirmID;
                IsFirm = true;
            }
            else
            {
                ID = ClassUtility.MemberID;
                IsFirm = false;
            }
        }

        public FrmMemberShop()
        {
            InitializeComponent();
            this.tabControl1.SelectedIndex = 0;
            this.button5.Visible = false;
            MemberFirm();
            LoadData();

        }

        public void LoadData()
        {
            db = new DB_GamingFormEntities();
            if (IsFirm)
            {
                //=======================================================================
                //訂單追蹤
                var q = from x in db.Orders.AsEnumerable()
                        where x.FirmID == ID
                        select new { x.Status.Name, x.OrderID, Payment = x.Payment.Name, ShipMethod = x.ShipMethod.Name, x.OrderDate, x.PaymentDate, x.ShippingDate, x.CompletedDate, x.ShipName, x.ShipAddress };
                this.dataGridView1.DataSource = q.ToList();

                //=======================================================================
                //商品管理
                var q2 = from x in db.Products.AsEnumerable()
                         where x.FirmID == ID
                         select new { x.Status.Name, x.ProductID, x.ProductName, x.Price, x.UnitStock };
                int quan = 0;
                List<COrderProduct> products = new List<COrderProduct>();
                foreach (var w in q2)
                {
                    var qq = from x in db.OrderProducts.AsEnumerable()
                             where x.ProductID == w.ProductID
                             select new { x.Quantinty };
                    foreach (var w2 in qq)
                    {
                        quan += w2.Quantinty;
                    }
                    products.Add(new COrderProduct
                    {
                        ProductID = w.ProductID,
                        ProductName = w.ProductName,
                        UnitPrice = w.Price,
                        Quantinty = quan,
                        UnitStock = w.UnitStock,
                        Discount = 1
                    });
                }
                this.dataGridView3.DataSource = products;

                //=======================================================================
                //訂單處理
                var q3 = from x in db.Products.AsEnumerable()
                         where x.FirmID == ID
                         select new { x.ProductID };
                List<COrder> order = new List<COrder>();
                foreach (var w in q3)
                {
                    var q4 = from x in db.OrderProducts.AsEnumerable()
                             where x.ProductID == w.ProductID
                             select new
                             {
                                 x.OrderID,
                                 x.Product.ProductName,
                                 x.Order.ShipName,
                                 x.Order.OrderDate,
                                 x.Order.PaymentDate,
                                 x.Order.ShippingDate,
                                 Payment = x.Order.Payment.Name,
                                 ShipMethod = x.Order.ShipMethod.Name,
                                 x.Order.ShipAddress,
                                 x.Order.Note,
                                 Status = x.Order.Status.Name,
                                 x.Quantinty
                             };
                    var q5 = q4.OrderBy(x => x.OrderID);
                    foreach (var w2 in q5)
                    {
                        order.Add(new COrder
                        {
                            Status = w2.Status,
                            OrderID = w2.OrderID,
                            ProductName = w2.ProductName,
                            Quantinty = w2.Quantinty,
                            ShipName = w2.ShipName,
                            OrderDate = w2.OrderDate,
                            PaymentDate = w2.PaymentDate,
                            ShippingDate = w2.ShippingDate,
                            PaymentName = w2.Payment,
                            ShipMethod = w2.ShipMethod,
                            ShipAddress = w2.ShipAddress,
                            Note = w2.Note
                        });
                    }
                }

                this.dataGridView4.DataSource = order;
                this.dataGridView4.Columns["MemberID"].Visible = false;
                this.dataGridView4.Columns["PaymentID"].Visible = false;
                this.dataGridView4.Columns["ShipID"].Visible = false;
                this.dataGridView4.Columns["StatusID"].Visible = false;

                //=======================================================================
                //願望清單
            }
            else
            {


                //=======================================================================
                //訂單追蹤
                db = new DB_GamingFormEntities();
                var q = from x in db.Orders.AsEnumerable()
                        where x.MemberID == ID
                        select new { x.Status.Name, x.OrderID, Payment = x.Payment.Name, ShipMethod = x.ShipMethod.Name, x.OrderDate, x.PaymentDate, x.ShippingDate, x.CompletedDate, x.ShipName, x.ShipAddress };
                this.dataGridView1.DataSource = q.ToList();

                //=======================================================================
                //商品管理
                var q2 = from x in db.Products.AsEnumerable()
                         where x.MemberID == ID
                         select new { x.Status.Name, x.ProductID, x.ProductName, x.Price, x.UnitStock };
                int quan = 0;
                List<COrderProduct> products = new List<COrderProduct>();
                db = new DB_GamingFormEntities();
                foreach (var w in q2)
                {
                    var qq = from x in db.OrderProducts.AsEnumerable()
                             where x.ProductID == w.ProductID
                             select new { x.Quantinty };
                    foreach (var w2 in qq)
                    {
                        quan += w2.Quantinty;
                    }
                    products.Add(new COrderProduct
                    {
                        ProductID = w.ProductID,
                        ProductName = w.ProductName,
                        UnitPrice = w.Price,
                        Quantinty = quan,
                        UnitStock = w.UnitStock,
                        Discount = 1
                    });
                }
                this.dataGridView3.DataSource = products;

                //=======================================================================
                //訂單處理
                var q3 = from x in db.Products.AsEnumerable()
                         where x.MemberID == ID
                         select new { x.ProductID };
                List<COrder> order = new List<COrder>();
                foreach (var w in q3)
                {
                    var q4 = from x in db.OrderProducts.AsEnumerable()
                             where x.ProductID == w.ProductID
                             select new
                             {
                                 x.OrderID,
                                 x.Product.ProductName,
                                 x.Order.ShipName,
                                 x.Order.OrderDate,
                                 x.Order.PaymentDate,
                                 x.Order.ShippingDate,
                                 Payment = x.Order.Payment.Name,
                                 ShipMethod = x.Order.ShipMethod.Name,
                                 x.Order.ShipAddress,
                                 x.Order.Note,
                                 Status = x.Order.Status.Name,
                                 x.Quantinty
                             };
                    var q5 = q4.OrderBy(x => x.OrderID);
                    foreach (var w2 in q5)
                    {
                        order.Add(new COrder
                        {
                            Status = w2.Status,
                            OrderID = w2.OrderID,
                            ProductName = w2.ProductName,
                            Quantinty = w2.Quantinty,
                            ShipName = w2.ShipName,
                            OrderDate = w2.OrderDate,
                            PaymentDate = w2.PaymentDate,
                            ShippingDate = w2.ShippingDate,
                            PaymentName = w2.Payment,
                            ShipMethod = w2.ShipMethod,
                            ShipAddress = w2.ShipAddress,
                            Note = w2.Note
                        });
                    }
                }

                this.dataGridView4.DataSource = order;
                this.dataGridView4.Columns["MemberID"].Visible = false;
                this.dataGridView4.Columns["PaymentID"].Visible = false;
                this.dataGridView4.Columns["ShipID"].Visible = false;
                this.dataGridView4.Columns["StatusID"].Visible = false;

                //=======================================================================
                //願望清單
                var q6 = from x in db.WishLists.AsEnumerable()
                         where x.MemberID == ID
                         select new { x.ProductID, x.Product.ProductName };
                this.dataGridView5.DataSource = q6.ToList();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var q = from x in db.OrderProducts.AsEnumerable()
                    where x.OrderID == (int)this.dataGridView1.CurrentRow.Cells[1].Value
                    select new { x.OrderID, x.Product.ProductName, x.UnitPrice, x.Quantinty };
            this.dataGridView2.DataSource = q.ToList();
            int price = 0;
            foreach (var x in q)
            {
                price += (int)x.UnitPrice * x.Quantinty;
            }
            this.label1.Text = "訂單金額: "+price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int OrderID = (int)this.dataGridView4.CurrentRow.Cells["OrderID"].Value;
            Order status = db.Orders.First(x => x.OrderID == OrderID);
            if (status.StatusID < 13)
            {
                status.StatusID = 13;
            }
            else if (status.StatusID == 13)
            {
                status.StatusID++;
                status.PaymentDate = DateTime.Now;
                db.SaveChanges();
            }
            else if (status.StatusID == 14)
            {
                status.StatusID++;
                status.ShippingDate = DateTime.Now;
                db.SaveChanges();
            }
            else if (status.StatusID == 15)
            {
                status.StatusID++;
                status.CompletedDate = DateTime.Now;
                db.SaveChanges();
            }
            else if (status.StatusID == 16)
            {
                MessageBox.Show("訂單已完成");
            }
            LoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int productid = (int)this.dataGridView5.CurrentRow.Cells[0].Value;
            try
            {
                var wishlist = (from w in db.WishLists
                                where w.ProductID == productid && w.MemberID == ID
                                select w).First();
                if (wishlist == null) return;
                db.WishLists.Remove(wishlist);
                db.SaveChanges();
                MessageBox.Show("已移除願望清單");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUpdateProduct f = new FrmUpdateProduct();
            f.textBox5.Text = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            f.textBox1.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            f.textBox2.Text = this.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            f.textBox3.Text = this.dataGridView3.CurrentRow.Cells[4].Value.ToString();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsFirm)
            {
                var q2 = from x in db.Products.AsEnumerable()
                         where x.FirmID == ID
                         select new { x.Status.Name, x.ProductID, x.ProductName, x.Price, x.UnitStock };
                int quan = 0;
                List<COrderProduct> products = new List<COrderProduct>();
                foreach (var w in q2)
                {
                    var qq = from x in db.OrderProducts.AsEnumerable()
                             where x.ProductID == w.ProductID
                             select new { x.Quantinty };
                    foreach (var w2 in qq)
                    {
                        quan += w2.Quantinty;
                    }
                    products.Add(new COrderProduct
                    {
                        ProductID = w.ProductID,
                        ProductName = w.ProductName,
                        UnitPrice = w.Price,
                        Quantinty = quan,
                        UnitStock = w.UnitStock,
                        Discount = 1
                    });
                }
                this.dataGridView3.DataSource = products;
            }
            else
            { var q2 = from x in db.Products.AsEnumerable()
                     where x.MemberID == ID
                     select new { x.Status.Name, x.ProductID, x.ProductName, x.Price, x.UnitStock };
            int quan = 0;
            List<COrderProduct> products = new List<COrderProduct>();
            foreach (var w in q2)
            {
                var qq = from x in db.OrderProducts.AsEnumerable()
                         where x.ProductID == w.ProductID
                         select new { x.Quantinty };
                foreach (var w2 in qq)
                {
                    quan += w2.Quantinty;
                }
                products.Add(new COrderProduct
                {
                    ProductID = w.ProductID,
                    ProductName = w.ProductName,
                    UnitPrice = w.Price,
                    Quantinty = quan,
                    UnitStock = w.UnitStock,
                    Discount = 1
                });
            }
            this.dataGridView3.DataSource = products; 
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //int productid = (int)this.dataGridView3.CurrentRow.Cells[0].Value;
            //if (IsFirm)
            //{
            //    try
            //    {
            //        var product = (from w in db.Products
            //                        where w.ProductID == productid && w.FirmID == ID
            //                        select w).First();
            //        //var producttag = db.ProductTags.Include(x=>x.ProductID == productid)
            //        if (product == null) return;
            //        db.Products.Remove(product);
            //        db.SaveChanges();
            //        MessageBox.Show("已移除商品");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    LoadData();
            //}
            //else
            //{
            //    try
            //    {
            //        var product = (from w in db.Products
            //                       where w.ProductID == productid && w.MemberID == ID
            //                       select w).First();
            //        if (product == null) return;
            //        db.Products.Remove(product);
            //        db.SaveChanges();
            //        MessageBox.Show("已移除商品");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    LoadData();
            //}
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddProduct a = new AddProduct();
            a.Show();
        }
    }
}
