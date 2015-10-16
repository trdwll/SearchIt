namespace SearchIt
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FormOpacity = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormBackgroundColor = new System.Windows.Forms.ComboBox();
            this.FormForegroundColor = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ElementBorderColor = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchBackgroundColor = new System.Windows.Forms.ComboBox();
            this.SearchForegroundColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFormBackgroundImage = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormOpacity)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnFormBackgroundImage);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.FormOpacity);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.FormBackgroundColor);
            this.groupBox2.Controls.Add(this.FormForegroundColor);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 144);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Form";
            // 
            // FormOpacity
            // 
            this.FormOpacity.Location = new System.Drawing.Point(167, 63);
            this.FormOpacity.Maximum = 100;
            this.FormOpacity.Minimum = 10;
            this.FormOpacity.Name = "FormOpacity";
            this.FormOpacity.Size = new System.Drawing.Size(246, 45);
            this.FormOpacity.TabIndex = 1;
            this.FormOpacity.Value = 75;
            this.FormOpacity.Scroll += new System.EventHandler(this.FormOpacity_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Opacity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Foreground:";
            // 
            // FormBackgroundColor
            // 
            this.FormBackgroundColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormBackgroundColor.FormattingEnabled = true;
            this.FormBackgroundColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Blue"});
            this.FormBackgroundColor.Location = new System.Drawing.Point(167, 13);
            this.FormBackgroundColor.MaxDropDownItems = 10;
            this.FormBackgroundColor.Name = "FormBackgroundColor";
            this.FormBackgroundColor.Size = new System.Drawing.Size(246, 21);
            this.FormBackgroundColor.TabIndex = 0;
            this.FormBackgroundColor.SelectedIndexChanged += new System.EventHandler(this.FormBackgroundColor_SelectedIndexChanged);
            // 
            // FormForegroundColor
            // 
            this.FormForegroundColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormForegroundColor.FormattingEnabled = true;
            this.FormForegroundColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Blue"});
            this.FormForegroundColor.Location = new System.Drawing.Point(167, 40);
            this.FormForegroundColor.MaxDropDownItems = 10;
            this.FormForegroundColor.Name = "FormForegroundColor";
            this.FormForegroundColor.Size = new System.Drawing.Size(246, 21);
            this.FormForegroundColor.TabIndex = 2;
            this.FormForegroundColor.SelectedIndexChanged += new System.EventHandler(this.FormForegroundColor_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.ElementBorderColor);
            this.groupBox4.Location = new System.Drawing.Point(6, 248);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 49);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Element Border";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Background:";
            // 
            // ElementBorderColor
            // 
            this.ElementBorderColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ElementBorderColor.FormattingEnabled = true;
            this.ElementBorderColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Blue"});
            this.ElementBorderColor.Location = new System.Drawing.Point(167, 13);
            this.ElementBorderColor.MaxDropDownItems = 10;
            this.ElementBorderColor.Name = "ElementBorderColor";
            this.ElementBorderColor.Size = new System.Drawing.Size(246, 21);
            this.ElementBorderColor.TabIndex = 0;
            this.ElementBorderColor.SelectedIndexChanged += new System.EventHandler(this.ElementBorderColor_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.SearchBackgroundColor);
            this.groupBox3.Controls.Add(this.SearchForegroundColor);
            this.groupBox3.Location = new System.Drawing.Point(6, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 73);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Searchbox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Background:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Foreground:";
            // 
            // SearchBackgroundColor
            // 
            this.SearchBackgroundColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchBackgroundColor.FormattingEnabled = true;
            this.SearchBackgroundColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Blue"});
            this.SearchBackgroundColor.Location = new System.Drawing.Point(167, 13);
            this.SearchBackgroundColor.MaxDropDownItems = 10;
            this.SearchBackgroundColor.Name = "SearchBackgroundColor";
            this.SearchBackgroundColor.Size = new System.Drawing.Size(246, 21);
            this.SearchBackgroundColor.TabIndex = 0;
            this.SearchBackgroundColor.SelectedIndexChanged += new System.EventHandler(this.SearchBackgroundColor_SelectedIndexChanged);
            // 
            // SearchForegroundColor
            // 
            this.SearchForegroundColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchForegroundColor.FormattingEnabled = true;
            this.SearchForegroundColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Blue"});
            this.SearchForegroundColor.Location = new System.Drawing.Point(167, 40);
            this.SearchForegroundColor.MaxDropDownItems = 10;
            this.SearchForegroundColor.Name = "SearchForegroundColor";
            this.SearchForegroundColor.Size = new System.Drawing.Size(246, 21);
            this.SearchForegroundColor.TabIndex = 2;
            this.SearchForegroundColor.SelectedIndexChanged += new System.EventHandler(this.SearchForegroundColor_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Background Image:";
            // 
            // btnFormBackgroundImage
            // 
            this.btnFormBackgroundImage.Location = new System.Drawing.Point(379, 113);
            this.btnFormBackgroundImage.Name = "btnFormBackgroundImage";
            this.btnFormBackgroundImage.Size = new System.Drawing.Size(34, 23);
            this.btnFormBackgroundImage.TabIndex = 7;
            this.btnFormBackgroundImage.Text = "...";
            this.btnFormBackgroundImage.UseVisualStyleBackColor = true;
            this.btnFormBackgroundImage.Click += new System.EventHandler(this.btnFormBackgroundImage_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(449, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "- this is buggy";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(507, 355);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(91, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset Settings";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 390);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormOpacity)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FormBackgroundColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FormForegroundColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SearchBackgroundColor;
        private System.Windows.Forms.ComboBox SearchForegroundColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ElementBorderColor;
        private System.Windows.Forms.TrackBar FormOpacity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFormBackgroundImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReset;
    }
}