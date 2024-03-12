using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoForm
{
    public partial class BlogForm_UC : UserControl
    {
        public Action Save;

        public BlogForm_UC()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save is null)
            {
                return;
            }

            Save();
        }
    }
}
