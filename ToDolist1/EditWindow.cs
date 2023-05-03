using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDolist1
{
    public partial class EditWindow : Form
    {
        private int TaskID;
        private int UserID;
        public EditWindow(int TaskID, int UserID)
        {
            InitializeComponent();
            this.TaskID = TaskID;
            this.UserID = UserID;
        }

        private void EditWindow_Load(object sender, EventArgs e)
        {
            Task task = new Task();
            task = task.GetUserTask(this.UserID, this.TaskID);

            textBox1.Text = task.Title;
            richTextBox1.Text = task.Description;
            Console.WriteLine(task.Deadline);
            dateTimePicker1.Value = Convert.ToDateTime(task.Deadline);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            
            task.TaskID = this.TaskID;
            task.Title = textBox1.Text;
            task.Description = textBox1.Text;
            task.Deadline = dateTimePicker1.Value.ToString();

            task.EditUserTask(this.UserID, task);

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
