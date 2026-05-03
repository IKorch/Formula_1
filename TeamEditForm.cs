using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    /// <summary>Діалог додавання/редагування команди.</summary>
    public class TeamEditForm : Form
    {
        // ── Результати ────────────────────────────────────────────────────────
        public string TeamName      { get; private set; }
        public string Country       { get; private set; }
        public int    Founded       { get; private set; }
        public int    Championships { get; private set; }
        public string LogoFile      { get; private set; }

        // ── Контролли ─────────────────────────────────────────────────────────
        private readonly TextBox  _txtName;
        private readonly TextBox  _txtCountry;
        private readonly TextBox  _txtFounded;
        private readonly TextBox  _txtChamp;
        private readonly TextBox  _txtLogo;
        private readonly Button   _btnBrowse;
        private readonly Button   _btnOk;
        private readonly Button   _btnCancel;

        public TeamEditForm(DataRow existingRow)
        {
            Text            = existingRow == null ? "Нова команда" : "Редагувати команду";
            ClientSize      = new System.Drawing.Size(440, 310);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            StartPosition   = FormStartPosition.CenterParent;
            BackColor       = System.Drawing.Color.FromArgb(28, 28, 36);
            ForeColor       = System.Drawing.Color.White;
            Font            = new System.Drawing.Font("Segoe UI", 9.5F);

            int lx = 12, tx = 170, w = 240, h = 24, gap = 36;

            _txtName    = AddRow("Назва команди:",   lx, tx, w, h, 10,          w);
            _txtCountry = AddRow("Країна:",          lx, tx, w, h, 10 + gap,    w);
            _txtFounded = AddRow("Рік заснування:",  lx, tx, w, h, 10 + gap*2,  w);
            _txtChamp   = AddRow("Чемпіонства:",     lx, tx, w, h, 10 + gap*3,  w);
            _txtLogo    = AddRow("Файл логотипу:",   lx, tx, w, h, 10 + gap*4,  180);

            _btnBrowse = new Button
            {
                Text      = "...",
                Location  = new System.Drawing.Point(tx + 186, 10 + gap*4),
                Size      = new System.Drawing.Size(50, h),
                BackColor = System.Drawing.Color.FromArgb(60, 60, 80),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            _btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 57, 43);
            _btnBrowse.Click += BrowseLogo;
            Controls.Add(_btnBrowse);

            _btnOk = new Button
            {
                Text      = "Зберегти",
                DialogResult = DialogResult.OK,
                Location  = new System.Drawing.Point(250, 266),
                Size      = new System.Drawing.Size(85, 28),
                BackColor = System.Drawing.Color.FromArgb(192, 57, 43),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            _btnOk.FlatAppearance.BorderSize = 0;
            _btnOk.Click += OkClick;
            Controls.Add(_btnOk);

            _btnCancel = new Button
            {
                Text         = "Скасувати",
                DialogResult = DialogResult.Cancel,
                Location     = new System.Drawing.Point(344, 266),
                Size         = new System.Drawing.Size(85, 28),
                BackColor    = System.Drawing.Color.FromArgb(60, 60, 80),
                ForeColor    = System.Drawing.Color.White,
                FlatStyle    = FlatStyle.Flat
            };
            _btnCancel.FlatAppearance.BorderSize = 0;
            Controls.Add(_btnCancel);

            AcceptButton = _btnOk;
            CancelButton = _btnCancel;

            if (existingRow != null)
            {
                _txtName.Text    = existingRow["team_name"].ToString();
                _txtCountry.Text = existingRow["team_country"].ToString();
                _txtFounded.Text = existingRow["team_founded"].ToString();
                _txtChamp.Text   = existingRow["team_championships"].ToString();
                _txtLogo.Text    = existingRow["team_logo_file"].ToString();
            }
        }

        private TextBox AddRow(string labelText, int lx, int tx, int w, int h, int y, int fieldWidth)
        {
            var lbl = new Label
            {
                Text      = labelText,
                Location  = new System.Drawing.Point(lx, y + 4),
                Size      = new System.Drawing.Size(155, h),
                ForeColor = System.Drawing.Color.White,
                Font      = new System.Drawing.Font("Segoe UI", 9.5F)
            };
            Controls.Add(lbl);

            var txt = new TextBox
            {
                Location  = new System.Drawing.Point(tx, y),
                Size      = new System.Drawing.Size(fieldWidth, h),
                BackColor = System.Drawing.Color.FromArgb(50, 50, 65),
                ForeColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font      = new System.Drawing.Font("Segoe UI", 9.5F)
            };
            Controls.Add(txt);
            return txt;
        }

        private void BrowseLogo(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title  = "Оберіть файл логотипу";
                dlg.Filter = "Зображення (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                dlg.InitialDirectory = DatabaseHelper.LogosFolderPath;

                if (dlg.ShowDialog() == DialogResult.OK)
                    _txtLogo.Text = Path.GetFileName(dlg.FileName);
            }
        }

        private void OkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtName.Text))
            {
                MessageBox.Show("Введіть назву команди.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            int founded, champ;
            if (!int.TryParse(_txtFounded.Text, out founded) || founded < 1950 || founded > 2100)
            {
                MessageBox.Show("Рік заснування має бути числом (1950–2100).", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (!int.TryParse(_txtChamp.Text, out champ) || champ < 0)
            {
                MessageBox.Show("Кількість чемпіонств — невід'ємне ціле число.", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            TeamName      = _txtName.Text.Trim();
            Country       = _txtCountry.Text.Trim();
            Founded       = founded;
            Championships = champ;
            LogoFile      = _txtLogo.Text.Trim();
        }
    }
}
