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
using ApartmanYönetim.entity;

namespace ApartmanYönetim
{
    public partial class kayitForm : Form
    {
        public kayitForm()
        {
            InitializeComponent();
        }
        apartmanyonetimEntities db = new apartmanyonetimEntities();
        SqlConnection connection = girisForm.connection;
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
        public static string hesapID;
        public static string username2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            username2 = textBox1.Text;
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from apartmanyonet", connection);
            SqlDataReader reader = command.ExecuteReader();
            

            while (reader.Read())
            {
                
                if (username2 == reader["username"].ToString().TrimEnd())
                {
                    
                    if (MessageBox.Show("Zaten Böyle bir hesap bulunuyor!\nGiriş Sayfasına dönmek ister misiniz?", "Program", MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        girisForm frmGiris = new girisForm();
                        this.Hide();
                        frmGiris.Show();
                        break;

                    }
                    else
                    {
                        MessageBox.Show("Aynı Değil");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            connection.Close();

            connection.Open();
            string password = textBox2.Text;
            SqlCommand command3 = new SqlCommand("Insert into apartmanyonet (username,password,aidat,dogalgaz) values ('" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"','"+textBox4.Text+"')", connection);
            command3.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand("Select @@IDENTITY", connection);
            hesapID = command2.ExecuteScalar().ToString().TrimEnd();
            girisForm.kullaniciID = "";
            

            connection.Close();
            MessageBox.Show("Kayıt tamamlandı","Apartman");
             
            this.Hide();
            binayarForm frm = new binayarForm();
            frm.Show();
             
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "aidat")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "dogalgaz")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void kayitForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
