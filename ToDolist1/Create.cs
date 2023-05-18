using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ToDolist1
{
    public partial class Create : UserControl
    {
        private static Create _instance;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        public static Create instance
        {
            get
            {
                if (_instance == null) _instance = new Create();
                return _instance;
            }
        }
        public Create()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(225, 244, 255);
            Form1.SetRoundedShape(panel1, 25);
            Form1.SetRoundedShape(panel2, 25);
            Form1.SetRoundedShape(panel3, 25);
            Form1.SetRoundedShape(panel4, 25);
            Form1.SetRoundedShape(panel5, 25);
            Form1.SetRoundedShape(panel6, 25);
            Form1.SetRoundedShape(button2, 25);
            textBox5.ForeColor = Color.FromArgb(115, 188, 255);
            textBox2.ForeColor = Color.FromArgb(115, 188, 255);
            textBox1.ForeColor = Color.FromArgb(115, 188, 255);

            panel2.BackColor = Color.FromArgb(210, 227, 236);
            panel5.BackColor = Color.FromArgb(210, 227, 236);
            panel6.BackColor = Color.FromArgb(210, 227, 236);
            panel7.BackColor = Color.FromArgb(95, 160, 221);

            button2.BackColor = Color.FromArgb(175, 217, 255);
            button2.ForeColor = Color.FromArgb(15, 128, 232);
            label2.ForeColor = Color.FromArgb(15, 128, 232);
            button2.FlatAppearance.BorderSize = 0;

        }

        private void Create_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=" + System.Environment.MachineName +";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != string.Empty || textBox2.Text != string.Empty || textBox1.Text != string.Empty)
            {
                if (textBox2.Text == textBox1.Text)
                {
                    cmd = new SqlCommand("select * from Users where Name='" + textBox5.Text + "' and Password='" + textBox1.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        label1.ForeColor = Color.Red;
                        label1.Location = new Point(33, 290);
                        label1.Text = "Username Already exist please try another";
                        //MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Users values(@username,@password,@profilepicture)", con);
                        cmd.Parameters.AddWithValue("username", textBox5.Text);
                        cmd.Parameters.AddWithValue("password", textBox2.Text);
                        cmd.Parameters.AddWithValue("profilepicture", "");
                        cmd.ExecuteNonQuery();
                        this.Hide();
                    }
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Location = new Point(65, 290);
                    label1.Text = "Please enter both password same";
                    //MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Location = new Point(83, 290);
                label1.Text = "Please enter value in all field";
                //MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Form1.Show();
            this.Hide();
            //create.Location = new Point(0, 50);
        }


        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Login")
            {
                textBox5.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
            {
                textBox1.Text = "";
            }
        }
    }
}
