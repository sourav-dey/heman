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
    public partial class Summary : Form
    {
        public Summary(string name, int accno, int acctype, int toacc, int amount)
        {
            InitializeComponent();

            label3.Text = name;
            label5.Text = accno.ToString();
            label7.Text = (acctype==1?"Debit":"Credit");
            label9.Text = toacc.ToString();
            label11.Text = amount.ToString();
        }


        private void Summary_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Object o;

            //The fellow using this system account info change
            //Taking the amount presently in his system
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=tubai1990;persistsecurityinfo=True;database=bankapp");
            MySqlCommand cmd1 = new MySqlCommand("SELECT Amount from bankapp where Account_No=@var3", conn);
            cmd1.Parameters.Add("@var3", MySqlDbType.Int64);
            cmd1.Parameters["@var3"].Value = Int64.Parse(label5.Text);
            conn.Open();
            o = cmd1.ExecuteScalar();
            conn.Close();
            float amt = float.Parse(o.ToString());

            //Updating his current bank amount
            MySqlCommand cmd = new MySqlCommand("UPDATE bankapp SET Amount = @var1 WHERE Account_No = @var2", conn);
            cmd.Parameters.Add("@var2", MySqlDbType.Int64);
            cmd.Parameters["@var2"].Value = Int64.Parse(label5.Text);
            if (label7.Text.Equals("Debit"))
                amt += float.Parse(label11.Text);
            else if (label7.Text.Equals("Credit"))
                amt -= float.Parse(label11.Text);

            cmd.Parameters.Add("@var1", MySqlDbType.Float);
            cmd.Parameters["@var1"].Value = amt;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


            Object ob;
            //The other fellow, he is transferring from
            //Taking his present balance
            MySqlCommand cmd2 = new MySqlCommand("SELECT Amount from bankapp where Account_No=@var4", conn);
            cmd2.Parameters.Add("@var4", MySqlDbType.Int64);
            cmd2.Parameters["@var4"].Value = Int64.Parse(label9.Text);
            conn.Open();
            ob = cmd2.ExecuteScalar();
            conn.Close();
            amt = float.Parse(ob.ToString());

            //Updating his balance 
            MySqlCommand cmd3 = new MySqlCommand("UPDATE bankapp SET Amount = @var5 WHERE Account_No = @var6", conn);
            cmd3.Parameters.Add("@var6", MySqlDbType.Int64);
            cmd3.Parameters["@var6"].Value = Int64.Parse(label9.Text);
            if (label7.Text.Equals("Debit"))
                amt -= float.Parse(label11.Text);
            else if (label7.Text.Equals("Credit"))
                amt += float.Parse(label11.Text);

            cmd3.Parameters.Add("@var5", MySqlDbType.Float);
            cmd3.Parameters["@var5"].Value = amt;

            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();





            this.Hide();
            Confirmation c = new Confirmation(label5.Text);
            c.Show();
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
