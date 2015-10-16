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
using System.Reflection;

namespace SearchIt
{
    public partial class SettingsForm : Form
    {
        List<Color> ColorList = new List<Color>();

        private Color _FormBackgroundColor;
        private Color _FormForegroundColor;

        private Color _SearchBackgroundColor;
        private Color _SearchForegroundColor;

        private Color _ElementBorderColor;

        private int _FormOpacity;

        private string _FormBackgroundImage;

        public SettingsForm()
        {
            InitializeComponent();

            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    ColorList.Add((Color)property.GetValue(null));
                }
            }

            // Remove Transparent from the list
            ColorList.RemoveAt(0);

            FormBackgroundColor.DataSource = new List<Color>(ColorList);
            FormForegroundColor.DataSource = new List<Color>(ColorList);
            SearchBackgroundColor.DataSource = new List<Color>(ColorList);
            SearchForegroundColor.DataSource = new List<Color>(ColorList);
            ElementBorderColor.DataSource = new List<Color>(ColorList);

            SetSelectedIndex();
          //  FormOpacity.Value = Properties.Settings.Default.FormOpacity;

            //label6.Text = "Opacity: (" + FormOpacity.Value.ToString() + ")"; 
        }

        private void SetSelectedIndex()
        {
            FormBackgroundColor.SelectedItem = Properties.Settings.Default.FormBackgroundColor;
            FormForegroundColor.SelectedItem = Properties.Settings.Default.FormForegroundColor;
            SearchBackgroundColor.SelectedItem = Properties.Settings.Default.SearchBackgroundColor;
            SearchForegroundColor.SelectedItem = Properties.Settings.Default.SearchForegroundColor;
            ElementBorderColor.SelectedItem = Properties.Settings.Default.ElementBorderColor;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["FormBackgroundColor"] = _FormBackgroundColor;
            Properties.Settings.Default["FormForegroundColor"] = _FormForegroundColor;
            Properties.Settings.Default["SearchBackgroundColor"] = _SearchBackgroundColor;
            Properties.Settings.Default["SearchForegroundColor"] = _SearchForegroundColor;
            Properties.Settings.Default["ElementBorderColor"] = _ElementBorderColor;
            Properties.Settings.Default["FormOpacity"] = _FormOpacity;
            Properties.Settings.Default["FormBackgroundImage"] = _FormBackgroundImage;

            Properties.Settings.Default.Save();
        }

        #region Stylizer

        private void FormBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FormBackgroundColor = ColorList[FormBackgroundColor.SelectedIndex];
        }

        private void FormForegroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FormForegroundColor = ColorList[FormForegroundColor.SelectedIndex];
        }

        private void SearchBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SearchBackgroundColor = ColorList[SearchBackgroundColor.SelectedIndex];
        }
        private void SearchForegroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SearchForegroundColor = ColorList[SearchForegroundColor.SelectedIndex];
        }

        private void ElementBorderColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ElementBorderColor = ColorList[ElementBorderColor.SelectedIndex];
        }

        private void FormOpacity_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Opacity: (" + FormOpacity.Value.ToString() + ")";
            _FormOpacity = FormOpacity.Value;
        }

        private void btnFormBackgroundImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Set an image as the form background!";
            ofd.Filter = "BMP Image (*.bmp)|*.bmp|JPEG Image (*.jpg, *.jpeg)|*.jpg;*.jpeg|PNG Image (*.png)|*.png|All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file = ofd.FileName;
                textBox1.Text = file;

                _FormBackgroundImage = file;
            }
        }

        #endregion Stylizer

        private void SettingsForm_Load(object sender, EventArgs e) { }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            SetSelectedIndex();

            Properties.Settings.Default.Save();
        }
    }
}


