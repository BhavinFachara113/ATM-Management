using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_Management
{
    public partial class Withdraw : Form
    {
        string add_amount;
        string add_pin;
        int next = 0;
        double acc_no;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        private object timerUpdateDateTime;
        string time;
        int n_time;
        public Withdraw(double x)
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer4.Interval = 1000; // 1 second
            timer4.Tick += TimerUpdateDateTime_Tick;
            timer4.Start();
            acc_no = x;
            message();
        }
        private void TimerUpdateDateTime_Tick(object sender, EventArgs e)
        {
            DisplayCurrentDateTime();
        }
        private void DisplayCurrentDateTime()
        {
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyy-MM-dd HH:mm:ss");
            time = now.ToString("HH");
            DataAndTime.Text = "Current Date and Time: " + formattedDateTime;
        }
        public void message()
        {
            DisplayCurrentDateTime();
            n_time = Convert.ToInt32(time);
            string mes;

            if (n_time >= 6 && n_time <= 12)
            {
                mes = "Good Morning";
            }
            else if (n_time >= 13 && n_time <= 16)
            {
                mes = "Good Afternoon";
            }
            else
            {
                mes = "Good Evening";
            }
            time_bash_message.Text = mes;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(acc_no);
            h.Show();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
        public void withdraw(string x)
        {
            add_amount = add_amount + x;
            withdraw_amount.Text = add_amount.ToString();


        }
        public void pin(string x)
        {
            add_pin = add_pin + x;
            withdraw_pin.Text = add_pin.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(next==0)
            {
                withdraw("1");
            }
            else
            {
                pin("1");
            }

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("2");
            }
            else
            {
                pin("2");
            }
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("3");
            }
            else
            {
                pin("3");
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("4");
            }
            else
            {
                pin("4");
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("5");
            }
            else
            {
                pin("5");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("0");
            }
            else
            {
                pin("0");
            }
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("6");
            }
            else
            {
                pin("6");
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("7");
            }
            else
            {
                pin("7");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("8");
            }
            else
            {
                pin("8");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                withdraw("9");
            }
            else
            {
                pin("9");
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            next = 1;
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            double cu_amount = Convert.ToInt64(add_amount);
            double cu_pin = Convert.ToInt64(add_pin);
            double newbalance;

           try
           {
                con.Open();
                SqlCommand data = new SqlCommand("Select Balance From userdata where Acc_No='" + acc_no + "' ", con);
                data.ExecuteNonQuery();
                object res = data.ExecuteScalar();
                double balance = Convert.ToInt64(res);

                SqlCommand data1 = new SqlCommand("Select Acc_Pin From userdata where Acc_No='" + acc_no + "' ", con);
                data1.ExecuteNonQuery();
                object res1 = data1.ExecuteScalar();
                double pin = Convert.ToInt64(res1);

                if (cu_amount > 0 && cu_amount <= balance)
                {
                    if (cu_pin ==pin)
                    {
                        newbalance = balance - cu_amount;
                        SqlCommand updata = new SqlCommand("UPDATE userdata set Balance='" + newbalance + "' where Acc_no='" + acc_no + "'", con);
                        updata.ExecuteNonQuery();
                        MessageBox.Show("Your New Balance Is " + newbalance);
                        withdraw_amount.Text =null;
                        withdraw_pin.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin");
                        add_pin = null;
                        withdraw_pin.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Amount");
                }
                con.Close();
           }
           catch(Exception q)
           {
                MessageBox.Show("Incorrect Amount And Pin");
           }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void withdraw_pin_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Withdraw_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
