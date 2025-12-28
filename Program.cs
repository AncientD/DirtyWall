using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Dirtywall.Properties;

namespace Dirtywall
{
    class Program
    {
        public static string query = "";
        public static string searchQuery = "";
        public static int interval = 15;
        private static NotifyIcon trayIcon = new NotifyIcon();
        static XmlDocument config = new XmlDocument();
        static string configStr;

        static void mainSegment()
        {
            query = "";
            searchQuery = "";

            try
            {
                configStr = File.ReadAllText("config.xml");
            }
            catch (FileNotFoundException ex)
            {
                Directory.CreateDirectory("cache");
                XElement config =
                    new XElement("config",
                        new XElement("query", "car|abstract"),
                        new XElement("interval", "12"));
                configStr = config.ToString();
                config.Save("config.xml");
            }

            try
            {
                string[] files = Directory.GetFiles("cache", "*.jpg");
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                config.LoadXml(configStr);
                searchQuery = config.GetElementsByTagName("query")[0].InnerText;
                interval = Convert.ToInt32(config.GetElementsByTagName("interval")[0].InnerText);
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.Source + "-----" + ex.Message + "\r\n" + ex.ToString());
            }

            while (true)
            {
                WallhavenParser.parseAndSet(query, searchQuery);
                Thread.Sleep(interval * 1000 * 60);
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ContextMenuStrip trayMenu = new ContextMenuStrip();
            ToolStripMenuItem nextWallpaper = new ToolStripMenuItem();
            nextWallpaper.Text = "Next";
            nextWallpaper.Click += NextWallpaper_Click;

            ToolStripMenuItem openCache = new ToolStripMenuItem();
            openCache.Text = "Open Cache";
            openCache.Click += OpenCache_Click;

            ToolStripMenuItem cleanCache = new ToolStripMenuItem();
            cleanCache.Text = "Clean Cache";
            cleanCache.Click += CleanCache_Click;

            ToolStripMenuItem settings = new ToolStripMenuItem();
            settings.Text = "Settings";
            settings.Click += Settings_Click;

            ToolStripMenuItem exitApp = new ToolStripMenuItem();
            exitApp.Text = "Exit";
            exitApp.Click += ExitApp_Click;

            trayMenu.Items.Add(nextWallpaper);
            trayMenu.Items.Add(openCache);
            trayMenu.Items.Add(cleanCache);
            trayMenu.Items.Add(settings);
            trayMenu.Items.Add(exitApp);

            trayIcon.ContextMenuStrip = trayMenu;

            trayIcon.Icon = Resources.curr_icon;
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(100, "Dirty wall", "Программа запущена!", ToolTipIcon.Info);

            Thread mainThread = new Thread(mainSegment);
            mainThread.Priority = ThreadPriority.Highest;
            mainThread.IsBackground = false;

            mainThread.Start();
            Application.Run();
        }

        private static void OpenCache_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Application.StartupPath, "cache"));
        }

        private static void Settings_Click(object sender, EventArgs e)
        {
            config.LoadXml(configStr);
            if (new formSettings(searchQuery, interval).ShowDialog() == DialogResult.OK)
            {
                config.GetElementsByTagName("query")[0].InnerText = searchQuery;
                config.GetElementsByTagName("interval")[0].InnerText = interval.ToString();
                config.Save("config.xml");
            }
        }

        private static void CleanCache_Click(object sender, EventArgs e)
        {
            string[] images = Directory.GetFiles("cache/", "*.jpg");
            foreach (var file in images)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
        }

        private static void ExitApp_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }

        private static void NextWallpaper_Click(object sender, EventArgs e)
        {
            WallhavenParser.parseAndSet(query, searchQuery);
        }
    }
}