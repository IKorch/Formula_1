using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class MediaForm : Form
    {
        private readonly List<MediaItem> _mediaItems = new List<MediaItem>();
        private MediaItem _currentItem;

        private MediaPlayerHost _mediaPlayerHost;
        private dynamic _ocxPlayer;

        public MediaForm()
        {
            InitializeComponent();
        }

        private void MediaForm_Load(object sender, EventArgs e)
        {
            InitializePlayerHost();
            LoadAudioPlaceholder();
            LoadMediaItems();

            if (listBoxMediaFiles.Items.Count > 0)
            {
                listBoxMediaFiles.SelectedIndex = 0;
            }
            else
            {
                labelNowPlaying.Text = "Now Playing: медіафайли не знайдено";
                btnPlay.Enabled = false;
                btnPause.Enabled = false;
            }
        }

        private void MediaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePlayer();
        }

        private void listBoxMediaFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaItem selected = listBoxMediaFiles.SelectedItem as MediaItem;
            if (selected == null)
            {
                return;
            }

            _currentItem = selected;
            PlayCurrentItem();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_currentItem == null)
            {
                return;
            }

            PlayCurrentItem();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_ocxPlayer == null)
            {
                return;
            }

            try
            {
                _ocxPlayer.controls.pause();
            }
            catch
            {
            }
        }

        private void InitializePlayerHost()
        {
            _mediaPlayerHost = new MediaPlayerHost
            {
                Dock = DockStyle.Fill,
                Enabled = true
            };

            panelPlayerHost.Controls.Add(_mediaPlayerHost);

            try
            {
                _ocxPlayer = _mediaPlayerHost.GetPlayerOcx();
            }
            catch
            {
                _ocxPlayer = null;
            }
        }

        private void LoadAudioPlaceholder()
        {
            string placeholderPath = Path.Combine(Application.StartupPath, "Assets", "Media", "audio_placeholder.png");
            if (File.Exists(placeholderPath))
            {
                pictureBoxAudioPlaceholder.Load(placeholderPath);
            }
            else
            {
                pictureBoxAudioPlaceholder.Image = null;
            }
        }

        private void LoadMediaItems()
        {
            _mediaItems.Clear();
            listBoxMediaFiles.Items.Clear();

            string assetsMediaFolder = Path.Combine(Application.StartupPath, "Assets", "Media");
            AddMediaFilesFromAssetsFolder(assetsMediaFolder);

            foreach (MediaItem mediaItem in _mediaItems)
            {
                listBoxMediaFiles.Items.Add(mediaItem);
            }
        }

        private void AddMediaFilesFromAssetsFolder(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath) || !Directory.Exists(directoryPath))
            {
                return;
            }

            string[] extensions = { "*.mp4", "*.wmv", "*.avi", "*.mp3", "*.wav", "*.wma" };
            List<string> files = new List<string>();

            foreach (string extensionPattern in extensions)
            {
                files.AddRange(Directory.GetFiles(directoryPath, extensionPattern));
            }

            // IEnumerable<string> orderedFiles = files
            //     .Distinct(StringComparer.OrdinalIgnoreCase)
            //     .OrderBy(path => Path.GetFileName(path), StringComparer.OrdinalIgnoreCase);

            // 1. DISTINCT: Ручне видалення дублікатів
            List<string> orderedFiles = new List<string>();
            foreach (string path in files)
            {
                bool exists = false;
                foreach (string added in orderedFiles)
                {
                    if (string.Equals(path, added, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    orderedFiles.Add(path);
                }
            }

            // 2. ORDER BY: Ручне сортування бульбашками за назвою файлу. Алгоритм бульбашків я вивчав і у міській школі, а також в академії ШАГ.
            for (int i = 0; i < orderedFiles.Count - 1; i++)
            {
                for (int j = 0; j < orderedFiles.Count - i - 1; j++)
                {
                    string fileA = GetFileNameManual(orderedFiles[j]);
                    string fileB = GetFileNameManual(orderedFiles[j + 1]);

                    if (string.Compare(fileA, fileB, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        string temp = orderedFiles[j];
                        orderedFiles[j] = orderedFiles[j + 1];
                        orderedFiles[j + 1] = temp;
                    }
                }
            }

            foreach (string filePath in orderedFiles)
            {
                if (_mediaItems.Any(existing => string.Equals(existing.FilePath, filePath, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                bool isAudio = IsAudioFile(filePath);
                string displayName = Path.GetFileNameWithoutExtension(filePath) + (isAudio ? " (audio)" : " (video)");
                MediaItem mediaItemEntry = new MediaItem(displayName, filePath, isAudio);
                _mediaItems.Add(mediaItemEntry);
            }
        }

        private string GetFileNameManual(string path)
        {
            int lastSeparator = path.LastIndexOfAny(new char[] { '\\', '/' });
            if (lastSeparator == -1) return path;
            return path.Substring(lastSeparator + 1);
        }

        private bool IsAudioFile(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLowerInvariant();
            return extension == ".mp3" || extension == ".wav" || extension == ".wma";
        }

        private void PlayCurrentItem()
        {
            if (_ocxPlayer == null || _currentItem == null)
            {
                return;
            }

            bool showAudioPlaceholder = _currentItem.IsAudio;
            pictureBoxAudioPlaceholder.Visible = showAudioPlaceholder;
            panelPlayerHost.Visible = true;

            try
            {
                _ocxPlayer.URL = _currentItem.FilePath;
                _ocxPlayer.controls.play();
                labelNowPlaying.Text = "Now Playing: " + _currentItem.DisplayName;
            }
            catch
            {
                labelNowPlaying.Text = "Now Playing: помилка відтворення";
            }
        }

        private void ClosePlayer()
        {
            if (_ocxPlayer == null)
            {
                return;
            }

            try
            {
                _ocxPlayer.controls.stop();
                _ocxPlayer.close();
            }
            catch
            {
            }
            finally
            {
                _ocxPlayer = null;
            }
        }

        //Прибрав AutoFill, а також sealed
        private class MediaItem
        {
            private readonly string _displayName;
            private readonly string _filePath;
            private readonly bool _isAudio;

            public MediaItem(string displayName, string filePath, bool isAudio)
            {
                this._displayName = displayName;
                this._filePath = filePath;
                this._isAudio = isAudio;
            }

            public string DisplayName { get { return _displayName; } }
            public string FilePath { get { return _filePath; } }
            public bool IsAudio { get { return _isAudio; } }

            public override string ToString()
            {
                return this._displayName;
            }
        }

        private sealed class MediaPlayerHost : AxHost
        {
            public MediaPlayerHost()
                : base("6BF52A52-394A-11d3-B153-00C04F79FAA6")
            {
            }

            public object GetPlayerOcx()
            {
                return GetOcx();
            }
        }
    }
}
