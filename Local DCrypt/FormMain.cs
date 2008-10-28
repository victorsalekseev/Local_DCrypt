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
using Remote_DCrypt.Action;
using System.Text.RegularExpressions;
using Local_DCrypt;
using System.Reflection;

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
            flatFileExplorerDec.SendFileName += new Netcode.Controls.FlatFileExplorer.OnSendFileName(flatFileExplorerDec_SendFileName);
            flatFileExplorerEnc.SendFileName += new Netcode.Controls.FlatFileExplorer.OnSendFileName(flatFileExplorerEnc_SendFileName);
            настройкиToolStripMenuItem.Click += new EventHandler(настройкиToolStripMenuItem_Click);
            button_to_remote.Click+=new EventHandler(button_to_remote_Click);
            button_from_remote.Click+=new EventHandler(button_from_remote_Click);
            this.Shown += new EventHandler(FormMain_Shown);
            выходToolStripMenuItem_2.Click += new EventHandler(выходToolStripMenuItem_2_Click);
            менеджерКонтактовToolStripMenuItem.Click += new EventHandler(менеджерКонтактовToolStripMenuItem_Click);
            менеджерКонтактовToolStripMenuItem1.Click += new EventHandler(менеджерКонтактовToolStripMenuItem_Click);
            файловыйКрипторToolStripMenuItem.Click += new EventHandler(файловыйКрипторToolStripMenuItem_Click);
            Text += Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
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

        void flatFileExplorerEnc_SendFileName(string full_path, string file_name)
        {
            //TODO PostDecrypting
            FormAction fa = new FormAction(full_path, flatFileExplorerDec.CurrLocalPath, false);
            fa.ShowDialog();
            //flatFileExplorerDec.RefreshExp();
            flatFileExplorerDec.RefreshExp();
            ActiveControl = flatFileExplorerDec;
        }

        void flatFileExplorerDec_SendFileName(string full_path, string file_name)
        {
            //TODO PostEncrypting
            FormAction fa = new FormAction(full_path, flatFileExplorerEnc.CurrLocalPath, true);
            fa.ShowDialog();
            flatFileExplorerEnc.RefreshExp();
            //flatFileExplorerDec.RefreshExp();
            ActiveControl = flatFileExplorerEnc;
        }

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