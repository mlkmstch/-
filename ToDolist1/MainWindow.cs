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
        public MainWindow()
        {

            Program.MN = this;
            InitializeComponent();
            this.BackColor = Color.FromArgb(225, 244, 255);
            panel1.BackColor = Color.FromArgb(176, 227, 255);
            Form1.SetRoundedShape(button1, 10);
            Form1.SetRoundedShape(button2, 10);
            Form1.SetRoundedShape(panel10, 25);
            Form1.SetRoundedShape(panel2, 25);
            Form1.SetRoundedShape(panel3, 25);
            Form1.SetRoundedShape(panel4, 25);
            Form1.SetRoundedShape(panel5, 25);
            Form1.SetRoundedShape(dataGridView1, 25);
            monthCalendar1.BringToFront();
            panel3.BackColor = Color.FromArgb(210, 227, 236);
            panel4.BackColor = Color.FromArgb(210, 227, 236);
            panel5.BackColor = Color.FromArgb(210, 227, 236);

            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
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

        private void FillGridView()
        {
            Task task = new Task();
            List<Task> tasks = task.getUserTasks(userID);

            dataGridView1.DataSource = tasks;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void MainWindow_Activated(object sender, EventArgs e)
        {
            FillGridView();
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

        private void avatar_Click(object sender, EventArgs e)
        {

        }
            AddWindow addwindow = new AddWindow(userID);
            addwindow.Show();


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            string connectionString = "Data Source=DESKTOP-FA33UUU;Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
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
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Установите фильтр для диалогового окна открытия файла, чтобы пользователь мог выбрать только изображения
            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp;*.jfif)|*.jpg;*.jpeg;*.png;*.bmp;*.jfif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получите путь к выбранному файлу
                string imagePath = openFileDialog.FileName;

                // Загрузите изображение в PictureBox
                avatar.Image = Image.FromFile(imagePath);
            }
        }
    }
}
