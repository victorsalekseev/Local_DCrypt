using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Remote_DCrypt.Settings;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using Local_DCrypt;
using System.Reflection;
using Necode.Crypt.Action;
using Netcode.Messages;
using Netcode.Search;
using System.Collections;
using Netcode.Crypt;

namespace Remote_DCrypt
{
    public partial class FormMain : Form
    {
        NIcon nic;
        public FormMain()
        {
            InitializeComponent();

            flatFileExplorerEnc.pwd_key = PrefSettings.key_fname;
            flatFileExplorerDec.pwd_key = PrefSettings.key_fname;
            flatFileExplorerDec.SendObject += new Netcode.Controls.FlatFileExplorer.OnSendObject(flatFileExplorerDec_SendFileName);
            flatFileExplorerEnc.SendObject += new Netcode.Controls.FlatFileExplorer.OnSendObject(flatFileExplorerEnc_SendFileName);
            настройкиToolStripMenuItem.Click += new EventHandler(настройкиToolStripMenuItem_Click);
            button_to_remote.Click+=new EventHandler(button_to_remote_Click);
            button_from_remote.Click+=new EventHandler(button_from_remote_Click);
            this.Shown += new EventHandler(FormMain_Shown);
            выходToolStripMenuItem_2.Click += new EventHandler(выходToolStripMenuItem_2_Click);
            менеджерКонтактовToolStripMenuItem.Click += new EventHandler(менеджерКонтактовToolStripMenuItem_Click);
            менеджерКонтактовToolStripMenuItem1.Click += new EventHandler(менеджерКонтактовToolStripMenuItem_Click);
            файловыйКрипторToolStripMenuItem.Click += new EventHandler(файловыйКрипторToolStripMenuItem_Click);
            Text += Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            оПрограммеToolStripMenuItem.Click += new EventHandler(оПрограммеToolStripMenuItem_Click);
        }

        void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormLicensing frm_l = new FormLicensing(true))
            {
                frm_l.ShowDialog();
            }
        }

        void файловыйКрипторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nic.ChangeVisiblePosition();
        }

        void менеджерКонтактовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowContactManager();
        }

        private static void ShowContactManager()
        {
            FormCM frm_cm = new FormCM();
            frm_cm.Show();
        }

        void выходToolStripMenuItem_2_Click(object sender, EventArgs e)
        {
            nic.CloseApp();
        }

        void FormMain_Shown(object sender, EventArgs e)
        {
            nic = new NIcon(contextMenuStrip, this);
            nic.IconImg = global::Local_DCrypt.Properties.Resources.indx;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Загрузка настроек.
            if (!File.Exists(ManageSetting.path_to_set_file) || !CryptoConnection.InitState)
            {
                Application.Exit();
            }
            if (!string.IsNullOrEmpty(PrefSettings.left_init_dir))
            {
                flatFileExplorerDec.GetDirs(PrefSettings.left_init_dir);
            }
            if (!string.IsNullOrEmpty(PrefSettings.right_init_dir))
            {
                flatFileExplorerEnc.GetDirs(PrefSettings.right_init_dir);
            }
        }
        #region --- дешифрование ---
        void flatFileExplorerEnc_SendFileName(string full_name, string object_name, string object_type)
        {
            switch (object_type)
            {
                case "Directory":
                    {
                        Search sr = new Search();
                        sr.FindFile += new Search.OnFindFile(sr_FindEncryptedFile);
                        sr.MakeError += new Search.OnMakeError(sr_MakeError);
                        Hashtable ht = new Hashtable();
                        ht.Add(full_name, object_name);
                        sr.ScanFiles(ht);
                    }
                    break;
                case "File":
                    {
                        DecryptSelectedObject(full_name);
                    }
                    break;
                default:

                    break;
            }
        }

        void sr_MakeError(string Error)
        {
            new CriticalErrors().PrintError("S3", "Ошибка поиска: " + Error);
        }

        void sr_FindEncryptedFile(FileInfo nm)
        {
            DecryptSelectedObject(nm.FullName); ;
        }
        
        private void DecryptSelectedObject(string full_name)
        {
            string full_path_dir = Path.GetDirectoryName(full_name);
            string rel = full_path_dir.Replace(flatFileExplorerEnc.CurrLocalPath, "");
            if (rel.Length > 0)
            {
                if (rel[0] == Path.DirectorySeparatorChar)
                {
                    rel = rel.Substring(1);
                }
            }
            rel = Path.Combine(flatFileExplorerDec.CurrLocalPath, rel);

            //TODO PostDecrypting
            FormAction fa = new FormAction(full_name, rel, string.Empty, string.Empty, false, PrefSettings.prefix, PrefSettings.pwd_file_enc, Convert.ToUInt16(PrefSettings.key_size), PrefSettings.key_fname);
            fa.ShowDialog();
            //flatFileExplorerDec.RefreshExp();
            flatFileExplorerDec.RefreshExp();
            ActiveControl = flatFileExplorerDec;
        }
        #endregion

        #region --- шифрование ---
        void flatFileExplorerDec_SendFileName(string full_name, string object_name, string object_type)
        {
            switch (object_type)
            {
                case "Directory":
                    {
                        Search sr = new Search();
                        sr.FindFile += new Search.OnFindFile(sr_FindDecryptedFile);
                        sr.MakeError += new Search.OnMakeError(sr_MakeError);
                        Hashtable ht = new Hashtable();
                        ht.Add(full_name, object_name);
                        sr.ScanFiles(ht);
                    }
                    break;
                case "File":
                    {
                        EncryptSelectedObject(full_name);
                    }
                    break;
                default:

                    break;
            }
        }

        void sr_FindDecryptedFile(FileInfo nm)
        {
            EncryptSelectedObject(nm.FullName);
        }


        private void EncryptSelectedObject(string full_name)
        {
            //TODO PostEncrypting
            string full_path_dir = Path.GetDirectoryName(full_name);
            string rel = full_path_dir.Replace(flatFileExplorerDec.CurrLocalPath, "");
            if (rel.Length > 0)
            {
                if (rel[0] == Path.DirectorySeparatorChar)
                {
                    rel=rel.Substring(1);
                }
            }
            rel = Path.Combine(flatFileExplorerEnc.CurrLocalPath, rel);

            FormAction fa = new FormAction(full_name, rel, string.Empty, string.Empty, true, PrefSettings.prefix, PrefSettings.pwd_file_enc, Convert.ToUInt16(PrefSettings.key_size), PrefSettings.key_fname);
            fa.ShowDialog();
            flatFileExplorerEnc.RefreshExp();
            //flatFileExplorerDec.RefreshExp();
            ActiveControl = flatFileExplorerEnc;
        }
        #endregion 

        private void button_to_remote_Click(object sender, EventArgs e)
        {
            flatFileExplorerDec.GetSelectedFileName();
        }

        private void button_from_remote_Click(object sender, EventArgs e)
        {
            flatFileExplorerEnc.GetSelectedFileName();
        }

        void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormSettings frm_fs = new FormSettings())
            {
                if (frm_fs.DialogResult != DialogResult.Cancel)
                {
                    //TODO обновить список
                    frm_fs.ShowDialog();
                    flatFileExplorerEnc.pwd_key = PrefSettings.key_fname;
                    flatFileExplorerDec.pwd_key = PrefSettings.key_fname;
                    //FormCM.default_filename = PrefSettings.def_name_fcont;
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nic.CloseApp();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CryptoConnection.Kill();
        }
    }
}