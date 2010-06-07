using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using Netcode.Crypt;
using Netcode.Messages;
using Netcode.Common.File;

namespace Remote_DCrypt.Controls
{
    public partial class FormViewer : Form
    {
        bool _is_edited = false;
        string _crypt_filename = string.Empty;
        string _decrypt_filename = string.Empty;
        bool _is_image_data = false;
        FileCrypt cr = new FileCrypt();
        FileMarks fmr = new FileMarks();
        public FormViewer()
        {
            InitializeComponent();
        }

        public FormViewer(string crypt_filename)
        {
            InitializeComponent();
            _crypt_filename = crypt_filename;
            _decrypt_filename = cr.DecryptFName(new FileInfo(_crypt_filename).Name, PrefSettings.key_fname, PrefSettings.prefix);
            _is_image_data = fmr.IsImageFile(new FileInfo(_decrypt_filename).Extension);
            
            comboBoxEnc.SelectedIndex = 0;
            comboBoxEnc.SelectedIndexChanged += new EventHandler(comboBoxEnc_SelectedIndexChanged);
            comboBoxEnc.KeyDown += new KeyEventHandler(comboBoxEnc_KeyDown);
            this.FormClosing += new FormClosingEventHandler(FormViewer_FormClosing);
            this.ActiveControl = textBoxList;
            textBoxList.TextChanged += new EventHandler(textBoxList_TextChanged);
            saveToolStripButton.Click += new EventHandler(saveToolStripButton_Click);
            cutToolStripButton.Click += new EventHandler(cutToolStripButton_Click);
            copy_textToolStripButton.Click += new EventHandler(copy_textToolStripButton_Click);
            copy_imgtoolStripButton.Click += new EventHandler(copy_imgtoolStripButton_Click);
            pasteToolStripButton.Click += new EventHandler(pasteToolStripButton_Click);
            undotoolStripButton.Click += new EventHandler(undotoolStripButton_Click);
            redotoolStripButton.Click += new EventHandler(redotoolStripButton_Click);
            refrtoolStripButton.Click += new EventHandler(refrtoolStripButton_Click);
            rotate_img_toolStripButton.Click += new EventHandler(rotate_img_toolStripButton_Click);
            as_text_toolStripButton.Click += new EventHandler(as_text_toolStripButton_Click);

            Decrypt();
        }

        void as_text_toolStripButton_Click(object sender, EventArgs e)
        {
            switch (_is_image_data)
            {
                case true:
                    {
                        _is_image_data = false;
                        as_text_toolStripButton.Text = "Отобразить как изображение";
                       Decrypt();
                    }
                    break;
                case false:
                    {
                        _is_image_data = true;
                        as_text_toolStripButton.Text = "Отобразить как текст";
                        Decrypt();
                    }
                    break;
                default:
                    {
                        as_text_toolStripButton.Text = "Отобразить как изображение";
                         _is_image_data = false;
                         Decrypt();
                    }
                    break;
            }
            
        }

        void rotate_img_toolStripButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox.Refresh();
        }

        void refrtoolStripButton_Click(object sender, EventArgs e)
        {
            Decrypt();
        }

        void redotoolStripButton_Click(object sender, EventArgs e)
        {
            textBoxList.ClearUndo();
        }

        void undotoolStripButton_Click(object sender, EventArgs e)
        {
            textBoxList.Undo();
        }

        void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            textBoxList.Paste();
        }

        void copy_textToolStripButton_Click(object sender, EventArgs e)
        {
            if (IsSelectedText())
            {
                textBoxList.Copy();
            }
        }

        void copy_imgtoolStripButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox.Image);
        }

        void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (IsSelectedText())
            {                
                textBoxList.Cut();
            }
        }

        bool IsSelectedText()
        {
            return textBoxList.SelectionLength > 0;
        }

        void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        void FormViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_is_edited && !_is_image_data)
            {
                if (MessageBox.Show("Сохранить изменения в файле?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveChanges();
                }
            }
        }

        /// <summary>
        /// Сохранить все изменения
        /// </summary>
        private void SaveChanges()
        {
            try
            {
                cr.encryt_byte_to_file(PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), Encoding.GetEncoding(comboBoxEnc.Text).GetBytes(textBoxList.Text), _crypt_filename, progressBarSt);
                progressBarSt.Value = 0;
                _is_edited = false;
            }
            catch (Exception ex)
            {
                new CriticalErrors().PrintError("E4", ex.Message + " | " + ex.TargetSite);
            }
        }

        void textBoxList_TextChanged(object sender, EventArgs e)
        {
            _is_edited = true;
        }

        /// <summary>
        /// Загрузить расшифрованное
        /// </summary>
        private void Decrypt()
        {
            try
            {             
                byte[] decr = cr.decrypt_file_to_byte(PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), _crypt_filename, progressBarSt);
                progressBarSt.Value = 0;

                if (decr.Length > 3 && _is_image_data)
                {
                    byte[] fb = new byte[4];
                    for (int i = 0; i < fb.Length; i++)
                    {
                        fb[i] = decr[i];
                    }               

                    switch ((FileMarks.FileTypes)fmr.GetFileType(fb))
                    {
                        case FileMarks.FileTypes.PNG:
                        case FileMarks.FileTypes.GIF:
                        case FileMarks.FileTypes.BMP:
                        case FileMarks.FileTypes.JPG:
                            {
                                as_text_toolStripButton.Text = "Отобразить как текст";
                                this.Text = "Просмотр файлов изображений (" + _decrypt_filename + ")";
                                MemoryStream ms = new MemoryStream(decr, true);
                                pictureBox.Image = Image.FromStream(ms);
                                pictureBox.Dock = DockStyle.Fill;
                                
                                saveToolStripButton.Visible = false;
                                undotoolStripButton.Visible = false;
                                redotoolStripButton.Visible = false;
                                cutToolStripButton.Visible = false;
                                copy_imgtoolStripButton.Visible = true;
                                copy_textToolStripButton.Visible = false;
                                pasteToolStripButton.Visible = false;
                                rotate_img_toolStripButton.Visible = true;

                                pictureBox.Visible = true;
                                comboBoxEnc.Visible = false;
                                textBoxList.Clear();
                                _is_edited = false;
                                _is_image_data = true;
                            }
                            break;
                        default:
                            {
                                as_text_toolStripButton.Text = "Отобразить как изображение";
                                this.Text = "Просмотр текстовых файлов (" + _decrypt_filename + ")";

                                saveToolStripButton.Visible = true;
                                undotoolStripButton.Visible = true;
                                redotoolStripButton.Visible = true;
                                cutToolStripButton.Visible = true;
                                copy_imgtoolStripButton.Visible = false;
                                copy_textToolStripButton.Visible = true;
                                pasteToolStripButton.Visible = true;
                                rotate_img_toolStripButton.Visible = false;

                                pictureBox.Visible = false;
                                comboBoxEnc.Visible = true;

                                pictureBox.Image = null;
                                textBoxList.Text = Encoding.GetEncoding(comboBoxEnc.Text).GetString(decr);
                                _is_edited = false;
                                _is_image_data = false;
                            }
                            break;
                    }
                }
                else
                {
                    as_text_toolStripButton.Text = "Отобразить как изображение";
                    this.Text = "Просмотр текстовых файлов (" + _decrypt_filename + ")";

                    saveToolStripButton.Visible = true;
                    undotoolStripButton.Visible = true;
                    redotoolStripButton.Visible = true;
                    cutToolStripButton.Visible = true;
                    copy_imgtoolStripButton.Visible = false;
                    copy_textToolStripButton.Visible = true;
                    pasteToolStripButton.Visible = true;
                    rotate_img_toolStripButton.Visible = false;

                    pictureBox.Visible = false;
                    comboBoxEnc.Visible = true;

                    pictureBox.Image = null;

                    textBoxList.Text = Encoding.GetEncoding(comboBoxEnc.Text).GetString(decr);
                    _is_edited = false;
                    _is_image_data = false;
                }
            }
            catch (Exception ex)
            {
                new CriticalErrors().PrintError("D4", ex.Message + " | " + ex.TargetSite);
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