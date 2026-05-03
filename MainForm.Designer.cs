namespace Formula_1
{
    partial class MainForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.labelArticles = new System.Windows.Forms.Label();
            this.labelGallery = new System.Windows.Forms.Label();
            this.labelMedia = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(24, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(752, 58);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Formula 1";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelSubtitle.Location = new System.Drawing.Point(24, 86);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(752, 35);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "Головне меню проєкту";
            this.labelSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelArticles
            // 
            this.labelArticles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelArticles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelArticles.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArticles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.labelArticles.Location = new System.Drawing.Point(236, 156);
            this.labelArticles.Name = "labelArticles";
            this.labelArticles.Size = new System.Drawing.Size(328, 64);
            this.labelArticles.TabIndex = 2;
            this.labelArticles.Text = "Статті";
            this.labelArticles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelArticles.Click += new System.EventHandler(this.labelArticles_Click);
            this.labelArticles.MouseEnter += new System.EventHandler(this.labelMenu_MouseEnter);
            this.labelArticles.MouseLeave += new System.EventHandler(this.labelMenu_MouseLeave);
            // 
            // labelGallery
            // 
            this.labelGallery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelGallery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGallery.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGallery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.labelGallery.Location = new System.Drawing.Point(236, 240);
            this.labelGallery.Name = "labelGallery";
            this.labelGallery.Size = new System.Drawing.Size(328, 64);
            this.labelGallery.TabIndex = 3;
            this.labelGallery.Text = "Фотогалерея";
            this.labelGallery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGallery.Click += new System.EventHandler(this.labelGallery_Click);
            this.labelGallery.MouseEnter += new System.EventHandler(this.labelMenu_MouseEnter);
            this.labelGallery.MouseLeave += new System.EventHandler(this.labelMenu_MouseLeave);
            // 
            // labelMedia
            // 
            this.labelMedia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMedia.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMedia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.labelMedia.Location = new System.Drawing.Point(236, 324);
            this.labelMedia.Name = "labelMedia";
            this.labelMedia.Size = new System.Drawing.Size(328, 64);
            this.labelMedia.TabIndex = 4;
            this.labelMedia.Text = "Відео та медіа";
            this.labelMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMedia.Click += new System.EventHandler(this.labelMedia_Click);
            this.labelMedia.MouseEnter += new System.EventHandler(this.labelMenu_MouseEnter);
            this.labelMedia.MouseLeave += new System.EventHandler(this.labelMenu_MouseLeave);
            // 
            // labelHelp
            // 
            this.labelHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHelp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.labelHelp.Location = new System.Drawing.Point(236, 408);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(328, 64);
            this.labelHelp.TabIndex = 5;
            this.labelHelp.Text = "Довідка";
            this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHelp.Click += new System.EventHandler(this.labelHelp_Click);
            this.labelHelp.MouseEnter += new System.EventHandler(this.labelMenu_MouseEnter);
            this.labelHelp.MouseLeave += new System.EventHandler(this.labelMenu_MouseLeave);
            // 
            // labelDatabase
            // 
            this.labelDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDatabase.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.labelDatabase.Location = new System.Drawing.Point(236, 492);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(328, 64);
            this.labelDatabase.TabIndex = 6;
            this.labelDatabase.Text = "База даних";
            this.labelDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDatabase.Click += new System.EventHandler(this.labelDatabase_Click);
            this.labelDatabase.MouseEnter += new System.EventHandler(this.labelMenu_MouseEnter);
            this.labelDatabase.MouseLeave += new System.EventHandler(this.labelMenu_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.labelDatabase);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelMedia);
            this.Controls.Add(this.labelGallery);
            this.Controls.Add(this.labelArticles);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formula 1 - Головна форма";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelArticles;
        private System.Windows.Forms.Label labelGallery;
        private System.Windows.Forms.Label labelMedia;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label labelDatabase;
    }
}
