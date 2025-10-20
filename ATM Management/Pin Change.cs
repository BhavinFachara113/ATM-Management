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
    public partial class Pin_Change : Form
    {
        string o_pin;
        string n_pin;
        string c_pin;
        double acc_no;
        private object timerUpdateDateTime;
        string time;
        int n_time;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        double next = 0;
        public Pin_Change(double x)
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            timer6.Interval = 1000; // 1 second
            timer6.Tick += TimerUpdateDateTime_Tick;
            timer6.Start();
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
        private void guna2Button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(acc_no);
            h.Show();
        }
        public void old_pin(string x)
        {
            o_pin =o_pin+ x;
            pin_old.Text = o_pin;
        }
        public void new_pin(string x)
        {
            n_pin =n_pin+ x;
            pin_new.Text = n_pin;
        }
        public void conform_pin(string x)
        {
            c_pin = c_pin+x;
            pin_conform.Text = c_pin;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(next==0)
            {
                old_pin("1");
            }
            else if(next==1)
            {
                new_pin("1");
            }
            else
            {
                conform_pin("1");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("2");
            }
            else if (next == 1)
            {
                new_pin("2");
            }
            else
            {
                conform_pin("2");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("3");
            }
            else if (next == 1)
            {
                new_pin("3");
            }
            else
            {
                conform_pin("3");
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("4");
            }
            else if (next == 1)
            {
                new_pin("4");
            }
            else
            {
                conform_pin("4");
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("5");
            }
            else if (next == 1)
            {
                new_pin("5");
            }
            else
            {
                conform_pin("5");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("6");
            }
            else if (next == 1)
            {
                new_pin("6");
            }
            else
            {
                conform_pin("6");
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("7");
            }
            else if (next == 1)
            {
                new_pin("7");
            }
            else
            {
                conform_pin("7");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("0");
            }
            else if (next == 1)
            {
                new_pin("0");
            }
            else
            {
                conform_pin("0");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("8");
            }
            else if (next == 1)
            {
                new_pin("8");
            }
            else
            {
                conform_pin("8");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                old_pin("9");
            }
            else if (next == 1)
            {
                new_pin("9");
            }
            else
            {
                conform_pin("9");
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if(next==0)
            {
                next = 1;
            }
            else if(next==1)
            {
                next = 2;
            }
            else
            {
                next = 3;
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand data = new SqlCommand("Select Acc_Pin From userdata where Acc_No='" + acc_no + "' ", con);
            data.ExecuteNonQuery();
            object res = data.ExecuteScalar();
            string pin = res.ToString();

            if(o_pin.ToString().Length<=4)
            {
                if(n_pin.ToString().Length<=4)
                {
                    if(c_pin.ToString().Length<=4)
                    {
                        if(pin==o_pin)
                        {
                            SqlCommand updata = new SqlCommand("UPDATE userdata set Acc_Pin='" + n_pin + "' where Acc_no='" + acc_no + "'", con);
                            updata.ExecuteNonQuery();
                            MessageBox.Show("Your New Pin Is" + n_pin);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Coform Pin");
                        pin_conform.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect New Pin");
                    pin_new.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Incorrect Old Pin");
                pin_old.Text = null;
            }
            con.Close();
        }

        private void Pin_Change_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
