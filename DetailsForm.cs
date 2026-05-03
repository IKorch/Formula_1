using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class DetailsForm : Form
    {
        private readonly int _teamId;
        private DataTable _drivers;

        public DetailsForm(int teamId)
        {
            _teamId = teamId;
            InitializeComponent();
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            LoadTeamInfo();
            LoadDriversList();
        }

        private void LoadTeamInfo()
        {
            DataRow row = DatabaseHelper.GetTeamById(_teamId);
            if (row == null) return;

            string name  = row["team_name"].ToString();
            labelTitle.Text = string.Format("ДЕТАЛІ: {0}", name.ToUpper());

            SetLabel(labelTeamName,      "Команда:",       name);
            SetLabel(labelCountry,       "Країна:",        row["team_country"].ToString());
            SetLabel(labelFounded,       "Заснована:",     row["team_founded"].ToString());
            SetLabel(labelChampionships, "Чемпіонства:",   row["team_championships"].ToString());
            SetLabel(labelLogoFile,      "Логотип:",       row["team_logo_file"].ToString());

            string logoFile = row["team_logo_file"].ToString();
            if (!string.IsNullOrWhiteSpace(logoFile))
            {
                string path = Path.Combine(DatabaseHelper.LogosFolderPath, logoFile);
                if (File.Exists(path))
                {
                    try
                    {
                        using (System.Drawing.Bitmap tmp = new System.Drawing.Bitmap(path))
                        {
                            if (pictureBoxLogo.Image != null) pictureBoxLogo.Image.Dispose();
                            pictureBoxLogo.Image = new System.Drawing.Bitmap(tmp);
                        }
                    }
                    catch { pictureBoxLogo.Image = null; }
                }
            }
        }

        private void LoadDriversList()
        {
            _drivers = DatabaseHelper.GetDriversByTeam(_teamId);
            listBoxDrivers.Items.Clear();

            foreach (DataRow row in _drivers.Rows)
            {
                string item = string.Format("#{0}  {1}",
                    row["driver_number"],
                    row["driver_name"]);
                listBoxDrivers.Items.Add(item);
            }

            if (listBoxDrivers.Items.Count > 0)
                listBoxDrivers.SelectedIndex = 0;
        }

        private void listBoxDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBoxDrivers.SelectedIndex;
            if (idx < 0 || _drivers == null || idx >= _drivers.Rows.Count) return;

            DataRow row = _drivers.Rows[idx];
            ShowDriverDetails(row);
        }

        private void ShowDriverDetails(DataRow row)
        {
            SetLabel(lblDName,    "Ім'я:",           row["driver_name"].ToString());
            SetLabel(lblDNumber,  "Номер:",          row["driver_number"].ToString());
            SetLabel(lblDNat,     "Національність:", row["driver_nationality"].ToString());
            SetLabel(lblDWins,    "Перемоги:",       row["driver_wins"].ToString());
            SetLabel(lblDPoints,  "Очки:",           row["driver_points"].ToString());
            SetLabel(lblDWinRate, "Win rate %:",     row["win_rate"].ToString());

            string photoFile = row["driver_photo_file"].ToString();
            if (!string.IsNullOrWhiteSpace(photoFile))
            {
                string path = Path.Combine(DatabaseHelper.PhotosFolderPath, photoFile);
                if (File.Exists(path))
                {
                    try
                    {
                        using (System.Drawing.Bitmap tmp = new System.Drawing.Bitmap(path))
                        {
                            if (pictureBoxDriver.Image != null) pictureBoxDriver.Image.Dispose();
                            pictureBoxDriver.Image = new System.Drawing.Bitmap(tmp);
                        }
                        return;
                    }
                    catch { }
                }
            }
            if (pictureBoxDriver.Image != null) { pictureBoxDriver.Image.Dispose(); pictureBoxDriver.Image = null; }
        }

        private static void SetLabel(Label lbl, string caption, string value)
        {
            lbl.Text = string.Format("{0}  {1}", caption, value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
