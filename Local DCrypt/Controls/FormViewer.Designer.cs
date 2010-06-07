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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewer));
            this.panel_bot = new System.Windows.Forms.Panel();
            this.progressBarSt = new System.Windows.Forms.ProgressBar();
            this.comboBoxEnc = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refrtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.undotoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.redotoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copy_imgtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copy_textToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rotate_img_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.as_text_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.textBoxList = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel_bot.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.refrtoolStripButton,
            this.undotoolStripButton,
            this.redotoolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copy_imgtoolStripButton,
            this.copy_textToolStripButton,
            this.pasteToolStripButton,
            this.rotate_img_toolStripButton,
            this.as_text_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(498, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Local_DCrypt.Properties.Resources.save_16;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Сохранить";
            // 
            // refrtoolStripButton
            // 
            this.refrtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refrtoolStripButton.Image = global::Local_DCrypt.Properties.Resources._ref;
            this.refrtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refrtoolStripButton.Name = "refrtoolStripButton";
            this.refrtoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refrtoolStripButton.Text = "Обновить";
            // 
            // undotoolStripButton
            // 
            this.undotoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undotoolStripButton.Image = global::Local_DCrypt.Properties.Resources.undo;
            this.undotoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undotoolStripButton.Name = "undotoolStripButton";
            this.undotoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.undotoolStripButton.Text = "Вернуть";
            // 
            // redotoolStripButton
            // 
            this.redotoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redotoolStripButton.Image = global::Local_DCrypt.Properties.Resources.redo;
            this.redotoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redotoolStripButton.Name = "redotoolStripButton";
            this.redotoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.redotoolStripButton.Text = "Вперед";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Печать";
            this.printToolStripButton.Visible = false;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "В&ырезать";
            // 
            // copy_imgtoolStripButton
            // 
            this.copy_imgtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copy_imgtoolStripButton.Image = global::Local_DCrypt.Properties.Resources.copy_16;
            this.copy_imgtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy_imgtoolStripButton.Name = "copy_imgtoolStripButton";
            this.copy_imgtoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copy_imgtoolStripButton.Text = "&Копировать изображение";
            // 
            // copy_textToolStripButton
            // 
            this.copy_textToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copy_textToolStripButton.Image = global::Local_DCrypt.Properties.Resources.copy_16;
            this.copy_textToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy_textToolStripButton.Name = "copy_textToolStripButton";
            this.copy_textToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copy_textToolStripButton.Text = "&Копировать текст";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Вставить";
            // 
            // rotate_img_toolStripButton
            // 
            this.rotate_img_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotate_img_toolStripButton.Image = global::Local_DCrypt.Properties.Resources.stock_tool_rotate_22;
            this.rotate_img_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotate_img_toolStripButton.Name = "rotate_img_toolStripButton";
            this.rotate_img_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.rotate_img_toolStripButton.Text = "Повернуть на 90 градусов по часовой стрелке";
            // 
            // as_text_toolStripButton
            // 
            this.as_text_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.as_text_toolStripButton.Image = global::Local_DCrypt.Properties.Resources.Wand;
            this.as_text_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.as_text_toolStripButton.Name = "as_text_toolStripButton";
            this.as_text_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.as_text_toolStripButton.Text = "Отобразить как изображение";
            // 
            // textBoxList
            // 
            this.textBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxList.Location = new System.Drawing.Point(0, 25);
            this.textBoxList.Multiline = true;
            this.textBoxList.Name = "textBoxList";
            this.textBoxList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxList.Size = new System.Drawing.Size(498, 286);
            this.textBoxList.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(442, 38);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(34, 33);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // FormViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 333);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBoxList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel_bot);
            this.Name = "FormViewer";
            this.ShowIcon = false;
            this.Text = "Просмотр текстовых файлов";
            this.panel_bot.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_bot;
        private System.Windows.Forms.ComboBox comboBoxEnc;
        private System.Windows.Forms.ProgressBar progressBarSt;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copy_textToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.TextBox textBoxList;
        private System.Windows.Forms.ToolStripButton undotoolStripButton;
        private System.Windows.Forms.ToolStripButton redotoolStripButton;
        private System.Windows.Forms.ToolStripButton refrtoolStripButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripButton copy_imgtoolStripButton;
        private System.Windows.Forms.ToolStripButton rotate_img_toolStripButton;
        private System.Windows.Forms.ToolStripButton as_text_toolStripButton;

    }
}