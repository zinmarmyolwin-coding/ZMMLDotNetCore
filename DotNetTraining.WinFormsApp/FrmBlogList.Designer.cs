namespace ZMMLDotNetCore.WinFormsApp
{
    partial class FrmBlogList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            datagv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            coltile = new DataGridViewTextBoxColumn();
            colauthor = new DataGridViewTextBoxColumn();
            colcontent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)datagv).BeginInit();
            SuspendLayout();
            // 
            // datagv
            // 
            datagv.AllowUserToAddRows = false;
            datagv.AllowUserToDeleteRows = false;
            datagv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagv.Columns.AddRange(new DataGridViewColumn[] { colId, coltile, colauthor, colcontent });
            datagv.Dock = DockStyle.Top;
            datagv.Location = new Point(0, 0);
            datagv.Name = "datagv";
            datagv.ReadOnly = true;
            datagv.Size = new Size(751, 45);
            datagv.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "BlogId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // coltile
            // 
            coltile.DataPropertyName = "Title";
            coltile.HeaderText = "Title";
            coltile.Name = "coltile";
            coltile.ReadOnly = true;
            // 
            // colauthor
            // 
            colauthor.DataPropertyName = "Author";
            colauthor.HeaderText = "Author";
            colauthor.Name = "colauthor";
            colauthor.ReadOnly = true;
            // 
            // colcontent
            // 
            colcontent.DataPropertyName = "Content";
            colcontent.HeaderText = "Content";
            colcontent.Name = "colcontent";
            colcontent.ReadOnly = true;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(6F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 450);
            Controls.Add(datagv);
            Name = "FrmBlogList";
            Text = "Blog List";
            Load += FrmBlogList_Load;
            ((System.ComponentModel.ISupportInitialize)datagv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView datagv;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn coltile;
        private DataGridViewTextBoxColumn colauthor;
        private DataGridViewTextBoxColumn colcontent;
    }
}