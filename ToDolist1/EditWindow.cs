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

namespace ToDolist1
{
    public partial class EditWindow : Form
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;

        private int TaskID;
        private int UserID;
        public EditWindow(int TaskID, int UserID)
        {
            InitializeComponent();
            Form1.SetRoundedShape(trashButton, 10);
            Form1.SetRoundedShape(panel2, 25);
            Form1.SetRoundedShape(button1, 10);
            this.BackColor = Color.FromArgb(225, 244, 255);
            panel1.BackColor = Color.FromArgb(176, 227, 255);

            this.TaskID = TaskID;
            this.UserID = UserID;
        }

        private void EditWindow_Load(object sender, EventArgs e)
        {
            Task task = new Task();
            task = task.GetUserTask(this.UserID, this.TaskID);

            textBox1.Text = task.Title;
            richTextBox1.Text = task.Description;
            dateTimePicker1.Value = Convert.ToDateTime(task.Deadline);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            
            task.TaskID = this.TaskID;
            task.Title = textBox1.Text;
            task.Description = richTextBox1.Text;
            task.Deadline = dateTimePicker1.Value.ToString();

            task.EditUserTask(this.UserID, task);

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trashButton_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.DeleteUserTask(this.UserID, this.TaskID);
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }
    }
}
