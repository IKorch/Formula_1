namespace Formula_1
{
    partial class GalleryForm
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
            this.components = new System.ComponentModel.Container();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.labelPhotoTitle = new System.Windows.Forms.Label();
            this.thumbnail1 = new System.Windows.Forms.PictureBox();
            this.thumbnail2 = new System.Windows.Forms.PictureBox();
            this.thumbnail3 = new System.Windows.Forms.PictureBox();
            this.thumbnail4 = new System.Windows.Forms.PictureBox();
            this.thumbnail5 = new System.Windows.Forms.PictureBox();
            this.btnSlideShow = new System.Windows.Forms.Button();
            this.slideShowTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail5)).BeginInit();
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
            this.labelHeader.Text = "Фотогалерея Formula 1";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxMain.Location = new System.Drawing.Point(40, 88);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(720, 300);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 1;
            this.pictureBoxMain.TabStop = false;
            // 
            // labelPhotoTitle
            // 
            this.labelPhotoTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelPhotoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhotoTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPhotoTitle.Location = new System.Drawing.Point(40, 392);
            this.labelPhotoTitle.Name = "labelPhotoTitle";
            this.labelPhotoTitle.Size = new System.Drawing.Size(720, 26);
            this.labelPhotoTitle.TabIndex = 2;
            this.labelPhotoTitle.Text = "Підпис фото";
            this.labelPhotoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thumbnail1
            // 
            this.thumbnail1.BackColor = System.Drawing.Color.White;
            this.thumbnail1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnail1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thumbnail1.Location = new System.Drawing.Point(40, 426);
            this.thumbnail1.Name = "thumbnail1";
            this.thumbnail1.Size = new System.Drawing.Size(120, 68);
            this.thumbnail1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail1.TabIndex = 3;
            this.thumbnail1.TabStop = false;
            this.thumbnail1.Click += new System.EventHandler(this.thumbnail_Click);
            // 
            // thumbnail2
            // 
            this.thumbnail2.BackColor = System.Drawing.Color.White;
            this.thumbnail2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnail2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thumbnail2.Location = new System.Drawing.Point(176, 426);
            this.thumbnail2.Name = "thumbnail2";
            this.thumbnail2.Size = new System.Drawing.Size(120, 68);
            this.thumbnail2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail2.TabIndex = 4;
            this.thumbnail2.TabStop = false;
            this.thumbnail2.Click += new System.EventHandler(this.thumbnail_Click);
            // 
            // thumbnail3
            // 
            this.thumbnail3.BackColor = System.Drawing.Color.White;
            this.thumbnail3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnail3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thumbnail3.Location = new System.Drawing.Point(312, 426);
            this.thumbnail3.Name = "thumbnail3";
            this.thumbnail3.Size = new System.Drawing.Size(120, 68);
            this.thumbnail3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail3.TabIndex = 5;
            this.thumbnail3.TabStop = false;
            this.thumbnail3.Click += new System.EventHandler(this.thumbnail_Click);
            // 
            // thumbnail4
            // 
            this.thumbnail4.BackColor = System.Drawing.Color.White;
            this.thumbnail4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnail4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thumbnail4.Location = new System.Drawing.Point(448, 426);
            this.thumbnail4.Name = "thumbnail4";
            this.thumbnail4.Size = new System.Drawing.Size(120, 68);
            this.thumbnail4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail4.TabIndex = 6;
            this.thumbnail4.TabStop = false;
            this.thumbnail4.Click += new System.EventHandler(this.thumbnail_Click);
            // 
            // thumbnail5
            // 
            this.thumbnail5.BackColor = System.Drawing.Color.White;
            this.thumbnail5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnail5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thumbnail5.Location = new System.Drawing.Point(584, 426);
            this.thumbnail5.Name = "thumbnail5";
            this.thumbnail5.Size = new System.Drawing.Size(120, 68);
            this.thumbnail5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail5.TabIndex = 7;
            this.thumbnail5.TabStop = false;
            this.thumbnail5.Click += new System.EventHandler(this.thumbnail_Click);
            // 
            // btnSlideShow
            // 
            this.btnSlideShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSlideShow.Location = new System.Drawing.Point(710, 452);
            this.btnSlideShow.Name = "btnSlideShow";
            this.btnSlideShow.Size = new System.Drawing.Size(82, 32);
            this.btnSlideShow.TabIndex = 8;
            this.btnSlideShow.Text = "Старт слайдшоу";
            this.btnSlideShow.UseVisualStyleBackColor = true;
            this.btnSlideShow.Click += new System.EventHandler(this.btnSlideShow_Click);
            // 
            // slideShowTimer
            // 
            this.slideShowTimer.Interval = 2000;
            this.slideShowTimer.Tick += new System.EventHandler(this.slideShowTimer_Tick);
            // 
            // GalleryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(24)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.btnSlideShow);
            this.Controls.Add(this.thumbnail5);
            this.Controls.Add(this.thumbnail4);
            this.Controls.Add(this.thumbnail3);
            this.Controls.Add(this.thumbnail2);
            this.Controls.Add(this.thumbnail1);
            this.Controls.Add(this.labelPhotoTitle);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GalleryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formula 1 - Фотогалерея";
            this.Activated += new System.EventHandler(this.GalleryForm_Activated);
            this.Deactivate += new System.EventHandler(this.GalleryForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GalleryForm_FormClosing);
            this.Load += new System.EventHandler(this.GalleryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Label labelPhotoTitle;
        private System.Windows.Forms.PictureBox thumbnail1;
        private System.Windows.Forms.PictureBox thumbnail2;
        private System.Windows.Forms.PictureBox thumbnail3;
        private System.Windows.Forms.PictureBox thumbnail4;
        private System.Windows.Forms.PictureBox thumbnail5;
        private System.Windows.Forms.Button btnSlideShow;
        private System.Windows.Forms.Timer slideShowTimer;
    }
}
