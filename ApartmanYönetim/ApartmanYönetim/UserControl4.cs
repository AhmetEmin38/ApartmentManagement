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

namespace ApartmanYönetim
{
    
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }
        SqlConnection connection = girisForm.connection;
        private void button1_Click(object sender, EventArgs e)
        {
            duyuruForm form = new duyuruForm();
            //this.Hide();
            form.Show();
        }
        
        private void UserControl4_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public void duyuru()
        {
            
            flowLayoutPanel1.Controls.Clear();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            SqlCommand command = new SqlCommand("select *from duyurular where id=@id", connection);
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                GroupBox grp = new GroupBox();
                grp.Size = new Size(212, 107);

                Label lbl = new Label();
                lbl.AutoSize = false;
                Label lbl2 = new Label();
                lbl.Location = new Point(6, 11);
                lbl2.Location = new Point(7, 75);
                lbl.Size = new Size(178, 30);
                lbl2.Size = new Size(199, 23);
                lbl.ForeColor = Color.Cyan;
                lbl2.ForeColor = Color.LightGray;
                string title;
                lbl.Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold);
                lbl2.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
                string message;
                grp.Controls.Add(lbl);
                grp.Controls.Add(lbl2);
                title = dr["baslik"].ToString();
                message = dr["message"].ToString();
                lbl.Text = title;
                lbl2.Text = message;
                grp.Name = title;
                grp.AccessibleDescription = message;
                flowLayoutPanel1.Controls.Add(grp);
                lbl.Name = title;
                lbl.AccessibleDescription = message;
                lbl2.Name = title;
                lbl2.AccessibleDescription = message;
                grp.Click += Grp_Click;
                lbl.Click += Lbl_Click;
                
                lbl2.Click += Lbl2_Click;
                
            }
            connection.Close();
            
            
            

        }

        private void Lbl2_Click(object sender, EventArgs e)
        {
            Label lbl2 = (Label)sender;
            connection.Open();

            SqlCommand command = new SqlCommand("select *from duyurular where id=@id");
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                label5.Text = lbl2.Name;
                label6.Text = lbl2.AccessibleDescription;
            }
            connection.Close();
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            connection.Open();

            SqlCommand command = new SqlCommand("select *from duyurular where id=@id");
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                label5.Text = lbl.Name;
                label6.Text = lbl.AccessibleDescription;
            }
            connection.Close();
        }

        private void Grp_Click(object sender, EventArgs e)
        {
            GroupBox grp = (GroupBox)sender;
            connection.Open();
            
            SqlCommand command = new SqlCommand("select *from duyurular where id=@id");
            command.Parameters.AddWithValue("@id", girisForm.kullaniciID);
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            
            if (dr.Read())
            {
                label5.Text = grp.Name;
                label6.Text = grp.AccessibleDescription;
            }
            connection.Close();
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            duyuru();
        }
    }
}
