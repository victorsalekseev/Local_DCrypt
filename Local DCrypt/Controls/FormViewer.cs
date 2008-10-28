using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Remote_DCrypt.Controls
{
    public partial class FormViewer : Form
    {
        bool _is_editing = false;
        string _crypt_filename = string.Empty;
        Crypt cr = new Crypt();
        public FormViewer()
        {
            InitializeComponent();
        }

        public FormViewer(string crypt_filename)
        {
            InitializeComponent();
            _crypt_filename = crypt_filename;
            comboBoxEnc.SelectedIndex = 0;
            comboBoxEnc.SelectedIndexChanged += new EventHandler(comboBoxEnc_SelectedIndexChanged);
            comboBoxEnc.KeyDown += new KeyEventHandler(comboBoxEnc_KeyDown);
            this.FormClosing += new FormClosingEventHandler(FormViewer_FormClosing);
            Decrypt();
            textBoxList.TextChanged += new EventHandler(textBoxList_TextChanged);
        }

        void FormViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_is_editing)
            {
                if (MessageBox.Show("Сохранить изменения в файле?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cr.encryt_byte_to_file(PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size),  Encoding.GetEncoding(comboBoxEnc.Text).GetBytes(textBoxList.Text), _crypt_filename, progressBarSt);
                        progressBarSt.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
            }
        }

        void textBoxList_TextChanged(object sender, EventArgs e)
        {
            _is_editing = true;
        }

        private void Decrypt()
        {
            try
            {
                textBoxList.Text = Encoding.GetEncoding(comboBoxEnc.Text).GetString(cr.decrypt_file_to_byte(PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), _crypt_filename, progressBarSt));
                progressBarSt.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        void comboBoxEnc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Decrypt();
            }
        }

        void comboBoxEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decrypt();
        }
    }
}