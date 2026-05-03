namespace Formula_1
{
    partial class DetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.panelTop           = new System.Windows.Forms.Panel();
            this.labelTitle         = new System.Windows.Forms.Label();

            this.panelTeamInfo      = new System.Windows.Forms.Panel();
            this.labelTeamName      = new System.Windows.Forms.Label();
            this.labelCountry       = new System.Windows.Forms.Label();
            this.labelFounded       = new System.Windows.Forms.Label();
            this.labelChampionships = new System.Windows.Forms.Label();
            this.labelLogoFile      = new System.Windows.Forms.Label();
            this.pictureBoxLogo     = new System.Windows.Forms.PictureBox();

            this.panelDrivers       = new System.Windows.Forms.Panel();
            this.labelDriversTitle  = new System.Windows.Forms.Label();
            this.listBoxDrivers     = new System.Windows.Forms.ListBox();

            this.panelDriverDetail  = new System.Windows.Forms.Panel();
            this.labelDriverDetail  = new System.Windows.Forms.Label();
            this.lblDName           = new System.Windows.Forms.Label();
            this.lblDNumber         = new System.Windows.Forms.Label();
            this.lblDNat            = new System.Windows.Forms.Label();
            this.lblDWins           = new System.Windows.Forms.Label();
            this.lblDPoints         = new System.Windows.Forms.Label();
            this.lblDWinRate        = new System.Windows.Forms.Label();
            this.pictureBoxDriver   = new System.Windows.Forms.PictureBox();

            this.btnClose           = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            this.ClientSize    = new System.Drawing.Size(860, 620);
            this.Text          = "Деталі команди";
            this.Name          = "DetailsForm";
            this.BackColor     = System.Drawing.Color.FromArgb(28, 28, 36);
            this.ForeColor     = System.Drawing.Color.White;
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load         += new System.EventHandler(this.DetailsForm_Load);

            // ── panelTop ──────────────────────────────────────────────────────
            this.panelTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height    = 48;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.panelTop.Controls.Add(this.labelTitle);

            this.labelTitle.Text      = "ДЕТАЛІ КОМАНДИ";
            this.labelTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;

            // ── panelTeamInfo ─────────────────────────────────────────────────
            this.panelTeamInfo.Location  = new System.Drawing.Point(10, 58);
            this.panelTeamInfo.Size      = new System.Drawing.Size(840, 170);
            this.panelTeamInfo.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelTeamInfo.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);
            this.panelTeamInfo.Controls.Add(this.labelTeamName);
            this.panelTeamInfo.Controls.Add(this.labelCountry);
            this.panelTeamInfo.Controls.Add(this.labelFounded);
            this.panelTeamInfo.Controls.Add(this.labelChampionships);
            this.panelTeamInfo.Controls.Add(this.labelLogoFile);
            this.panelTeamInfo.Controls.Add(this.pictureBoxLogo);

            // Логотип
            this.pictureBoxLogo.Location  = new System.Drawing.Point(600, 10);
            this.pictureBoxLogo.Size      = new System.Drawing.Size(230, 150);
            this.pictureBoxLogo.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);
            this.pictureBoxLogo.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // Поля команди
            SetInfoLabel(this.labelTeamName,      10, 15, "Команда:",     "");
            SetInfoLabel(this.labelCountry,        10, 45, "Країна:",      "");
            SetInfoLabel(this.labelFounded,        10, 75, "Заснована:",   "");
            SetInfoLabel(this.labelChampionships,  10, 105,"Чемпіонства:", "");
            SetInfoLabel(this.labelLogoFile,       10, 135,"Логотип:",     "");

            // ── Список пілотів ────────────────────────────────────────────────
            this.panelDrivers.Location  = new System.Drawing.Point(10, 238);
            this.panelDrivers.Size      = new System.Drawing.Size(260, 340);
            this.panelDrivers.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);
            this.panelDrivers.Controls.Add(this.labelDriversTitle);
            this.panelDrivers.Controls.Add(this.listBoxDrivers);

            this.labelDriversTitle.Text      = "ПІЛОТИ";
            this.labelDriversTitle.Location  = new System.Drawing.Point(8, 6);
            this.labelDriversTitle.Size      = new System.Drawing.Size(240, 20);
            this.labelDriversTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.labelDriversTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.listBoxDrivers.Location         = new System.Drawing.Point(8, 30);
            this.listBoxDrivers.Size             = new System.Drawing.Size(244, 298);
            this.listBoxDrivers.BackColor        = System.Drawing.Color.FromArgb(28, 28, 36);
            this.listBoxDrivers.ForeColor        = System.Drawing.Color.White;
            this.listBoxDrivers.BorderStyle      = System.Windows.Forms.BorderStyle.None;
            this.listBoxDrivers.Font             = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listBoxDrivers.SelectedIndexChanged += new System.EventHandler(this.listBoxDrivers_SelectedIndexChanged);

            // ── Деталі пілота ─────────────────────────────────────────────────
            this.panelDriverDetail.Location  = new System.Drawing.Point(280, 238);
            this.panelDriverDetail.Size      = new System.Drawing.Size(570, 340);
            this.panelDriverDetail.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);
            this.panelDriverDetail.Controls.Add(this.labelDriverDetail);
            this.panelDriverDetail.Controls.Add(this.lblDName);
            this.panelDriverDetail.Controls.Add(this.lblDNumber);
            this.panelDriverDetail.Controls.Add(this.lblDNat);
            this.panelDriverDetail.Controls.Add(this.lblDWins);
            this.panelDriverDetail.Controls.Add(this.lblDPoints);
            this.panelDriverDetail.Controls.Add(this.lblDWinRate);
            this.panelDriverDetail.Controls.Add(this.pictureBoxDriver);

            this.labelDriverDetail.Text      = "ДЕТАЛІ ПІЛОТА";
            this.labelDriverDetail.Location  = new System.Drawing.Point(8, 6);
            this.labelDriverDetail.Size      = new System.Drawing.Size(280, 20);
            this.labelDriverDetail.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.labelDriverDetail.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            SetInfoLabel(this.lblDName,    8,  32, "Ім'я:",           "—");
            SetInfoLabel(this.lblDNumber,  8,  62, "Номер:",          "—");
            SetInfoLabel(this.lblDNat,     8,  92, "Національність:", "—");
            SetInfoLabel(this.lblDWins,    8, 122, "Перемоги:",       "—");
            SetInfoLabel(this.lblDPoints,  8, 152, "Очки:",           "—");
            SetInfoLabel(this.lblDWinRate, 8, 182, "Win rate %:",     "—");

            this.pictureBoxDriver.Location  = new System.Drawing.Point(300, 10);
            this.pictureBoxDriver.Size      = new System.Drawing.Size(258, 315);
            this.pictureBoxDriver.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDriver.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);

            // ── Кнопка закрити ────────────────────────────────────────────────
            this.btnClose.Text      = "Закрити";
            this.btnClose.Location  = new System.Drawing.Point(760, 582);
            this.btnClose.Size      = new System.Drawing.Size(90, 28);
            this.btnClose.Anchor    = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            // ── Додаємо все до форми ──────────────────────────────────────────
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelTeamInfo);
            this.Controls.Add(this.panelDrivers);
            this.Controls.Add(this.panelDriverDetail);
            this.Controls.Add(this.btnClose);

            this.ResumeLayout(false);
        }

        private static void SetInfoLabel(System.Windows.Forms.Label lbl,
                                          int x, int y, string caption, string value)
        {
            lbl.Text      = caption + "  " + value;
            lbl.Location  = new System.Drawing.Point(x, y);
            // Ширина 285 — щоб мітки не перекривали pictureBoxDriver (X=300)
            lbl.Size      = new System.Drawing.Size(285, 22);
            lbl.ForeColor = System.Drawing.Color.White;
            lbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lbl.Tag       = caption;
        }

        private System.Windows.Forms.Panel      panelTop;
        private System.Windows.Forms.Label      labelTitle;
        private System.Windows.Forms.Panel      panelTeamInfo;
        private System.Windows.Forms.Label      labelTeamName;
        private System.Windows.Forms.Label      labelCountry;
        private System.Windows.Forms.Label      labelFounded;
        private System.Windows.Forms.Label      labelChampionships;
        private System.Windows.Forms.Label      labelLogoFile;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel      panelDrivers;
        private System.Windows.Forms.Label      labelDriversTitle;
        private System.Windows.Forms.ListBox    listBoxDrivers;
        private System.Windows.Forms.Panel      panelDriverDetail;
        private System.Windows.Forms.Label      labelDriverDetail;
        private System.Windows.Forms.Label      lblDName;
        private System.Windows.Forms.Label      lblDNumber;
        private System.Windows.Forms.Label      lblDNat;
        private System.Windows.Forms.Label      lblDWins;
        private System.Windows.Forms.Label      lblDPoints;
        private System.Windows.Forms.Label      lblDWinRate;
        private System.Windows.Forms.PictureBox pictureBoxDriver;
        private System.Windows.Forms.Button     btnClose;
        #endregion
    }
}
