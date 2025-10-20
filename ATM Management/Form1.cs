using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace ATM_Management
{
    public partial class Form1 : Form
    {
      
        private object timerUpdateDateTime;
        string time;
        int n_time;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        double acc_no;
        double acc_pin;
        public Form1()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer1.Interval = 1000; // 1 second
            timer1.Tick += TimerUpdateDateTime_Tick;
            timer1.Start();
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
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataAndTime_Click(object sender, EventArgs e)
        {
            DisplayCurrentDateTime();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            try
            {
                 acc_no = Convert.ToInt64(login_acc_no.Text);
                 acc_pin = Convert.ToInt64(login_acc_pin.Text);
                con.Open();
                SqlCommand data = new SqlCommand("Select * From userdata where Acc_No='"+acc_no+"' ", con);
                data.ExecuteNonQuery();

                SqlCommand data1 = new SqlCommand("select Acc_Pin from userdata where Acc_No='" + acc_no+ "'", con);
                data1.ExecuteNonQuery();
                object res1 = data1.ExecuteScalar();
                double pin = Convert.ToInt64(res1);

                if(acc_pin==pin)
                {
                    this.Hide();
                    Home h = new Home(acc_no);
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Pin");
                    login_acc_pin.Text = null;
                }

                con.Close();

            }
            catch(Exception q)
            {
              MessageBox.Show("Incorrect Account Number And Pin");
            }
           
        }

        private void login_singupbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SingUp sin = new SingUp();
            sin.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }
    }
}
