namespace Formula_1
{
    partial class ArticlesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.treeViewArticles = new System.Windows.Forms.TreeView();
            this.webBrowserArticle = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.labelHeader.Location = new System.Drawing.Point(24, 24);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(752, 60);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Статті про Formula 1";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeViewArticles
            // 
            this.treeViewArticles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewArticles.FullRowSelect = true;
            this.treeViewArticles.HideSelection = false;
            this.treeViewArticles.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.treeViewArticles.Location = new System.Drawing.Point(24, 104);
            this.treeViewArticles.Name = "treeViewArticles";
            this.treeViewArticles.Size = new System.Drawing.Size(230, 392);
            this.treeViewArticles.TabIndex = 1;
            this.treeViewArticles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewArticles_AfterSelect);
            // 
            // webBrowserArticle
            // 
            this.webBrowserArticle.AllowNavigation = true;
            this.webBrowserArticle.Location = new System.Drawing.Point(270, 104);
            this.webBrowserArticle.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserArticle.Name = "webBrowserArticle";
            this.webBrowserArticle.Size = new System.Drawing.Size(506, 392);
            this.webBrowserArticle.TabIndex = 2;
            // 
            // ArticlesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(24)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.webBrowserArticle);
            this.Controls.Add(this.treeViewArticles);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ArticlesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formula 1 - Статті";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TreeView treeViewArticles;
        private System.Windows.Forms.WebBrowser webBrowserArticle;
    }
}
