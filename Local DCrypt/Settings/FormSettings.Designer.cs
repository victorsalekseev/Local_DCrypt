namespace Remote_DCrypt.Settings
{
    partial class FormSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabSet = new System.Windows.Forms.TabControl();
            this.tabServ = new System.Windows.Forms.TabPage();
            this.gBoxConnSet = new System.Windows.Forms.GroupBox();
            this.textBoxSelectFolderRight = new Netcode.Controls.TextBoxSelectFolder();
            this.textBoxSelectFolderLeft = new Netcode.Controls.TextBoxSelectFolder();
            this.label7 = new System.Windows.Forms.Label();
            this.label_right = new System.Windows.Forms.Label();
            this.comboBox_use_auth_key = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_prefix = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.label_left = new System.Windows.Forms.Label();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.gBoxFile = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_key_size = new System.Windows.Forms.ComboBox();
            this.label_msg = new System.Windows.Forms.Label();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gBoxFNamesKey = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.label_help = new System.Windows.Forms.Label();
            this.textBox_fnamekey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_common = new System.Windows.Forms.TabPage();
            this.groupBox_int = new System.Windows.Forms.GroupBox();
            this.checkBox_shell = new System.Windows.Forms.CheckBox();
            this.groupBox_cm = new System.Windows.Forms.GroupBox();
            this.label_fcont = new System.Windows.Forms.Label();
            this.textBox_fcont = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabSet.SuspendLayout();
            this.tabServ.SuspendLayout();
            this.gBoxConnSet.SuspendLayout();
            this.tabKeys.SuspendLayout();
            this.gBoxFile.SuspendLayout();
            this.gBoxFNamesKey.SuspendLayout();
            this.tabPage_common.SuspendLayout();
            this.groupBox_int.SuspendLayout();
            this.groupBox_cm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 46);
            this.panel1.TabIndex = 0;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(340, 11);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Location = new System.Drawing.Point(259, 11);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "ОК";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabSet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 287);
            this.panel2.TabIndex = 1;
            // 
            // tabSet
            // 
            this.tabSet.Controls.Add(this.tabServ);
            this.tabSet.Controls.Add(this.tabKeys);
            this.tabSet.Controls.Add(this.tabPage_common);
            this.tabSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSet.Location = new System.Drawing.Point(0, 0);
            this.tabSet.Name = "tabSet";
            this.tabSet.SelectedIndex = 0;
            this.tabSet.Size = new System.Drawing.Size(419, 287);
            this.tabSet.TabIndex = 1;
            // 
            // tabServ
            // 
            this.tabServ.Controls.Add(this.gBoxConnSet);
            this.tabServ.Location = new System.Drawing.Point(4, 22);
            this.tabServ.Name = "tabServ";
            this.tabServ.Padding = new System.Windows.Forms.Padding(3);
            this.tabServ.Size = new System.Drawing.Size(411, 261);
            this.tabServ.TabIndex = 0;
            this.tabServ.Text = "Основные";
            this.tabServ.UseVisualStyleBackColor = true;
            // 
            // gBoxConnSet
            // 
            this.gBoxConnSet.Controls.Add(this.textBoxSelectFolderRight);
            this.gBoxConnSet.Controls.Add(this.textBoxSelectFolderLeft);
            this.gBoxConnSet.Controls.Add(this.label7);
            this.gBoxConnSet.Controls.Add(this.label_right);
            this.gBoxConnSet.Controls.Add(this.comboBox_use_auth_key);
            this.gBoxConnSet.Controls.Add(this.label2);
            this.gBoxConnSet.Controls.Add(this.textBox_prefix);
            this.gBoxConnSet.Controls.Add(this.label_user);
            this.gBoxConnSet.Controls.Add(this.label_left);
            this.gBoxConnSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxConnSet.Location = new System.Drawing.Point(3, 3);
            this.gBoxConnSet.Name = "gBoxConnSet";
            this.gBoxConnSet.Size = new System.Drawing.Size(405, 255);
            this.gBoxConnSet.TabIndex = 0;
            this.gBoxConnSet.TabStop = false;
            this.gBoxConnSet.Text = "Основные параметры";
            // 
            // textBoxSelectFolderRight
            // 
            this.textBoxSelectFolderRight.InputText = "";
            this.textBoxSelectFolderRight.Location = new System.Drawing.Point(84, 46);
            this.textBoxSelectFolderRight.Name = "textBoxSelectFolderRight";
            this.textBoxSelectFolderRight.Size = new System.Drawing.Size(315, 21);
            this.textBoxSelectFolderRight.TabIndex = 10;
            // 
            // textBoxSelectFolderLeft
            // 
            this.textBoxSelectFolderLeft.InputText = "";
            this.textBoxSelectFolderLeft.Location = new System.Drawing.Point(84, 19);
            this.textBoxSelectFolderLeft.Name = "textBoxSelectFolderLeft";
            this.textBoxSelectFolderLeft.Size = new System.Drawing.Size(315, 21);
            this.textBoxSelectFolderLeft.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Соответствует соглашениям об именах файлов";
            // 
            // label_right
            // 
            this.label_right.AutoSize = true;
            this.label_right.Location = new System.Drawing.Point(19, 50);
            this.label_right.Name = "label_right";
            this.label_right.Size = new System.Drawing.Size(59, 13);
            this.label_right.TabIndex = 6;
            this.label_right.Text = "Приемник";
            // 
            // comboBox_use_auth_key
            // 
            this.comboBox_use_auth_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_use_auth_key.Enabled = false;
            this.comboBox_use_auth_key.FormattingEnabled = true;
            this.comboBox_use_auth_key.Items.AddRange(new object[] {
            "Клавиатура",
            "Обмен ключами"});
            this.comboBox_use_auth_key.Location = new System.Drawing.Point(84, 99);
            this.comboBox_use_auth_key.Name = "comboBox_use_auth_key";
            this.comboBox_use_auth_key.Size = new System.Drawing.Size(87, 21);
            this.comboBox_use_auth_key.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ввод пароля";
            // 
            // textBox_prefix
            // 
            this.textBox_prefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_prefix.Location = new System.Drawing.Point(84, 73);
            this.textBox_prefix.Name = "textBox_prefix";
            this.textBox_prefix.Size = new System.Drawing.Size(53, 20);
            this.textBox_prefix.TabIndex = 3;
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(25, 76);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(53, 13);
            this.label_user.TabIndex = 2;
            this.label_user.Text = "Префикс";
            // 
            // label_left
            // 
            this.label_left.AutoSize = true;
            this.label_left.Location = new System.Drawing.Point(23, 23);
            this.label_left.Name = "label_left";
            this.label_left.Size = new System.Drawing.Size(55, 13);
            this.label_left.TabIndex = 0;
            this.label_left.Text = "Источник";
            // 
            // tabKeys
            // 
            this.tabKeys.Controls.Add(this.gBoxFile);
            this.tabKeys.Controls.Add(this.gBoxFNamesKey);
            this.tabKeys.Location = new System.Drawing.Point(4, 22);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeys.Size = new System.Drawing.Size(411, 261);
            this.tabKeys.TabIndex = 1;
            this.tabKeys.Text = "Шифрование";
            this.tabKeys.UseVisualStyleBackColor = true;
            // 
            // gBoxFile
            // 
            this.gBoxFile.Controls.Add(this.label3);
            this.gBoxFile.Controls.Add(this.label5);
            this.gBoxFile.Controls.Add(this.comboBox_key_size);
            this.gBoxFile.Controls.Add(this.label_msg);
            this.gBoxFile.Controls.Add(this.textBox_pwd);
            this.gBoxFile.Controls.Add(this.label4);
            this.gBoxFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxFile.Location = new System.Drawing.Point(3, 130);
            this.gBoxFile.Name = "gBoxFile";
            this.gBoxFile.Size = new System.Drawing.Size(405, 128);
            this.gBoxFile.TabIndex = 1;
            this.gBoxFile.TabStop = false;
            this.gBoxFile.Text = "Шифрование файлов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Бит";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ключ";
            // 
            // comboBox_key_size
            // 
            this.comboBox_key_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_key_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_key_size.FormattingEnabled = true;
            this.comboBox_key_size.Items.AddRange(new object[] {
            "256",
            "192",
            "128"});
            this.comboBox_key_size.Location = new System.Drawing.Point(311, 100);
            this.comboBox_key_size.Name = "comboBox_key_size";
            this.comboBox_key_size.Size = new System.Drawing.Size(57, 21);
            this.comboBox_key_size.TabIndex = 3;
            this.comboBox_key_size.SelectedIndexChanged += new System.EventHandler(this.comboBox_key_size_SelectedIndexChanged);
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_msg.Location = new System.Drawing.Point(57, 97);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(201, 28);
            this.label_msg.TabIndex = 2;
            this.label_msg.Text = "Если поле пустое, будет использован\r\nключ по умолчанию";
            this.label_msg.Click += new System.EventHandler(this.label_msg_Click);
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_pwd.Location = new System.Drawing.Point(57, 19);
            this.textBox_pwd.MaxLength = 255;
            this.textBox_pwd.Multiline = true;
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_pwd.Size = new System.Drawing.Size(342, 71);
            this.textBox_pwd.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Пароль";
            // 
            // gBoxFNamesKey
            // 
            this.gBoxFNamesKey.Controls.Add(this.label6);
            this.gBoxFNamesKey.Controls.Add(this.textBox_count);
            this.gBoxFNamesKey.Controls.Add(this.label_help);
            this.gBoxFNamesKey.Controls.Add(this.textBox_fnamekey);
            this.gBoxFNamesKey.Controls.Add(this.label1);
            this.gBoxFNamesKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxFNamesKey.Location = new System.Drawing.Point(3, 3);
            this.gBoxFNamesKey.Name = "gBoxFNamesKey";
            this.gBoxFNamesKey.Size = new System.Drawing.Size(405, 127);
            this.gBoxFNamesKey.TabIndex = 0;
            this.gBoxFNamesKey.TabStop = false;
            this.gBoxFNamesKey.Text = "Шифрование имен файлов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Длина";
            // 
            // textBox_count
            // 
            this.textBox_count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_count.Enabled = false;
            this.textBox_count.Location = new System.Drawing.Point(312, 96);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.Size = new System.Drawing.Size(87, 20);
            this.textBox_count.TabIndex = 3;
            this.textBox_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_help
            // 
            this.label_help.AutoSize = true;
            this.label_help.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_help.Location = new System.Drawing.Point(57, 96);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(201, 28);
            this.label_help.TabIndex = 2;
            this.label_help.Text = "Если поле пустое, будет использован\r\nключ по умолчанию";
            // 
            // textBox_fnamekey
            // 
            this.textBox_fnamekey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_fnamekey.Location = new System.Drawing.Point(57, 19);
            this.textBox_fnamekey.MaxLength = 1024;
            this.textBox_fnamekey.Multiline = true;
            this.textBox_fnamekey.Name = "textBox_fnamekey";
            this.textBox_fnamekey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_fnamekey.Size = new System.Drawing.Size(342, 71);
            this.textBox_fnamekey.TabIndex = 1;
            this.textBox_fnamekey.TextChanged += new System.EventHandler(this.textBox_fnamekey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пароль";
            // 
            // tabPage_common
            // 
            this.tabPage_common.Controls.Add(this.groupBox_cm);
            this.tabPage_common.Controls.Add(this.groupBox_int);
            this.tabPage_common.Location = new System.Drawing.Point(4, 22);
            this.tabPage_common.Name = "tabPage_common";
            this.tabPage_common.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_common.Size = new System.Drawing.Size(411, 261);
            this.tabPage_common.TabIndex = 2;
            this.tabPage_common.Text = "Общие";
            this.tabPage_common.UseVisualStyleBackColor = true;
            // 
            // groupBox_int
            // 
            this.groupBox_int.Controls.Add(this.checkBox_shell);
            this.groupBox_int.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_int.Location = new System.Drawing.Point(3, 3);
            this.groupBox_int.Name = "groupBox_int";
            this.groupBox_int.Size = new System.Drawing.Size(405, 47);
            this.groupBox_int.TabIndex = 0;
            this.groupBox_int.TabStop = false;
            this.groupBox_int.Text = "Интеграция";
            // 
            // checkBox_shell
            // 
            this.checkBox_shell.AutoSize = true;
            this.checkBox_shell.Location = new System.Drawing.Point(6, 19);
            this.checkBox_shell.Name = "checkBox_shell";
            this.checkBox_shell.Size = new System.Drawing.Size(324, 17);
            this.checkBox_shell.TabIndex = 0;
            this.checkBox_shell.Text = "Добавить пункт в контекстное меню проводника Windows";
            this.checkBox_shell.UseVisualStyleBackColor = true;
            // 
            // groupBox_cm
            // 
            this.groupBox_cm.Controls.Add(this.label_fcont);
            this.groupBox_cm.Controls.Add(this.textBox_fcont);
            this.groupBox_cm.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_cm.Location = new System.Drawing.Point(3, 50);
            this.groupBox_cm.Name = "groupBox_cm";
            this.groupBox_cm.Size = new System.Drawing.Size(405, 47);
            this.groupBox_cm.TabIndex = 15;
            this.groupBox_cm.TabStop = false;
            this.groupBox_cm.Text = "Менеджер контактов";
            // 
            // label_fcont
            // 
            this.label_fcont.AutoSize = true;
            this.label_fcont.Location = new System.Drawing.Point(7, 21);
            this.label_fcont.Name = "label_fcont";
            this.label_fcont.Size = new System.Drawing.Size(91, 13);
            this.label_fcont.TabIndex = 16;
            this.label_fcont.Text = "Файл контактов";
            // 
            // textBox_fcont
            // 
            this.textBox_fcont.Location = new System.Drawing.Point(104, 18);
            this.textBox_fcont.Name = "textBox_fcont";
            this.textBox_fcont.Size = new System.Drawing.Size(295, 20);
            this.textBox_fcont.TabIndex = 15;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(419, 333);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSettings_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabSet.ResumeLayout(false);
            this.tabServ.ResumeLayout(false);
            this.gBoxConnSet.ResumeLayout(false);
            this.gBoxConnSet.PerformLayout();
            this.tabKeys.ResumeLayout(false);
            this.gBoxFile.ResumeLayout(false);
            this.gBoxFile.PerformLayout();
            this.gBoxFNamesKey.ResumeLayout(false);
            this.gBoxFNamesKey.PerformLayout();
            this.tabPage_common.ResumeLayout(false);
            this.groupBox_int.ResumeLayout(false);
            this.groupBox_int.PerformLayout();
            this.groupBox_cm.ResumeLayout(false);
            this.groupBox_cm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabSet;
        private System.Windows.Forms.TabPage tabServ;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.GroupBox gBoxFNamesKey;
        private System.Windows.Forms.TextBox textBox_fnamekey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_help;
        private System.Windows.Forms.GroupBox gBoxConnSet;
        private System.Windows.Forms.Label label_left;
        private System.Windows.Forms.TextBox textBox_prefix;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.ComboBox comboBox_use_auth_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_right;
        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.GroupBox gBoxFile;
        private System.Windows.Forms.Label label_msg;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_key_size;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage_common;
        private System.Windows.Forms.GroupBox groupBox_int;
        private System.Windows.Forms.CheckBox checkBox_shell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private Netcode.Controls.TextBoxSelectFolder textBoxSelectFolderLeft;
        private Netcode.Controls.TextBoxSelectFolder textBoxSelectFolderRight;
        private System.Windows.Forms.GroupBox groupBox_cm;
        private System.Windows.Forms.Label label_fcont;
        private System.Windows.Forms.TextBox textBox_fcont;

    }
}