using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
namespace ToDolist1
{
    public partial class Form1 : Form
    {

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        Create create = Create.instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-BIO9OQ1;Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            this.Controls.Add(create);
            create.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                cmd = new SqlCommand("select * from Users where Name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    Program.MN.Visible = true;
                    Program.MN.ShowInTaskbar = true;
                    Program.MN.Activate();
                    this.Close();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            create.Show();
            create.BringToFront();
            create.Location = new Point(0, 50);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MN.Close();
            con.Close();
        }
    }
}
