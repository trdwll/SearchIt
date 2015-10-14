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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchIt
{
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
            foreach (JObject o in JArray.Parse(GetSettingsFileContents()).Children<JObject>())
            {
                Titles.Add((string)o["Title"]);
                URLS.Add((string)o["URL"]);
            }
        }
    }
}
