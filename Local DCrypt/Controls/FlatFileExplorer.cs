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
using Netcode.Crypt;
using System.Diagnostics;
using Netcode.Messages;
using Netcode.Calc;

namespace Netcode.Controls
{
    public partial class FlatFileExplorer : UserControl
    {
        /// <summary>
        /// �������� ������ ��� ���������� ��������
        /// </summary>
        /// <param name="full_name">������ ���� �� �������</param>
        /// <param name="object_name">��� �������</param>
        /// <param name="object_type">��� ������� (Drive, File, Directory)</param>
        public delegate void OnSendObject(string full_name, string object_name, string object_type);
        public event OnSendObject SendObject;

        private string init_expl_dir = string.Empty;

        FileCrypt cn = new FileCrypt();

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

            this.���������ToolStripMenuItem.Click += new System.EventHandler(this.���������ToolStripMenuItem_Click);
            this.contextMenuStrip_local.Opening += new CancelEventHandler(contextMenuStrip_local_Opening);
            this.�������ToolStripMenuItem.Click += new System.EventHandler(this.�������ToolStripMenuItem_Click);
            this.��������ToolStripMenuItem1.Click += new System.EventHandler(this.��������ToolStripMenuItem1_Click);
            this.�������ToolStripMenuItem.Click += new System.EventHandler(this.�������ToolStripMenuItem_Click);
            this.��������ToolStripMenuItem.Click += new EventHandler(��������ToolStripMenuItem_Click);
            this.�������������ToolStripMenuItem.Click += new EventHandler(�������������ToolStripMenuItem_Click);
            this.������������ToolStripMenuItem.Click += new EventHandler(������������ToolStripMenuItem_Click);
            �������������ToolStripMenuItem.Click += new EventHandler(�������������ToolStripMenuItem_Click);
            ������������ToolStripMenuItem.Click += new EventHandler(������������ToolStripMenuItem_Click);
            comboBox_drive.SelectedIndexChanged += new EventHandler(comboBox_drive_SelectedIndexChanged);
            textBoxPath.Click += new EventHandler(textBoxPath_Click);
            textBoxPath.TextChanged += new EventHandler(textBoxPath_TextChanged);
            this.ActiveControl = listView_Local;
        }


        void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    foreach (ListViewItem lvi in listView_Local.Items)
                    {
                        sw.WriteLine(lvi.Text+" -<>- "+lvi.Tag.ToString());
                    }
                    sw.Close();
                }
            }
        }

        void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPath.Text))
            {
                textBoxPath.Enabled = false;
            }
            else
            {
                textBoxPath.Enabled = true;
            }
        }
        void textBoxPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(textBoxPath.Text))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo("explorer.exe", textBoxPath.Text);
                    p.Start();
                }
                else
                {
                    new HauptMessages().PrintMessage("S1", "����������� ���������� �����������.");
                }
            }
            catch (Exception ex)
            {
                new CriticalErrors().PrintError("S1", ex.Message + " | " + ex.TargetSite);
            }
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
        /// ������ ������ ��� ������ �����������/������������� ������
        /// </summary>
        private void CryptoBtnText()
        {
            if (_isEncryptedNames)
            {
                ���������ToolStripMenuItem.Text = "������������";
                ���������ToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.decr;
                �������������ToolStripMenuItem.Visible = true;

                if (isSelectedLV(listView_Local))
                {
                    if (!listView_Local.SelectedItems[0].Text.Contains(FileCrypt.not_crypted_mess) && listView_Local.SelectedItems[0].Name == "File")
                    {
                        �������������ToolStripMenuItem.Enabled = true;
                        �������ToolStripMenuItem.Enabled = false;
                        ��������ToolStripMenuItem1.Enabled = false;
                    }
                    else
                    {
                        �������������ToolStripMenuItem.Enabled = false;
                        �������ToolStripMenuItem.Enabled = true;
                        ��������ToolStripMenuItem1.Enabled = true;
                    }

                    if (listView_Local.SelectedItems[0].Name == "Directory" || listView_Local.SelectedItems[0].Name == "Drive")
                    {
                        ��������ToolStripMenuItem1.Enabled = false;
                    }
                }
            }
            else
            {
                ���������ToolStripMenuItem.Text = "�����������";
                ���������ToolStripMenuItem.Image = global::Local_DCrypt.Properties.Resources.encr;
                �������������ToolStripMenuItem.Visible = false;
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
                MessageBox.Show(ex.Message + " | " + ex.TargetSite, "Error");
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
                        vol_label = " (�������� ������ ������)";
                    }
                    else
                    {
                        disk_litera = dic.Name;
                        if (dic.IsReady)
                        {
                            vol_label = "  (" + dic.VolumeLabel + ")";
                            disk_total_size = "������:    " + FileSize.PrintFileSize(dic.TotalSize) + Environment.NewLine;
                            disk_total_size += "������:     " + FileSize.PrintFileSize(dic.TotalSize - dic.AvailableFreeSpace) + Environment.NewLine;
                            disk_avial_free_space = "��������: " + FileSize.PrintFileSize(dic.AvailableFreeSpace);
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
                ������������ToolStripMenuItem.Enabled = false;
            }
            else
            {
                ������������ToolStripMenuItem.Enabled = true;
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
                        //����������� �����? ���������!
                        if (_isEncryptedNames)
                        {
                            FolderName = cn.DecryptFName(FolderName, _pwd_key, PrefSettings.prefix);
                        }
                        li.Text = FolderName;
                        li.Tag = Path.Combine(init_dir, dic.Name);
                        init_expl_dir = init_dir;
                        li.Group = l_view.Groups["listViewGroupFolders"];

                        if (!FolderName.Contains(FileCrypt.not_crypted_mess))
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
                        //����������� �����? ���������!
                        if (_isEncryptedNames)
                        {
                            FileName = cn.DecryptFName(FileName, _pwd_key, PrefSettings.prefix);
                        }
                        li.Text = FileName;
                        li.Tag = Path.Combine(init_dir, dic.Name);
                        li.Group = l_view.Groups["listViewGroupFiles"];
                        if (!FileName.Contains(FileCrypt.not_crypted_mess))
                        {
                            //
                            li.ImageIndex = 3;
                        }
                        else
                        {
                            //
                            li.ImageIndex = 4;
                        }
                        li.SubItems.Add(FileSize.PrintFileSize(dic.Length));
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

            if (e.KeyCode == Keys.F5)
            {
                RefreshExp();
            }

            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedObject();
            }

            if (e.KeyCode == Keys.F2)
            {
                RenameSelectedObject();
            }
        }

        private void listView_Local_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enabled_faf_contr(listView_Local, _button_to_remote, new ToolStripMenuItem[] { �������������ToolStripMenuItem, �������ToolStripMenuItem, ���������ToolStripMenuItem, �������ToolStripMenuItem, �������������ToolStripMenuItem });
            Disabled_folder_contr(listView_Local, new ToolStripMenuItem[] { ��������ToolStripMenuItem1 });
        }

        /// <summary>
        /// �������� �� �����?
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ������ ��� ���������� ������ ���� � ������ File � Directory ���������, � ��������� - �� ��������� 
        /// </summary>
        /// <param name="li"></param>
        /// <param name="btn"></param>
        /// <param name="tsm"></param>
        private void Enabled_faf_contr(ListView li, Button btn, ToolStripMenuItem[] tsm)
        {
            if (isSelectedLV(li))
            {
                string file_name = string.Empty;
                file_name = li.SelectedItems[0].Name;

                switch (file_name)
                {
                    case "File":
                        {
                            ���������ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                            btn.Enabled = true;
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = true;
                            }

                        }
                        break;
                    case "Directory":
                        {
                            ���������ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                            if (li.SelectedItems[0].Text != "..")
                            {
                                btn.Enabled = true;
                                foreach (ToolStripMenuItem t in tsm)
                                {
                                    t.Enabled = true;
                                }
                            }
                        }
                        break;
                    default:
                        {
                            ���������ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
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
                ���������ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                btn.Enabled = false;
                foreach (ToolStripMenuItem t in tsm)
                {
                    t.Enabled = false;
                }
            }
        }

        /// <summary>
        /// ����������� �� ��� ���������� ������ ���� � ������ Directory � ���������� �� File
        /// </summary>
        /// <param name="li"></param>
        /// <param name="btn"></param>
        /// <param name="tsm"></param>
        private void Disabled_folder_contr(ListView li, ToolStripMenuItem[] tsm)
        {
            if (isSelectedLV(li))
            {
                string file_name = string.Empty;
                file_name = li.SelectedItems[0].Name;

                switch (file_name)
                {
                    case "Directory":
                        {
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = false;
                            }
                        }
                        break;
                    case "File":
                        {
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = true;
                            }
                        }
                        break;
                    default:

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

        #region �������� � ���������

        /// <summary>
        /// ���������� ������� ������ �������
        /// </summary>
        /// <param name="li"></param>
        private void GetFileName(ListView li)
        {
            if (isSelectedLV(li))
            {
                string full_name = li.SelectedItems[0].Tag.ToString();
                string object_name = li.SelectedItems[0].Text;
                string object_type = li.SelectedItems[0].Name;

                if (isSelectedLV(li))
                {
                    //TODO �������� ������ ��� ����������
                    if (SendObject != null)
                    {
                        SendObject.Invoke(full_name, object_name, object_type);
                    }
                }
            }
            else
            {
                button_to_remote.Enabled = false;
            }
        }

        /// <summary>
        /// �������� ������ ����������� �������
        /// </summary>
        /// <param name="li"></param>
        /// <returns></returns>
        private int GetIndexSelectedItem(ListView li)
        {
            return isSelectedLV(li) ? li.SelectedItems[0].Index : 0;
        }

        /// <summary>
        /// ��������� �� ��������
        /// </summary>
        public void GetSelectedFileName()
        {
            ���������ToolStripMenuItem_Click(this, null);
        }

        /// <summary>
        /// �������� ������ �������� � �����
        /// </summary>
        public void RefreshExp()
        {
            _refresh_exp(GetIndexSelectedItem(listView_Local));
        }

        /// <summary>
        /// �������� ������ �������� � ����� (��������)
        /// </summary>
        public void RefreshExp(int pos)
        {
            _refresh_exp(pos);
        }

        /// <summary>
        /// �������� ������ ��������
        /// </summary>
        /// <param name="pos"></param>
        private void _refresh_exp(int pos)
        {
            if (isSelectedLV(listView_Local) && pos == 0 && listView_Local.Items.Count > 0)
            {
                pos = listView_Local.SelectedItems[0].Index;
            }
            GetDirs(CurrLocalPath, listView_Local);
            if (listView_Local.Items.Count > pos && listView_Local.Items.Count>0)
            {
                listView_Local.Items[pos].Selected = true;//-1 ��-�� ".."
            }
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        public void ClearItems()
        {
            listView_Local.Items.Clear();
        }

        /// <summary>
        /// ������� ������
        /// </summary>
        private void CreateObject()
        {
            try
            {
                using (FormCFolder frm_cf = new FormCFolder("������ �����"))
                {
                    if (isSelectedLV(listView_Local))
                    {
                        string view_tree_name = listView_Local.SelectedItems[0].Text;
                        if (view_tree_name.Contains(FileCrypt.not_crypted_mess))
                        {
                            view_tree_name = view_tree_name.Remove(view_tree_name.IndexOf(FileCrypt.not_crypted_mess)).Trim();
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
                MessageBox.Show(ex.Message + " | " + ex.TargetSite, "������");
            }
        }

        /// <summary>
        /// ������������� ������
        /// </summary>
        private void RenameSelectedObject()
        {
            if (isSelectedLV(listView_Local))
            {
                switch (listView_Local.SelectedItems[0].Name)
                {
                    case "File":
                    case "Directory":
                        {
                            try
                            {
                                string real_fs_full_name = listView_Local.SelectedItems[0].Tag.ToString();
                                string view_tree_name = listView_Local.SelectedItems[0].Text;
                                using (FormCFolder frm_cf = new FormCFolder("������������� " + view_tree_name))
                                {
                                    if (view_tree_name.Contains(FileCrypt.not_crypted_mess))
                                    {
                                        view_tree_name = view_tree_name.Remove(view_tree_name.IndexOf(FileCrypt.not_crypted_mess)).Trim();
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
                                                    if (listView_Local.SelectedItems[0].Text != "..")
                                                    {
                                                        Directory.Move(real_fs_full_name, Path.Combine(path_d, frm_cf.InputText));
                                                    }
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
                                MessageBox.Show(ex.Message + " | " + ex.TargetSite, "������");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// ������� ������ ������
        /// </summary>
        private void EditInsideObject()
        {
            if (isSelectedLV(listView_Local))
            {
                using (FormViewer frm_v = new FormViewer(listView_Local.SelectedItems[0].Tag.ToString()))
                {
                    frm_v.ShowDialog();
                }
            }
        }

        /// <summary>
        /// ������� ������
        /// </summary>
        private void DeleteSelectedObject()
        {
            if (isSelectedLV(listView_Local))
            {
                try
                {
                    switch (listView_Local.SelectedItems[0].Name)
                    {
                        case "File":
                            {
                                if (MessageBox.Show("������� ����" + Environment.NewLine + listView_Local.SelectedItems[0].Text, "��������", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    File.Delete(listView_Local.SelectedItems[0].Tag.ToString());
                                    RefreshExp(listView_Local.SelectedItems[0].Index - 1);
                                }
                            }
                            break;
                        case "Directory":
                            {
                                if (listView_Local.SelectedItems[0].Text != "..")
                                {
                                    if (MessageBox.Show("������� �����" + Environment.NewLine + listView_Local.SelectedItems[0].Text, "��������", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        Directory.Delete(listView_Local.SelectedItems[0].Tag.ToString(), true);
                                        RefreshExp(listView_Local.SelectedItems[0].Index - 1);
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " | " + ex.TargetSite, "������");
                }
            }
        }

        /// <summary>
        /// ������� ������� ������
        /// </summary>
        private void EditOutsideObject()
        {
            if (isSelectedLV(listView_Local))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "notepad.exe";
                p.StartInfo.Arguments = listView_Local.SelectedItems[0].Tag.ToString();
                p.Start();
            }
        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        private void ExecuteObject()
        {
            if (isSelectedLV(listView_Local))
            {
                try
                {
                    System.Diagnostics.Process.Start(listView_Local.SelectedItems[0].Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ �������: " + ex.Message + " | " + ex.TargetSite);
                }
            }
        }

        /// <summary>
        /// ����� � ����� ��� �������� ����
        /// </summary>
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

        #endregion

        #region ------------------ ������ ���� ------------------

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFileName(listView_Local);
        }

        void contextMenuStrip_local_Opening(object sender, CancelEventArgs e)
        {
            CryptoBtnText();
        }

        void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshExp();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteObject();
        }

        private void ��������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditOutsideObject();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedObject();
        }

        void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditInsideObject();
        }

        void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateObject();
        }

        void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameSelectedObject();
        }

        #endregion ------------------ ������ ���� ------------------

    }
}
