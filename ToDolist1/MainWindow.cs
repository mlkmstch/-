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
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http;
using System.Collections;

namespace ToDolist1
{
    public partial class MainWindow : Form
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

        public static int userID;

        private static String combostatus = null;
        private static String search = "";
        public MainWindow()
        {

            Program.MN = this;
            InitializeComponent();

            this.BackColor = Color.FromArgb(225, 244, 255);

            Form1.SetRoundedShape(button1, 10);
            Form1.SetRoundedShape(button2, 10);
            Form1.SetRoundedShape(panel10, 25);
            Form1.SetRoundedShape(panel2, 25);
            Form1.SetRoundedShape(panel3, 25);
            Form1.SetRoundedShape(panel4, 25);
            Form1.SetRoundedShape(panel5, 25);
            Form1.SetRoundedShape(dataGridView1, 25);
            Form1.SetRoundedShape(panel7, 25);
            Form1.SetRoundedShape(panel8, 25);

            monthCalendar1.BringToFront();

            panel1.BackColor = Color.FromArgb(176, 227, 255);
            panel3.BackColor = Color.FromArgb(210, 227, 236);
            panel4.BackColor = Color.FromArgb(210, 227, 236);
            panel5.BackColor = Color.FromArgb(210, 227, 236);
            panel7.BackColor = Color.FromArgb(210, 227, 236);
            panel9.BackColor = Color.FromArgb(95, 160, 221);
            panel6.BackColor = Color.FromArgb(57, 128, 194);

            comboBox1.Height = 40;

            
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            Form1 SignWindow = new Form1();
            SignWindow.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
            comboBox1.FlatStyle = FlatStyle.Flat;
            Completed.FlatStyle = FlatStyle.Flat;
            Achievements.FlatStyle = FlatStyle.Flat;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combostatus = comboBox1.SelectedItem.ToString();
            FillGridView(combostatus, search);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search = textBox1.Text.Trim();
            FillGridView(combostatus, search);
        }
        private void FillGridView(String combostatus, String search)
        { 
            Task task = new Task();
            List<Task> tasks = task.getUserTasks(userID);
            if (tasks.Count >= 5)
            {
                string connectionString = "Data Source=" + System.Environment.MachineName + ";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("update Achievements set IsCompleted='1' from Achievements where UserID='" + userID.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            List<Task> SortedTasks = new List<Task>();
            if (search != "")
            {
                foreach (Task t in tasks)
                {
                    if (t.Title.Contains(search))
                    {
                        SortedTasks.Add(t);
                    }
                }
            }
            else { SortedTasks = tasks; }
            switch (combostatus)
            {
                case "Name":
                    SortedTasks = SortedTasks.OrderBy(o => o.Title).ToList();
                    dataGridView1.DataSource = SortedTasks;
                    break;
                case "Deadline":
                    SortedTasks = SortedTasks.OrderBy(o => o.Deadline).ToList();
                    dataGridView1.DataSource = SortedTasks;
                    break;
                case null:
                    dataGridView1.DataSource = SortedTasks;
                    break;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            FillGridView(combostatus, search);
            avatar.Image = ProfilePic();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int taskID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            EditWindow editwindow = new EditWindow(taskID, userID);
            editwindow.Show();
        }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddWindow addwindow = new AddWindow(userID);
            addwindow.Show();
        }

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        private void Usermane_Click(object sender, EventArgs e)
        {

        }
        private void Achievements_Click(object sender, EventArgs e)
        {
            Achievements achievements = new Achievements(userID);
            achievements.Show();
        }
        private void addButton_Click(object sender, EventArgs e)
        {

        }
            AddWindow addwindow = new AddWindow(userID);
            addwindow.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search")
            {
                textBox1.Text = "";
            }
        }

        private void Username_Paint(object sender, PaintEventArgs e)
        {
            string connectionString = "Data Source=" + System.Environment.MachineName + ";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select Name from Users where UserID='" + userID.ToString() + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Username.Text = dr["Name"].ToString();
            }
            dr.Close();
        }

        private void avatar_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "Data Source=" + System.Environment.MachineName + ";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                cmd = new SqlCommand("update Users set ProfilePicture='" + imagePath + "' Where UserID='" + userID.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                avatar.Image = ProfilePic();
            }

        }
        private Image ProfilePic()
        {

            string connectionString = "Data Source=" + System.Environment.MachineName + ";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select ProfilePicture from Users where UserID='" + userID.ToString() + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {   
                String imagePath = dr[0].ToString();
                dr.Close();
                if (imagePath != "")
                {
                    return Image.FromFile(imagePath);
                }
            }
            return null;
        }

        private void avatar_MouseHover(object sender, EventArgs e)
        {
            avatar.Image=ProfilePic();
        }

        

        /*private void avatar_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "Data Source=" + System.Environment.MachineName + ";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData;
                using (System.IO.FileStream fs = new System.IO.FileStream(imagePath, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                    fs.Close();
                }
                cmd = new SqlCommand("update Users set ProfilePicture='" + imageData + "' Where UserID='"+userID.ToString()+"'", con);
                cmd.ExecuteNonQuery();
                ProfilePic();
            }

        }



        private void ProfilePic()
        {

            string connectionString = "Data Source=" + System.Environment.MachineName +";Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select ProfilePicture from Users where UserID='" + userID.ToString() + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                object obj = dr["ProfilePicture"];

                byte[] data = (byte[])obj;
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        avatar.Image = Image.FromStream(ms);
                    }
                }
            }
            try
            {
                if (dr.Read())
                {
                    /*Byte[] byteArrayIn = Convert.ToByte((dr["Pfp"]));
                    Console.WriteLine(byteArrayIn.ToString());
                    using (var ms = new MemoryStream(byteArrayIn))
                    {
                        return Image.FromStream(ms);
                    }
                    byte[] data = (byte[])dr["Pfp"];
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch (Exception) { Console.WriteLine("222222222"); }
            con.Close();
            return null;
        }*/

    }
}
