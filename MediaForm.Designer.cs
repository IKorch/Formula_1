namespace Formula_1
{
    partial class MediaForm
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
            this.listBoxMediaFiles = new System.Windows.Forms.ListBox();
            this.panelPlayerHost = new System.Windows.Forms.Panel();
            this.pictureBoxAudioPlaceholder = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.labelNowPlaying = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAudioPlaceholder)).BeginInit();
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
            this.labelHeader.Text = "Відео та медіа Formula 1";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxMediaFiles
            // 
            this.listBoxMediaFiles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxMediaFiles.FormattingEnabled = true;
            this.listBoxMediaFiles.ItemHeight = 17;
            this.listBoxMediaFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(94)))));
            this.listBoxMediaFiles.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxMediaFiles.Location = new System.Drawing.Point(24, 92);
            this.listBoxMediaFiles.Name = "listBoxMediaFiles";
            this.listBoxMediaFiles.Size = new System.Drawing.Size(238, 378);
            this.listBoxMediaFiles.TabIndex = 1;
            this.listBoxMediaFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxMediaFiles_SelectedIndexChanged);
            // 
            // panelPlayerHost
            // 
            this.panelPlayerHost.BackColor = System.Drawing.Color.Black;
            this.panelPlayerHost.Location = new System.Drawing.Point(280, 92);
            this.panelPlayerHost.Name = "panelPlayerHost";
            this.panelPlayerHost.Size = new System.Drawing.Size(496, 280);
            this.panelPlayerHost.TabIndex = 2;
            // 
            // pictureBoxAudioPlaceholder
            // 
            this.pictureBoxAudioPlaceholder.BackColor = System.Drawing.Color.White;
            this.pictureBoxAudioPlaceholder.Location = new System.Drawing.Point(280, 92);
            this.pictureBoxAudioPlaceholder.Name = "pictureBoxAudioPlaceholder";
            this.pictureBoxAudioPlaceholder.Size = new System.Drawing.Size(496, 280);
            this.pictureBoxAudioPlaceholder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAudioPlaceholder.TabIndex = 3;
            this.pictureBoxAudioPlaceholder.TabStop = false;
            this.pictureBoxAudioPlaceholder.Visible = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.Location = new System.Drawing.Point(280, 391);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(120, 34);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPause.Location = new System.Drawing.Point(416, 391);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(120, 34);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // labelNowPlaying
            // 
            this.labelNowPlaying.BackColor = System.Drawing.Color.Transparent;
            this.labelNowPlaying.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNowPlaying.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelNowPlaying.Location = new System.Drawing.Point(280, 433);
            this.labelNowPlaying.Name = "labelNowPlaying";
            this.labelNowPlaying.Size = new System.Drawing.Size(496, 37);
            this.labelNowPlaying.TabIndex = 6;
            this.labelNowPlaying.Text = "Now Playing: -";
            // 
            // MediaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(24)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.labelNowPlaying);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBoxAudioPlaceholder);
            this.Controls.Add(this.panelPlayerHost);
            this.Controls.Add(this.listBoxMediaFiles);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MediaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formula 1 - Відео та медіа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MediaForm_FormClosing);
            this.Load += new System.EventHandler(this.MediaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAudioPlaceholder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.ListBox listBoxMediaFiles;
        private System.Windows.Forms.Panel panelPlayerHost;
        private System.Windows.Forms.PictureBox pictureBoxAudioPlaceholder;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label labelNowPlaying;
    }
}
