using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApplicationDBEntityFirst
{
    public partial class MainForm : Form
    {
        User user;

        public MainForm(User user)
        {
            InitializeComponent();

            this.user = user;
            label1.Text = $"You sing in as {user.Login}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ShopDBEntities db = new ShopDBEntities())
            {
                FavoriteProducts pr = db.FavoriteProducts.FirstOrDefault(fp => (fp.Id_Product == (int)comboBox1.SelectedValue && fp.Id_User == user.Id));
                if (pr != null)
                {
                    MessageBox.Show("This product already in your favorite products");
                    return;
                }
                db.FavoriteProducts.Add(new FavoriteProducts(user.Id, (int)comboBox1.SelectedValue));
                db.SaveChanges();
                dataGridView1.DataSource = db.FavoriteProducts.Where((p) => p.Id_User == user.Id).ToList();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            using (ShopDBEntities db = new ShopDBEntities())
            {
                dataGridView1.DataSource = db.FavoriteProducts.Where((p) => p.Id_User == user.Id).ToList();
                comboBox1.DataSource = db.Product.ToList();
            }
        }
    }
}
