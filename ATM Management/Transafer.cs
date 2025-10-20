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
    public partial class Transafer : Form
    {
        double tra_acc;
        double tra_pin;
        double tra_note;
        double acc_no;
        double next = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bhavinpatel\OneDrive\Documents\Visual Studio 2015\Projects\ATM Management\ATM Management\atm.mdf;Integrated Security=True");
        private object timerUpdateDateTime;
        string time;
        int n_time;
        public Transafer(double x)
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
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(acc_no);
            h.Show();
        }
        public void account(double x)
        {
            tra_note = tra_note + x;
            Tra_Note.Text = tra_note.ToString();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
             if(next==0)
            {
                account(1);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(5);
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(10);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(20);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(50);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(100);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(500);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (next == 0)
            {
                account(1000);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            next = 1;
        }

        private void Tra_pin_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            tra_acc = Convert.ToInt64(Tra_Number.Text);
            tra_pin = Convert.ToInt64(Tra_pin.Text);

            con.Open();
            SqlCommand data = new SqlCommand("Select Balance From userdata where Acc_No='" + acc_no + "' ", con);
            data.ExecuteNonQuery();
            object res = data.ExecuteScalar();
            double balance = Convert.ToInt64(res);

            SqlCommand data1 = new SqlCommand("Select Balance From userdata where Acc_No='" + tra_acc + "' ", con);
            data1.ExecuteNonQuery();
            object res1 = data1.ExecuteScalar();
            double balance1 = Convert.ToInt64(res1);

            SqlCommand data2= new SqlCommand("Select Acc_Pin From userdata where Acc_No='" + acc_no + "' ", con);
            data2.ExecuteNonQuery();
            object res2 = data2.ExecuteScalar();
            double pin = Convert.ToInt64(res2);

            double newbalance=balance-tra_note;
            double newbalance2 = balance1 + tra_note;

            if (tra_acc!=acc_no)
            {
                if(tra_acc.ToString().Length==10 && tra_note>=0 && tra_note<=10000)
                {
                     if(tra_pin==pin)
                    {
                        SqlCommand updata = new SqlCommand("UPDATE userdata set Balance='" + newbalance + "' where Acc_no='" + acc_no + "'", con);
                        updata.ExecuteNonQuery();
                        SqlCommand updata1= new SqlCommand("UPDATE userdata set Balance='" + newbalance2 + "' where Acc_no='" + tra_acc + "'", con);
                        updata1.ExecuteNonQuery();
                        MessageBox.Show("Your New Balance Is " + newbalance);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin");
                    }     
                }
                else
                {
                    MessageBox.Show("Incorrect Account Number");
                }
            }
            else
            {
                MessageBox.Show("You Can Not Transafer Cash To Same Account");
            }
            con.Close();
        }

        private void Transafer_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
