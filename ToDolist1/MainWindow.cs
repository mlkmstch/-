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
            this.BackColor = Color.FromArgb(244, 251, 255);
            panel1.BackColor = Color.FromArgb(205, 237, 255);
            panel3.BackColor = Color.FromArgb(244, 251, 255);
            
        }
        

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Form1 SignWindow = new Form1();
            SignWindow.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
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
        private void panels1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            
            using (GraphicsPath path = new GraphicsPath())
            {
                int cornerRadius = 10; 
                
                

                
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color fillColor = Color.FromArgb(154, 206, 254);
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                   
                    g.FillPath(brush, path);
                }
            }
        }
        private void panels2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            
            using (GraphicsPath path = new GraphicsPath())
            {
                int cornerRadius = 10; 
               

                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color fillColor = Color.FromArgb(244, 251, 255);
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    g.FillPath(brush, path);
                }
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;

            
            using (GraphicsPath path = new GraphicsPath())
            {
                int cornerRadius = 20; 

                
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); 
                path.AddArc(panel3.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); 
                path.AddArc(panel3.Width - cornerRadius, panel3.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel3.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); 
                path.CloseFigure();

                
                g.SmoothingMode = SmoothingMode.AntiAlias;
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddWindow addwindow = new AddWindow(userID);
            addwindow.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
