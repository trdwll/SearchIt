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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;

using SearchIt;

namespace SearchIt
{
    public partial class MainForm : Form
    {
        private GlobalHotkey ghk;

        private Rectangle screen = Screen.PrimaryScreen.WorkingArea;

        private bool isFormShowing = true;

        public MainForm()
        {
            InitializeComponent();

            // Run the styling before form load
            this.BackColor = Settings.GetFormBackgroundColor();
            this.ForeColor = Settings.GetFormForegroundColor();
            BackgroundImage = Settings.GetFormBackgroundImage();
            BackgroundImageLayout = ImageLayout.Stretch;

            SearchBox.BackColor = Settings.GetSearchBackgroundColor();
            SearchBox.ForeColor = Settings.GetSearchForegroundColor();

           // this.Opacity = Settings.GetFormOpacity(); // Opacity is bugged for some reason... it sets as either 0 or 100 

            Settings.GetJSONFile();

            ghk = new GlobalHotkey(0x0000, Keys.Oem3, this);

            comboBox1.SelectedIndex = 0;
            comboBox1.DataSource = Settings.Titles;

            MoveIn();
        }

        private void Search(string str)
        {
            List<string> tlds = new List<string>(new string[] { ".aaa", ".abb", ".abbott", ".abogado", ".ac", ".academy", ".accenture", ".accountant", ".accountants", ".aco", ".active", ".actor", ".ad", ".ads", ".adult", ".ae", ".aeg", ".aero", ".af", ".afl", ".ag", ".agency", ".ai", ".aig", ".airforce", ".airtel", ".al", ".allfinanz", ".alsace", ".am", ".amica", ".amsterdam", ".android", ".ao", ".apartments", ".app", ".aq", ".aquarelle", ".ar", ".archi", ".army", ".arpa", ".as", ".asia", ".associates", ".at", ".attorney", ".au", ".auction", ".audio", ".auto", ".autos", ".aw", ".ax", ".axa", ".az", ".azure", ".ba", ".band", ".bank", ".bar", ".barcelona", ".barclaycard", ".barclays", ".bargains", ".bauhaus", ".bayern", ".bb", ".bbc", ".bbva", ".bcn", ".bd", ".be", ".beer", ".bentley", ".berlin", ".best", ".bet", ".bf", ".bg", ".bh", ".bharti", ".bi", ".bible", ".bid", ".bike", ".bing", ".bingo", ".bio", ".biz", ".bj", ".black", ".blackfriday", ".bloomberg", ".blue", ".bm", ".bms", ".bmw", ".bn", ".bnl", ".bnpparibas", ".bo", ".boats", ".bom", ".bond", ".boo", ".boots", ".boutique", ".br", ".bradesco", ".bridgestone", ".broker", ".brother", ".brussels", ".bs", ".bt", ".budapest", ".build", ".builders", ".business", ".buzz", ".bv", ".bw", ".by", ".bz", ".bzh", ".ca", ".cab", ".cafe", ".cal", ".camera", ".camp", ".cancerresearch", ".canon", ".capetown", ".capital", ".car", ".caravan", ".cards", ".care", ".career", ".careers", ".cars", ".cartier", ".casa", ".cash", ".casino", ".cat", ".catering", ".cba", ".cbn", ".cc", ".cd", ".ceb", ".center", ".ceo", ".cern", ".cf", ".cfa", ".cfd", ".cg", ".ch", ".chanel", ".channel", ".chat", ".cheap", ".chloe", ".christmas", ".chrome", ".church", ".ci", ".cipriani", ".cisco", ".citic", ".city", ".ck", ".cl", ".claims", ".cleaning", ".click", ".clinic", ".clothing", ".cloud", ".club", ".clubmed", ".cm", ".cn", ".co", ".coach", ".codes", ".coffee", ".college", ".cologne", ".com", ".commbank", ".community", ".company", ".computer", ".condos", ".construction", ".consulting", ".contractors", ".cooking", ".cool", ".coop", ".corsica", ".country", ".coupons", ".courses", ".cr", ".credit", ".creditcard", ".cricket", ".crown", ".crs", ".cruises", ".csc", ".cu", ".cuisinella", ".cv", ".cw", ".cx", ".cy", ".cymru", ".cyou", ".cz", ".dabur", ".dad", ".dance", ".date", ".dating", ".datsun", ".day", ".dclk", ".de", ".deals", ".degree", ".delivery", ".dell", ".delta", ".democrat", ".dental", ".dentist", ".desi", ".design", ".dev", ".diamonds", ".diet", ".digital", ".direct", ".directory", ".discount", ".dj", ".dk", ".dm", ".dnp", ".do", ".docs", ".dog", ".doha", ".domains", ".doosan", ".download", ".drive", ".durban", ".dvag", ".dz", ".earth", ".eat", ".ec", ".edu", ".education", ".ee", ".eg", ".email", ".emerck", ".energy", ".engineer", ".engineering", ".enterprises", ".epson", ".equipment", ".er", ".erni", ".es", ".esq", ".estate", ".et", ".eu", ".eurovision", ".eus", ".events", ".everbank", ".exchange", ".expert", ".exposed", ".express", ".fage", ".fail", ".faith", ".family", ".fan", ".fans", ".farm", ".fashion", ".feedback", ".fi", ".film", ".final", ".finance", ".financial", ".firmdale", ".fish", ".fishing", ".fit", ".fitness", ".fj", ".fk", ".flights", ".florist", ".flowers", ".flsmidth", ".fly", ".fm", ".fo", ".foo", ".football", ".forex", ".forsale", ".forum", ".foundation", ".fr", ".frl", ".frogans", ".fund", ".furniture", ".futbol", ".fyi", ".ga", ".gal", ".gallery", ".game", ".garden", ".gb", ".gbiz", ".gd", ".gdn", ".ge", ".gea", ".gent", ".genting", ".gf", ".gg", ".ggee", ".gh", ".gi", ".gift", ".gifts", ".gives", ".giving", ".gl", ".glass", ".gle", ".global", ".globo", ".gm", ".gmail", ".gmo", ".gmx", ".gn", ".gold", ".goldpoint", ".golf", ".goo", ".goog", ".google", ".gop", ".gov", ".gp", ".gq", ".gr", ".graphics", ".gratis", ".green", ".gripe", ".group", ".gs", ".gt", ".gu", ".guge", ".guide", ".guitars", ".guru", ".gw", ".gy", ".hamburg", ".hangout", ".haus", ".healthcare", ".help", ".here", ".hermes", ".hiphop", ".hitachi", ".hiv", ".hk", ".hm", ".hn", ".hockey", ".holdings", ".holiday", ".homedepot", ".homes", ".honda", ".horse", ".host", ".hosting", ".hoteles", ".hotmail", ".house", ".how", ".hr", ".hsbc", ".ht", ".hu", ".hyundai", ".ibm", ".icbc", ".ice", ".icu", ".id", ".ie", ".ifm", ".iinet", ".il", ".im", ".immo", ".immobilien", ".in", ".industries", ".infiniti", ".info", ".ing", ".ink", ".institute", ".insure", ".int", ".international", ".investments", ".io", ".ipiranga", ".iq", ".ir", ".irish", ".is", ".ist", ".istanbul", ".it", ".itau", ".iwc", ".java", ".jcb", ".je", ".jetzt", ".jewelry", ".jlc", ".jll", ".jm", ".jo", ".jobs", ".joburg", ".jp", ".jprs", ".juegos", ".kaufen", ".kddi", ".ke", ".kg", ".kh", ".ki", ".kia", ".kim", ".kinder", ".kitchen", ".kiwi", ".km", ".kn", ".koeln", ".komatsu", ".kp", ".kr", ".krd", ".kred", ".kw", ".ky", ".kyoto", ".kz", ".la", ".lacaixa", ".lancaster", ".land", ".lasalle", ".lat", ".latrobe", ".law", ".lawyer", ".lb", ".lc", ".lds", ".lease", ".leclerc", ".legal", ".lexus", ".lgbt", ".li", ".liaison", ".lidl", ".life", ".lighting", ".limited", ".limo", ".linde", ".link", ".live", ".lixil", ".lk", ".loan", ".loans", ".lol", ".london", ".lotte", ".lotto", ".love", ".lr", ".ls", ".lt", ".ltd", ".ltda", ".lu", ".lupin", ".luxe", ".luxury", ".lv", ".ly", ".ma", ".madrid", ".maif", ".maison", ".man", ".management", ".mango", ".market", ".marketing", ".markets", ".marriott", ".mba", ".mc", ".md", ".me", ".media", ".meet", ".melbourne", ".meme", ".memorial", ".men", ".menu", ".mg", ".mh", ".miami", ".microsoft", ".mil", ".mini", ".mk", ".ml", ".mm", ".mma", ".mn", ".mo", ".mobi", ".moda", ".moe", ".moi", ".mom", ".monash", ".money", ".montblanc", ".mormon", ".mortgage", ".moscow", ".motorcycles", ".mov", ".movie", ".movistar", ".mp", ".mq", ".mr", ".ms", ".mt", ".mtn", ".mtpc", ".mtr", ".mu", ".museum", ".mv", ".mw", ".mx", ".my", ".mz", ".na", ".nadex", ".nagoya", ".name", ".navy", ".nc", ".ne", ".nec", ".net", ".netbank", ".network", ".neustar", ".new", ".news", ".nexus", ".nf", ".ng", ".ngo", ".nhk", ".ni", ".nico", ".ninja", ".nissan", ".nl", ".no", ".nokia", ".np", ".nr", ".nra", ".nrw", ".ntt", ".nu", ".nyc", ".nz", ".obi", ".office", ".okinawa", ".om", ".omega", ".one", ".ong", ".onl", ".online", ".ooo", ".oracle", ".orange", ".org", ".organic", ".osaka", ".otsuka", ".ovh", ".pa", ".page", ".panerai", ".paris", ".partners", ".parts", ".party", ".pe", ".pet", ".pf", ".pg", ".ph", ".pharmacy", ".philips", ".photo", ".photography", ".photos", ".physio", ".piaget", ".pics", ".pictet", ".pictures", ".pink", ".pizza", ".pk", ".pl", ".place", ".play", ".plumbing", ".plus", ".pm", ".pn", ".pohl", ".poker", ".porn", ".post", ".pr", ".praxi", ".press", ".pro", ".prod", ".productions", ".prof", ".properties", ".property", ".protection", ".ps", ".pt", ".pub", ".pw", ".py", ".qa", ".qpon", ".quebec", ".racing", ".re", ".realtor", ".realty", ".recipes", ".red", ".redstone", ".rehab", ".reise", ".reisen", ".reit", ".ren", ".rent", ".rentals", ".repair", ".report", ".republican", ".rest", ".restaurant", ".review", ".reviews", ".rich", ".ricoh", ".rio", ".rip", ".ro", ".rocks", ".rodeo", ".rs", ".rsvp", ".ru", ".ruhr", ".run", ".rw", ".ryukyu", ".sa", ".saarland", ".sakura", ".sale", ".samsung", ".sandvik", ".sandvikcoromant", ".sanofi", ".sap", ".sarl", ".saxo", ".sb", ".sc", ".sca", ".scb", ".schmidt", ".scholarships", ".school", ".schule", ".schwarz", ".science", ".scor", ".scot", ".sd", ".se", ".seat", ".security", ".seek", ".sener", ".services", ".seven", ".sew", ".sex", ".sexy", ".sg", ".sh", ".shiksha", ".shoes", ".show", ".shriram", ".si", ".singles", ".site", ".sj", ".sk", ".ski", ".sky", ".skype", ".sl", ".sm", ".sn", ".sncf", ".so", ".soccer", ".social", ".software", ".sohu", ".solar", ".solutions", ".sony", ".soy", ".space", ".spiegel", ".spreadbetting", ".sr", ".srl", ".st", ".stada", ".starhub", ".statoil", ".stc", ".stcgroup", ".stockholm", ".studio", ".study", ".style", ".su", ".sucks", ".supplies", ".supply", ".support", ".surf", ".surgery", ".suzuki", ".sv", ".swatch", ".swiss", ".sx", ".sy", ".sydney", ".systems", ".sz", ".taipei", ".tatamotors", ".tatar", ".tattoo", ".tax", ".taxi", ".tc", ".td", ".team", ".tech", ".technology", ".tel", ".telefonica", ".temasek", ".tennis", ".tf", ".tg", ".th", ".thd", ".theater", ".theatre", ".tickets", ".tienda", ".tips", ".tires", ".tirol", ".tj", ".tk", ".tl", ".tm", ".tn", ".to", ".today", ".tokyo", ".tools", ".top", ".toray", ".toshiba", ".tours", ".town", ".toyota", ".toys", ".tr", ".trade", ".trading", ".training", ".travel", ".trust", ".tt", ".tui", ".tv", ".tw", ".tz", ".ua", ".ubs", ".ug", ".uk", ".university", ".uno", ".uol", ".us", ".uy", ".uz", ".va", ".vacations", ".vc", ".ve", ".vegas", ".ventures", ".versicherung", ".vet", ".vg", ".vi", ".viajes", ".video", ".villas", ".vin", ".virgin", ".vision", ".vista", ".vistaprint", ".viva", ".vlaanderen", ".vn", ".vodka", ".vote", ".voting", ".voto", ".voyage", ".vu", ".wales", ".walter", ".wang", ".watch", ".webcam", ".website", ".wed", ".wedding", ".weir", ".wf", ".whoswho", ".wien", ".wiki", ".williamhill", ".win", ".windows", ".wine", ".wme", ".work", ".works", ".world", ".ws", ".wtc", ".wtf", ".xbox", ".xerox", ".xin", ".xperia", ".xxx", ".xyz", ".yachts", ".yamaxun", ".yandex", ".ye", ".yodobashi", ".yoga", ".yokohama", ".youtube", ".yt", ".za", ".zip", ".zm", ".zone", ".zuerich", ".zw" });
            bool istld = false;

            foreach (string tld in tlds)
            {
                if (str.ToLower().Contains(tld) && !str.Contains(" "))
                {
                    istld = true;
                }
            }

            switch (str)
            {
                case "!help":
                    MessageBox.Show("Commands:\n!settings - Settings Menu\n!quit - Quit Applicaation\n!restart - Restart Application", "Help");
                    break;
                case "!settings":
                    SettingsForm sf = new SettingsForm();
                    sf.Show();
                    break;
                case "!quit":
                    Application.Exit();
                    break;
                case "!restart":
                    Application.Restart();
                    break;
                default:
                    Process.Start(istld ? "http://" + str : (ParseSelection(comboBox1.SelectedIndex) + Uri.EscapeDataString(str)));
                    break;
            }
           
            SearchBox.Text = "";
            comboBox1.SelectedIndex = 0;
            MoveOut();
        }


        private string ParseSelection(int p)
        {
            return Settings.URLS[p].ToString();
        }

        private void MoveIn()
        {
            this.Show();
            this.Location = new Point(screen.Location.X, screen.Location.Y);
            this.Size = new Size(screen.Width, screen.Height / 2);

            SearchBox.Focus();
            Focus();
        }

        private void MoveOut()
        {
            for (int i = 0; i < screen.Width - 1; i++)
            {
                this.Location = new Point(i, this.Location.Y);
                
//                 if ((i % 5) == 0)
//                 {
//                     this.Width -= 5;
//                 }
            }

            this.Width = 0;
            this.Hide();
        }

        private void SpawnForm()
        {
            isFormShowing = !isFormShowing;
            if (isFormShowing)
            {
                MoveIn();
            }
            else
            {
                MoveOut();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ghk.Register())
            {
                Console.WriteLine("Hotkey registered.");
            }
            else
            {
                Console.WriteLine("Hotkey failed to register");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Search(SearchBox.Text);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                SpawnForm();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = new Rectangle(SearchBox.Location.X, SearchBox.Location.Y, SearchBox.ClientSize.Width, SearchBox.ClientSize.Height);
            System.Drawing.Rectangle rect2 = new Rectangle(comboBox1.Location.X, comboBox1.Location.Y, comboBox1.ClientSize.Width, comboBox1.ClientSize.Height);

            rect.Inflate(2, 2);
            rect2.Inflate(2, 2);
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect, Settings.GetElementBorderColor(), ButtonBorderStyle.Solid);
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect2, Settings.GetElementBorderColor(), ButtonBorderStyle.Solid);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                SpawnForm();
            }

            base.WndProc(ref m);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
            {
                MessageBox.Show("Hotkey failed to unregister!");
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!isFormShowing)
            {
                Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
           if (comboBox1.SelectedItem.Equals("---------"))
           {
               comboBox1.SelectedIndex = index;
           }
           else
           {
               index = comboBox1.SelectedIndex;
           }
        }
    }

    public class GlobalHotkey
    {
        private int modifier;
        private int key;
        private IntPtr hWnd;
        private int id;

        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            this.id = GetHashCode();
        }

        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    }
}
