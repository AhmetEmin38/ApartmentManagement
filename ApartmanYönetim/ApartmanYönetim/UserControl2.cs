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
using System.Reflection.Emit;
using System.Net.Configuration;

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

        public void baslangıc()
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

                SqlCommand cmd = new SqlCommand("Select *from dairelerveborclar where daireID='" + girisForm.kullaniciID + "'", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //label2.Text = dr["username"].ToString();
                    DateTime dt = DateTime.Now;

                    DateTime appDate = DateTime.Parse(dr["tarih"].ToString());

                }

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


                SqlCommand cmd2 = new SqlCommand("Select *from dairelerveborclar where daireID='" + kayitForm.hesapID + "'", connection);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    DateTime dt = DateTime.Now;
                    DateTime appDate = DateTime.Parse(dr2["tarih"].ToString());


                }
                connection.Close();
            }




        }

        private async void button1_Click(object sender, EventArgs e)
        {




            if (button1.Text == "Verileri Değiştir")
            {
                dataGridView1.ReadOnly = false;
                button1.Text = "Değişiklikleri Kaydet";
                button2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                comboBox1.Visible = true;
                label2.Visible = true;
                txtBorc.Visible = true;

                button7.Visible = true;

                if (islemlerForm.giristenmi == true)
                {


                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select *from dairelerveborclar where daireID='" + girisForm.kullaniciID + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    comboBox1.Items.Clear();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["dairead"]);
                    }
                    dr.Close();

                    connection.Close();








                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select *from dairelerveborclar where daireID='" + kayitForm.hesapID + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    comboBox1.Items.Clear();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["dairead"]);
                    }
                    dr.Close();


                }

            }
            else
            {
                connection.Open();
                da.Update(ds, "dairelerveborclar");
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
                comboBox1.Visible = false;
                label2.Visible = false;
                txtBorc.Visible = false;

                button7.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
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
                DialogResult durum = MessageBox.Show(isim + " Kaydını Silmek istediğinizden emin misiniz", "Program", MessageBoxButtons.YesNo);
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
                SqlCommand command = new SqlCommand(kayit, connection);
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

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtBorc_Click(object sender, EventArgs e)
        {
            if (txtBorc.Text == "Mevcut Borç")
            {
                txtBorc.Text = "";
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (islemlerForm.giristenmi == true)
            {



                SqlCommand command = new SqlCommand("Select *from dairelerveborclar where daireID='" + girisForm.kullaniciID + "' and dairead='" + comboBox1.Text + "'", connection);




                connection.Open();
                if (comboBox1.Text != "")
                {

                }
                SqlDataReader dr2 = command.ExecuteReader();
                if (dr2.Read())
                {
                    txtBorc.Text = dr2["toplamborc"].ToString();

                }
                connection.Close();

                dr2.Close();




            }
            else
            {

                SqlCommand command = new SqlCommand("Select *from dairelerveborclar where daireID='" + kayitForm.hesapID + "' and dairead='" + comboBox1.Text + "'", connection);

                SqlDataReader dr2 = command.ExecuteReader();
                if (dr2.Read())
                {
                    txtBorc.Text = dr2["toplamborc"].ToString();

                }
                connection.Close();

                dr2.Close();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update dairelerveborclar set toplamborc=@toplamborc where dairead=@dairead",connection);
            command.Parameters.AddWithValue("@toplamborc", txtBorc.Text);
            command.Parameters.AddWithValue("@dairead", comboBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncelleme Tamamlandı");
            baslangıc();

        }
        
    }
}
