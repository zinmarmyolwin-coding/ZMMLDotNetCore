using DotNetTraining.WinFormsApp.Model;
using DotNetTraining.WinFormsApp.Query;
using DotNetTrainingBatch4.Shared;
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
        private static string message;
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
            try
            {
                string connectionStr = ConnectionString.connectionString.ToString();
                DapperService dapperService = new DapperService(connectionStr);

                BlogModel blogModel = new BlogModel()
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Content = txtContent.Text,
                };

                int result = dapperService.Execute(BlogQuery.BlogCreate, blogModel);

                message = result == 0 ? "Save Failed" : "Save Sucessfull!";
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex?.Message);
            }
        }
    }
}
