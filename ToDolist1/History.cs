using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace ToDolist1
{
    public partial class History : Form
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;

        private int UserID;
        public History(int UserID)
        {
            this.UserID = UserID;
            InitializeComponent();
            Form1.SetRoundedShape(button1, 10);
            this.BackColor = Color.FromArgb(225, 244, 255);
            panel1.BackColor = Color.FromArgb(176, 227, 255);
            panel3.BackColor = Color.FromArgb(95, 160, 221);
        }
        private void Achievements_Load(object sender, EventArgs e)
        {

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

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FillGridView()
        {
            Task task = new Task();
            List<Task> tasks = task.getUserTasks(UserID);
            List<Task> SortedTasks = new List<Task>();
            foreach (Task t in tasks)
            {
                if (t.Completed == true)
                {
                    SortedTasks.Add(t);
                }
            }
            SortedTasks = SortedTasks.OrderBy(o => o.Deadline).ToList();
            label2.Text="Amount of completed: "+SortedTasks.Count.ToString();
            dataGridView1.DataSource = SortedTasks;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

        }
        private void History_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                int taskID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                Task task = new Task();
                bool state = (bool)dataGridView1.CurrentRow.Cells[4].Value;
                task.UpdateTaskState(UserID, taskID, !state);
                FillGridView();
            }
        }
    }
}
