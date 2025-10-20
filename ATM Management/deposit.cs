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
    public partial class deposit : Form
    {
        double dop_amount=0;
        double dop_pin;
        double t_note = 0;
        int next = 0;
        double acc_no;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");

        private object timerUpdateDateTime;
        string time;
        int n_time;
        public deposit(double x)
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer5.Interval = 1000; // 1 second
            timer5.Tick += TimerUpdateDateTime_Tick;
            timer5.Start();
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
        public void d_amount(double x)
        {
            dop_amount = dop_amount + x;
            t_note = t_note +1;
            deposit_amount.Text = dop_amount.ToString();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if(next==0)
            {
                if(t_note<=200)
                {
                    if(dop_amount<=10000)
                    {
                        d_amount(1);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(acc_no);
            h.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(5);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }

                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }
        private void guna2Button14_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(10);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(20);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(50);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(100);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(500);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                if (t_note <= 200)
                {
                    if (dop_amount <= 10000)
                    {
                        d_amount(1000);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Deposit More Then 10000");
                    }
                }
                else
                {
                    MessageBox.Show("You Can Not Deposit More Then 200 Note");
                }
            }
        }

        private void deposit_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            next = 1;
            deposit_pin.Focus();

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            double newbalance;
            try
            {
                con.Open();
                SqlCommand data = new SqlCommand("Select Balance From userdata where Acc_No='" + acc_no + "' ", con);
                data.ExecuteNonQuery();
                object res = data.ExecuteScalar();
                double balance = Convert.ToInt64(res);

                SqlCommand data2 = new SqlCommand("Select Acc_Pin From userdata where Acc_No='" + acc_no + "' ", con);
                data2.ExecuteNonQuery();
                object res2 = data2.ExecuteScalar();
                double pin = Convert.ToInt64(res2);

                dop_pin=Convert.ToInt64(deposit_pin.Text);

                if (dop_amount > 0 && dop_amount<10000)
                {
                   if(dop_pin==pin)
                   {
                        newbalance = dop_amount + balance;
                        SqlCommand update = new SqlCommand("UPDATE userdata SET Balance='" + newbalance + "' where Acc_No='"+acc_no+"'", con);
                        update.ExecuteNonQuery();
                        MessageBox.Show("Your New Balance Is" + newbalance);
                   }
                   else
                   {
                        MessageBox.Show("Incorrect Pin");
                        deposit_pin.Text = null;
                   }
                }
                else
                {
                    MessageBox.Show("Incorrect Amount");
                }
                con.Close();
            }
            catch (Exception q)
            {
                MessageBox.Show("Incorrect Amount Or Pin");
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel16_Click(object sender, EventArgs e)
        {

        }

        private void deposit_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
