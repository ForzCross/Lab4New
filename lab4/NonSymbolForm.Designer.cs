namespace lab4
{
    partial class NonSymbolForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddFromDBButton = new System.Windows.Forms.Button();
            this.AddInDBButton = new System.Windows.Forms.Button();
            this.DoneSelectFromDBButton = new System.Windows.Forms.Button();
            this.NameSymbolText = new System.Windows.Forms.TextBox();
            this.InfoSymbolText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DoneAddInDBButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DoneAddInDBButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.InfoSymbolText);
            this.panel1.Controls.Add(this.NameSymbolText);
            this.panel1.Location = new System.Drawing.Point(245, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 210);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DoneSelectFromDBButton);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(137, 210);
            this.panel2.TabIndex = 2;
            // 
            // AddFromDBButton
            // 
            this.AddFromDBButton.Location = new System.Drawing.Point(155, 68);
            this.AddFromDBButton.Name = "AddFromDBButton";
            this.AddFromDBButton.Size = new System.Drawing.Size(84, 36);
            this.AddFromDBButton.TabIndex = 3;
            this.AddFromDBButton.Text = "Выбрать из БД";
            this.AddFromDBButton.UseVisualStyleBackColor = true;
            // 
            // AddInDBButton
            // 
            this.AddInDBButton.Location = new System.Drawing.Point(155, 131);
            this.AddInDBButton.Name = "AddInDBButton";
            this.AddInDBButton.Size = new System.Drawing.Size(84, 38);
            this.AddInDBButton.TabIndex = 4;
            this.AddInDBButton.Text = "Добавить в БД";
            this.AddInDBButton.UseVisualStyleBackColor = true;
            // 
            // DoneSelectFromDBButton
            // 
            this.DoneSelectFromDBButton.Location = new System.Drawing.Point(29, 166);
            this.DoneSelectFromDBButton.Name = "DoneSelectFromDBButton";
            this.DoneSelectFromDBButton.Size = new System.Drawing.Size(75, 23);
            this.DoneSelectFromDBButton.TabIndex = 1;
            this.DoneSelectFromDBButton.Text = "Выбрать";
            this.DoneSelectFromDBButton.UseVisualStyleBackColor = true;
            // 
            // NameSymbolText
            // 
            this.NameSymbolText.Location = new System.Drawing.Point(33, 34);
            this.NameSymbolText.Name = "NameSymbolText";
            this.NameSymbolText.Size = new System.Drawing.Size(100, 20);
            this.NameSymbolText.TabIndex = 0;
            // 
            // InfoSymbolText
            // 
            this.InfoSymbolText.Location = new System.Drawing.Point(33, 83);
            this.InfoSymbolText.Name = "InfoSymbolText";
            this.InfoSymbolText.Size = new System.Drawing.Size(100, 20);
            this.InfoSymbolText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "info";
            // 
            // DoneAddInDBButton
            // 
            this.DoneAddInDBButton.Location = new System.Drawing.Point(46, 166);
            this.DoneAddInDBButton.Name = "DoneAddInDBButton";
            this.DoneAddInDBButton.Size = new System.Drawing.Size(75, 23);
            this.DoneAddInDBButton.TabIndex = 4;
            this.DoneAddInDBButton.Text = "Добавить";
            this.DoneAddInDBButton.UseVisualStyleBackColor = true;
            // 
            // NonSymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 234);
            this.Controls.Add(this.AddInDBButton);
            this.Controls.Add(this.AddFromDBButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NonSymbolForm";
            this.Text = "NonSymbolForm";
            this.Load += new System.EventHandler(this.NonSymbolForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DoneAddInDBButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InfoSymbolText;
        private System.Windows.Forms.TextBox NameSymbolText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DoneSelectFromDBButton;
        private System.Windows.Forms.Button AddFromDBButton;
        private System.Windows.Forms.Button AddInDBButton;
    }
}