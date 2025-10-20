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
    public partial class Fast_Cash : Form
    {
        private object timerUpdateDateTime;
        string time;
        int n_time;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        public int add_amount=0;
        double acc_no;

        public Fast_Cash(double x)
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer3.Interval = 1000; // 1 second
            timer3.Tick += TimerUpdateDateTime_Tick;
            timer3.Start();
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
        private void guna2Button9_Click(object sender, EventArgs e)
        {
          try
          {
             
                double newbalance=0;

                con.Open();
                SqlCommand data = new SqlCommand("Select Balance From userdata where Acc_No='" + acc_no + "' ", con);
                data.ExecuteNonQuery();
                object res = data.ExecuteScalar();
                double balance = Convert.ToInt64(res);
                if(add_amount>0 && add_amount<=balance)
                {
                    newbalance = balance - add_amount;
                    SqlCommand updata = new SqlCommand("UPDATE userdata set Balance='"+newbalance+"' where Acc_no='"+acc_no+"'",con);
                    updata.ExecuteNonQuery();
                    MessageBox.Show("Your New Balance Is " + newbalance);
                }
                else
                {
                    MessageBox.Show("" + newbalance + "");
                }
                con.Close();
           }
            catch(Exception q)
            {
                MessageBox.Show("Invalid Amount");
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addmount(50);
            string s = add_amount.ToString();
            amount.Text = s;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(acc_no);
            h.Show();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            addmount(10);
        }
        private void addmount(int x)
        {
            add_amount = add_amount + x;
            string s = add_amount.ToString();
            amount.Text = s;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string s = add_amount.ToString();
            amount.Text = s;
        }

        private void Fast_Cash_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            addmount(20); 
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            addmount(100); 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addmount(150);   
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            addmount(200);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            addmount(250);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            addmount(500);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            add_amount = 0;
            string s = add_amount.ToString();
            amount.Text = s;
        }
    }
}
