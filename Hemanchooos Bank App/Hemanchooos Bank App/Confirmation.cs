using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hemanchooos_Bank_App
{
    public partial class Confirmation : Form
    {
        
        public Confirmation(String accno)
        {
            InitializeComponent();
            label5.Text = accno;
           
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=tubai1990;persistsecurityinfo=True;database=bankapp");
            MySqlCommand cmd1 = new MySqlCommand("SELECT * from bankapp where Account_No=@var3", conn);
            cmd1.Parameters.Add("@var3", MySqlDbType.Int64);
            cmd1.Parameters["@var3"].Value = accno;
            conn.Open();
            MySqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                label3.Text = dr[1].ToString();
                label7.Text = dr[2].ToString();
            }

            conn.Close();
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            /*MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=tubai1990;persistsecurityinfo=True;database=bankapp");
            MySqlCommand cmd1 = new MySqlCommand("SELECT * from bankapp where Account_No=@var3", conn);
            cmd1.Parameters.Add("@var3", MySqlDbType.Int64);
            cmd1.Parameters["@var3"].Value = Int64.Parse(label5.Text);
            conn.Open();
            MySqlDataReader dr = cmd1.ExecuteReader();
            while(dr.Read())
            {
                label3.Text = dr[1].ToString();
                label7.Text = dr[2].ToString();
            }

            conn.Close();*/
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
