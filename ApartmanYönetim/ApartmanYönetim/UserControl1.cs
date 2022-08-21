﻿using System;
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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdb;


        private void button1_Click(object sender, EventArgs e)
        {
            islemlerForm frm = new islemlerForm();
            frm.Show();
        }
        girisForm frm = new girisForm();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection connection = girisForm.connection;
        private void UserControl1_Load(object sender, EventArgs e)
        {

            baslangic();
            


        }

        void baslangic()
        {
            connection.Open();
            if (islemlerForm.giristenmi == true)
            {
                //da = new SqlDataAdapter("Select *from apartmanyonet where userID='"+girisForm.kullaniciID+"'", connection);
                SqlCommand cmd = new SqlCommand("Select *from apartmanyonet where userID='" + girisForm.kullaniciID + "'", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label2.Text = dr["username"].ToString();
                    //label1.Text = dr["KolonAdi"].ToString();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select *from apartmanyonet where userID='" + kayitForm.hesapID + "'", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label2.Text = dr["username"].ToString();
                    //label1.Text = dr["KolonAdi"].ToString();
                }
                //da = new SqlDataAdapter("Select *from apartmanyonet where userID='" + kayitForm.hesapID + "'", connection);
            }

            //cmdb = new SqlCommandBuilder(da);
            //ds = new DataSet();
            //da.Fill(ds, "apartmanyonet");
            //dataGridView1.DataSource = ds.Tables[0];
            connection.Close();



            //connection.Open();
            //SqlCommand command = new SqlCommand("Select aidat from apartmanyonetici where username='"+girisForm.username+"'", connection);
            //textBox1.Text = command.ExecuteScalar().ToString();
            //SqlCommand command2 = new SqlCommand("Select dogalgaz from apartmanyonetici where username='"+girisForm.username+"'", connection);
            //textBox2.Text = command2.ExecuteScalar().ToString();
            //connection.Close();



            //MessageBox.Show("Bir hata oluştu" + ex.Message);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //girisForm form = new girisForm();
            //try
            //{
            //    if (girisForm.username != "")
            //    {
            //        connection.Open();
            //        SqlCommand command3 = new SqlCommand("update apartmanyonet set aidat='" + textBox1.Text + "',dogalgaz='" + textBox2.Text + "' where username='" + girisForm.username + "'");
                    

            //        MessageBox.Show("Değişim has completed");
            //        connection.Close();
            //    }
            //    else
            //    {
            //        connection.Open();
            //        SqlCommand command3 = new SqlCommand("update apartmanyonet set aidat='" + textBox1.Text + "',dogalgaz='" + textBox2.Text + "' where username='" + kayitForm.username + "'");


            //        MessageBox.Show("Değişim has completed");
            //        connection.Close();
            //    }

                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}
            
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Visible == false)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                button2.Visible = false;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (islemlerForm.giristenmi == true)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update apartmanyonet set username=@username, password=@password where userID='" + girisForm.kullaniciID + "'",connection);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update apartmanyonet set username=@username, password=@password where userID='" + kayitForm.hesapID + "'",connection);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            
            MessageBox.Show("Kullanıcı adı ve şifre değiştirildi", "Program");
            textBox1.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            baslangic();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Visible == true)
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                button4.Visible = false;
            }
            else
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                button4.Visible = true;
                connection.Open();
                if (islemlerForm.giristenmi = true)
                {
                    SqlCommand command = new SqlCommand("Select *from apartmanyonet where userID='" + girisForm.kullaniciID + "'", connection);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox3.Text = dr["aidat"].ToString();
                        textBox4.Text = dr["dogalgaz"].ToString();
                    }

                }
                else
                {
                    SqlCommand command = new SqlCommand("Select *from apartmanyonet where userID='" + kayitForm.hesapID + "'", connection);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox3.Text = dr["aidat"].ToString();
                        textBox4.Text = dr["dogalgaz"].ToString();
                    }
                }
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (islemlerForm.giristenmi = true)
            {
                SqlCommand command = new SqlCommand("update apartmanyonet set aidat=@aidat, dogalgaz=@dogalgaz where userID='" + girisForm.kullaniciID + "'", connection);
                command.Parameters.AddWithValue("@aidat", textBox3.Text);
                command.Parameters.AddWithValue("@dogalgaz", textBox4.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Değişim Tamamlandı");
            }
            else
            {
                SqlCommand command = new SqlCommand("update apartmanyonet set aidat=@aidat, dogalgaz=@dogalgaz where userID='" + kayitForm.hesapID + "'", connection);
                command.Parameters.AddWithValue("@aidat", textBox3.Text);
                command.Parameters.AddWithValue("@dogalgaz", textBox4.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Değişim Tamamlandı");
            }
            connection.Close();
            
        }
    }
}
