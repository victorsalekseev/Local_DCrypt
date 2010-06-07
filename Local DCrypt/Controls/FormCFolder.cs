using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Netcode.Crypt;

namespace Remote_DCrypt.Controls
{
    public partial class FormCFolder : Form
    {
        public FormCFolder()
        {
            InitializeComponent();
        }

        public FormCFolder(string main_title)
        {
            InitializeComponent();
            this.ActiveControl = textBox_act;
            this.Text = main_title;

            textBox_act.KeyDown += new KeyEventHandler(textBox_act_KeyDown);
            button_ok.Click += new EventHandler(button_ok_Click);
            FormClosing += new FormClosingEventHandler(FormCFolder_FormClosing);
            textBox_act.Text = InputText;
        }

        void FormCFolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_act.Text))
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        void button_ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_act.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        void textBox_act_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox_act.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
            }
        }

        public string InputText
        {
            get {
                if (checkBox_isEncrypt.Checked)
                {
                    return new FileCrypt().EncryptFName(textBox_act.Text, PrefSettings.key_fname, PrefSettings.prefix);
                }
                return textBox_act.Text; }
            set { textBox_act.Text = value; }
        }
    }
}