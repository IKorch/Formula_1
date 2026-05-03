using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    /// <summary>Діалог додавання/редагування пілота.</summary>
    public class DriverEditForm : Form
    {
        // ── Результати ────────────────────────────────────────────────────────
        public int    TeamId      { get; private set; }
        public string DriverName  { get; private set; }
        public int    Number      { get; private set; }
        public string Nationality { get; private set; }
        public int    Wins        { get; private set; }
        public double Points      { get; private set; }
        public string PhotoFile   { get; private set; }

        // ── Контролли ─────────────────────────────────────────────────────────
        private readonly ComboBox _cmbTeam;
        private readonly TextBox  _txtName;
        private readonly TextBox  _txtNumber;
        private readonly TextBox  _txtNat;
        private readonly TextBox  _txtWins;
        private readonly TextBox  _txtPoints;
        private readonly TextBox  _txtPhoto;
        private readonly Button   _btnBrowse;
        private readonly Button   _btnOk;
        private readonly Button   _btnCancel;

        private DataRow _existingRow;
        private int     _defaultTeamId;

        public DriverEditForm(DataRow existingRow, int defaultTeamId)
        {
            Text            = existingRow == null ? "Новий пілот" : "Редагувати пілота";
            ClientSize      = new System.Drawing.Size(440, 346);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            StartPosition   = FormStartPosition.CenterParent;
            BackColor       = System.Drawing.Color.FromArgb(28, 28, 36);
            ForeColor       = System.Drawing.Color.White;
            Font            = new System.Drawing.Font("Segoe UI", 9.5F);

            int lx = 12, tx = 170, w = 240, h = 24, gap = 36;

            // Team ComboBox
            AddLabel("Команда:", lx, 10 + 4);
            _cmbTeam = new ComboBox
            {
                Location     = new System.Drawing.Point(tx, 10),
                Size         = new System.Drawing.Size(w, h),
                DropDownStyle= ComboBoxStyle.DropDownList,
                BackColor    = System.Drawing.Color.FromArgb(50, 50, 65),
                ForeColor    = System.Drawing.Color.White,
                FlatStyle    = FlatStyle.Flat,
                Font         = new System.Drawing.Font("Segoe UI", 9.5F)
            };
            Controls.Add(_cmbTeam);

            _txtName   = AddRow("Ім'я пілота:",      lx, tx, w, h, 10 + gap,   w);
            _txtNumber = AddRow("Номер:",             lx, tx, w, h, 10 + gap*2, w);
            _txtNat    = AddRow("Національність:",   lx, tx, w, h, 10 + gap*3, w);
            _txtWins   = AddRow("Перемоги:",         lx, tx, w, h, 10 + gap*4, w);
            _txtPoints = AddRow("Очки:",             lx, tx, w, h, 10 + gap*5, w);
            _txtPhoto  = AddRow("Файл фото:",        lx, tx, w, h, 10 + gap*6, 186);

            _btnBrowse = new Button
            {
                Text      = "...",
                Location  = new System.Drawing.Point(tx + 192, 10 + gap*6),
                Size      = new System.Drawing.Size(46, h),
                BackColor = System.Drawing.Color.FromArgb(60, 60, 80),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            _btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 57, 43);
            _btnBrowse.Click += BrowsePhoto;
            Controls.Add(_btnBrowse);

            _btnOk = new Button
            {
                Text         = "Зберегти",
                DialogResult = DialogResult.OK,
                Location     = new System.Drawing.Point(250, 306),
                Size         = new System.Drawing.Size(85, 28),
                BackColor    = System.Drawing.Color.FromArgb(192, 57, 43),
                ForeColor    = System.Drawing.Color.White,
                FlatStyle    = FlatStyle.Flat
            };
            _btnOk.FlatAppearance.BorderSize = 0;
            _btnOk.Click += OkClick;
            Controls.Add(_btnOk);

            _btnCancel = new Button
            {
                Text         = "Скасувати",
                DialogResult = DialogResult.Cancel,
                Location     = new System.Drawing.Point(344, 306),
                Size         = new System.Drawing.Size(85, 28),
                BackColor    = System.Drawing.Color.FromArgb(60, 60, 80),
                ForeColor    = System.Drawing.Color.White,
                FlatStyle    = FlatStyle.Flat
            };
            _btnCancel.FlatAppearance.BorderSize = 0;
            Controls.Add(_btnCancel);

            AcceptButton = _btnOk;
            CancelButton = _btnCancel;

            _existingRow   = existingRow;
            _defaultTeamId = defaultTeamId;
            Load += DriverEditForm_Load;
        }

        private void DriverEditForm_Load(object sender, EventArgs e)
        {
            PopulateTeams(_existingRow, _defaultTeamId);
        }

        private void PopulateTeams(DataRow existingRow, int defaultTeamId)
        {
            DataTable teams = DatabaseHelper.GetTeamsList();
            _cmbTeam.DataSource    = teams;
            _cmbTeam.DisplayMember = "team_name";
            _cmbTeam.ValueMember   = "team_id";

            int selectTeamId = defaultTeamId;
            if (existingRow != null)
                selectTeamId = Convert.ToInt32(existingRow["team_id"]);

            _cmbTeam.SelectedValue = selectTeamId;
            if (_cmbTeam.SelectedIndex < 0 && _cmbTeam.Items.Count > 0)
                _cmbTeam.SelectedIndex = 0;

            if (existingRow != null)
            {
                _txtName.Text   = existingRow["driver_name"].ToString();
                _txtNumber.Text = existingRow["driver_number"].ToString();
                _txtNat.Text    = existingRow["driver_nationality"].ToString();
                _txtWins.Text   = existingRow["driver_wins"].ToString();
                _txtPoints.Text = existingRow["driver_points"].ToString();
                _txtPhoto.Text  = existingRow["driver_photo_file"].ToString();
            }
        }

        private void AddLabel(string text, int x, int y)
        {
            var lbl = new Label
            {
                Text     = text,
                Location = new System.Drawing.Point(x, y),
                Size     = new System.Drawing.Size(155, 22),
                ForeColor= System.Drawing.Color.White,
                Font     = new System.Drawing.Font("Segoe UI", 9.5F)
            };
            Controls.Add(lbl);
        }

        private TextBox AddRow(string labelText, int lx, int tx, int w, int h, int y, int fieldWidth)
        {
            AddLabel(labelText, lx, y + 4);
            var txt = new TextBox
            {
                Location    = new System.Drawing.Point(tx, y),
                Size        = new System.Drawing.Size(fieldWidth, h),
                BackColor   = System.Drawing.Color.FromArgb(50, 50, 65),
                ForeColor   = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font        = new System.Drawing.Font("Segoe UI", 9.5F)
            };
            Controls.Add(txt);
            return txt;
        }

        private void BrowsePhoto(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title  = "Оберіть фото пілота";
                dlg.Filter = "Зображення (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                dlg.InitialDirectory = DatabaseHelper.PhotosFolderPath;
                if (dlg.ShowDialog() == DialogResult.OK)
                    _txtPhoto.Text = Path.GetFileName(dlg.FileName);
            }
        }

        private void OkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtName.Text))
            {
                MessageBox.Show("Введіть ім'я пілота.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            int number, wins;
            double points;

            if (!int.TryParse(_txtNumber.Text, out number) || number < 0 || number > 99)
            {
                MessageBox.Show("Номер пілота — ціле число від 0 до 99.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (!int.TryParse(_txtWins.Text, out wins) || wins < 0)
            {
                MessageBox.Show("Перемоги — невід'ємне ціле число.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (!double.TryParse(_txtPoints.Text, out points) || points < 0)
            {
                MessageBox.Show("Очки — невід'ємне число.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (_cmbTeam.SelectedValue == null)
            {
                MessageBox.Show("Оберіть команду.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            TeamId      = Convert.ToInt32(_cmbTeam.SelectedValue);
            DriverName  = _txtName.Text.Trim();
            Number      = number;
            Nationality = _txtNat.Text.Trim();
            Wins        = wins;
            Points      = points;
            PhotoFile   = _txtPhoto.Text.Trim();
        }
    }
}
