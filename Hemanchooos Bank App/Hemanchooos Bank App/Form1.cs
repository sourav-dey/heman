using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hemanchooos_Bank_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Heman"))
            {
                this.Hide();
                HomePage hp = new HomePage();
               
                hp.Show();

            }
            else
                MessageBox.Show("Wrong Password. Please Enter Correct Password");
        }
    }
}
