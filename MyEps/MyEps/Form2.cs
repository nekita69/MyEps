using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEps
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // All Objects;
        Form1 form1;
        public User user;
        public Storage st;
        Bank bank;

        public void SendDataForm2(User user, Form1 f1, Storage st)
        {
            form1 = f1;
            this.user = user;
            this.st = st;
            bank = new Bank(user);
            MessageBox.Show(user.login);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            st.Change(user);
            st.Save();
            Application.Exit();
        }
    }
}
