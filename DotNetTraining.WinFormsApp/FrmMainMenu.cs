using DotNetTraining.WinFormsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZMMLDotNetCore.WinFormsApp
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
  DotNetTrainingBatch4.WinFormsAppSqlInjection      {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            Test frmBlog = new Test();
            frmBlog.ShowDialog();
        }

        private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlogList frmBlogList = new FrmBlogList();
            frmBlogList.ShowDialog();
        }
    }
}
