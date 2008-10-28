namespace Remote_DCrypt.Controls
{
    partial class FormViewer
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
            this.panel_bot = new System.Windows.Forms.Panel();
            this.progressBarSt = new System.Windows.Forms.ProgressBar();
            this.comboBoxEnc = new System.Windows.Forms.ComboBox();
            this.textBoxList = new System.Windows.Forms.TextBox();
            this.panel_bot.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_bot
            // 
            this.panel_bot.Controls.Add(this.progressBarSt);
            this.panel_bot.Controls.Add(this.comboBoxEnc);
            this.panel_bot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bot.Location = new System.Drawing.Point(0, 311);
            this.panel_bot.Name = "panel_bot";
            this.panel_bot.Size = new System.Drawing.Size(498, 22);
            this.panel_bot.TabIndex = 4;
            // 
            // progressBarSt
            // 
            this.progressBarSt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarSt.Location = new System.Drawing.Point(0, 0);
            this.progressBarSt.Name = "progressBarSt";
            this.progressBarSt.Size = new System.Drawing.Size(378, 22);
            this.progressBarSt.TabIndex = 2;
            // 
            // comboBoxEnc
            // 
            this.comboBoxEnc.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBoxEnc.FormattingEnabled = true;
            this.comboBoxEnc.Items.AddRange(new object[] {
            "Windows-1251",
            "UTF-8",
            "KOI8-R",
            "Windows-1252"});
            this.comboBoxEnc.Location = new System.Drawing.Point(378, 0);
            this.comboBoxEnc.Name = "comboBoxEnc";
            this.comboBoxEnc.Size = new System.Drawing.Size(120, 21);
            this.comboBoxEnc.TabIndex = 0;
            // 
            // textBoxList
            // 
            this.textBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxList.Location = new System.Drawing.Point(0, 0);
            this.textBoxList.Multiline = true;
            this.textBoxList.Name = "textBoxList";
            this.textBoxList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxList.Size = new System.Drawing.Size(498, 311);
            this.textBoxList.TabIndex = 5;
            // 
            // FormViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 333);
            this.Controls.Add(this.textBoxList);
            this.Controls.Add(this.panel_bot);
            this.Name = "FormViewer";
            this.ShowIcon = false;
            this.Text = "Просмотр текстовых файлов";
            this.panel_bot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_bot;
        private System.Windows.Forms.ComboBox comboBoxEnc;
        private System.Windows.Forms.ProgressBar progressBarSt;
        private System.Windows.Forms.TextBox textBoxList;

    }
}