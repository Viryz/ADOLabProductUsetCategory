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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            using (ShopDBEntities db = new ShopDBEntities())
            {
                User user = db.User.FirstOrDefault((u) => u.Login == login);
                if (user == null)
                {
                    MessageBox.Show("Not found");
                    return;
                }
                if (user.Password.Trim() == password)
                {
                    MainForm form = new MainForm(user);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }
    }
}
