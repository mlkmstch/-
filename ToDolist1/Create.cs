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
    public partial class Create : UserControl
    {
        private static Create _instance;
        public static Create instance
        {
            get
            {
                if (_instance == null) _instance = new Create();
                return _instance;
            }
        }
        public Create()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }
    }
}
