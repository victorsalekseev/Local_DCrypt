namespace Local_DCrypt
{
    partial class FormCM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCM));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСвойствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_pref = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.телефонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wMIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яндекскошелекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.адресToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wWWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExpandOn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExpandOff = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.treeView_с = new System.Windows.Forms.TreeView();
            this.contextMenuStrip.SuspendLayout();
            this.contextMenuStrip_pref.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.добавитьСвойствоToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 114);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.ID__Add;
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить контакт";
            // 
            // добавитьСвойствоToolStripMenuItem
            // 
            this.добавитьСвойствоToolStripMenuItem.DropDown = this.contextMenuStrip_pref;
            this.добавитьСвойствоToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.ID_Inf;
            this.добавитьСвойствоToolStripMenuItem.Name = "добавитьСвойствоToolStripMenuItem";
            this.добавитьСвойствоToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьСвойствоToolStripMenuItem.Text = "Добавить к";
            // 
            // contextMenuStrip_pref
            // 
            this.contextMenuStrip_pref.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.телефонToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.wMIDToolStripMenuItem,
            this.яндекскошелекToolStripMenuItem,
            this.iCQToolStripMenuItem,
            this.адресToolStripMenuItem,
            this.wWWToolStripMenuItem,
            this.другоеToolStripMenuItem});
            this.contextMenuStrip_pref.Name = "contextMenuStrip";
            this.contextMenuStrip_pref.Size = new System.Drawing.Size(171, 202);
            // 
            // телефонToolStripMenuItem
            // 
            this.телефонToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.Telecommunications;
            this.телефонToolStripMenuItem.Name = "телефонToolStripMenuItem";
            this.телефонToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.телефонToolStripMenuItem.Tag = "2";
            this.телефонToolStripMenuItem.Text = "Телефон";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.Mail;
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.emailToolStripMenuItem.Tag = "3";
            this.emailToolStripMenuItem.Text = "E-mail";
            // 
            // wMIDToolStripMenuItem
            // 
            this.wMIDToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.wm;
            this.wMIDToolStripMenuItem.Name = "wMIDToolStripMenuItem";
            this.wMIDToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.wMIDToolStripMenuItem.Tag = "4";
            this.wMIDToolStripMenuItem.Text = "WM";
            // 
            // яндекскошелекToolStripMenuItem
            // 
            this.яндекскошелекToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.YM;
            this.яндекскошелекToolStripMenuItem.Name = "яндекскошелекToolStripMenuItem";
            this.яндекскошелекToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.яндекскошелекToolStripMenuItem.Tag = "5";
            this.яндекскошелекToolStripMenuItem.Text = "Яндекс-кошелек";
            // 
            // iCQToolStripMenuItem
            // 
            this.iCQToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.icq;
            this.iCQToolStripMenuItem.Name = "iCQToolStripMenuItem";
            this.iCQToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.iCQToolStripMenuItem.Tag = "6";
            this.iCQToolStripMenuItem.Text = "ICQ";
            // 
            // адресToolStripMenuItem
            // 
            this.адресToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.Caribean;
            this.адресToolStripMenuItem.Name = "адресToolStripMenuItem";
            this.адресToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.адресToolStripMenuItem.Tag = "7";
            this.адресToolStripMenuItem.Text = "Адрес";
            // 
            // wWWToolStripMenuItem
            // 
            this.wWWToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.Earth;
            this.wWWToolStripMenuItem.Name = "wWWToolStripMenuItem";
            this.wWWToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.wWWToolStripMenuItem.Tag = "8";
            this.wWWToolStripMenuItem.Text = "WWW";
            // 
            // другоеToolStripMenuItem
            // 
            this.другоеToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.other;
            this.другоеToolStripMenuItem.Name = "другоеToolStripMenuItem";
            this.другоеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.другоеToolStripMenuItem.Tag = "1";
            this.другоеToolStripMenuItem.Text = "Другое";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.copy_16;
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.edit_16;
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.del_16;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ID.png");
            this.imageList.Images.SetKeyName(1, "other.png");
            this.imageList.Images.SetKeyName(2, "Telecommunications.png");
            this.imageList.Images.SetKeyName(3, "Mail.png");
            this.imageList.Images.SetKeyName(4, "wm.png");
            this.imageList.Images.SetKeyName(5, "YM.png");
            this.imageList.Images.SetKeyName(6, "icq.png");
            this.imageList.Images.SetKeyName(7, "Caribean.png");
            this.imageList.Images.SetKeyName(8, "Earth.png");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.copyToolStripButton,
            this.toolStripButtonExpandOn,
            this.toolStripButtonExpandOff});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(323, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = global::Local_DCrypt.Properties.Resources.ID__Add;
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&Новый контакт";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::Local_DCrypt.Properties.Resources.folder_open_16;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Открыть файл контактов";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem});
            this.saveToolStripButton.Image = global::Local_DCrypt.Properties.Resources.save_16;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.saveToolStripButton.Text = "&Сохранить контакты";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.saveas_16;
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = global::Local_DCrypt.Properties.Resources.copy_16;
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Копировать значение";
            // 
            // toolStripButtonExpandOn
            // 
            this.toolStripButtonExpandOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExpandOn.Image = global::Local_DCrypt.Properties.Resources.down;
            this.toolStripButtonExpandOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExpandOn.Name = "toolStripButtonExpandOn";
            this.toolStripButtonExpandOn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExpandOn.Text = "Раскрыть все";
            // 
            // toolStripButtonExpandOff
            // 
            this.toolStripButtonExpandOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExpandOff.Image = global::Local_DCrypt.Properties.Resources.up;
            this.toolStripButtonExpandOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExpandOff.Name = "toolStripButtonExpandOff";
            this.toolStripButtonExpandOff.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExpandOff.Text = "Закрыть все";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Выберите файл контактов";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Сохранение файла контактов";
            // 
            // treeView_с
            // 
            this.treeView_с.ContextMenuStrip = this.contextMenuStrip;
            this.treeView_с.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_с.ImageIndex = 0;
            this.treeView_с.ImageList = this.imageList;
            this.treeView_с.Location = new System.Drawing.Point(0, 25);
            this.treeView_с.Name = "treeView_с";
            this.treeView_с.SelectedImageIndex = 0;
            this.treeView_с.Size = new System.Drawing.Size(323, 332);
            this.treeView_с.TabIndex = 5;
            // 
            // FormCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 357);
            this.Controls.Add(this.treeView_с);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Менеджер контактов";
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip_pref.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_pref;
        private System.Windows.Forms.ToolStripMenuItem телефонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wMIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem яндекскошелекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iCQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem адресToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСвойствоToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wWWToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSplitButton saveToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TreeView treeView_с;
        private System.Windows.Forms.ToolStripButton toolStripButtonExpandOn;
        private System.Windows.Forms.ToolStripButton toolStripButtonExpandOff;
    }
}

