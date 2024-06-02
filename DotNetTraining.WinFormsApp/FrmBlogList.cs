using DotNetTraining.WinFormsApp;
using DotNetTraining.WinFormsApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZMMLDotNetCore.Shared.ConnectionService;
using ZMMLDotNetCore.Shared.Services;

namespace ZMMLDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService = new DapperService();

        public FrmBlogList()
        {
            InitializeComponent();
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
           var list = _dapperService.Query<BlogModel>("select * from Tbl_Blog");
            datagv.DataSource = list;
        }
    }
}
