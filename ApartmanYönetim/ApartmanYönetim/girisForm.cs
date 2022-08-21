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
using System.Threading;

namespace ApartmanYönetim
{
    public partial class girisForm : Form
    {
        public girisForm()
        {
            InitializeComponent();
        }

        public static SqlConnection connection = new SqlConnection("Data Source=AHMETPC\\SQLEXPRESS; Initial Catalog=apartmanyonetim; Integrated Security=true");

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
            
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }
        bool isthere;
        public static string kullaniciID;
        public static string username;
        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            string password = textBox2.Text;
            
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from apartmanyonet", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (username == reader["username"].ToString().TrimEnd() && password == reader["password"].ToString().TrimEnd())
                {
                    kullaniciID = reader["userID"].ToString().TrimEnd();
                    islemlerForm islemlerForm = new islemlerForm();
                    this.Hide();
                    islemlerForm.Show();
                    isthere = true;
                    break;
                }
                else
                {
                    isthere = false;
                }
            }
            
            
            
            
            connection.Close();
            
            
            if (isthere == false)
            {
                MessageBox.Show("Giriş yaparken bir sorun oluştu", "Program");
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayitForm frm = new kayitForm();
            this.Hide();
            frm.Show();
        }

        private void girisForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
