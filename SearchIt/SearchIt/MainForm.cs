﻿/**
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

using Newtonsoft.Json;
using SearchIt;

namespace SearchIt
{
    public partial class MainForm : Form
    {
        private Point origin;
        private GlobalHotkey ghk;

        private Rectangle screen = Screen.PrimaryScreen.WorkingArea;

        bool isFormShowing = true;

        public MainForm()
        {
            InitializeComponent();

            Settings.GetJSONFile();

            ghk = new GlobalHotkey(0x0000, Keys.Oem3, this);

            comboBox1.SelectedIndex = 0;
            comboBox1.DataSource = Settings.Titles;

            MoveIn();

            //origin = new Point(0, screen.Height / 4);
        }


        void Search(string str)
        {
            System.Diagnostics.Process.Start(ParseSelection(comboBox1.SelectedIndex) + Uri.EscapeDataString(str));
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            MoveOut();
        }

        private string ParseSelection(int p)
        {
            return Settings.URLS[p].ToString();
        }

        void MoveIn()
        {
            this.Show();
            this.Size = new Size(screen.Width, screen.Height / 2);

            if (origin != null)
            {
                this.Location = origin;
            }

            textBox1.Focus();
            Focus();
        }

        void MoveOut()
        {
            // this.Location = new Point(screen.Location.X, screen.Location.Y);
            for (int i = 0; i < screen.Width - 1; i++)
            {
                this.Location = new Point(i, this.Location.Y);
               // this.Width -= 2;
            }

            this.Hide();
        }

        void SpawnForm()
        {
            isFormShowing = !isFormShowing;
            if (isFormShowing)
            {
                Console.WriteLine("Showing form now!");
                MoveIn();
            }
            else
            {
                Console.WriteLine("Hiding form now!");
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
                Search(textBox1.Text);
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

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312) SpawnForm();

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
