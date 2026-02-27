using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    public partial class ArticlesForm : Form
    {
        private readonly Dictionary<string, string> _articleFileNames = new Dictionary<string, string>
        {
            { "Історія", "history.html" },
            { "Команди та конструктори", "teams.html" },
            { "Легендарні пілоти", "drivers.html" },
            { "Траси та Гран-прі", "circuits.html" },
            { "Технічний регламент", "regulations.html" },
            { "Безпека", "safety.html" }
        };

        public ArticlesForm()
        {
            InitializeComponent();
            InitializeArticlesMenu();
            if (treeViewArticles.Nodes.Count > 0 && treeViewArticles.Nodes[0].Nodes.Count > 0)
            {
                treeViewArticles.SelectedNode = treeViewArticles.Nodes[0].Nodes[0];
            }
        }

        private void InitializeArticlesMenu()
        {
            treeViewArticles.Nodes.Clear();
            TreeNode rootNode = new TreeNode("Формула-1");

            foreach (KeyValuePair<string, string> articleEntry in _articleFileNames)
            {
                TreeNode node = new TreeNode(articleEntry.Key)
                {
                    Tag = articleEntry.Value
                };

                rootNode.Nodes.Add(node);
            }

            treeViewArticles.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        private void treeViewArticles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string articleFileName = e.Node.Tag as string;
            if (string.IsNullOrWhiteSpace(articleFileName))
            {
                return;
            }

            string articlePath = Path.Combine(Application.StartupPath, "Assets", "Articles", articleFileName);
            if (!File.Exists(articlePath))
            {
                webBrowserArticle.DocumentText = "<html><body style='font-family:Segoe UI;'><h2>Файл не знайдено</h2><p>" + articleFileName + "</p></body></html>";
                return;
            }

            webBrowserArticle.Navigate(articlePath);
        }
    }
}
