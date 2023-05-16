using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace ToDolist1
{
    public partial class AddWindow : Form
    {   
        private int UserID;
        public AddWindow(int UserID)
        {
            this.UserID = UserID;
            InitializeComponent();
            Form1.SetRoundedShape(button3, 10);
            Form1.SetRoundedShape(panel2, 25);
            Form1.SetRoundedShape(button1, 10);
            this.BackColor = Color.FromArgb(225, 244, 255);
            panel1.BackColor = Color.FromArgb(176, 227, 255);
            button3.BackColor = Color.FromArgb(175, 217, 255);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.Title = textBox1.Text;
            task.Description = richTextBox1.Text;
            task.Deadline = dateTimePicker1.Value.ToString();

            task.AddTask(this.UserID, task);

            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
