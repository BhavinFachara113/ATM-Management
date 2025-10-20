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
    public partial class SingUp : Form
    {
        private object timerUpdateDateTime;
        string time;
        int n_time;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        public SingUp()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer2.Interval = 1000; // 1 second
            timer2.Tick += TimerUpdateDateTime_Tick;
            timer2.Start();
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
        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            double acc_no = Convert.ToInt64(acc_num.Text);
            double pho = Convert.ToInt64(phone.Text);
            double pin = Convert.ToInt64(acc_pin.Text);
            double con_pin = Convert.ToInt64(c_pin.Text);
            double acc_len = acc_no.ToString().Length;
            double pho_len = pho.ToString().Length;
            double balance = 100000;

            if (pin==con_pin)
            {
                if(acc_len==10 && pho_len==10)
                {
                    try
                    {
                        con.Open();
                        SqlCommand data = new SqlCommand("INSERT INTO userdata VALUES('" + acc_no + "','" + pin + "','" + pho + "','" + balance + "')", con);
                        data.ExecuteNonQuery();
                        MessageBox.Show("Account Is Created");
                        con.Close();
                    }
                    catch(Exception q)
                    {
                        MessageBox.Show("Incorrect Values");
                    }
                }
                else if(acc_len!=10)
                {
                    MessageBox.Show("Account Number Is Invalid");
                }
                else if(pho_len!=10)
                {
                    MessageBox.Show("Phone Number Is Invalid");
                }
            }
            else
            {
                MessageBox.Show("Entered Pin And Conform Pin Is Not Metch");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void SingUp_Load(object sender, EventArgs e)
        {

        }
    }
}
