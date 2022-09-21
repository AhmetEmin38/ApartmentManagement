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
    public partial class binayarForm : Form
    {
        SqlConnection connection = girisForm.connection;
        public binayarForm()
        {
            InitializeComponent();
        }
        kayitForm frm = new kayitForm();
        private void button1_Click(object sender, EventArgs e)
        {
                
            
            try
            {
                List<string> isimler = new List<string>();
                isimler = richTextBox1.Text.Split(' ').ToList();
                connection.Open();
                
                Thread.Sleep(1000);
                
                foreach (var item in isimler)
                {
                    SqlCommand command = new SqlCommand("Insert into dairelerveborclar (dairead,toplamborc,daireID,tarih) values ('" + item + "','" + 0 + "','"+kayitForm.hesapID+"','"+ DateTime.UtcNow.ToString("d") +"')", connection);
                   
                    
                    command.ExecuteNonQuery();
                }

                connection.Close();
                MessageBox.Show("Kaydınız Tamamlanmıştır");
                islemlerForm frm2 = new islemlerForm();
                this.Hide();
                frm2.Show();
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
            }
            
        }

        private void binayarForm_Load(object sender, EventArgs e)
        {

        }
    }
}
