using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyMainMenuBackground();
        }

        private void ApplyMainMenuBackground()
        {
            string startupPath = Application.StartupPath;
            string[] candidatePaths =
            {
                Path.Combine(startupPath, "Assets", "Main", "main_menu_bg.jpg"),
                Path.Combine(startupPath, "..", "..", "Assets", "Main", "main_menu_bg.jpg"),
                Path.Combine(startupPath, "..", "..", "..", "Assets", "Main", "main_menu_bg.jpg")
            };

            foreach (string candidatePath in candidatePaths)
            {
                string fullPath = Path.GetFullPath(candidatePath);
                if (!File.Exists(fullPath))
                {
                    continue;
                }

                BackgroundImage = Image.FromFile(fullPath);
                BackgroundImageLayout = ImageLayout.Stretch;
                return;
            }
        }

        private void labelArticles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ArticlesForm());
        }

        private void labelGallery_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GalleryForm());
        }

        private void labelMedia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MediaForm());
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HelpForm());
        }

        private void labelMenu_MouseEnter(object sender, EventArgs e)
        {
            Label currentLabel = sender as Label;
            if (currentLabel == null)
            {
                return;
            }

            currentLabel.ForeColor = Color.White;
            currentLabel.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void labelMenu_MouseLeave(object sender, EventArgs e)
        {
            Label currentLabel = sender as Label;
            if (currentLabel == null)
            {
                return;
            }

            currentLabel.ForeColor = Color.FromArgb(192, 57, 43);
            currentLabel.BackColor = Color.Transparent;
        }

        private void OpenChildForm(Form form)
        {
            form.Show();
        }
    }
}
