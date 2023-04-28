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
        Create create = Create.instance;
        MainScreen mainScreen = MainScreen.instance;
        Note note = Note.instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(create);
            create.Hide();
            this.Controls.Add(mainScreen);
            mainScreen.Hide();
            this.Controls.Add(note);
            note.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainScreen.Show();
            mainScreen.BringToFront();
            //this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            create.Show();
            create.BringToFront();
            //this.Hide();
            
        }
    }
}
