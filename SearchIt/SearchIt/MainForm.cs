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

namespace SearchIt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;

            MoveIn();
        }

        private Rectangle screen = Screen.PrimaryScreen.WorkingArea;
        private readonly int sWidth = Screen.PrimaryScreen.WorkingArea.Width;
        private readonly int sHeight = Screen.PrimaryScreen.WorkingArea.Height;

        bool isFormShowing = true;

        void Search(string str)
        {
            System.Diagnostics.Process.Start(ParseSelection(comboBox1.SelectedIndex) + Uri.EscapeDataString(str));
            MoveOut();
        }

        private string ParseSelection(int p)
        {
            switch (p)
            {
                case 0:
                    return "http://www.google.com/search?q=";
                case 1:
                    return "https://www.youtube.com/results?search_query=";
            }
            return "";
        }

        void MoveIn()
        {
            int w = screen.Width;
            int h = screen.Height / 2;
            this.Size = new Size(w, h);
        }

        void MoveOut()
        {
            // this.Location = new Point(screen.Location.X, screen.Location.Y);
            for (int i = 0; i < screen.Width; i++)
            {
                this.Location = new Point(i, this.Location.Y);
            }
        }       


        void SpawnForm()
        {
            isFormShowing = !isFormShowing;
            if (isFormShowing)
            {
                Console.WriteLine("Showing form now!");
                int w = screen.Width;
                int h = screen.Height / 2;
                this.Size = new Size(w, h);

            }
            else
            {
                Console.WriteLine("Hiding form now!");
                for (int i = 0; i < screen.Width; i++)
                {
                    this.Location = new Point(i, this.Location.Y);
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Search(textBox1.Text);
                return true;
            }
            if (keyData == Keys.Oem3)
            {
                

                SpawnForm();

                Console.WriteLine(isFormShowing ? "Show Form" : "Hide Form");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = new Rectangle(textBox1.Location.X, textBox1.Location.Y, textBox1.ClientSize.Width, textBox1.ClientSize.Height);
            System.Drawing.Rectangle rect2 = new Rectangle(comboBox1.Location.X, comboBox1.Location.Y, comboBox1.ClientSize.Width, comboBox1.ClientSize.Height);

            rect.Inflate(2, 2);
            rect2.Inflate(2, 2);
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect, Color.Green, ButtonBorderStyle.Solid);
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect2, Color.Green, ButtonBorderStyle.Solid);
        }

    }
}
