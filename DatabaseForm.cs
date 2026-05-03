using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class DatabaseForm : Form
    {
        // Індекс поточного вибраного рядка у таблиці dgvTeams.
        // Використовується для навігації (кнопки «Перший», «Наступний» і т.д.).
        // Починаємо з -1 — означає «нічого не вибрано».
        private int _teamCurrentRow = -1;

        public DatabaseForm()
        {
            InitializeComponent();
        }

        // ─── Load ─────────────────────────────────────────────────────────────
        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.InitializeDatabase();
                LoadTeams();
                SetStatus("База даних завантажена успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка ініціалізації БД:\n" + ex.Message,
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Teams: завантаження та оновлення ─────────────────────────────────

        // Перевантаження без параметрів — завантажує всі команди зі стандартним сортуванням за назвою.
        // "Перевантаження" (overloading) — два методи з однаковою назвою але різними параметрами.
        // Компілятор сам обирає потрібний варіант залежно від того, які аргументи передаються.
        private void LoadTeams()
        {
            LoadTeams("team_name", true, "", "");
        }

        // Завантажує команди з заданим сортуванням та фільтрами.
        private void LoadTeams(string sortField, bool ascending, string filterCountry, string filterChampMin)
        {
            DataTable dt = DatabaseHelper.GetTeams(sortField, ascending, filterCountry, filterChampMin);
            dgvTeams.DataSource = dt;

            SetTeamsColumnHeaders();
            UpdateTeamNavLabel();

            if (dgvTeams.Rows.Count > 0)
            {
                if (_teamCurrentRow < 0 || _teamCurrentRow >= dgvTeams.Rows.Count)
                    _teamCurrentRow = 0;
                dgvTeams.Rows[_teamCurrentRow].Selected = true;
                dgvTeams.FirstDisplayedScrollingRowIndex = _teamCurrentRow;
                LoadTeamLogo();
                LoadDriversForSelectedTeam();
            }
            else
            {
                pictureBoxLogo.Image = null;
                dgvDrivers.DataSource = null;
            }
        }

        private void SetTeamsColumnHeaders()
        {
            if (dgvTeams.Columns.Count == 0) return;

            HideColumn(dgvTeams, "team_id");

            SetColumnHeader(dgvTeams, "team_name",          "Команда",         160);
            SetColumnHeader(dgvTeams, "team_country",       "Країна",          110);
            SetColumnHeader(dgvTeams, "team_founded",       "Рік зас.",        80);
            SetColumnHeader(dgvTeams, "team_championships", "Чемп-ва",         80);
            SetColumnHeader(dgvTeams, "team_logo_file",     "Файл логотипу",   140);
        }

        private void LoadDriversForSelectedTeam()
        {
            int teamId = GetSelectedTeamId();
            if (teamId < 0) return;

            DataTable dt = DatabaseHelper.GetDriversByTeam(teamId);
            dgvDrivers.DataSource = dt;
            SetDriversColumnHeaders();

            string teamName = GetSelectedTeamName();
            labelDriversTitle.Text = string.Format("ПІЛОТИ: {0}", teamName);
        }

        private void SetDriversColumnHeaders()
        {
            if (dgvDrivers.Columns.Count == 0) return;

            HideColumn(dgvDrivers, "driver_id");
            HideColumn(dgvDrivers, "team_id");

            SetColumnHeader(dgvDrivers, "driver_name",        "Пілот",         150);
            SetColumnHeader(dgvDrivers, "driver_number",      "№",             50);
            SetColumnHeader(dgvDrivers, "driver_nationality", "Національність",120);
            SetColumnHeader(dgvDrivers, "driver_wins",        "Перемоги",      90);
            SetColumnHeader(dgvDrivers, "driver_points",      "Очки",          80);
            SetColumnHeader(dgvDrivers, "driver_photo_file",  "Файл фото",     130);
            SetColumnHeader(dgvDrivers, "win_rate",           "Win rate %",    90);
        }

        // Завантажує логотип команди у PictureBox.
        // Завантажуємо через Bitmap (не через Load) — так зображення завантажується в пам'ять
        // повністю і потім відрисовується зразу без полос.
        private void LoadTeamLogo()
        {
            int teamId = GetSelectedTeamId();
            if (teamId < 0) { pictureBoxLogo.Image = null; return; }

            DataRow row = DatabaseHelper.GetTeamById(teamId);
            if (row == null) { pictureBoxLogo.Image = null; return; }

            string logoFile = row["team_logo_file"].ToString();
            if (string.IsNullOrWhiteSpace(logoFile)) { pictureBoxLogo.Image = null; return; }

            string logoPath = Path.Combine(DatabaseHelper.LogosFolderPath, logoFile);
            if (File.Exists(logoPath))
            {
                try
                {
                    using (System.Drawing.Bitmap tmp = new System.Drawing.Bitmap(logoPath))
                    {
                        if (pictureBoxLogo.Image != null) pictureBoxLogo.Image.Dispose();
                        pictureBoxLogo.Image = new System.Drawing.Bitmap(tmp);
                    }
                }
                catch { pictureBoxLogo.Image = null; }
            }
            else
            {
                pictureBoxLogo.Image = null;
            }
        }

        // ─── Навігація Teams ──────────────────────────────────────────────────
        private void dgvTeams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeams.SelectedRows.Count == 0) return;
            _teamCurrentRow = dgvTeams.SelectedRows[0].Index;
            UpdateTeamNavLabel();
            LoadTeamLogo();
            LoadDriversForSelectedTeam();
        }

        private void btnTeamFirst_Click(object sender, EventArgs e)  { NavigateTeams(0); }
        private void btnTeamLast_Click(object sender, EventArgs e)   { NavigateTeams(dgvTeams.Rows.Count - 1); }
        private void btnTeamPrev_Click(object sender, EventArgs e)   { NavigateTeams(_teamCurrentRow - 1); }
        private void btnTeamNext_Click(object sender, EventArgs e)   { NavigateTeams(_teamCurrentRow + 1); }

        private void NavigateTeams(int index)
        {
            if (dgvTeams.Rows.Count == 0) return;

            // Обмежуємо index в допустимих межах: від 0 до (кількість рядків - 1)
            if (index < 0)
                index = 0;
            if (index > dgvTeams.Rows.Count - 1)
                index = dgvTeams.Rows.Count - 1;

            _teamCurrentRow = index;
            dgvTeams.ClearSelection();
            dgvTeams.Rows[index].Selected = true;
            dgvTeams.FirstDisplayedScrollingRowIndex = index;
            UpdateTeamNavLabel();
        }

        private void UpdateTeamNavLabel()
        {
            // Рядки у DataGridView нумеруються з 0, але користувачу показуємо з 1
            int currentDisplay;
            if (dgvTeams.Rows.Count > 0)
                currentDisplay = _teamCurrentRow + 1;
            else
                currentDisplay = 0;

            labelTeamPos.Text = string.Format("{0} / {1}", currentDisplay, dgvTeams.Rows.Count);
        }

        // ─── Пошук ────────────────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string val = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(val))
            {
                LoadTeams();
                return;
            }

            DataTable dt = DatabaseHelper.SearchTeams(val);
            dgvTeams.DataSource = dt;
            SetTeamsColumnHeaders();
            _teamCurrentRow = 0;
            UpdateTeamNavLabel();
            SetStatus(string.Format("Пошук '{0}': знайдено {1} команд(и).", val, dt.Rows.Count));

            if (dt.Rows.Count > 0)
            {
                dgvTeams.Rows[0].Selected = true;
                LoadTeamLogo();
                LoadDriversForSelectedTeam();
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadTeams();
            SetStatus("Пошук скинуто.");
        }

        // ─── Фільтр ───────────────────────────────────────────────────────────
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string country  = txtFilterCountry.Text.Trim();
            string champMin = txtFilterChampMin.Text.Trim();

            string sortField = "team_name";
            if (cmbSortField.SelectedItem != null)
                sortField = cmbSortField.SelectedItem.ToString();

            _teamCurrentRow = 0;
            LoadTeams(sortField, chkSortAsc.Checked, country, champMin);

            // Формуємо текст статусу: якщо поле порожнє — показуємо "*" або "0"
            string countryDisplay;
            if (string.IsNullOrWhiteSpace(country))
                countryDisplay = "*";
            else
                countryDisplay = country;

            string champDisplay;
            if (string.IsNullOrWhiteSpace(champMin))
                champDisplay = "0";
            else
                champDisplay = champMin;

            SetStatus(string.Format("Фільтр застосовано: Країна='{0}' AND Чемп≥{1}. Знайдено: {2}.",
                countryDisplay, champDisplay, dgvTeams.Rows.Count));
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterCountry.Clear();
            txtFilterChampMin.Clear();
            _teamCurrentRow = 0;
            LoadTeams();
            SetStatus("Фільтр скинуто.");
        }

        // ─── Сортування ───────────────────────────────────────────────────────
        private void btnApplySort_Click(object sender, EventArgs e)
        {
            string field = "team_name";
            if (cmbSortField.SelectedItem != null)
                field = cmbSortField.SelectedItem.ToString();
            bool asc = chkSortAsc.Checked;

            _teamCurrentRow = 0;
            LoadTeams(field, asc,
                txtFilterCountry.Text.Trim(),
                txtFilterChampMin.Text.Trim());

            SetStatus(string.Format("Сортування: {0} {1}", field, asc ? "ASC" : "DESC"));
        }

        // ─── CRUD: Teams ──────────────────────────────────────────────────────
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            // "using" з формою — гарантує закриття форми і звільнення пам'яті після закриття.
            // null — передаємо без існуючого рядка (режим додавання).
            using (TeamEditForm dlg = new TeamEditForm(null))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DatabaseHelper.AddTeam(dlg.TeamName, dlg.Country, dlg.Founded,
                                           dlg.Championships, dlg.LogoFile);
                    LoadTeams();
                    SetStatus("Команду додано.");
                }
            }
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTeamId();
            if (id < 0) { ShowNoSelection(); return; }

            DataRow row = DatabaseHelper.GetTeamById(id);
            if (row == null) return;

            using (TeamEditForm dlg = new TeamEditForm(row))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DatabaseHelper.UpdateTeam(id, dlg.TeamName, dlg.Country, dlg.Founded,
                                              dlg.Championships, dlg.LogoFile);
                    LoadTeams();
                    SetStatus("Команду оновлено.");
                }
            }
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTeamId();
            if (id < 0) { ShowNoSelection(); return; }

            string name = GetSelectedTeamName();
            DialogResult confirm = MessageBox.Show(
                string.Format("Видалити команду «{0}»?\nВсі пілоти цієї команди будуть видалені!", name),
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteTeam(id);

                // Після видалення переходимо на попередній рядок (але не менше 0)
                if (_teamCurrentRow > 0)
                    _teamCurrentRow = _teamCurrentRow - 1;

                LoadTeams();
                SetStatus(string.Format("Команду «{0}» видалено.", name));
            }
        }

        private void btnDetailsTeam_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTeamId();
            if (id < 0) { ShowNoSelection(); return; }

            using (DetailsForm details = new DetailsForm(id))
                details.ShowDialog(this);
        }

        // ─── CRUD: Drivers ────────────────────────────────────────────────────
        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            int teamId = GetSelectedTeamId();
            if (teamId < 0) { ShowNoSelection(); return; }

            using (DriverEditForm dlg = new DriverEditForm(null, teamId))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DatabaseHelper.AddDriver(dlg.TeamId, dlg.DriverName, dlg.Number,
                                             dlg.Nationality, dlg.Wins, dlg.Points, dlg.PhotoFile);
                    LoadDriversForSelectedTeam();
                    SetStatus("Пілота додано.");
                }
            }
        }

        private void btnEditDriver_Click(object sender, EventArgs e)
        {
            int driverId = GetSelectedDriverId();
            if (driverId < 0) { ShowNoSelection(); return; }

            DataRow row = DatabaseHelper.GetDriverById(driverId);
            if (row == null) return;

            using (DriverEditForm dlg = new DriverEditForm(row, GetSelectedTeamId()))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DatabaseHelper.UpdateDriver(driverId, dlg.TeamId, dlg.DriverName, dlg.Number,
                                               dlg.Nationality, dlg.Wins, dlg.Points, dlg.PhotoFile);
                    LoadDriversForSelectedTeam();
                    SetStatus("Дані пілота оновлено.");
                }
            }
        }

        private void btnDeleteDriver_Click(object sender, EventArgs e)
        {
            int driverId = GetSelectedDriverId();
            if (driverId < 0) { ShowNoSelection(); return; }

            string name = GetSelectedDriverName();
            DialogResult confirm = MessageBox.Show(
                string.Format("Видалити пілота «{0}»?", name),
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteDriver(driverId);
                LoadDriversForSelectedTeam();
                SetStatus(string.Format("Пілота «{0}» видалено.", name));
            }
        }

        // ─── Close ────────────────────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ─── Helper методи ────────────────────────────────────────────────────
        // Повертає team_id вибраної команди, або -1 якщо нічого не вибрано.
        private int GetSelectedTeamId()
        {
            if (dgvTeams.SelectedRows.Count == 0) return -1;
            object val = dgvTeams.SelectedRows[0].Cells["team_id"].Value;
            // DBNull.Value — спеціальне значення C# для порожнього поля БД (NULL у SQL).
            // Перевіряємо обидва випадки: поле порожнє (null) або це NULL з БД (DBNull.Value).
            if (val == null || val == DBNull.Value) return -1;
            // Convert.ToInt32 — перетворює object у int
            return Convert.ToInt32(val);
        }

        private string GetSelectedTeamName()
        {
            if (dgvTeams.SelectedRows.Count == 0) return string.Empty;
            object val = dgvTeams.SelectedRows[0].Cells["team_name"].Value;
            if (val == null) return string.Empty;
            return val.ToString();
        }

        private int GetSelectedDriverId()
        {
            if (dgvDrivers.SelectedRows.Count == 0) return -1;
            object val = dgvDrivers.SelectedRows[0].Cells["driver_id"].Value;
            if (val == null || val == DBNull.Value) return -1;
            return Convert.ToInt32(val);
        }

        private string GetSelectedDriverName()
        {
            if (dgvDrivers.SelectedRows.Count == 0) return string.Empty;
            object val = dgvDrivers.SelectedRows[0].Cells["driver_name"].Value;
            if (val == null) return string.Empty;
            return val.ToString();
        }

        private static void SetColumnHeader(DataGridView dgv, string columnName, string header, int width)
        {
            if (!dgv.Columns.Contains(columnName)) return;
            dgv.Columns[columnName].HeaderText = header;
            dgv.Columns[columnName].Width      = width;
            dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        private static void HideColumn(DataGridView dgv, string columnName)
        {
            if (dgv.Columns.Contains(columnName))
                dgv.Columns[columnName].Visible = false;
        }

        private void SetStatus(string text)
        {
            labelStatus.Text = text;
        }

        private void ShowNoSelection()
        {
            MessageBox.Show("Будь ласка, оберіть запис.", "Увага",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
