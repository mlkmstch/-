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
    public partial class CreateAcc : UserControl
    {
        private static CreateAcc _instance;
        public static CreateAcc instance
        {
            get
            {
                if (_instance == null) _instance = new CreateAcc();
                return _instance;
            }
        }
        public CreateAcc()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(244, 251, 255);
        }

        private void CreateAcc_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(205, 237, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
