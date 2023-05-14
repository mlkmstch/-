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
            this.BackColor = Color.FromArgb(244, 251, 255);
            Form1.SetRoundedShape(textBox1, 25);
            Form1.SetRoundedShape(textBox2, 25);
            Form1.SetRoundedShape(textBox3, 25);
            Form1.SetRoundedShape(button2, 25);
            textBox1.ForeColor = Color.FromArgb(195, 227, 255);
            textBox2.ForeColor = Color.FromArgb(195, 227, 255);
            textBox3.ForeColor = Color.FromArgb(195, 227, 255);

            button2.BackColor = Color.White;
            button2.ForeColor = Color.FromArgb(15, 128, 232);
            label2.ForeColor = Color.FromArgb(15, 128, 232);
            button2.FlatAppearance.BorderSize = 0;

        }

        private void Create_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-FA33UUU;Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    cmd = new SqlCommand("select * from Users where Name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Users values(@username,@password)", con);
                        cmd.Parameters.AddWithValue("username", textBox1.Text);
                        cmd.Parameters.AddWithValue("password", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Form1.Show();
            this.Hide();
            //create.Location = new Point(0, 50);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
