/**
 * 
 * SearchIt
 * 
 * www.trdwll.com
 * 
 * Developed by Russ 'trdwll' Treadwell
 * 
 * Licensed under the MIT License <http://opensource.org/licenses/MIT>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;

namespace SearchIt
{
    public class Config
    {
        public List<SearchEngine> SearchEngines = new List<SearchEngine>();
        public List<Misc> Miscellaneous = new List<Misc>();

        public class SearchEngine
        {
            public string Title { get; set; }
            public string URL { get; set; }
        }

        public class Misc
        {
            public string Title { get; set; }
            public string URL { get; set; }
        }
    }

    public class Settings
    {
        public static List<string> Titles = new List<string>();
        public static List<string> URLS = new List<string>();

        public static void GetJSONFile()
        {
            string Path = Application.StartupPath + "\\settings.json";

            Config cfg = new JavaScriptSerializer().Deserialize<Config>(File.Exists(Path) ? File.ReadAllText(Path) : @"{ ""SearchEngines"": [ { ""Title"": ""Google"", ""URL"": ""http://www.google.com/search?q="" }, { ""Title"": ""Bing"", ""URL"": ""http://www.bing.com/search?q="" } ], ""Miscellaneous"": [ { ""Title"": ""YouTube"", ""URL"": ""https://www.youtube.com/results?search_query="" } ] }");
            
            foreach (Config.SearchEngine engine in cfg.SearchEngines)
            {
                Titles.Add(engine.Title);
                URLS.Add(engine.URL);
            }
            Titles.Add("---------");
            URLS.Add("");
            foreach (Config.Misc misc in cfg.Miscellaneous)
            {
                Titles.Add(misc.Title);
                URLS.Add(misc.URL);
            }
        }

        #region Stylizer

        public static Color GetFormBackgroundColor()
        {
            return Properties.Settings.Default.FormBackgroundColor;
        }

        public static Color GetFormForegroundColor()
        {
            return Properties.Settings.Default.FormForegroundColor;
        }

        public static Color GetSearchBackgroundColor()
        {
            return Properties.Settings.Default.SearchBackgroundColor;
        }

        public static Color GetSearchForegroundColor()
        {
            return Properties.Settings.Default.SearchForegroundColor;
        }

        public static Color GetElementBorderColor()
        {
            return Properties.Settings.Default.ElementBorderColor;
        }

        public static int GetFormOpacity()
        {
            return Properties.Settings.Default.FormOpacity;
        }

        public static Image GetFormBackgroundImage()
        {
            string path = Properties.Settings.Default.FormBackgroundImage;

            return File.Exists(path) && (!string.IsNullOrEmpty(path) || !string.IsNullOrWhiteSpace(path)) ? Image.FromFile(path) : null;
        }

        #endregion Stylizer

    }
}
