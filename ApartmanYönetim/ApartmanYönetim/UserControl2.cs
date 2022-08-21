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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        SqlConnection connection = girisForm.connection;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdb;
        private BindingSource bs = new BindingSource();
        private void UserControl2_Load(object sender, EventArgs e)
        {
            baslangıc();
            datagridStyle();
        }

        void datagridStyle()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30);
            dataGridView1.BackgroundColor = Color.FromArgb(44, 44, 44);
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        void baslangıc()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            
            if (girisForm.kullaniciID != "")
            {
                Thread.Sleep(1500);
                connection.Open();
                da = new SqlDataAdapter("Select *from dairelerveborclar where daireID='" + girisForm.kullaniciID + "'", connection);
                cmdb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "dairelerveborclar");
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            else if (girisForm.kullaniciID == "")
            {
                connection.Open();
                da = new SqlDataAdapter("Select *from dairelerveborclar where daireID='" + kayitForm.hesapID + "'", connection);
                cmdb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "dairelerveborclar");
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text == "Verileri Değiştir")
            {
                dataGridView1.ReadOnly = false;
                button1.Text = "Değişiklikleri Kaydet";
                button2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                
            }
            else
            {
                connection.Open();
                da.Update(ds, "dairelerveborclar") ;
                MessageBox.Show("Değişim Tamamlandı", "Program");
                dataGridView1.ReadOnly = true;
                button2.Visible = false;
                button4.Visible = false;
                connection.Close();
                button1.Text = "Verileri Değiştir";
                label1.Visible = false;
                textBox1.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string secmeSorgusu = "SELECT * from dairelerveborclar where dairead=@dairead";
            SqlCommand komut = new SqlCommand(secmeSorgusu, connection);
            komut.Parameters.AddWithValue("@dairead", dataGridView1.CurrentCell.Value.ToString());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                string isim = dr["dairead"].ToString();
                dr.Close();
                DialogResult durum = MessageBox.Show(isim + " Kaydını Silmek istediğinizden emin misiniz","Program",MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    string silmeSorgusu = "DELETE from dairelerveborclar where dairead=@dairead";
                    SqlCommand silmeKomutu = new SqlCommand(silmeSorgusu, connection);
                    silmeKomutu.Parameters.AddWithValue("@dairead", dataGridView1.CurrentCell.Value.ToString());
                    silmeKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi");
                    baslangıc();
                }
            }
            else
            {
                MessageBox.Show("Daire Bulunamadı");
                connection.Close();
            }
            //dataGridView1.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
              //this.dataGridView1.SelectedRows[0].Index
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            baslangıc();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kullaniciekleForm kullaniciekleform = new kullaniciekleForm();
            kullaniciekleform.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button6.Visible = true;
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            connection.Open();
            int eklenen = Convert.ToInt32(textBox1.Text);
            if (islemlerForm.kayittanmi == true)
            {

                string kayit = "update dairelerveborclar set toplamborc = toplamborc + @eklenen where daireID=@daireID";
                SqlCommand command = new SqlCommand(kayit, connection);
                command.Parameters.AddWithValue("@eklenen", eklenen);
                command.Parameters.AddWithValue("@daireID", kayitForm.hesapID);
                //SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
            }
            else if (islemlerForm.giristenmi == true)
            {
                string kayit = "update dairelerveborclar set toplamborc = toplamborc + @eklenen where daireID=@daireID";
                SqlCommand command = new SqlCommand(kayit,connection);
                command.Parameters.AddWithValue("@eklenen", eklenen);
                command.Parameters.AddWithValue("@daireID", girisForm.kullaniciID);
                //SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                
                

                

            }
            connection.Close();
            textBox1.Visible = false;
            label1.Visible = false;
            button6.Visible = false;
            baslangıc();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
