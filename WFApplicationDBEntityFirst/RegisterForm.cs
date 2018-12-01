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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                return;
            string login = textBox1.Text;
            using (ShopDBEntities db = new ShopDBEntities())
            {
                User user = db.User.FirstOrDefault((u) => u.Login == login);
                if (user != null)
                {
                    MessageBox.Show("This user already exist");
                    return;
                }
                db.User.Add(new User(textBox1.Text, textBox2.Text));
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
