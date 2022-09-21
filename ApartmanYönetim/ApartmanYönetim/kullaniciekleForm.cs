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

namespace ApartmanYönetim
{
    public partial class kullaniciekleForm : Form
    {
        public kullaniciekleForm()
        {
            InitializeComponent();
        }
        public static string eklenenKullanici;
        
        public static string eklenenkullaniciBorc;
        SqlConnection connection = girisForm.connection;
        private void button1_Click(object sender, EventArgs e)
        {
            
        
            eklenenKullanici = textBox1.Text;
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            eklenenkullaniciBorc = textBox3.Text;
            if (girisForm.kullaniciID != "")
            {

                SqlCommand command = new SqlCommand("Insert into dairelerveborclar (dairead,toplamborc,daireID,tarih) values ('" + textBox1.Text + "','" + textBox3.Text + "','" + girisForm.kullaniciID + "','" + DateTime.UtcNow.ToString("d") + "')", connection);
                command.ExecuteNonQuery();
            }
            else if (girisForm.kullaniciID == "")
            {

                SqlCommand command2 = new SqlCommand("Insert into dairelerveborclar (dairead,toplamborc,daireID,tarih) values ('" + textBox1.Text + "','" + textBox3.Text + "','" + kayitForm.hesapID + "','" + DateTime.UtcNow.ToString("d") + "')", connection);
                command2.ExecuteNonQuery();
            }
            MessageBox.Show("Ekleme İşlemi Tamamlandı");
            connection.Close();
            islemlerForm islemlerform = new islemlerForm();
            
            
            this.Hide();
            UserControl2 user = new UserControl2();
            user.baslangıc();


        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;

            }
            
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Mevcut Borç")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
                
            }
        }

        private void kullaniciekleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
