using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetTraining.WinFormsApp
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();
            txtTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
