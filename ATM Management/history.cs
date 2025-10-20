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
    public partial class history : Form
    {
        private object timerUpdateDateTime;
        string formattedDateTime;
        string time;
        int n_time;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        public int add_amount = 0;
        double acc_no;
        public history(double x)
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer7.Interval = 1000; // 1 second
            timer7.Tick += TimerUpdateDateTime_Tick;
            timer7.Start();
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
            formattedDateTime = now.ToString("yyyy-MM-dd HH:mm:ss");
            time = now.ToString("HH");
            DataAndTime.Text = "Current Date and Time: " + formattedDateTime;
        }
        public void message()
        {
            DisplayCurrentDateTime();
            n_time =Convert.ToInt32(time);
            string mes;
           
            if(n_time>=6 && n_time<=12)
            {
                mes = "Good Morning";
            }
            else if(n_time>=13 && n_time<=16)
            {
                mes = "Good Afternoon";
            }
            else
            {
                mes = "Good Evening";
            }
            time_bash_message.Text = mes;
        }
        private void history_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(acc_no);
            h.Show();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
