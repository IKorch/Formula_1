using System;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class HelpForm : Form
    {
        private const string AuthorPhotoFileName = "author_photo.jpg";

        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            string photoPath = ResolveAuthorPhotoPath();
            if (!string.IsNullOrWhiteSpace(photoPath) && File.Exists(photoPath))
            {
                pictureBoxAuthorPhoto.Load(photoPath);
            }
            else
            {
                pictureBoxAuthorPhoto.Image = null;
            }
        }

        private string ResolveAuthorPhotoPath()
        {
            string startupPath = Application.StartupPath;

            string[] possiblePaths =
            {
                Path.Combine(startupPath, "Assets", "Help", AuthorPhotoFileName),
                Path.Combine(startupPath, "..", "..", "Assets", "Help", AuthorPhotoFileName),
                Path.Combine(startupPath, "..", "..", "..", "Assets", "Help", AuthorPhotoFileName)
            };

            foreach (string path in possiblePaths)
            {
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return null;
        }
    }
}
