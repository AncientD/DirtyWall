using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Threading;
using System.Net;
using System.Xml;
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
        static string configStr = File.ReadAllText("config.xml");

        static void mainSegment()
        {
            query = "";
            searchQuery = "";
            interval = 15;
            Random seed = new Random();
            try
            {
                string[] files = Directory.GetFiles("cache", "*.jpg");
                foreach(string file in files)
                {
                    File.Delete(file);
                }
                config.LoadXml(configStr);
                searchQuery = config.GetElementsByTagName("query")[0].InnerText;
                interval = Convert.ToInt32(config.GetElementsByTagName("interval")[0].InnerText);
            }
            catch(Exception ex)
            {
                File.AppendAllText("error.log", ex.Source + "-----" + ex.Message + "\r\n"+ex.ToString());
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

            ContextMenu trayMenu = new ContextMenu();
            MenuItem nextWallpaper = new MenuItem();
            nextWallpaper.Text = "Next";
            nextWallpaper.Index = 0;
            nextWallpaper.Click += NextWallpaper_Click;

            MenuItem cleanCache = new MenuItem();
            cleanCache.Text = "Clean Cache";
            cleanCache.Index = 2;
            cleanCache.Click += CleanCache_Click;

            MenuItem openCache = new MenuItem();
            openCache.Text = "Open Cache";
            openCache.Index = 1;
            openCache.Click += OpenCache_Click;

            MenuItem settings = new MenuItem();
            settings.Text = "Settings";
            settings.Index = 3;
            settings.Click += Settings_Click;

            MenuItem exitApp = new MenuItem();
            exitApp.Text = "Exit";
            exitApp.Index = 4;
            exitApp.Click += ExitApp_Click;

            trayMenu.MenuItems.Add(nextWallpaper);
            trayMenu.MenuItems.Add(openCache);
            trayMenu.MenuItems.Add(cleanCache);
            trayMenu.MenuItems.Add(settings);
            trayMenu.MenuItems.Add(exitApp);


            trayIcon.ContextMenu = trayMenu;

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
                try {
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
            WallhavenParser.parseAndSet(query,searchQuery);
        }
    }
}