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
    public partial class islemlerForm : Form
    {
        public static bool giristenmi = false;
        public static bool kayittanmi = false;
        public islemlerForm()
        {
            
            InitializeComponent();
            if (girisForm.kullaniciID != "")
            {
                giristenmi = true;
            }
            else
            {
                kayittanmi = true;
            }


        }
        int move;
        int mouse_X;
        int mouse_Y;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        girisForm frm = new girisForm();
        SqlConnection connection = girisForm.connection;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(750);
            frm.Show();
            connection.Close();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {
            userControl11.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            userControl21.Hide();
            userControl11.Show();
            userControl31.Hide();
            userControl41.Hide();
            
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public static void giristengelis()
        {
            //girisForm.kullaniciID
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl41.Show();
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Show();
            userControl31.Hide();
            userControl41.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Show();
            userControl41.Hide();
        }

        private void islemlerForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
