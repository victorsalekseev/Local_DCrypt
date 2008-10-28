using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;

// вот о чём речь
[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify = "HKEY_CURRENT_USER")]
namespace Remote_DCrypt.Settings
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            if (File.Exists(ManageSetting.path_to_set_file))
            {
                if (MessageBox.Show("Перед внесением новых настроек проверьте, есть ли резервная копия файла." + Environment.NewLine + "Начать просмотр настроек?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        Options o = new Options();

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (Crypt.CheckKeyFNameLen(textBox_fnamekey.Text))
            {
                SaveFromControls();
                ManageSetting.CreateSettings(o);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            CryptoConnection.Kill();
            //TODO Заглушка: аутентификация только с клавы
            comboBox_use_auth_key.SelectedIndex = 0;
            if (File.Exists(ManageSetting.path_to_set_file))
            {
                ManageSetting.LoadSettings(ref o);
            }
            else
            {
                o.key_fname = Crypt.default_key;//50;
                o.left_init_dir = @"";
                o.right_init_dir = @"";
                o.prefix = "0";
                o.key_size = "256";
                o.pwd_file_enc = Crypt.default_key;
                o.def_name_fcont = "Contacts.cr";
                //o.pwd = "password";
                //ManageSetting.CreateSettings(o);
            }
            LoadToControls();
        }

        private void LoadToControls()
        {
            textBox_fnamekey.Text = o.key_fname;
            textBoxSelectFolderLeft.InputText = o.left_init_dir;
            textBoxSelectFolderRight.InputText = o.right_init_dir;
            textBox_prefix.Text = o.prefix;
            comboBox_key_size.Text = o.key_size;
            textBox_pwd.Text = o.pwd_file_enc;
            checkBox_shell.Checked = GetShellExCheck();
            textBox_fcont.Text = o.def_name_fcont;
        }

        private void SaveFromControls()
        {
            o.key_fname = textBox_fnamekey.Text;
            o.left_init_dir = textBoxSelectFolderLeft.InputText;
            o.right_init_dir = textBoxSelectFolderRight.InputText;
            o.prefix = textBox_prefix.Text;
            o.key_size = comboBox_key_size.Text;
            o.pwd_file_enc = textBox_pwd.Text;
            SetShellEx(checkBox_shell.Checked);
            o.def_name_fcont = textBox_fcont.Text;
        }

        private bool GetShellExCheck()
        {
            string somename = Application.ProductName;
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.OpenSubKey(@"Software\Classes\*\shell\" + somename + @"\command");
            if (regKey != null)
            {
                try
                {
                    if (code_for_shell_exec() == regKey.GetValue("").ToString())
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void SetShellEx(bool save)
        {
            string somename = Application.ProductName;
            if (save)
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.CreateSubKey(@"Software\Classes\*\shell\" + somename + @"\command");
                regKey.SetValue("", (object)code_for_shell_exec());
            }
            else
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey(@"Software\Classes\*\shell", true);//\somename\command", true);
                if (regKey != null)
                {
                    try
                    {
                        regKey.DeleteSubKeyTree(somename);
                    }
                    catch
                    {}
                }
            }
        }

        private string code_for_shell_exec()
        {
            return Application.ExecutablePath + " \"" + "%1" + "\"";
        }

        private void textBox_fnamekey_TextChanged(object sender, EventArgs e)
        {
            textBox_count.Text = textBox_fnamekey.Text.Length.ToString();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            CryptoConnection.Init();
        }

        private void label_msg_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_key_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            int key_err = 256;
            if (int.TryParse(comboBox_key_size.Text, out key_err))
            {
                comboBox_key_size.SelectedText = key_err.ToString();
            }
        }

    }
}