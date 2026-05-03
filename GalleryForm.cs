using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class GalleryForm : Form
    {
        private const int VisibleThumbnails = 5;

        private readonly List<GalleryPhoto>  _photos = new List<GalleryPhoto>();
        private List<PictureBox> _thumbnailBoxes;

        private int _selectedPhotoIndex;
        private int _shownPhotosMinIndex;

        private bool _isSlideShowActive;
        private bool _resumeSlideShowAfterActivate;

        private dynamic _musicPlayer;
        private string _musicFilePath;

        public GalleryForm()
        {
            InitializeComponent();
            _thumbnailBoxes = new List<PictureBox>
            {
                thumbnail1,
                thumbnail2,
                thumbnail3,
                thumbnail4,
                thumbnail5
            };
        }

        private void GalleryForm_Load(object sender, EventArgs e)
        {
            LoadPhotos();
            InitializeMusicPlayer();
            UpdateGalleryView();
        }

        private void thumbnail_Click(object sender, EventArgs e)
        {
            PictureBox clickedThumbnail = sender as PictureBox;
            if (clickedThumbnail == null || clickedThumbnail.Tag == null)
            {
                return;
            }

            int photoIndex = (int)clickedThumbnail.Tag;
            if (photoIndex < 0 || photoIndex >= _photos.Count)
            {
                return;
            }

            _selectedPhotoIndex = photoIndex;
            EnsureSelectedInVisibleRange();
            UpdateGalleryView();
        }

        private void btnSlideShow_Click(object sender, EventArgs e)
        {
            if (_photos.Count == 0)
            {
                return;
            }

            if (_isSlideShowActive)
            {
                StopSlideShow();
            }
            else
            {
                StartSlideShow();
            }
        }

        private void slideShowTimer_Tick(object sender, EventArgs e)
        {
            if (_photos.Count == 0)
            {
                return;
            }

            _selectedPhotoIndex = _selectedPhotoIndex == _photos.Count - 1 ? 0 : _selectedPhotoIndex + 1;
            EnsureSelectedInVisibleRange();
            UpdateGalleryView();
        }

        private void GalleryForm_Deactivate(object sender, EventArgs e)
        {
            if (!_isSlideShowActive)
            {
                return;
            }

            _resumeSlideShowAfterActivate = true;
            slideShowTimer.Stop();
            PauseMusic();
        }

        private void GalleryForm_Activated(object sender, EventArgs e)
        {
            if (!_resumeSlideShowAfterActivate)
            {
                return;
            }

            _resumeSlideShowAfterActivate = false;
            slideShowTimer.Start();
            ResumeMusic();
        }

        private void GalleryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopSlideShow();
            TryDisposeMusicPlayer();
        }

        private void  LoadPhotos()
        {
            _photos.Clear();

            string photosFolderPath = Path.Combine(Application.StartupPath, "Assets", "Photos");
            string csvPath = Path.Combine(photosFolderPath, "ImageTitles.csv");
            if (!File.Exists(csvPath))
            {
                return;
            }

            string[] rows = File.ReadAllLines(csvPath);
            foreach (string row in rows)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }

                string[] parts = row.Split(new[] { ',' }, 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                string fileName = parts[0].Trim();
                string title = parts[1].Trim();
                string fullPath = Path.Combine(photosFolderPath, fileName);
                if (!File.Exists(fullPath))
                {
                    continue;
                }

                _photos.Add(new GalleryPhoto(fullPath, title));
            }

            _selectedPhotoIndex = 0;
            _shownPhotosMinIndex = 0;
        }

        private void UpdateGalleryView()
        {
            bool hasPhotos = _photos.Count > 0;

            if (!hasPhotos)
            {
                pictureBoxMain.Image = null;
                labelPhotoTitle.Text = "Фотографії не знайдено у Assets/Photos";
                btnSlideShow.Enabled = false;
                foreach (PictureBox thumbnail in _thumbnailBoxes)
                {
                    thumbnail.Image = null;
                    thumbnail.Tag = -1;
                    thumbnail.BorderStyle = BorderStyle.FixedSingle;
                }

                return;
            }

            btnSlideShow.Enabled = true;

            GalleryPhoto selectedPhoto = _photos[_selectedPhotoIndex];

            // Завантажуємо через Bitmap а не .Load(), щоб уникнути "полосок"
            // (PictureBox.Load() відображає JPEG прогресивно — рядок за рядком).
            using (System.Drawing.Bitmap tmp = new System.Drawing.Bitmap(selectedPhoto.ImagePath))
            {
                if (pictureBoxMain.Image != null) pictureBoxMain.Image.Dispose();
                pictureBoxMain.Image = new System.Drawing.Bitmap(tmp);
            }
            labelPhotoTitle.Text = selectedPhoto.Title;

            for (int i = 0; i < _thumbnailBoxes.Count; i++)
            {
                PictureBox thumbnail = _thumbnailBoxes[i];
                int photoIndex = _shownPhotosMinIndex + i;
                if (photoIndex >= _photos.Count)
                {
                    thumbnail.Image = null;
                    thumbnail.Tag = -1;
                    thumbnail.BorderStyle = BorderStyle.FixedSingle;
                    continue;
                }

                // Завантажуємо через Bitmap, щоб отримати повне фото без полосок
                using (System.Drawing.Bitmap tmp = new System.Drawing.Bitmap(_photos[photoIndex].ImagePath))
                {
                    if (thumbnail.Image != null) thumbnail.Image.Dispose();
                    thumbnail.Image = new System.Drawing.Bitmap(tmp);
                }
                thumbnail.Tag = photoIndex;
                thumbnail.BorderStyle = photoIndex == _selectedPhotoIndex
                    ? BorderStyle.Fixed3D
                    : BorderStyle.FixedSingle;
            }
        }

        private void EnsureSelectedInVisibleRange()
        {
            if (_selectedPhotoIndex < _shownPhotosMinIndex)
            {
                _shownPhotosMinIndex = _selectedPhotoIndex;
            }

            int shownPhotosMaxIndex = _shownPhotosMinIndex + VisibleThumbnails - 1;
            if (_selectedPhotoIndex > shownPhotosMaxIndex)
            {
                _shownPhotosMinIndex = _selectedPhotoIndex - VisibleThumbnails + 1;
            }

            int allowedMinIndex = Math.Max(0, _photos.Count - VisibleThumbnails);
            if (_shownPhotosMinIndex > allowedMinIndex)
            {
                _shownPhotosMinIndex = allowedMinIndex;
            }
        }

        private void StartSlideShow()
        {
            _isSlideShowActive = true;
            _resumeSlideShowAfterActivate = false;
            slideShowTimer.Start();
            btnSlideShow.Text = "Стоп слайдшоу";
            StartMusic();
        }

        private void StopSlideShow()
        {
            _isSlideShowActive = false;
            _resumeSlideShowAfterActivate = false;
            slideShowTimer.Stop();
            btnSlideShow.Text = "Старт слайдшоу";
            StopMusic();
        }

        private void InitializeMusicPlayer()
        {
            _musicFilePath = ResolveMusicPath();
            if (string.IsNullOrWhiteSpace(_musicFilePath))
            {
                return;
            }

            try
            {
                Type playerType = Type.GetTypeFromProgID("WMPlayer.OCX");
                if (playerType == null)
                {
                    return;
                }

                _musicPlayer = Activator.CreateInstance(playerType);
                _musicPlayer.settings.setMode("loop", true);
            }
            catch
            {
                _musicPlayer = null;
            }
        }

        private string ResolveMusicPath()
        {
            string mediaFolderPath = Path.Combine(Application.StartupPath, "Assets", "Media");
            if (Directory.Exists(mediaFolderPath))
            {
                string customAudio = Directory.GetFiles(mediaFolderPath, "*.mp3").FirstOrDefault()
                    ?? Directory.GetFiles(mediaFolderPath, "*.wav").FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(customAudio))
                {
                    return customAudio;
                }
            }

            string windowsMediaPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            if (!string.IsNullOrWhiteSpace(windowsMediaPath))
            {
                string defaultMediaFolder = Path.Combine(windowsMediaPath, "Media");
                if (Directory.Exists(defaultMediaFolder))
                {
                    return Directory.GetFiles(defaultMediaFolder, "*.wav").FirstOrDefault();
                }
            }

            return null;
        }

        private void StartMusic()
        {
            if (_musicPlayer == null || string.IsNullOrWhiteSpace(_musicFilePath))
            {
                return;
            }

            try
            {
                _musicPlayer.URL = _musicFilePath;
                _musicPlayer.controls.play();
            }
            catch
            {
            }
        }

        private void PauseMusic()
        {
            if (_musicPlayer == null)
            {
                return;
            }

            try
            {
                _musicPlayer.controls.pause();
            }
            catch
            {
            }
        }

        private void ResumeMusic()
        {
            if (_musicPlayer == null)
            {
                return;
            }

            try
            {
                _musicPlayer.controls.play();
            }
            catch
            {
            }
        }

        private void StopMusic()
        {
            if (_musicPlayer == null)
            {
                return;
            }

            try
            {
                _musicPlayer.controls.stop();
            }
            catch
            {
            }
        }

        private void TryDisposeMusicPlayer()
        {
            if (_musicPlayer == null)
            {
                return;
            }

            try
            {
                _musicPlayer.close();
            }
            catch
            {
            }
            finally
            {
                _musicPlayer = null;
            }
        }

        //Прибрав AutoFill, а також sealed
        private class GalleryPhoto
        {
            private readonly string _imagePath;
            private readonly string _title;

            public GalleryPhoto(string imagePath, string title)
            {
                this._imagePath = imagePath;
                this._title = title;
            }

            public string ImagePath { get { return _imagePath; } }
            public string Title { get { return _title; } }
        }
    }
}
