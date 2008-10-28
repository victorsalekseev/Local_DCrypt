using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Local_DCrypt
{
    public partial class FormPref : Form
    {
        public FormPref()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            textBox_pref.KeyDown += new KeyEventHandler(textBox_pref_KeyDown);
            button_pref.Click += new EventHandler(button_pref_Click);
        }

        public bool EditType
        {
            get { return textBox_pref_name.Enabled; }
            set { textBox_pref_name.Enabled = value; }
        }

        public string NewPref
        {
            get { return textBox_pref.Text; }
            set { textBox_pref.Text = value; }
        }

        public string NewPrefName
        {
            get { return textBox_pref_name.Text; }
            set { textBox_pref_name.Text = value; }
        }

        public string MainText
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        private void CheckBlankPref()
        {
            if (textBox_pref.Text.Length < 1 || textBox_pref_name.Text.Length < 1)
            {
                //this.ActiveControl = textBox_pref;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        void button_pref_Click(object sender, EventArgs e)
        {
            CheckBlankPref();
        }

        void textBox_pref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckBlankPref();
            }
        }
    }
}