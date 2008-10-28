using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Remote_DCrypt.Settings;
using System.IO;
using System.Security.Cryptography;

namespace Remote_DCrypt.Action
{
    public partial class FormAction : Form
    {
        public FormAction()
        {
            InitializeComponent();
        }

        string _src_file_path = string.Empty;
        string _dst_path = string.Empty;

        bool _IsEncrypt = true;

        /// <summary>
        /// Конструктор формы де/шифрования файла
        /// </summary>
        /// <param name="src_file_path">Исходный файл</param>
        /// <param name="dst_file">Получаемый файл</param>
        /// <param name="IsEncrypt"></param>
        public FormAction(string src_file_path, string dst_path, bool IsEncrypt)
        {
            Crypt cr = new Crypt();
            InitializeComponent();

            dst_path = PrefSettings.FixDrivePath(dst_path);

            _src_file_path = src_file_path;
            _dst_path = dst_path;
            _IsEncrypt = IsEncrypt;
        }

        private void FormAction_Shown(object sender, EventArgs e)
        {
            //Заокмментировано, потому что проверка пароля для входа не используется пока
            //if (PrefSettings.pwd == null)
            //{
            //    FormPwd fp = new FormPwd();
            //    if (fp.ShowDialog() == DialogResult.OK)
            //    {
            //        FileTransfer(_src_file_path, _dst_path, _IsEncrypt);
            //    }
            //}
            //else
            //{
            FileTransfer(_src_file_path, _dst_path, _IsEncrypt);
            //}
        }

        private void FileTransfer(string src_file_path, string dst_path, bool isEncrypt)
        {
            Application.DoEvents();
            Crypt cr = new Crypt();
            string dst_file_path;
            string _enc_file_name = string.Empty;
            string _dec_file_name = string.Empty;
            textBox_src_file.Text = src_file_path;

            try
            {
                if (isEncrypt)
                {
                    this.Text = "Шифрование";
                    listBox_log.Items.Add("Шифрование начато...");
                    //EncryptFName - вызов из флат-эксплорера по хорошему
                    _enc_file_name = cr.EncryptFName(Path.GetFileName(src_file_path), PrefSettings.key_fname, PrefSettings.prefix);
                    dst_file_path = Path.Combine(dst_path, _enc_file_name);
                    textBox_dst_file.Text = dst_file_path;

                    if (dst_path.Length < 3)
                    {
                        MessageBox.Show("В эту папку сохранять нельзя");
                    }
                    else
                    {
                        if (File.Exists(dst_file_path))
                        {
                            if (MessageBox.Show("Файл с таким именем существует. Перезаписать?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cr.crypt_file( true, PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), src_file_path, dst_file_path, progressBar_crypt);
                            }
                        }
                        else
                        {
                            cr.crypt_file(true, PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), src_file_path, dst_file_path, progressBar_crypt);
                        }
                    }
                }
                else
                {
                    this.Text = "Дешифрование";
                    listBox_log.Items.Add("Дешифрование начато...");
                    _dec_file_name = cr.DecryptFName(Path.GetFileName(src_file_path), PrefSettings.key_fname, PrefSettings.prefix);
                    dst_file_path = Path.Combine(dst_path, _dec_file_name);
                    textBox_dst_file.Text = dst_file_path;

                    if (dst_path.Length < 3)
                    {
                        MessageBox.Show("В эту папку сохранять нельзя");
                    }
                    else
                    {
                        if (File.Exists(dst_file_path))
                        {
                            if (MessageBox.Show("Файл с таким именем существует. Перезаписать?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cr.crypt_file(false,PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), src_file_path, dst_file_path, progressBar_crypt);
                            }
                        }
                        else
                        {
                            cr.crypt_file(false, PrefSettings.pwd_file_enc, int.Parse(PrefSettings.key_size), src_file_path, dst_file_path, progressBar_crypt);
                        }
                    }
                    
                }
                listBox_log.Items.Add("OK");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                listBox_log.Items.Add(ex.Message);
                listBox_log.Items.Add("ERROR...");
            }
            finally
            {
                button_ok.Enabled = true;
            }
        }



        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void FormAction_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!button_ok.Enabled)
            //{

            //}
        }

    }
}