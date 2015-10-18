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
        public List<Command> Commands = new List<Command>();

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

        public class Command
        {
            public string Cmd { get; set; }
            public string URL { get; set; }
            public int Args = 1;
        }
    }

    public class Settings
    {
        public static Dictionary<string, Config.Command> CMDS = new Dictionary<string, Config.Command>();
        public static Dictionary<string, string> URLS = new Dictionary<string, string>();

        public static void GetJSONFile()
        {
            string Path = Application.StartupPath + "\\settings.json";

            Config cfg = new JavaScriptSerializer().Deserialize<Config>(File.Exists(Path) ? File.ReadAllText(Path) : @"{ ""SearchEngines"": [ { ""Title"": ""Google"", ""URL"": ""http://www.google.com/search?q="" }, { ""Title"": ""Bing"", ""URL"": ""http://www.bing.com/search?q="" } ], ""Miscellaneous"": [ { ""Title"": ""YouTube"", ""URL"": ""https://www.youtube.com/results?search_query="" } ] }");
            
            foreach (Config.SearchEngine engine in cfg.SearchEngines)
            {
                URLS.Add(engine.Title, engine.URL);
            }

            URLS.Add("---------", "");

            foreach (Config.Misc misc in cfg.Miscellaneous)
            {
                URLS.Add(misc.Title, misc.URL);
            }

            foreach (Config.Command cmd in cfg.Commands)
            {
                CMDS.Add(cmd.Cmd.ToLower(), cmd);
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
