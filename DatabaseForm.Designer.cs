namespace Formula_1
{
    partial class DatabaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop        = new System.Windows.Forms.Panel();
            this.labelTitle      = new System.Windows.Forms.Label();

            // ── TEAMS панель ──────────────────────────────────────────────────
            this.panelTeams      = new System.Windows.Forms.Panel();
            this.labelTeamsTitle = new System.Windows.Forms.Label();
            this.dgvTeams        = new System.Windows.Forms.DataGridView();

            this.panelTeamLogo   = new System.Windows.Forms.Panel();
            this.pictureBoxLogo  = new System.Windows.Forms.PictureBox();
            this.labelLogoTitle  = new System.Windows.Forms.Label();

            // CRUD кнопки Teams
            this.panelTeamButtons  = new System.Windows.Forms.Panel();
            this.btnAddTeam        = new System.Windows.Forms.Button();
            this.btnEditTeam       = new System.Windows.Forms.Button();
            this.btnDeleteTeam     = new System.Windows.Forms.Button();
            this.btnDetailsTeam    = new System.Windows.Forms.Button();

            // Навігація Teams
            this.panelTeamNav    = new System.Windows.Forms.Panel();
            this.btnTeamFirst    = new System.Windows.Forms.Button();
            this.btnTeamPrev     = new System.Windows.Forms.Button();
            this.btnTeamNext     = new System.Windows.Forms.Button();
            this.btnTeamLast     = new System.Windows.Forms.Button();
            this.labelTeamPos    = new System.Windows.Forms.Label();

            // ── Фільтр та пошук ───────────────────────────────────────────────
            this.panelFilter     = new System.Windows.Forms.Panel();
            this.labelFilterTitle= new System.Windows.Forms.Label();

            this.labelSearch     = new System.Windows.Forms.Label();
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.btnSearch       = new System.Windows.Forms.Button();
            this.btnClearSearch  = new System.Windows.Forms.Button();

            this.labelCountry    = new System.Windows.Forms.Label();
            this.txtFilterCountry= new System.Windows.Forms.TextBox();
            this.labelChampMin   = new System.Windows.Forms.Label();
            this.txtFilterChampMin= new System.Windows.Forms.TextBox();
            this.btnApplyFilter  = new System.Windows.Forms.Button();
            this.btnClearFilter  = new System.Windows.Forms.Button();

            this.labelSortField  = new System.Windows.Forms.Label();
            this.cmbSortField    = new System.Windows.Forms.ComboBox();
            this.chkSortAsc      = new System.Windows.Forms.CheckBox();
            this.btnApplySort    = new System.Windows.Forms.Button();

            // ── DRIVERS панель ────────────────────────────────────────────────
            this.panelDrivers       = new System.Windows.Forms.Panel();
            this.labelDriversTitle  = new System.Windows.Forms.Label();
            this.dgvDrivers         = new System.Windows.Forms.DataGridView();

            this.panelDriverButtons = new System.Windows.Forms.Panel();
            this.btnAddDriver       = new System.Windows.Forms.Button();
            this.btnEditDriver      = new System.Windows.Forms.Button();
            this.btnDeleteDriver    = new System.Windows.Forms.Button();

            // ── Підвал ────────────────────────────────────────────────────────
            this.panelBottom     = new System.Windows.Forms.Panel();
            this.btnClose        = new System.Windows.Forms.Button();
            this.labelStatus     = new System.Windows.Forms.Label();

            // ─────────────────────────────────────────────────────────────────
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            this.ClientSize    = new System.Drawing.Size(1200, 780);
            this.MinimumSize   = new System.Drawing.Size(1100, 700);
            this.WindowState   = System.Windows.Forms.FormWindowState.Maximized;
            this.Text          = "Formula-1 — База даних";
            this.Name          = "DatabaseForm";
            this.BackColor     = System.Drawing.Color.FromArgb(28, 28, 36);
            this.ForeColor     = System.Drawing.Color.White;
            this.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(this.DatabaseForm_Load);

            // ── panelTop ──────────────────────────────────────────────────────
            this.panelTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height    = 52;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.panelTop.Controls.Add(this.labelTitle);

            this.labelTitle.Text      = "FORMULA-1  |  БАЗА ДАНИХ";
            this.labelTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;

            // ── panelBottom ───────────────────────────────────────────────────
            this.panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height    = 40;
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(20, 20, 26);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.labelStatus);

            this.btnClose.Text      = "Закрити";
            this.btnClose.Size      = new System.Drawing.Size(90, 28);
            this.btnClose.Location  = new System.Drawing.Point(1090, 6);
            this.btnClose.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            this.labelStatus.Text      = "Готово";
            this.labelStatus.Location  = new System.Drawing.Point(10, 12);
            this.labelStatus.Size      = new System.Drawing.Size(600, 18);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);

            // ── panelFilter ───────────────────────────────────────────────────
            this.panelFilter.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Height    = 108;
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);
            this.panelFilter.Padding   = new System.Windows.Forms.Padding(8, 4, 8, 4);

            // Рядок 1: Пошук
            this.labelFilterTitle.Text      = "Пошук / Фільтр / Сортування";
            this.labelFilterTitle.Location  = new System.Drawing.Point(8, 5);
            this.labelFilterTitle.Size      = new System.Drawing.Size(250, 18);
            this.labelFilterTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.labelFilterTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.labelSearch.Text     = "Пошук:";
            this.labelSearch.Location = new System.Drawing.Point(8, 28);
            this.labelSearch.Size     = new System.Drawing.Size(55, 22);
            this.labelSearch.ForeColor= System.Drawing.Color.White;

            this.txtSearch.Location   = new System.Drawing.Point(66, 25);
            this.txtSearch.Size       = new System.Drawing.Size(200, 22);
            StyleTextBox(this.txtSearch);

            this.btnSearch.Text       = "Знайти";
            this.btnSearch.Location   = new System.Drawing.Point(274, 24);
            this.btnSearch.Size       = new System.Drawing.Size(75, 24);
            StyleButton(this.btnSearch);
            this.btnSearch.Click     += new System.EventHandler(this.btnSearch_Click);

            this.btnClearSearch.Text      = "✕";
            this.btnClearSearch.Location  = new System.Drawing.Point(356, 24);
            this.btnClearSearch.Size      = new System.Drawing.Size(30, 24);
            StyleButton(this.btnClearSearch);
            this.btnClearSearch.Click    += new System.EventHandler(this.btnClearSearch_Click);

            // Рядок 2: Фільтр
            this.labelCountry.Text     = "Країна:";
            this.labelCountry.Location = new System.Drawing.Point(8, 56);
            this.labelCountry.Size     = new System.Drawing.Size(55, 22);
            this.labelCountry.ForeColor= System.Drawing.Color.White;

            this.txtFilterCountry.Location = new System.Drawing.Point(66, 53);
            this.txtFilterCountry.Size     = new System.Drawing.Size(120, 22);
            StyleTextBox(this.txtFilterCountry);

            this.labelChampMin.Text     = "Чемп. ≥:";
            this.labelChampMin.Location = new System.Drawing.Point(196, 56);
            this.labelChampMin.Size     = new System.Drawing.Size(65, 22);
            this.labelChampMin.ForeColor= System.Drawing.Color.White;

            this.txtFilterChampMin.Location = new System.Drawing.Point(264, 53);
            this.txtFilterChampMin.Size     = new System.Drawing.Size(50, 22);
            StyleTextBox(this.txtFilterChampMin);

            this.btnApplyFilter.Text      = "Фільтр";
            this.btnApplyFilter.Location  = new System.Drawing.Point(322, 52);
            this.btnApplyFilter.Size      = new System.Drawing.Size(75, 24);
            StyleButton(this.btnApplyFilter);
            this.btnApplyFilter.Click    += new System.EventHandler(this.btnApplyFilter_Click);

            this.btnClearFilter.Text      = "Скинути";
            this.btnClearFilter.Location  = new System.Drawing.Point(404, 52);
            this.btnClearFilter.Size      = new System.Drawing.Size(75, 24);
            StyleButtonSecondary(this.btnClearFilter);
            this.btnClearFilter.Click    += new System.EventHandler(this.btnClearFilter_Click);

            // Рядок 3: Сортування
            this.labelSortField.Text     = "Сорт.:";
            this.labelSortField.Location = new System.Drawing.Point(500, 28);
            this.labelSortField.Size     = new System.Drawing.Size(45, 22);
            this.labelSortField.ForeColor= System.Drawing.Color.White;

            this.cmbSortField.Location   = new System.Drawing.Point(548, 25);
            this.cmbSortField.Size       = new System.Drawing.Size(160, 24);
            this.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortField.BackColor  = System.Drawing.Color.FromArgb(50, 50, 65);
            this.cmbSortField.ForeColor  = System.Drawing.Color.White;
            this.cmbSortField.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortField.Items.AddRange(new object[] {
                "team_name", "team_country", "team_founded", "team_championships"
            });
            this.cmbSortField.SelectedIndex = 0;

            this.chkSortAsc.Text      = "ASC";
            this.chkSortAsc.Checked   = true;
            this.chkSortAsc.Location  = new System.Drawing.Point(716, 26);
            this.chkSortAsc.Size      = new System.Drawing.Size(55, 22);
            this.chkSortAsc.ForeColor = System.Drawing.Color.White;

            this.btnApplySort.Text      = "Сортувати";
            this.btnApplySort.Location  = new System.Drawing.Point(776, 24);
            this.btnApplySort.Size      = new System.Drawing.Size(90, 24);
            StyleButton(this.btnApplySort);
            this.btnApplySort.Click    += new System.EventHandler(this.btnApplySort_Click);

            this.panelFilter.Controls.Add(this.labelFilterTitle);
            this.panelFilter.Controls.Add(this.labelSearch);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.btnSearch);
            this.panelFilter.Controls.Add(this.btnClearSearch);
            this.panelFilter.Controls.Add(this.labelCountry);
            this.panelFilter.Controls.Add(this.txtFilterCountry);
            this.panelFilter.Controls.Add(this.labelChampMin);
            this.panelFilter.Controls.Add(this.txtFilterChampMin);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Controls.Add(this.btnClearFilter);
            this.panelFilter.Controls.Add(this.labelSortField);
            this.panelFilter.Controls.Add(this.cmbSortField);
            this.panelFilter.Controls.Add(this.chkSortAsc);
            this.panelFilter.Controls.Add(this.btnApplySort);

            // ── panelTeams ────────────────────────────────────────────────────
            this.panelTeams.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelTeams.Height    = 280;
            this.panelTeams.BackColor = System.Drawing.Color.FromArgb(28, 28, 36);
            this.panelTeams.Padding   = new System.Windows.Forms.Padding(8, 4, 8, 4);

            this.labelTeamsTitle.Text      = "КОМАНДИ";
            this.labelTeamsTitle.Location  = new System.Drawing.Point(8, 4);
            this.labelTeamsTitle.Size      = new System.Drawing.Size(120, 20);
            this.labelTeamsTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.labelTeamsTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // DGV Teams
            this.dgvTeams.Location          = new System.Drawing.Point(8, 26);
            this.dgvTeams.Size              = new System.Drawing.Size(870, 210);
            this.dgvTeams.Anchor            = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            StyleDataGridView(this.dgvTeams);
            this.dgvTeams.SelectionChanged += new System.EventHandler(this.dgvTeams_SelectionChanged);

            // panelTeamLogo
            this.panelTeamLogo.Location  = new System.Drawing.Point(886, 4);
            this.panelTeamLogo.Size      = new System.Drawing.Size(300, 240);
            this.panelTeamLogo.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.panelTeamLogo.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);
            this.panelTeamLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTeamLogo.Controls.Add(this.pictureBoxLogo);
            this.panelTeamLogo.Controls.Add(this.labelLogoTitle);

            this.pictureBoxLogo.Location  = new System.Drawing.Point(10, 26);
            this.pictureBoxLogo.Size      = new System.Drawing.Size(278, 190);
            this.pictureBoxLogo.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.BackColor = System.Drawing.Color.FromArgb(38, 38, 50);

            this.labelLogoTitle.Text      = "Логотип команди";
            this.labelLogoTitle.Location  = new System.Drawing.Point(4, 6);
            this.labelLogoTitle.Size      = new System.Drawing.Size(290, 18);
            this.labelLogoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLogoTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.labelLogoTitle.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);

            // panelTeamButtons
            this.panelTeamButtons.Location  = new System.Drawing.Point(8, 240);
            this.panelTeamButtons.Size      = new System.Drawing.Size(600, 32);
            this.panelTeamButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelTeamButtons.Controls.Add(this.btnAddTeam);
            this.panelTeamButtons.Controls.Add(this.btnEditTeam);
            this.panelTeamButtons.Controls.Add(this.btnDeleteTeam);
            this.panelTeamButtons.Controls.Add(this.btnDetailsTeam);

            this.btnAddTeam.Text     = "+ Додати команду";
            this.btnAddTeam.Location = new System.Drawing.Point(0, 0);
            this.btnAddTeam.Size     = new System.Drawing.Size(140, 28);
            StyleButton(this.btnAddTeam);
            this.btnAddTeam.Click   += new System.EventHandler(this.btnAddTeam_Click);

            this.btnEditTeam.Text     = "✎ Редагувати";
            this.btnEditTeam.Location = new System.Drawing.Point(148, 0);
            this.btnEditTeam.Size     = new System.Drawing.Size(110, 28);
            StyleButtonSecondary(this.btnEditTeam);
            this.btnEditTeam.Click   += new System.EventHandler(this.btnEditTeam_Click);

            this.btnDeleteTeam.Text     = "✕ Видалити";
            this.btnDeleteTeam.Location = new System.Drawing.Point(266, 0);
            this.btnDeleteTeam.Size     = new System.Drawing.Size(100, 28);
            StyleButtonDanger(this.btnDeleteTeam);
            this.btnDeleteTeam.Click   += new System.EventHandler(this.btnDeleteTeam_Click);

            this.btnDetailsTeam.Text     = "Деталі →";
            this.btnDetailsTeam.Location = new System.Drawing.Point(374, 0);
            this.btnDetailsTeam.Size     = new System.Drawing.Size(90, 28);
            StyleButtonSecondary(this.btnDetailsTeam);
            this.btnDetailsTeam.Click   += new System.EventHandler(this.btnDetailsTeam_Click);

            // panelTeamNav
            this.panelTeamNav.Location  = new System.Drawing.Point(620, 240);
            this.panelTeamNav.Size      = new System.Drawing.Size(280, 32);
            this.panelTeamNav.BackColor = System.Drawing.Color.Transparent;
            this.panelTeamNav.Controls.Add(this.btnTeamFirst);
            this.panelTeamNav.Controls.Add(this.btnTeamPrev);
            this.panelTeamNav.Controls.Add(this.labelTeamPos);
            this.panelTeamNav.Controls.Add(this.btnTeamNext);
            this.panelTeamNav.Controls.Add(this.btnTeamLast);

            this.btnTeamFirst.Text     = "◀◀";
            this.btnTeamFirst.Location = new System.Drawing.Point(0, 0);
            this.btnTeamFirst.Size     = new System.Drawing.Size(36, 28);
            StyleButtonNav(this.btnTeamFirst);
            this.btnTeamFirst.Click   += new System.EventHandler(this.btnTeamFirst_Click);

            this.btnTeamPrev.Text     = "◀";
            this.btnTeamPrev.Location = new System.Drawing.Point(40, 0);
            this.btnTeamPrev.Size     = new System.Drawing.Size(36, 28);
            StyleButtonNav(this.btnTeamPrev);
            this.btnTeamPrev.Click   += new System.EventHandler(this.btnTeamPrev_Click);

            this.labelTeamPos.Text      = "0 / 0";
            this.labelTeamPos.Location  = new System.Drawing.Point(80, 4);
            this.labelTeamPos.Size      = new System.Drawing.Size(80, 22);
            this.labelTeamPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTeamPos.ForeColor = System.Drawing.Color.White;

            this.btnTeamNext.Text     = "▶";
            this.btnTeamNext.Location = new System.Drawing.Point(164, 0);
            this.btnTeamNext.Size     = new System.Drawing.Size(36, 28);
            StyleButtonNav(this.btnTeamNext);
            this.btnTeamNext.Click   += new System.EventHandler(this.btnTeamNext_Click);

            this.btnTeamLast.Text     = "▶▶";
            this.btnTeamLast.Location = new System.Drawing.Point(204, 0);
            this.btnTeamLast.Size     = new System.Drawing.Size(36, 28);
            StyleButtonNav(this.btnTeamLast);
            this.btnTeamLast.Click   += new System.EventHandler(this.btnTeamLast_Click);

            this.panelTeams.Controls.Add(this.labelTeamsTitle);
            this.panelTeams.Controls.Add(this.dgvTeams);
            this.panelTeams.Controls.Add(this.panelTeamLogo);
            this.panelTeams.Controls.Add(this.panelTeamButtons);
            this.panelTeams.Controls.Add(this.panelTeamNav);

            // ── panelDrivers ──────────────────────────────────────────────────
            this.panelDrivers.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelDrivers.BackColor = System.Drawing.Color.FromArgb(28, 28, 36);
            this.panelDrivers.Padding   = new System.Windows.Forms.Padding(8, 4, 8, 4);

            this.labelDriversTitle.Text      = "ПІЛОТИ ОБРАНОЇ КОМАНДИ";
            this.labelDriversTitle.Location  = new System.Drawing.Point(8, 4);
            this.labelDriversTitle.Size      = new System.Drawing.Size(300, 20);
            this.labelDriversTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.labelDriversTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.dgvDrivers.Location = new System.Drawing.Point(8, 28);
            this.dgvDrivers.Anchor   = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDrivers.Size     = new System.Drawing.Size(1180, 200);
            StyleDataGridView(this.dgvDrivers);

            this.panelDriverButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelDriverButtons.Height    = 36;
            this.panelDriverButtons.Padding   = new System.Windows.Forms.Padding(8, 4, 0, 0);
            this.panelDriverButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelDriverButtons.Controls.Add(this.btnAddDriver);
            this.panelDriverButtons.Controls.Add(this.btnEditDriver);
            this.panelDriverButtons.Controls.Add(this.btnDeleteDriver);

            this.btnAddDriver.Text     = "+ Додати пілота";
            this.btnAddDriver.Location = new System.Drawing.Point(0, 0);
            this.btnAddDriver.Size     = new System.Drawing.Size(130, 28);
            StyleButton(this.btnAddDriver);
            this.btnAddDriver.Click   += new System.EventHandler(this.btnAddDriver_Click);

            this.btnEditDriver.Text     = "✎ Редагувати";
            this.btnEditDriver.Location = new System.Drawing.Point(138, 0);
            this.btnEditDriver.Size     = new System.Drawing.Size(110, 28);
            StyleButtonSecondary(this.btnEditDriver);
            this.btnEditDriver.Click   += new System.EventHandler(this.btnEditDriver_Click);

            this.btnDeleteDriver.Text     = "✕ Видалити";
            this.btnDeleteDriver.Location = new System.Drawing.Point(256, 0);
            this.btnDeleteDriver.Size     = new System.Drawing.Size(100, 28);
            StyleButtonDanger(this.btnDeleteDriver);
            this.btnDeleteDriver.Click   += new System.EventHandler(this.btnDeleteDriver_Click);

            // Dock=Bottom треба додавати ДО Fill/Anchored елементів
            this.panelDrivers.Controls.Add(this.panelDriverButtons);
            this.panelDrivers.Controls.Add(this.labelDriversTitle);
            this.panelDrivers.Controls.Add(this.dgvDrivers);

            // ── Додаємо все до форми ──────────────────────────────────────────
            this.Controls.Add(this.panelDrivers);
            this.Controls.Add(this.panelTeams);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);

            this.ResumeLayout(false);
        }

        // ── Допоміжні методи стилів ───────────────────────────────────────────
        private static void StyleButton(System.Windows.Forms.Button btn)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        private static void StyleButtonSecondary(System.Windows.Forms.Button btn)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(60, 60, 80);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        private static void StyleButtonDanger(System.Windows.Forms.Button btn)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(100, 30, 30);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        private static void StyleButtonNav(System.Windows.Forms.Button btn)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(50, 50, 65);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 80, 100);
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        private static void StyleTextBox(System.Windows.Forms.TextBox txt)
        {
            txt.BackColor  = System.Drawing.Color.FromArgb(50, 50, 65);
            txt.ForeColor  = System.Drawing.Color.White;
            txt.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private static void StyleDataGridView(System.Windows.Forms.DataGridView dgv)
        {
            dgv.BackgroundColor           = System.Drawing.Color.FromArgb(28, 28, 36);
            dgv.GridColor                 = System.Drawing.Color.FromArgb(60, 60, 80);
            dgv.BorderStyle               = System.Windows.Forms.BorderStyle.None;
            dgv.RowHeadersVisible         = false;
            dgv.AllowUserToAddRows        = false;
            dgv.AllowUserToDeleteRows     = false;
            dgv.ReadOnly                  = true;
            dgv.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect               = false;
            dgv.AutoSizeColumnsMode       = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ScrollBars                = System.Windows.Forms.ScrollBars.Both;

            dgv.DefaultCellStyle.BackColor          = System.Drawing.Color.FromArgb(35, 35, 45);
            dgv.DefaultCellStyle.ForeColor          = System.Drawing.Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dgv.ColumnHeadersDefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(192, 57, 43);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersHeight                       = 28;
            dgv.EnableHeadersVisualStyles                 = false;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 52);
        }

        // ── Поля ─────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel    panelTop;
        private System.Windows.Forms.Label    labelTitle;
        private System.Windows.Forms.Panel    panelBottom;
        private System.Windows.Forms.Button   btnClose;
        private System.Windows.Forms.Label    labelStatus;

        private System.Windows.Forms.Panel    panelFilter;
        private System.Windows.Forms.Label    labelFilterTitle;
        private System.Windows.Forms.Label    labelSearch;
        private System.Windows.Forms.TextBox  txtSearch;
        private System.Windows.Forms.Button   btnSearch;
        private System.Windows.Forms.Button   btnClearSearch;
        private System.Windows.Forms.Label    labelCountry;
        private System.Windows.Forms.TextBox  txtFilterCountry;
        private System.Windows.Forms.Label    labelChampMin;
        private System.Windows.Forms.TextBox  txtFilterChampMin;
        private System.Windows.Forms.Button   btnApplyFilter;
        private System.Windows.Forms.Button   btnClearFilter;
        private System.Windows.Forms.Label    labelSortField;
        private System.Windows.Forms.ComboBox cmbSortField;
        private System.Windows.Forms.CheckBox chkSortAsc;
        private System.Windows.Forms.Button   btnApplySort;

        private System.Windows.Forms.Panel    panelTeams;
        private System.Windows.Forms.Label    labelTeamsTitle;
        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.Panel    panelTeamLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label    labelLogoTitle;
        private System.Windows.Forms.Panel    panelTeamButtons;
        private System.Windows.Forms.Button   btnAddTeam;
        private System.Windows.Forms.Button   btnEditTeam;
        private System.Windows.Forms.Button   btnDeleteTeam;
        private System.Windows.Forms.Button   btnDetailsTeam;
        private System.Windows.Forms.Panel    panelTeamNav;
        private System.Windows.Forms.Button   btnTeamFirst;
        private System.Windows.Forms.Button   btnTeamPrev;
        private System.Windows.Forms.Label    labelTeamPos;
        private System.Windows.Forms.Button   btnTeamNext;
        private System.Windows.Forms.Button   btnTeamLast;

        private System.Windows.Forms.Panel    panelDrivers;
        private System.Windows.Forms.Label    labelDriversTitle;
        private System.Windows.Forms.DataGridView dgvDrivers;
        private System.Windows.Forms.Panel    panelDriverButtons;
        private System.Windows.Forms.Button   btnAddDriver;
        private System.Windows.Forms.Button   btnEditDriver;
        private System.Windows.Forms.Button   btnDeleteDriver;

        #endregion
    }
}
