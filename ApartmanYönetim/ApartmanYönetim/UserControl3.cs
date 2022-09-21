using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;

namespace ApartmanYönetim
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        SqlConnection connection = girisForm.connection;
        private async void UserControl3_Load(object sender, EventArgs e)
        {
            
        }
        
        public  void mesajCekme()
        {
            
            flowLayoutPanel1.Controls.Clear();
            Thread.Sleep(1000);
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from gelenistekler where id=@id", connection);
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                GroupBox group = new GroupBox();
                string username;
                string message;
                Label label = new Label();
                label.ForeColor = Color.Cyan;
                label.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
                label.Text = dr["username"].ToString();
                label.Location = new Point(5, 16);
                username = dr["username"].ToString();


                Label label2 = new Label();
                label2.ForeColor = Color.LightGray;
                label2.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
                label2.Text = dr["message"].ToString() + "...";
                label2.AutoSize = false;
                label2.Size = new Size(170, 21);
                message = dr["message"].ToString();
                label2.Location = new Point(3, 72);

                group.Controls.Add(label);
                group.Controls.Add(label2);




                group.Name = username;

                group.AccessibleDescription = message;
                label.Name = username;
                label.AccessibleDescription = message;
                label2.Name = username;
                label2.AccessibleDescription = message;

                flowLayoutPanel1.Controls.Add(group);
                group.Click += Group_Click;
                label.Click += Label_Click1;
                label2.Click += Label2_Click;

            }
            connection.Close();
            
            
            
           
        }

        private void Label_Click1(object sender, EventArgs e)
        {
            Label label = (Label)sender;


            connection.Open();
            SqlCommand command = new SqlCommand("Select *from gelenistekler where id=@id", connection);
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                label5.AutoSize = false;
                label6.AutoSize = false;
                label6.Size = new Size(704, 519);
                label5.Text = label.Name;
                label6.Text = label.AccessibleDescription;
            }
            connection.Close();
        }

        

        private void Label2_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;


            connection.Open();
            SqlCommand command = new SqlCommand("Select *from gelenistekler where id=@id", connection);
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                label5.AutoSize = false;
                label6.AutoSize = false;
                label6.Size = new Size(704, 519);
                label5.Text = label.Name;
                label6.Text = label.AccessibleDescription;
            }
            connection.Close();
        }

        

        private async void Group_Click(object sender, EventArgs e)
        {
            
            GroupBox group2 = (GroupBox)sender;


            connection.Open();
            SqlCommand command = new SqlCommand("Select *from gelenistekler where id=@id", connection);
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                label5.AutoSize = false;
                label6.AutoSize = false;
                label6.Size = new Size(704, 519);
                label5.Text = group2.Name;
                label6.Text = group2.AccessibleDescription;
            }
            connection.Close();
            
            
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mesajCekme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mesajCekme();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
