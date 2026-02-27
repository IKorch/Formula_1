namespace Formula_1
{
    partial class HelpForm
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
            this.labelTheme = new System.Windows.Forms.Label();
            this.labelModules = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.pictureBoxAuthorPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthorPhoto)).BeginInit();
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
            this.labelHeader.Text = "Довідка";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTheme
            // 
            this.labelTheme.BackColor = System.Drawing.Color.Transparent;
            this.labelTheme.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTheme.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTheme.Location = new System.Drawing.Point(40, 110);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(502, 118);
            this.labelTheme.TabIndex = 1;
            this.labelTheme.Text = "Тема: Formula 1\r\nКоротка анотація: навчальний WinForms-проєкт, який знайомить з історією" +
            " Формули-1, командами, пілотами, фотоматеріалами та медіа-контентом.";
            // 
            // labelModules
            // 
            this.labelModules.BackColor = System.Drawing.Color.Transparent;
            this.labelModules.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelModules.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelModules.Location = new System.Drawing.Point(40, 238);
            this.labelModules.Name = "labelModules";
            this.labelModules.Size = new System.Drawing.Size(720, 122);
            this.labelModules.TabIndex = 2;
            this.labelModules.Text = "Структура додатку:\r\n1) Головне меню для навігації між модулями\r\n2) Модуль статей " +
            "(TreeView + WebBrowser)\r\n3) Фотогалерея (5 мініатюр, підпис, слайдшоу 2 секунди +" +
            " музика)\r\n4) Модуль відео та аудіо (ListBox, плеєр, Play/Pause, заглушка для аудіо)";
            // 
            // labelAuthor
            // 
            this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelAuthor.Location = new System.Drawing.Point(40, 386);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(720, 86);
            this.labelAuthor.TabIndex = 3;
            this.labelAuthor.Text = "Автор проєкту: Корчагін Ігнатій Павлович\r\nУчень 10 класу Ліцею Інформаційних Техн" +
    "ологій\r\nНазва проєкту: Formula_1 | Рік виконання: 2026";
            // 
            // pictureBoxAuthorPhoto
            // 
            this.pictureBoxAuthorPhoto.BackColor = System.Drawing.Color.White;
            this.pictureBoxAuthorPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAuthorPhoto.Location = new System.Drawing.Point(556, 110);
            this.pictureBoxAuthorPhoto.Name = "pictureBoxAuthorPhoto";
            this.pictureBoxAuthorPhoto.Size = new System.Drawing.Size(204, 118);
            this.pictureBoxAuthorPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAuthorPhoto.TabIndex = 4;
            this.pictureBoxAuthorPhoto.TabStop = false;
            // 
            // HelpForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(24)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.pictureBoxAuthorPhoto);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelModules);
            this.Controls.Add(this.labelTheme);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formula 1 - Довідка";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthorPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.Label labelModules;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.PictureBox pictureBoxAuthorPhoto;
    }
}
