namespace lab4
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertModeButton = new System.Windows.Forms.Button();
            this.userModeButton = new System.Windows.Forms.Button();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСимволыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // expertModeButton
            // 
            this.expertModeButton.Location = new System.Drawing.Point(264, 142);
            this.expertModeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.expertModeButton.Name = "expertModeButton";
            this.expertModeButton.Size = new System.Drawing.Size(180, 35);
            this.expertModeButton.TabIndex = 1;
            this.expertModeButton.Text = "Экспертный режим";
            this.expertModeButton.UseVisualStyleBackColor = true;
            this.expertModeButton.Click += new System.EventHandler(this.expertModeButton_Click);
            // 
            // userModeButton
            // 
            this.userModeButton.Location = new System.Drawing.Point(264, 237);
            this.userModeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userModeButton.Name = "userModeButton";
            this.userModeButton.Size = new System.Drawing.Size(180, 66);
            this.userModeButton.TabIndex = 2;
            this.userModeButton.Text = "Пользовательский режим";
            this.userModeButton.UseVisualStyleBackColor = true;
            this.userModeButton.Click += new System.EventHandler(this.userModeButton_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСимволыToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // добавитьСимволыToolStripMenuItem
            // 
            this.добавитьСимволыToolStripMenuItem.Name = "добавитьСимволыToolStripMenuItem";
            this.добавитьСимволыToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.добавитьСимволыToolStripMenuItem.Text = "Добавить символы";
            this.добавитьСимволыToolStripMenuItem.Click += new System.EventHandler(this.добавитьСимволыToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 437);
            this.Controls.Add(this.userModeButton);
            this.Controls.Add(this.expertModeButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Распознавание символов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button expertModeButton;
        private System.Windows.Forms.Button userModeButton;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСимволыToolStripMenuItem;
    }
}

