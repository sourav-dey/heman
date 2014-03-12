using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace Hemanchooos_Bank_App
{
   
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0)
                MessageBox.Show("Please Enter all the informations");
            else if (!radioButton1.Checked && !radioButton2.Checked)
                MessageBox.Show("Please Select Debit or Credit");
            else
            {
               /* Object o;

                //The fellow using this system account info change
                //Taking the amount presently in his system
                MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=tubai1990;persistsecurityinfo=True;database=bankapp");
                MySqlCommand cmd1 = new MySqlCommand("SELECT Amount from bankapp where Account_No=@var3", conn);
                cmd1.Parameters.Add("@var3", MySqlDbType.Int64);
                cmd1.Parameters["@var3"].Value = Int64.Parse(textBox2.Text);
                conn.Open();
                o = cmd1.ExecuteScalar();
                conn.Close();
                Int64 amt = Int64.Parse(o.ToString());

                //Updating his current bank amount
                MySqlCommand cmd = new MySqlCommand("UPDATE bankapp SET Amount = @var1 WHERE Account_No = @var2", conn);
                cmd.Parameters.Add("@var2", MySqlDbType.Int64);
                cmd.Parameters["@var2"].Value = Int64.Parse(textBox2.Text);
                if (radioButton1.Checked)
                    amt += Int64.Parse(textBox5.Text);
                else if (radioButton2.Checked)
                    amt -= Int64.Parse(textBox5.Text);
                
                cmd.Parameters.Add("@var1", MySqlDbType.Int64);
                cmd.Parameters["@var1"].Value = amt;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();



                //The other fellow, he is transferring from
                //Taking his present balance
                MySqlCommand cmd2 = new MySqlCommand("SELECT Amount from bankapp where Account_No=@var4", conn);
                cmd2.Parameters.Add("@var4", MySqlDbType.Int64);
                cmd2.Parameters["@var4"].Value = Int64.Parse(textBox4.Text);
                conn.Open();
                o = cmd2.ExecuteScalar();
                conn.Close();
                amt = Int64.Parse(o.ToString());

                //Updating his balance 
                MySqlCommand cmd3 = new MySqlCommand("UPDATE bankapp SET Amount = @var5 WHERE Account_No = @var6", conn);
                cmd3.Parameters.Add("@var5", MySqlDbType.Int64);
                cmd3.Parameters["@var5"].Value = Int64.Parse(textBox4.Text);
                if (radioButton1.Checked)
                    amt -= Int64.Parse(textBox5.Text); // minus because debit will make the fellows money less as he is giving to the fellow using our system
                else if (radioButton2.Checked)
                    amt += Int64.Parse(textBox5.Text); // plus because vice versa
              
                cmd3.Parameters.Add("@var6", MySqlDbType.Int64);
                cmd3.Parameters["@var6"].Value = amt;

                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();*/

               

                this.Hide();
                Summary s = new Summary(textBox1.Text, int.Parse(textBox2.Text), radioButton1.Checked ? 1 : 0, int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                
                s.Show();

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
