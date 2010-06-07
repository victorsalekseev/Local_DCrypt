namespace Remote_DCrypt
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.утилитыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менеджерКонтактовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flatFileExplorerEnc = new Netcode.Controls.FlatFileExplorer();
            this.button_from_remote = new System.Windows.Forms.Button();
            this.panel_local = new System.Windows.Forms.Panel();
            this.button_to_remote = new System.Windows.Forms.Button();
            this.flatFileExplorerDec = new Netcode.Controls.FlatFileExplorer();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.файловыйКрипторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менеджерКонтактовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.panel_local.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.утилитыToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(659, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.sett;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.close;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // утилитыToolStripMenuItem
            // 
            this.утилитыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менеджерКонтактовToolStripMenuItem});
            this.утилитыToolStripMenuItem.Name = "утилитыToolStripMenuItem";
            this.утилитыToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.утилитыToolStripMenuItem.Text = "Утилиты";
            // 
            // менеджерКонтактовToolStripMenuItem
            // 
            this.менеджерКонтактовToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.cm;
            this.менеджерКонтактовToolStripMenuItem.Name = "менеджерКонтактовToolStripMenuItem";
            this.менеджерКонтактовToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.менеджерКонтактовToolStripMenuItem.Text = "Менеджер контактов";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.flatFileExplorerEnc, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel_local, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.flatFileExplorerDec, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(659, 363);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // flatFileExplorerEnc
            // 
            this.flatFileExplorerEnc.button_to_remote = this.button_from_remote;
            this.flatFileExplorerEnc.CurrLocalPath = "";
            this.flatFileExplorerEnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flatFileExplorerEnc.isEncryptedNames = true;
            this.flatFileExplorerEnc.Location = new System.Drawing.Point(349, 3);
            this.flatFileExplorerEnc.Name = "flatFileExplorerEnc";
            this.flatFileExplorerEnc.NameFileExplorer = "Окно отображения зашифрованных файлов";
            this.flatFileExplorerEnc.pwd_key = "";
            this.flatFileExplorerEnc.Size = new System.Drawing.Size(307, 357);
            this.flatFileExplorerEnc.TabIndex = 6;
            // 
            // button_from_remote
            // 
            this.button_from_remote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_from_remote.Image = global::Local_DCrypt.Properties.Resources.decr;
            this.button_from_remote.Location = new System.Drawing.Point(1, 189);
            this.button_from_remote.Name = "button_from_remote";
            this.button_from_remote.Size = new System.Drawing.Size(24, 24);
            this.button_from_remote.TabIndex = 5;
            this.button_from_remote.UseVisualStyleBackColor = true;
            // 
            // panel_local
            // 
            this.panel_local.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_local.Controls.Add(this.button_from_remote);
            this.panel_local.Controls.Add(this.button_to_remote);
            this.panel_local.Location = new System.Drawing.Point(316, 3);
            this.panel_local.Name = "panel_local";
            this.panel_local.Size = new System.Drawing.Size(27, 357);
            this.panel_local.TabIndex = 5;
            // 
            // button_to_remote
            // 
            this.button_to_remote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_to_remote.Enabled = false;
            this.button_to_remote.Image = global::Local_DCrypt.Properties.Resources.encr;
            this.button_to_remote.Location = new System.Drawing.Point(1, 144);
            this.button_to_remote.Name = "button_to_remote";
            this.button_to_remote.Size = new System.Drawing.Size(24, 24);
            this.button_to_remote.TabIndex = 4;
            this.button_to_remote.UseVisualStyleBackColor = true;
            // 
            // flatFileExplorerDec
            // 
            this.flatFileExplorerDec.button_to_remote = this.button_to_remote;
            this.flatFileExplorerDec.CurrLocalPath = "";
            this.flatFileExplorerDec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flatFileExplorerDec.isEncryptedNames = false;
            this.flatFileExplorerDec.Location = new System.Drawing.Point(3, 3);
            this.flatFileExplorerDec.Name = "flatFileExplorerDec";
            this.flatFileExplorerDec.NameFileExplorer = "Окно отображения обычных файлов";
            this.flatFileExplorerDec.pwd_key = "";
            this.flatFileExplorerDec.Size = new System.Drawing.Size(307, 357);
            this.flatFileExplorerDec.TabIndex = 2;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файловыйКрипторToolStripMenuItem,
            this.менеджерКонтактовToolStripMenuItem1,
            this.выходToolStripMenuItem_2});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(191, 70);
            // 
            // файловыйКрипторToolStripMenuItem
            // 
            this.файловыйКрипторToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.файловыйКрипторToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.lc;
            this.файловыйКрипторToolStripMenuItem.Name = "файловыйКрипторToolStripMenuItem";
            this.файловыйКрипторToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.файловыйКрипторToolStripMenuItem.Text = "Файловый криптор";
            // 
            // менеджерКонтактовToolStripMenuItem1
            // 
            this.менеджерКонтактовToolStripMenuItem1.Image = global::Local_DCrypt.Properties.Resources.cm;
            this.менеджерКонтактовToolStripMenuItem1.Name = "менеджерКонтактовToolStripMenuItem1";
            this.менеджерКонтактовToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.менеджерКонтактовToolStripMenuItem1.Text = "Менеджер контактов";
            // 
            // выходToolStripMenuItem_2
            // 
            this.выходToolStripMenuItem_2.Image = global::Local_DCrypt.Properties.Resources.close;
            this.выходToolStripMenuItem_2.Name = "выходToolStripMenuItem_2";
            this.выходToolStripMenuItem_2.Size = new System.Drawing.Size(190, 22);
            this.выходToolStripMenuItem_2.Text = "Выход";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.info;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 387);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "FormMain";
            this.Text = "Файловый криптор LC v";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.panel_local.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Netcode.Controls.FlatFileExplorer flatFileExplorerEnc;
        private System.Windows.Forms.Button button_from_remote;
        private System.Windows.Forms.Panel panel_local;
        private System.Windows.Forms.Button button_to_remote;
        private Netcode.Controls.FlatFileExplorer flatFileExplorerDec;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem_2;
        private System.Windows.Forms.ToolStripMenuItem утилитыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem менеджерКонтактовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem менеджерКонтактовToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem файловыйКрипторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

