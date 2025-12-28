using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dirtywall
{
    class WallhavenParser
    {
        private static string MainUrl = "http://wallhaven.cc";
        private static string MainSearchUrl = MainUrl + "/search?q=";
        private static string MainUrlFullImage = "http://w.wallhaven.cc/full";
        public static void ParseAndSet(string query, string searchQuery)
        {
            Random seed = new Random();
            using (WebClient web = new WebClient())
            {
                try
                {
                    string[] keywords = searchQuery.Split(new string[] { "|" }, StringSplitOptions.None);
                    query = keywords.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                    string prePage = web.DownloadString(MainSearchUrl + query + "&categories=101&purity=100");
                    HtmlDocument preWallhavenPage = new HtmlDocument();
                    preWallhavenPage.LoadHtml(prePage);

                    var countTemplate = preWallhavenPage.DocumentNode.SelectSingleNode("//*[@id=\"main\"]/header/h1");
                    string itemsCount = countTemplate.InnerText.Replace("\"", "").Split(' ')[0].Replace(",", "");
                    int pages = Convert.ToInt32(itemsCount) / 20;
                    if (pages <= 0)
                    {
                        pages = 1;
                    }
                    int currentPage = seed.Next(1, pages > 1 ? pages / 2 : 1);
                    currentPage = currentPage > 0 ? currentPage : 1;


                    string page = web.DownloadString(MainSearchUrl + query.Replace(" ","+") + "&categories=101&purity=100&sorting=random&order=desc&page="+currentPage);
                    HtmlDocument wallhavenPage = new HtmlDocument();
                    wallhavenPage.LoadHtml(page);

                    var images = wallhavenPage.DocumentNode.SelectNodes("//*[@id=\"thumbs\"]/section/ul/li/figure");
                    List<HtmlNode> imagesList = images.ToList();

                    var randomImage = imagesList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    string imageId = randomImage.GetAttributeValue("data-wallpaper-id", "1");

                    string absolute = Path.GetFullPath($"cache/{ imageId }.jpg");
                    string firstTwoChar = new string(imageId.Take(2).ToArray());

                    web.DownloadFile($"{MainUrlFullImage}/{ firstTwoChar }/wallhaven-{ imageId }.jpg", $"cache/{ imageId }.jpg");
                    Wallpaper.Set(new Uri(absolute), Wallpaper.Style.Stretched);
                }
                catch (Exception ex)
                {
                    File.AppendAllText("error.log", ex.ToString());
                }
            }
        }
    }
}
