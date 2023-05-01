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
    public partial class MainScreen : UserControl
    {
        private static MainScreen _instance;

        public static MainScreen instance
        {
            get
            {
                if (_instance == null) _instance = new MainScreen();
                return _instance;
            }
        }
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
