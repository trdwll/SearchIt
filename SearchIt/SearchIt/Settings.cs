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

        private static readonly string Path = Application.StartupPath + "\\settings.json";

        private static string GetSettingsFileContents()
        {
            return File.ReadAllText(Path);
        }

        public static void GetJSONFile()
        {
            Config cfg = new JavaScriptSerializer().Deserialize<Config>(GetSettingsFileContents());
            
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


//             foreach (JObject o in JArray.Parse(GetSettingsFileContents()).Children<JObject>())
//             {
//                 Titles.Add((string)o["Title"]);
//                 URLS.Add((string)o["URL"]);
//             }
        }



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
    }
}
