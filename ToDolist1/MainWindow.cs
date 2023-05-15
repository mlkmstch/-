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
            SetRoundedShape(panel3,25);
            SetRoundedShape(panel4, 10);
            SetRoundedShape(panel5, 10);
            SetRoundedShape(panel6, 10);
            SetRoundedShape(panel7, 10);
            SetRoundedShape(panel8, 10);
            SetRoundedShape(panel9, 10);
            SetRoundedShape(comboBox1, 10);
            SetRoundedShape(panel2, 10);
            SetRoundedShape(textBox1, 10);
            SetRoundedShape(button1, 25);
            SetRoundedShape(button2, 15);
            SetRoundedShape(Completed, 25);
            SetRoundedShape(Achievements, 25);
            this.BackColor = Color.FromArgb(244, 251, 255);
            panel1.BackColor = Color.FromArgb(205, 237, 255);
            panel3.BackColor = Color.FromArgb(154, 206, 254);
            panel4.BackColor = Color.FromArgb(154, 206, 254);
            panel5.BackColor = Color.FromArgb(154, 206, 254);
            panel6.BackColor = Color.FromArgb(244, 251, 255);
            panel7.BackColor = Color.FromArgb(244, 251, 255);
            panel8.BackColor = Color.FromArgb(154, 206, 254);
            panel9.BackColor = Color.FromArgb(244, 251, 255);
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
        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
                Color fillColor = Color.FromArgb(154, 206, 254);
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    
                    g.FillPath(brush, path);
                }
            }
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
    }
}
