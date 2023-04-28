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
    public partial class Form1 : Form
    {
        CreateAcc create = CreateAcc.instance;
        MainScreen mainSreen = MainScreen.instance;
        Note note = Note.instance;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(244, 251, 255);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(create);
            create.Hide();
            this.Controls.Add(mainSreen);
            mainSreen.Hide();
            this.Controls.Add(note);
            note.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(205, 237, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainSreen.Show();
            mainSreen.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            create.Show();
            create.BringToFront();
        }
    }
}
