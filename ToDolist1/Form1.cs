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
            SetRoundedShape(panel5, 25);
            SetRoundedShape(panel4, 25);
            SetRoundedShape(button2, 25);
            SetRoundedShape(button1, 10);
            SetRoundedShape(panel2, 25);
            SetRoundedShape(panel3, 25);
            //SetRoundedShape(panel6, 25);
            this.BackColor = Color.FromArgb(225, 244, 255);
            panel5.BackColor = Color.FromArgb(210, 227, 236);
            panel2.BackColor = Color.FromArgb(210, 227, 236);
            //panel6.BackColor = Color.FromArgb(210, 227, 236);
            panel1.BackColor = Color.FromArgb(176, 227, 255);
            textBox1.ForeColor = Color.FromArgb(115, 188, 255);
            textBox2.ForeColor = Color.FromArgb(115, 188, 255);
            button2.BackColor = Color.FromArgb(175, 217, 255);
            button2.ForeColor = Color.FromArgb(15, 128, 232);
            label2.ForeColor = Color.FromArgb(15, 128, 232);
            button2.FlatAppearance.BorderSize = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-FA33UUU;Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            this.Controls.Add(create);
            create.Hide();
            
        }

        public static void SetRoundedShape(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
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
                    label1.ForeColor = Color.Red;
                    label1.Text = "Invalid login or password";
                    dr.Close();
                    //MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Invalid login or password";
                //MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            create.Show();
            create.BringToFront();
            create.Location = new Point(0, 50);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Login")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MN.Close();
            con.Close();
        }
    }
}
