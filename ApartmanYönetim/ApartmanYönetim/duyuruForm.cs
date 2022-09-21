using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanYönetim
{
    public partial class duyuruForm : Form
    {
        public duyuruForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        SqlConnection connection = girisForm.connection;
        int mouse_X;
        int mouse_Y;
        int move;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_X, MousePosition.Y - mouse_Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            mouse_X = e.X;
            mouse_Y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (islemlerForm.giristenmi == true)
            {
                
                connection.Open();
                SqlCommand command = new SqlCommand("insert into duyurular (baslik,message,id) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + girisForm.kullaniciID + "')");
                command.Connection = connection;
                //SqlCommand command = new SqlCommand("insert into duyurular baslik=@baslik, message=@message, id=@id", connection);
                //command.Parameters.AddWithValue("@baslik", textBox1.Text);
                //command.Parameters.AddWithValue("@message", textBox2.Text);
                //command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
                command.ExecuteNonQuery();
                MessageBox.Show("Duyuru Başarıyla Yayınlandı");
                
                

            }
            else
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into duyurular (baslik,message,id) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + kayitForm.hesapID + "')");
                command.Connection = connection;
                //command.Parameters.AddWithValue("@baslik", textBox1.Text);
                //command.Parameters.AddWithValue("@message", textBox2.Text);
                //command.Parameters.AddWithValue("@id", kayitForm.hesapID);
                command.ExecuteNonQuery();
                MessageBox.Show("Duyuru Başarıyla Yayınlandı");
               
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //islemlerForm form = new islemlerForm();
            this.Hide();
            //form.ShowDialog();
            
        }
    }
}
