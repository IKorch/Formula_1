// ─── Підключення просторів імен (using) ─────────────────────────────────────
// System           — базові типи: рядки, числа, винятки (Exception).
// System.Data      — DataTable, DataRow: таблиці та рядки даних у пам'яті.
// System.IO        — File, Path: робота з файлами та шляхами на диску.
// System.Windows.Forms — Form, Button, DataGridView та інші елементи GUI.
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    // DatabaseForm — форма «База даних».
    // "partial" означає, що клас розбитий на два файли:
    //   цей файл (DatabaseForm.cs)        — логіка (що робить форма),
    //   DatabaseForm.Designer.cs          — розмітка (де розміщені елементи).
    // Наслідується від Form — тобто є стандартним вікном Windows.
    public partial class DatabaseForm : Form
    {
        // ─── Поля класу ───────────────────────────────────────────────────────
        // Приватне поле (_teamCurrentRow) зберігає індекс поточного рядка в таблиці команд.
        // "private" — доступне тільки всередині цього класу.
        // "int" — ціле число.
        // Значення -1 — умовна ознака «жоден рядок ще не вибраний».
        // Використовується кнопками навігації «Перший / Попередній / Наступний / Останній».
        private int _teamCurrentRow = -1;

        // ─── Конструктор ──────────────────────────────────────────────────────
        // Конструктор — спеціальний метод, який викликається один раз при створенні форми.
        // InitializeComponent() — згенерований Designer-ом метод, який створює всі
        // кнопки, таблиці, підписи і розміщує їх на формі.
        public DatabaseForm()
        {
            InitializeComponent();
        }

        // ─── Подія завантаження форми (Load) ──────────────────────────────────
        // DatabaseForm_Load викликається автоматично, коли форма вперше з'являється на екрані.
        // "object sender" — це сам елемент, що породив подію (форма).
        // "EventArgs e"   — додаткові дані події (тут не використовуються).
        // try/catch — конструкція обробки помилок:
        //   try   — виконуємо ризикований код,
        //   catch — якщо щось пішло не так, ловимо виняток (Exception) і показуємо повідомлення.
        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Ініціалізація БД: якщо файл formula1.db не існує — він створюється
                // і заповнюється початковими даними (seed).
                DatabaseHelper.InitializeDatabase();

                // Завантажуємо команди у таблицю dgvTeams.
                LoadTeams();

                SetStatus("База даних завантажена успішно.");
            }
            catch (Exception ex)
            {
                // ex.Message — текстовий опис помилки, що автоматично генерується середовищем.
                MessageBox.Show("Помилка ініціалізації БД:\n" + ex.Message,
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Завантаження і оновлення команд ─────────────────────────────────

        // Версія без параметрів — зручний «ярлик»: завантажує всі команди
        // з сортуванням за назвою (за зростанням) і без жодного фільтру.
        // Це перевантаження методу (method overloading): два методи з однаковою
        // назвою LoadTeams, але з різними наборами параметрів.
        // C# самостійно обирає потрібну версію залежно від аргументів виклику.
        private void LoadTeams()
        {
            LoadTeams("team_name", true, "", "");
        }

        // Основна версія — отримує дані з БД і прив'язує їх до DataGridView.
        // Параметри:
        //   sortField      — назва колонки SQL, за якою сортуємо (наприклад, "team_name").
        //   ascending      — true = від А до Я (ASC), false = від Я до А (DESC).
        //   filterCountry  — фільтр за країною (порожній рядок = без фільтру).
        //   filterChampMin — мінімальна кількість чемпіонств (порожній = без фільтру).
        private void LoadTeams(string sortField, bool ascending, string filterCountry, string filterChampMin)
        {
            // GetTeams звертається до SQLite і повертає DataTable — таблицю даних у пам'яті.
            DataTable dt = DatabaseHelper.GetTeams(sortField, ascending, filterCountry, filterChampMin);

            // DataSource — прив'язка даних: DataGridView автоматично відображає всі рядки з dt.
            dgvTeams.DataSource = dt;

            // Перейменовуємо колонки (назви SQL → українські заголовки) та ховаємо service-колонки.
            SetTeamsColumnHeaders();

            // Оновлюємо лічильник «1 / 11» тощо.
            UpdateTeamNavLabel();

            if (dgvTeams.Rows.Count > 0)
            {
                // Якщо збережений індекс вийшов за межі (наприклад, після видалення) —
                // скидаємо на перший рядок.
                if (_teamCurrentRow < 0 || _teamCurrentRow >= dgvTeams.Rows.Count)
                    _teamCurrentRow = 0;

                // Виділяємо потрібний рядок і прокручуємо таблицю до нього.
                dgvTeams.Rows[_teamCurrentRow].Selected = true;
                dgvTeams.FirstDisplayedScrollingRowIndex = _teamCurrentRow;

                // Показуємо логотип та пілотів вибраної команди.
                LoadTeamLogo();
                LoadDriversForSelectedTeam();
            }
            else
            {
                // Якщо жодна команда не знайдена — очищаємо логотип і таблицю пілотів.
                pictureBoxLogo.Image = null;
                dgvDrivers.DataSource = null;
            }
        }

        // Налаштовує вигляд колонок таблиці команд.
        // HideColumn  — ховає технічні колонки (team_id), які не потрібні користувачу.
        // SetColumnHeader — задає заголовок і ширину кожної видимої колонки.
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

        // Завантажує пілотів вибраної команди у нижню таблицю dgvDrivers.
        private void LoadDriversForSelectedTeam()
        {
            // GetSelectedTeamId() зчитує team_id з вибраного рядка dgvTeams.
            int teamId = GetSelectedTeamId();

            // Якщо повернуто -1 (нічого не вибрано) — нічого не робимо.
            if (teamId < 0) return;

            // Запит до БД: отримуємо всіх пілотів, у яких team_id = teamId.
            DataTable dt = DatabaseHelper.GetDriversByTeam(teamId);
            dgvDrivers.DataSource = dt;
            SetDriversColumnHeaders();

            // Оновлюємо заголовок панелі пілотів, наприклад: «ПІЛОТИ: Ferrari».
            string teamName = GetSelectedTeamName();
            labelDriversTitle.Text = string.Format("ПІЛОТИ: {0}", teamName);
        }

        // Налаштовує вигляд колонок таблиці пілотів (аналогічно до SetTeamsColumnHeaders).
        private void SetDriversColumnHeaders()
        {
            if (dgvDrivers.Columns.Count == 0) return;

            // Ховаємо технічні колонки — вони потрібні для коду, але не для користувача.
            HideColumn(dgvDrivers, "driver_id");
            HideColumn(dgvDrivers, "team_id");

            SetColumnHeader(dgvDrivers, "driver_name",        "Пілот",          150);
            SetColumnHeader(dgvDrivers, "driver_number",      "№",              50);
            SetColumnHeader(dgvDrivers, "driver_nationality", "Національність", 120);
            SetColumnHeader(dgvDrivers, "driver_wins",        "Перемоги",       90);
            SetColumnHeader(dgvDrivers, "driver_points",      "Очки",           80);
            SetColumnHeader(dgvDrivers, "driver_photo_file",  "Файл фото",      130);
            SetColumnHeader(dgvDrivers, "win_rate",           "Win rate %",     90);
        }

        // ─── Завантаження логотипу команди ────────────────────────────────────
        // Показує логотип вибраної команди у PictureBox (pictureBoxLogo).
        // Техніка завантаження через Bitmap (не через pictureBoxLogo.Load(path)):
        //   1. Створюємо тимчасовий Bitmap(tmp) із файлу — він копіює дані у пам'ять.
        //   2. Конструкція "using" гарантує, що tmp буде закрито і файл — розблоковано.
        //   3. Створюємо новий Bitmap(tmp) — копію, яку і показуємо.
        // Це важливо: якщо завантажити зображення напряму через Load(), файл залишається
        // заблокованим (locked), доки форма відкрита, і Windows не дасть його замінити.
        private void LoadTeamLogo()
        {
            int teamId = GetSelectedTeamId();

            // Якщо нічого не вибрано — очищаємо PictureBox.
            if (teamId < 0) { pictureBoxLogo.Image = null; return; }

            // Отримуємо весь рядок команди з БД (DataRow — один рядок таблиці).
            DataRow row = DatabaseHelper.GetTeamById(teamId);
            if (row == null) { pictureBoxLogo.Image = null; return; }

            // Зчитуємо назву файлу логотипу (наприклад, "ferrari.png").
            string logoFile = row["team_logo_file"].ToString();
            if (string.IsNullOrWhiteSpace(logoFile)) { pictureBoxLogo.Image = null; return; }

            // Path.Combine збирає повний шлях: "C:\...\bin\Debug\Assets\Database\Logos\ferrari.png"
            string logoPath = Path.Combine(DatabaseHelper.LogosFolderPath, logoFile);

            if (File.Exists(logoPath))
            {
                try
                {
                    // using — конструкція, яка автоматично звільняє ресурс (закриває файл)
                    // після завершення блоку { }, навіть якщо виникне помилка.
                    using (System.Drawing.Bitmap tmp = new System.Drawing.Bitmap(logoPath))
                    {
                        // Перед заміною зображення звільняємо пам'ять від попереднього.
                        if (pictureBoxLogo.Image != null) pictureBoxLogo.Image.Dispose();

                        // Зберігаємо незалежну копію зображення.
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

        // ─── Навігація по таблиці команд ──────────────────────────────────────

        // Подія SelectionChanged — спрацьовує щоразу, коли користувач клікає
        // на інший рядок у dgvTeams (мишею або клавіатурою).
        private void dgvTeams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeams.SelectedRows.Count == 0) return;

            // Запам'ятовуємо новий поточний рядок.
            _teamCurrentRow = dgvTeams.SelectedRows[0].Index;
            UpdateTeamNavLabel();
            LoadTeamLogo();
            LoadDriversForSelectedTeam();
        }

        // Кнопки навігації — кожна викликає NavigateTeams з потрібним індексом.
        // «Перший» — індекс 0 (перший рядок).
        // «Останній» — індекс Rows.Count - 1 (останній рядок).
        // «Попередній» — поточний мінус 1.
        // «Наступний» — поточний плюс 1.
        private void btnTeamFirst_Click(object sender, EventArgs e)  { NavigateTeams(0); }
        private void btnTeamLast_Click(object sender, EventArgs e)   { NavigateTeams(dgvTeams.Rows.Count - 1); }
        private void btnTeamPrev_Click(object sender, EventArgs e)   { NavigateTeams(_teamCurrentRow - 1); }
        private void btnTeamNext_Click(object sender, EventArgs e)   { NavigateTeams(_teamCurrentRow + 1); }

        // Переходить до рядка з вказаним індексом.
        // Захищає від виходу за межі: якщо index < 0, ставимо 0;
        // якщо index > останнього рядка — ставимо останній.
        private void NavigateTeams(int index)
        {
            if (dgvTeams.Rows.Count == 0) return;

            // «Затискаємо» значення в допустимих межах [0 .. Rows.Count-1].
            if (index < 0)
                index = 0;
            if (index > dgvTeams.Rows.Count - 1)
                index = dgvTeams.Rows.Count - 1;

            _teamCurrentRow = index;

            // ClearSelection() прибирає поточне виділення, потім виділяємо потрібний рядок.
            dgvTeams.ClearSelection();
            dgvTeams.Rows[index].Selected = true;

            // Прокручуємо таблицю так, щоб вибраний рядок був видимий.
            dgvTeams.FirstDisplayedScrollingRowIndex = index;
            UpdateTeamNavLabel();
        }

        // Оновлює лічильник навігації, наприклад: «3 / 11».
        // DataGridView нумерує рядки з 0 (як масив),
        // але для користувача показуємо з 1, тому додаємо +1.
        private void UpdateTeamNavLabel()
        {
            int currentDisplay;
            if (dgvTeams.Rows.Count > 0)
                currentDisplay = _teamCurrentRow + 1;
            else
                currentDisplay = 0;

            labelTeamPos.Text = string.Format("{0} / {1}", currentDisplay, dgvTeams.Rows.Count);
        }

        // ─── Пошук ────────────────────────────────────────────────────────────

        // Обробник кнопки «Пошук».
        // Шукає команди, назва або країна яких містить введений текст.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Trim() — видаляє пробіли на початку і в кінці рядка.
            string val = txtSearch.Text.Trim();

            // Якщо поле порожнє — просто показуємо всі команди.
            if (string.IsNullOrWhiteSpace(val))
            {
                LoadTeams();
                return;
            }

            // SearchTeams виконує SQL-запит із LIKE '%val%' — шукає входження тексту.
            DataTable dt = DatabaseHelper.SearchTeams(val);
            dgvTeams.DataSource = dt;
            SetTeamsColumnHeaders();
            _teamCurrentRow = 0;
            UpdateTeamNavLabel();

            // string.Format — форматування рядка (замість "+" для склеювання).
            // {0}, {1}, {2} — замінюються значеннями val, dt.Rows.Count.
            SetStatus(string.Format("Пошук '{0}': знайдено {1} команд(и).", val, dt.Rows.Count));

            if (dt.Rows.Count > 0)
            {
                dgvTeams.Rows[0].Selected = true;
                LoadTeamLogo();
                LoadDriversForSelectedTeam();
            }
        }

        // Обробник кнопки «Очистити пошук» — скидає поле і показує всі команди.
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadTeams();
            SetStatus("Пошук скинуто.");
        }

        // ─── Фільтрування ─────────────────────────────────────────────────────

        // Обробник кнопки «Застосувати фільтр».
        // Дозволяє показати лише команди певної країни і/або з мінімальною кількістю чемпіонств.
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string country  = txtFilterCountry.Text.Trim();
            string champMin = txtFilterChampMin.Text.Trim();

            // Зчитуємо вибране поле сортування з ComboBox.
            // Якщо нічого не вибрано — сортуємо за назвою за замовчуванням.
            string sortField = "team_name";
            if (cmbSortField.SelectedItem != null)
                sortField = cmbSortField.SelectedItem.ToString();

            // Скидаємо на перший рядок, щоб не було помилок після зміни кількості результатів.
            _teamCurrentRow = 0;
            LoadTeams(sortField, chkSortAsc.Checked, country, champMin);

            // Формуємо зручний текст для рядка статусу:
            // якщо поле порожнє — показуємо «*» (означає «будь-яке») або «0».
            string countryDisplay  = string.IsNullOrWhiteSpace(country)  ? "*" : country;
            string champDisplay    = string.IsNullOrWhiteSpace(champMin) ? "0" : champMin;

            SetStatus(string.Format("Фільтр застосовано: Країна='{0}' AND Чемп≥{1}. Знайдено: {2}.",
                countryDisplay, champDisplay, dgvTeams.Rows.Count));
        }

        // Обробник кнопки «Скинути фільтр» — очищає поля фільтру і перезавантажує всі команди.
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterCountry.Clear();
            txtFilterChampMin.Clear();
            _teamCurrentRow = 0;
            LoadTeams();
            SetStatus("Фільтр скинуто.");
        }

        // ─── Сортування ───────────────────────────────────────────────────────

        // Обробник кнопки «Сортувати».
        // Зчитує вибране поле і напрямок, перезавантажує таблицю з новим ORDER BY.
        private void btnApplySort_Click(object sender, EventArgs e)
        {
            string field = "team_name";
            if (cmbSortField.SelectedItem != null)
                field = cmbSortField.SelectedItem.ToString();

            // chkSortAsc.Checked — true якщо прапорець «За зростанням» встановлений.
            bool asc = chkSortAsc.Checked;

            _teamCurrentRow = 0;

            // Передаємо поточні фільтри, щоб вони не скидалися під час зміни сортування.
            LoadTeams(field, asc,
                txtFilterCountry.Text.Trim(),
                txtFilterChampMin.Text.Trim());

            // ASC = ascending (за зростанням), DESC = descending (за спаданням).
            SetStatus(string.Format("Сортування: {0} {1}", field, asc ? "ASC" : "DESC"));
        }

        // ─── CRUD: Команди ────────────────────────────────────────────────────
        // CRUD = Create, Read, Update, Delete — чотири основні операції з даними БД.

        // Кнопка «Додати команду».
        // Відкриває діалогове вікно TeamEditForm у режимі «нова команда» (передаємо null).
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            // "using (TeamEditForm dlg = ...)" — після закриття вікна dlg автоматично
            // звільняє ресурси (пам'ять, дескриптори вікна) через метод Dispose().
            // null — сигнал формі, що ми додаємо новий запис, а не редагуємо існуючий.
            using (TeamEditForm dlg = new TeamEditForm(null))
            {
                // ShowDialog — відкриває форму у модальному режимі:
                // програма чекає, поки користувач не закриє dlg.
                // DialogResult.OK — користувач натиснув «Зберегти».
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // Передаємо введені дані в DatabaseHelper, який виконує SQL INSERT.
                    DatabaseHelper.AddTeam(dlg.TeamName, dlg.Country, dlg.Founded,
                                           dlg.Championships, dlg.LogoFile);
                    LoadTeams();
                    SetStatus("Команду додано.");
                }
            }
        }

        // Кнопка «Редагувати команду».
        // Відкриває TeamEditForm із заповненими полями вибраної команди.
        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTeamId();

            // ShowNoSelection() — показує повідомлення «оберіть запис».
            if (id < 0) { ShowNoSelection(); return; }

            // GetTeamById повертає DataRow — один рядок з таблиці Teams.
            DataRow row = DatabaseHelper.GetTeamById(id);
            if (row == null) return;

            // Передаємо row у форму — вона заповнить поля поточними значеннями.
            using (TeamEditForm dlg = new TeamEditForm(row))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // SQL UPDATE: оновлюємо запис з вказаним id.
                    DatabaseHelper.UpdateTeam(id, dlg.TeamName, dlg.Country, dlg.Founded,
                                              dlg.Championships, dlg.LogoFile);
                    LoadTeams();
                    SetStatus("Команду оновлено.");
                }
            }
        }

        // Кнопка «Видалити команду».
        // Запитує підтвердження, потім виконує SQL DELETE (з каскадним видаленням пілотів).
        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTeamId();
            if (id < 0) { ShowNoSelection(); return; }

            string name = GetSelectedTeamName();

            // MessageBox.Show з YesNo — запит підтвердження.
            // Повертає DialogResult.Yes або DialogResult.No.
            DialogResult confirm = MessageBox.Show(
                string.Format("Видалити команду «{0}»?\nВсі пілоти цієї команди будуть видалені!", name),
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteTeam(id);

                // Після видалення рядка зміщуємося на попередній (щоб не вийти за межі).
                if (_teamCurrentRow > 0)
                    _teamCurrentRow = _teamCurrentRow - 1;

                LoadTeams();
                SetStatus(string.Format("Команду «{0}» видалено.", name));
            }
        }

        // Кнопка «Деталі» — відкриває DetailsForm з докладною інформацією про команду і пілотів.
        private void btnDetailsTeam_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTeamId();
            if (id < 0) { ShowNoSelection(); return; }

            // DetailsForm отримує id команди і сама завантажує потрібні дані з БД.
            using (DetailsForm details = new DetailsForm(id))
                details.ShowDialog(this);
        }

        // ─── CRUD: Пілоти ─────────────────────────────────────────────────────

        // Кнопка «Додати пілота» — додає пілота до поточної вибраної команди.
        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            int teamId = GetSelectedTeamId();
            if (teamId < 0) { ShowNoSelection(); return; }

            // null — режим «новий пілот», teamId — команда, до якої додаємо.
            using (DriverEditForm dlg = new DriverEditForm(null, teamId))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DatabaseHelper.AddDriver(dlg.TeamId, dlg.DriverName, dlg.Number,
                                             dlg.Nationality, dlg.Wins, dlg.Points, dlg.PhotoFile);

                    // Оновлюємо лише нижню таблицю (пілоти), не всю сторінку.
                    LoadDriversForSelectedTeam();
                    SetStatus("Пілота додано.");
                }
            }
        }

        // Кнопка «Редагувати пілота».
        private void btnEditDriver_Click(object sender, EventArgs e)
        {
            int driverId = GetSelectedDriverId();
            if (driverId < 0) { ShowNoSelection(); return; }

            // Отримуємо поточні дані пілота з БД.
            DataRow row = DatabaseHelper.GetDriverById(driverId);
            if (row == null) return;

            using (DriverEditForm dlg = new DriverEditForm(row, GetSelectedTeamId()))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // SQL UPDATE для таблиці Drivers.
                    DatabaseHelper.UpdateDriver(driverId, dlg.TeamId, dlg.DriverName, dlg.Number,
                                               dlg.Nationality, dlg.Wins, dlg.Points, dlg.PhotoFile);
                    LoadDriversForSelectedTeam();
                    SetStatus("Дані пілота оновлено.");
                }
            }
        }

        // Кнопка «Видалити пілота».
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

        // ─── Закриття форми ───────────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close() закриває форму і звільняє всі її ресурси.
            Close();
        }

        // ─── Допоміжні (helper) методи ────────────────────────────────────────
        // Ці методи не прив'язані до конкретних подій —
        // вони виконують дрібні повторювані завдання і викликаються з багатьох місць.

        // Повертає team_id рядка, вибраного в dgvTeams, або -1 якщо нічого не вибрано.
        // Колонка team_id прихована від користувача, але присутня в DataTable і доступна через код.
        private int GetSelectedTeamId()
        {
            if (dgvTeams.SelectedRows.Count == 0) return -1;
            object val = dgvTeams.SelectedRows[0].Cells["team_id"].Value;

            // DBNull.Value — специфічне значення для NULL у базі даних (не те саме, що null у C#).
            // Перевіряємо обидва варіанти, щоб не отримати виняток при конвертації.
            if (val == null || val == DBNull.Value) return -1;

            // Convert.ToInt32 безпечно конвертує object → int.
            return Convert.ToInt32(val);
        }

        // Повертає назву вибраної команди або порожній рядок.
        private string GetSelectedTeamName()
        {
            if (dgvTeams.SelectedRows.Count == 0) return string.Empty;
            object val = dgvTeams.SelectedRows[0].Cells["team_name"].Value;
            if (val == null) return string.Empty;
            return val.ToString();
        }

        // Повертає driver_id вибраного пілота в dgvDrivers, або -1.
        private int GetSelectedDriverId()
        {
            if (dgvDrivers.SelectedRows.Count == 0) return -1;
            object val = dgvDrivers.SelectedRows[0].Cells["driver_id"].Value;
            if (val == null || val == DBNull.Value) return -1;
            return Convert.ToInt32(val);
        }

        // Повертає ім'я вибраного пілота або порожній рядок.
        private string GetSelectedDriverName()
        {
            if (dgvDrivers.SelectedRows.Count == 0) return string.Empty;
            object val = dgvDrivers.SelectedRows[0].Cells["driver_name"].Value;
            if (val == null) return string.Empty;
            return val.ToString();
        }

        // Встановлює заголовок і ширину колонки у DataGridView.
        // "static" — метод не потребує доступу до полів об'єкта (this), тому оголошений статичним.
        // Параметри: dgv — таблиця, columnName — SQL-назва колонки, header — текст заголовку,
        //            width — ширина в пікселях.
        private static void SetColumnHeader(DataGridView dgv, string columnName, string header, int width)
        {
            // Columns.Contains перевіряє наявність колонки — захист від помилки при першому рендері.
            if (!dgv.Columns.Contains(columnName)) return;
            dgv.Columns[columnName].HeaderText   = header;
            dgv.Columns[columnName].Width        = width;
            // None — вимикаємо авторозмір, щоб ширина була саме такою, яку ми задали.
            dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        // Ховає колонку з DataGridView (користувач її не бачить, але код може читати значення).
        private static void HideColumn(DataGridView dgv, string columnName)
        {
            if (dgv.Columns.Contains(columnName))
                dgv.Columns[columnName].Visible = false;
        }

        // Оновлює текст рядка статусу внизу форми.
        private void SetStatus(string text)
        {
            labelStatus.Text = text;
        }

        // Показує стандартне повідомлення, якщо користувач натискає кнопку дії без вибраного рядка.
        private void ShowNoSelection()
        {
            MessageBox.Show("Будь ласка, оберіть запис.", "Увага",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
