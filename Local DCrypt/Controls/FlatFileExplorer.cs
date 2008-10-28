using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;
using Remote_DCrypt;
using Remote_DCrypt.Controls;

namespace Netcode.Controls
{
    public partial class FlatFileExplorer : UserControl
    {
        public delegate void OnSendFileName(string full_path, string file_name);
        public event OnSendFileName SendFileName;

        private string init_expl_dir = string.Empty;

        Crypt cn = new Crypt();

        public FlatFileExplorer()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            listView_Local.DoubleClick += new EventHandler(listView_Local_DoubleClick);
            listView_Local.KeyDown += new KeyEventHandler(listView_Local_KeyDown);
            listView_Local.SelectedIndexChanged += new EventHandler(listView_Local_SelectedIndexChanged);
            GetDirs(string.Empty, listView_Local);
            if (listView_Local.Items.Count > 0)
            {
                listView_Local.Items[0].Selected = true;
            }

            this.çàãğóçèòüToolStripMenuItem.Click += new System.EventHandler(this.çàãğóçèòüToolStripMenuItem_Click);
            this.contextMenuStrip_local.Opening += new CancelEventHandler(contextMenuStrip_local_Opening);
            this.îòêğûòüToolStripMenuItem.Click += new System.EventHandler(this.îòêğûòüToolStripMenuItem_Click);
            this.èçìåíèòüToolStripMenuItem1.Click += new System.EventHandler(this.èçìåíèòüToolStripMenuItem1_Click);
            this.óäàëèòüToolStripMenuItem.Click += new System.EventHandler(this.óäàëèòüToolStripMenuItem_Click);
            this.îáíîâèòüToolStripMenuItem.Click += new EventHandler(îáíîâèòüToolStripMenuItem_Click);
            this.îòêğûòüÂíóòğèToolStripMenuItem.Click += new EventHandler(îòêğûòüÂíóòğèToolStripMenuItem_Click);
            this.ñîçäàòüÏàïêóToolStripMenuItem.Click += new EventHandler(ñîçäàòüÏàïêóToolStripMenuItem_Click);
            ïåğåèìåíîâàòüToolStripMenuItem.Click += new EventHandler(ïåğåèìåíîâàòüToolStripMenuItem_Click);
            comboBox_drive.SelectedIndexChanged += new EventHandler(comboBox_drive_SelectedIndexChanged);
            this.ActiveControl = listView_Local;
        }

        void comboBox_drive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drive = comboBox_drive.Text.Remove(comboBox_drive.Text.IndexOf(Convert.ToChar("\\")));
            textBoxPath.Text = drive;
            _CurrLocalPath = drive;
            GetDirs(drive, listView_Local);
        }

        private string _pwd_key = string.Empty;
        public string pwd_key
        {
            get { return _pwd_key; }
            set { _pwd_key = value; }
        }

        private bool _isEncryptedNames = false;
        public bool isEncryptedNames
        {
            get {
                return _isEncryptedNames;
            }
            set {
                _isEncryptedNames = value; }
        }

        public string NameFileExplorer
        {
            get { return textBox_local_name.Text; }
            set { textBox_local_name.Text = value; }
        }

        private string _CurrLocalPath = string.Empty;
        public string CurrLocalPath
        {
            get { return _CurrLocalPath; }
            set { _CurrLocalPath = value; }
        }

        private  Button _button_to_remote = new Button();
        public  Button button_to_remote
        {
            get { return _button_to_remote; }
            set { 
                _button_to_remote = value;
                _button_to_remote.Enabled = false;
            }
        }

        /// <summary>
        /// Ëîãèêà ğàáîòû ïğè âûáîğå øèôğîâàííûõ/íåøèôğîâàííûõ ôàéëîâ
        /// </summary>
        private void CryptoBtnText()
        {
            if (_isEncryptedNames)
            {
                çàãğóçèòüToolStripMenuItem.Text = "Ğàñøèôğîâàòü";
                çàãğóçèòüToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.decr;
                îòêğûòüÂíóòğèToolStripMenuItem.Visible = true;

                if (isSelectedLV(listView_Local))
                {
                    if (!listView_Local.SelectedItems[0].Text.Contains(Crypt.not_crypted_mess) && listView_Local.SelectedItems[0].Name == "File")
                    {
                        îòêğûòüÂíóòğèToolStripMenuItem.Enabled = true;
                        îòêğûòüToolStripMenuItem.Enabled = false;
                        èçìåíèòüToolStripMenuItem1.Enabled = false;
                    }
                    else
                    {
                        îòêğûòüÂíóòğèToolStripMenuItem.Enabled = false;
                        îòêğûòüToolStripMenuItem.Enabled = true;
                        èçìåíèòüToolStripMenuItem1.Enabled = true;
                    }

                    if (listView_Local.SelectedItems[0].Name == "Directory" || listView_Local.SelectedItems[0].Name == "Drive")
                    {
                        èçìåíèòüToolStripMenuItem1.Enabled = false;
                    }
                }
            }
            else
            {
                çàãğóçèòüToolStripMenuItem.Text = "Çàøèôğîâàòü";
                çàãğóçèòüToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.encr;
                îòêğûòüÂíóòğèToolStripMenuItem.Visible = false;
            }
        }

        public void GetDirs(string init_dir)
        {
            try
            {
                if (Directory.Exists(init_dir))
                {
                    if (init_dir.Length == 3 && init_dir[2] == Convert.ToChar("\\"))
                    {
                        init_dir= init_dir.Remove(2);
                    }
                    GetDirs(init_dir, listView_Local);
                    textBoxPath.Text = init_dir;
                    _CurrLocalPath = init_dir;
                }
                else
                {
                    GetDirs(string.Empty, listView_Local);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Îøèáêà: "+ex.Message, "Error");
            }
        }

        private void AddDrivesInCb(ComboBox cb, string drive, string d_name)
        {
            int i = cb.Items.Add(d_name);
        }

        private void GetDirs(string init_dir, ListView l_view)
        {
            l_view.Items.Clear();

            if (init_dir.Length == 0/* || init_dir.Length == 2*/)
            {
                comboBox_drive.Items.Clear();
                DriveInfo[] dinf = DriveInfo.GetDrives();
                foreach (DriveInfo dic in dinf)
                {
                    string vol_label = string.Empty;
                    string disk_litera = string.Empty;
                    string disk_avial_free_space = string.Empty;
                    string disk_total_size = string.Empty;

                    if (dic.Name == "A:\\")
                    {
                        disk_litera = "A:\\";
                        vol_label = " (Äèñêîâîä ãèáêèõ äèñêîâ)";
                    }
                    else
                    {
                        disk_litera = dic.Name;
                        if (dic.IsReady)
                        {
                            vol_label = "  (" + dic.VolumeLabel + ")";
                            disk_total_size = "Ğàçìåğ:    " + print_file_size(dic.TotalSize) + Environment.NewLine;
                            disk_total_size += "Çàíÿòî:     " + print_file_size(dic.TotalSize - dic.AvailableFreeSpace) + Environment.NewLine;
                            disk_avial_free_space = "Äîñòóïíî: " + print_file_size(dic.AvailableFreeSpace);
                        }
                    }

                    ListViewItem li = new ListViewItem();
                    li.Name = "Drive";
                    li.Text = disk_litera + vol_label;
                    li.ToolTipText = disk_total_size + disk_avial_free_space;
                    li.Tag = Path.Combine(init_dir, dic.Name.Remove(dic.Name.LastIndexOf("\\")));
                    li.Group = l_view.Groups["listViewGroupDrives"];
                    li.ImageIndex = 0;
                    li.SubItems.Add(dic.DriveType.ToString());
                    l_view.Items.Add(li);
                    AddDrivesInCb(comboBox_drive, li.Tag.ToString(), li.Text);
                }
                init_expl_dir = string.Empty;
                l_view.ShowItemToolTips = true;
                ñîçäàòüÏàïêóToolStripMenuItem.Enabled = false;
            }
            else
            {
                ñîçäàòüÏàïêóToolStripMenuItem.Enabled = true;
                l_view.ShowItemToolTips = false;
                ListViewItem liUp = new ListViewItem();
                liUp.Name = init_dir;
                liUp.Text = "..";

                if (init_dir.Length > 2)
                {
                    liUp.Tag = init_dir.Remove(init_dir.LastIndexOf("\\"));
                }
                else
                {
                    liUp.Tag = string.Empty;
                }
                liUp.Name = "Directory";
                liUp.Group = l_view.Groups["listViewGroupFolders"];
                liUp.ImageIndex = 1;
                l_view.Items.Add(liUp);

                init_dir = PrefSettings.FixDrivePath(init_dir);

                DirectoryInfo di = new DirectoryInfo(init_dir);
                try
                {
                    foreach (DirectoryInfo dic in di.GetDirectories())
                    {
                        ListViewItem li = new ListViewItem();
                        li.Name = "Directory";
                        string FolderName = dic.Name;
                        //Ğàñøèôğîâêà íóæíà? Ïğîâåğÿåì!
                        if (_isEncryptedNames)
                        {
                            FolderName = cn.DecryptFName(FolderName, _pwd_key, PrefSettings.prefix);
                        }
                        li.Text = FolderName;
                        li.Tag = Path.Combine(init_dir, dic.Name);
                        init_expl_dir = init_dir;
                        li.Group = l_view.Groups["listViewGroupFolders"];

                        if (!FolderName.Contains(Crypt.not_crypted_mess))
                        {
                            li.ImageIndex = 1;
                        }
                        else
                        {
                            li.ImageIndex = 2;
                        }
                        l_view.Items.Add(li);
                    }

                    foreach (FileInfo dic in di.GetFiles())
                    {
                        ListViewItem li = new ListViewItem();
                        li.Name = "File";
                        string FileName = dic.Name;
                        //Ğàñøèôğîâêà íóæíà? Ïğîâåğÿåì!
                        if (_isEncryptedNames)
                        {
                            FileName = cn.DecryptFName(FileName, _pwd_key, PrefSettings.prefix);
                        }
                        li.Text = FileName;
                        li.Tag = Path.Combine(init_dir, dic.Name);
                        li.Group = l_view.Groups["listViewGroupFiles"];
                        if (!FileName.Contains(Crypt.not_crypted_mess))
                        {
                            li.ImageIndex = 3;
                        }
                        else
                        {
                            li.ImageIndex = 4;
                        }
                        li.SubItems.Add(print_file_size(dic.Length));
                        l_view.Items.Add(li);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    //i.e.: System Volyme Information
                }
                catch (IOException)
                {
                    //i.e.: File is Folder
                }
                catch (SecurityException)
                {
                }
                catch (ArgumentNullException)
                {
                }
            }
        }

        private string print_file_size(long size)
        {
            string ret = string.Empty;
            if (size < 10240)
            {
                return size.ToString() + " Áàéò";
            }
            if (size < 1048576)
            {
                return Math.Floor((double)size / 1024) + " êÁàéò";
            }

            if (size < 737418240)
            {
                return string.Format("{0:0.00}", (double)size / 1048576) + " ÌÁàéò";
            }
            else
            {
                return string.Format("{0:0.00}", ((double)size / 1073741824)) + " ÃÁàéò";
            }
        }

        private void listView_Local_DoubleClick(object sender, EventArgs e)
        {
            EnterToPath();
        }

        void listView_Local_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterToPath();
            }
        }

        private void EnterToPath()
        {
            if (isSelectedLV(listView_Local))
            {
                string path = listView_Local.SelectedItems[0].Tag.ToString();
                switch (listView_Local.SelectedItems[0].Name)
                {
                    case "Directory":
                        {

                            textBoxPath.Text = path;
                            _CurrLocalPath = path;
                            GetDirs(path, listView_Local);
                        }
                        break;

                    case "File":
                        {
                            GetFileName(listView_Local);
                        }
                        break;

                    case "Drive":
                        {
                            textBoxPath.Text = path;
                            _CurrLocalPath = path;
                            GetDirs(path, listView_Local);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void listView_Local_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enabled_file_contr(listView_Local, _button_to_remote, new ToolStripMenuItem[] { çàãğóçèòüToolStripMenuItem, îòêğûòüToolStripMenuItem, èçìåíèòüToolStripMenuItem1, óäàëèòüToolStripMenuItem, îòêğûòüÂíóòğèToolStripMenuItem });
            //Enabled_folder_contr(listView_Local, new ToolStripMenuItem[] { óäàëèòüÏàïêóToolStripMenuItem });
            Enabled_faf_contr(listView_Local, new ToolStripMenuItem[] { ïåğåèìåíîâàòüToolStripMenuItem, óäàëèòüToolStripMenuItem });
        }

        private bool isSelectedLV(ListView lv)
        {
            if (lv.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Enabled_file_contr(ListView li, Button btn, ToolStripMenuItem[] tsm)
        {
            if (isSelectedLV(li))
            {
                string file_name = string.Empty;
                file_name = li.SelectedItems[0].Name;

                switch (file_name)
                {
                    case "File":
                        {
                            btn.Enabled = true;
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = true;
                            }

                        }
                        break;
                    default:
                        {
                            btn.Enabled = false;
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = false;
                            }
                        }
                        break;
                }
            }
            else
            {
                btn.Enabled = false;
                foreach (ToolStripMenuItem t in tsm)
                {
                    t.Enabled = false;
                }
            }
        }

        private void Enabled_faf_contr(ListView li, ToolStripMenuItem[] tsm)
        {
            if (isSelectedLV(li))
            {
                string file_name = string.Empty;
                file_name = li.SelectedItems[0].Name;

                switch (file_name)
                {
                    case "File":
                        {
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = true;
                            }

                        }
                        break;
                    case "Directory":
                        {
                            if (li.SelectedItems[0].Text != "..")
                            {
                                foreach (ToolStripMenuItem t in tsm)
                                {
                                    t.Enabled = true;
                                }
                            }
                        }
                        break;
                    default:
                        {
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = false;
                            }
                        }
                        break;
                }
            }
            else
            {
                foreach (ToolStripMenuItem t in tsm)
                {
                    t.Enabled = false;
                }
            }
        }

        private void Enabled_folder_contr(ListView li, ToolStripMenuItem[] tsm)
        {
            if (isSelectedLV(li))
            {
                string file_name = string.Empty;
                file_name = li.SelectedItems[0].Name;

                switch (file_name)
                {
                    case "Directory":
                        {
                            if (li.SelectedItems[0].Text != "..")
                            {
                                foreach (ToolStripMenuItem t in tsm)
                                {
                                    t.Enabled = true;
                                }
                            }
                            else
                            {
                                foreach (ToolStripMenuItem t in tsm)
                                {
                                    t.Enabled = false;
                                }
                            }
                        }
                        break;
                    default:
                        {
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = false;
                            }
                        }
                        break;
                }
            }
            else
            {
                foreach (ToolStripMenuItem t in tsm)
                {
                    t.Enabled = false;
                }
            }
        }

        private void GetFileName(ListView li)
        {
            if (isSelectedLV(li))
            {
                string file_name = li.SelectedItems[0].Text;
                string full_path = li.SelectedItems[0].Tag.ToString();

                if (isSelectedLV(li))
                {
                    //TODO ïåğåäà÷à äàííûõ äëÿ øèôğîâàíèÿ
                    if (SendFileName != null)
                    {
                        SendFileName(full_path, file_name);
                    }
                }
            }
            else
            {
                button_to_remote.Enabled = false;
            }
        }

        /// <summary>
        /// Îòïğàâèòü íà øèôğîâêó
        /// </summary>
        public void GetSelectedFileName()
        {
            çàãğóçèòüToolStripMenuItem_Click(this, null);
        }

        /// <summary>
        /// Îáíîâèòü ïàïêó
        /// </summary>
        public void RefreshExp()
        {
            _refresh_exp(0);
        }

        /// <summary>
        /// Îáíîâèòü ïàïêó (óäàëåíèå)
        /// </summary>
        public void RefreshExp(int pos)
        {
            _refresh_exp(pos);
        }

        private void _refresh_exp(int pos)
        {
            if (isSelectedLV(listView_Local) && pos == 0 && listView_Local.Items.Count > 0)
            {
                pos = listView_Local.SelectedItems[0].Index;
            }
            GetDirs(CurrLocalPath, listView_Local);
            if (listView_Local.Items.Count > pos && listView_Local.Items.Count>0)
            {
                listView_Local.Items[pos].Selected = true;//-1 èç-çà ".."
            }
        }

        /// <summary>
        /// Î÷èñòèòü ñïèñîê
        /// </summary>
        public void ClearItems()
        {
            listView_Local.Items.Clear();
        }

        #region ------------------ ÊÍÎÏÊÈ ÌÅÍŞ ------------------

        private void çàãğóçèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFileName(listView_Local);
        }

        void contextMenuStrip_local_Opening(object sender, CancelEventArgs e)
        {
            CryptoBtnText();
        }

        void îáíîâèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshExp();
        }

        private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                try
                {
                    System.Diagnostics.Process.Start(listView_Local.SelectedItems[0].Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Îøèáêà çàïóñêà: " + ex.Message);
                }
            }
        }

        private void èçìåíèòüToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "notepad.exe";
                p.StartInfo.Arguments = listView_Local.SelectedItems[0].Tag.ToString();
                p.Start();
            }
        }

        private void óäàëèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                try
                {
                    switch (listView_Local.SelectedItems[0].Name)
                    {
                        case "File":
                            {
                                if (MessageBox.Show("Óäàëèòü ôàéë" + Environment.NewLine + listView_Local.SelectedItems[0].Text, "Âíèìàíèå", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    File.Delete(listView_Local.SelectedItems[0].Tag.ToString());
                                }
                            }
                            break;
                        case "Directory":
                            {
                                if (MessageBox.Show("Óäàëèòü ïàïêó" + Environment.NewLine + listView_Local.SelectedItems[0].Text, "Âíèìàíèå", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Directory.Delete(listView_Local.SelectedItems[0].Tag.ToString(), true);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    RefreshExp(listView_Local.SelectedItems[0].Index - 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Îøèáêà");
                }
            }
        }

        void îòêğûòüÂíóòğèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                using (FormViewer frm_v = new FormViewer(listView_Local.SelectedItems[0].Tag.ToString()))
                {
                    frm_v.ShowDialog();
                }
            }
        }

        void ñîçäàòüÏàïêóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormCFolder frm_cf = new FormCFolder("Ñîçàòü ïàïêó"))
                {
                    if (isSelectedLV(listView_Local))
                    {
                        string view_tree_name = listView_Local.SelectedItems[0].Text;
                        if (view_tree_name.Contains(Crypt.not_crypted_mess))
                        {
                            view_tree_name = view_tree_name.Remove(view_tree_name.IndexOf(Crypt.not_crypted_mess)).Trim();
                        }
                        frm_cf.InputText = view_tree_name;
                    }
                    if (frm_cf.ShowDialog() == DialogResult.OK)
                    {
                        string path_d = CurrLocalPath;
                        path_d = PrefSettings.FixDrivePath(path_d);
                        Directory.CreateDirectory(Path.Combine(path_d, frm_cf.InputText));
                    }
                }
                RefreshExp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Îøèáêà");
            }
        }

        void ïåğåèìåíîâàòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string real_fs_full_name = listView_Local.SelectedItems[0].Tag.ToString();
                string view_tree_name = listView_Local.SelectedItems[0].Text;
                using (FormCFolder frm_cf = new FormCFolder("Ïåğåèìåíîâàòü " + view_tree_name))
                {
                    if (view_tree_name.Contains(Crypt.not_crypted_mess))
                    {
                        view_tree_name = view_tree_name.Remove(view_tree_name.IndexOf(Crypt.not_crypted_mess)).Trim();
                    }
                    frm_cf.InputText = view_tree_name;

                    if (frm_cf.ShowDialog() == DialogResult.OK)
                    {
                        string path_d = CurrLocalPath;
                        path_d = PrefSettings.FixDrivePath(path_d);

                        switch (listView_Local.SelectedItems[0].Name)
                        {
                            case "File":
                                {
                                    File.Move(real_fs_full_name, Path.Combine(path_d, frm_cf.InputText));
                                }
                                break;
                            case "Directory":
                                {
                                    Directory.Move(real_fs_full_name, Path.Combine(path_d, frm_cf.InputText));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                RefreshExp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Îøèáêà");
            }
        }
        #endregion ------------------ ÊÍÎÏÊÈ ÌÅÍŞ ------------------

    }
}
