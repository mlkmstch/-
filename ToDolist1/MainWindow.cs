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

        public static int userID;

        public MainWindow()
        {
            Program.MN = this;
            InitializeComponent();
            this.BackColor = Color.FromArgb(244, 251, 255);
            panel1.BackColor = Color.FromArgb(205, 237, 255);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Form1 SignWindow = new Form1();
            SignWindow.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddWindow addwindow = new AddWindow(userID);
            addwindow.Show();
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
}
