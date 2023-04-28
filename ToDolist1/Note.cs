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
    public partial class Note : UserControl
    {
        private static Note _instance;
        public static Note instance
        {
            get
            {
                if (_instance == null) _instance = new Note();
                return _instance;
            }
        }
        public Note()
        {
            InitializeComponent();
        }

        private void Note_Load(object sender, EventArgs e)
        {

        }
    }
}
