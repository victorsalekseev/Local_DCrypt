using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Remote_DCrypt;
using System.Security.Cryptography;
using Remote_DCrypt.Settings;

namespace Local_DCrypt
{
    public partial class FormCM : Form
    {
        contacts ct = new contacts();
        bool isChanged = false;
        public string default_filename =PrefSettings.def_name_fcont;// Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Contacts.cr");

        public FormCM()
        {
            InitializeComponent();
            добавитьToolStripMenuItem.Click+=new EventHandler(добавитьToolStripMenuItem_Click);
            contextMenuStrip.Opening += new CancelEventHandler(contextMenuStrip_Opening);
            изменитьToolStripMenuItem.Click += new EventHandler(изменитьToolStripMenuItem_Click);
            удалитьToolStripMenuItem.Click += new EventHandler(удалитьToolStripMenuItem_Click);
            копироватьToolStripMenuItem.Click += new EventHandler(копироватьToolStripMenuItem_Click);
            newToolStripButton.Click += new EventHandler(newToolStripButton_Click);
            openToolStripButton.Click += new EventHandler(openToolStripButton_Click);
            saveToolStripButton.Click += new EventHandler(saveToolStripButton_Click);
            сохранитьКакToolStripMenuItem.Click += new EventHandler(сохранитьКакToolStripMenuItem_Click);
            copyToolStripButton.Click += new EventHandler(копироватьToolStripMenuItem_Click);
            this.FormClosing += new FormClosingEventHandler(FormCM_FormClosing);
            foreach (ToolStripMenuItem tsmi in contextMenuStrip_pref.Items)
            {
                tsmi.Click+=new EventHandler(tsmi_Click);
            }
            LoadContactsToTree();
            toolStripButtonExpandOn.Click += new EventHandler(toolStripButtonExpandOn_Click);
            toolStripButtonExpandOff.Click += new EventHandler(toolStripButtonExpandOff_Click);
            saveFileDialog.FileName = default_filename;
        }

        void toolStripButtonExpandOff_Click(object sender, EventArgs e)
        {
            treeView_с.CollapseAll();
        }

        void toolStripButtonExpandOn_Click(object sender, EventArgs e)
        {
            treeView_с.ExpandAll();
        }

        void FormCM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                e.Cancel = true;

                switch (MessageBox.Show("Сохранить?", "Имеются несохраненные данные", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        {
                            SaveTreeContactsToFile(default_filename);
                            isChanged = false;
                            this.Close();
                        }  
                        break;
                    
                    case DialogResult.Cancel:
                        {

                        }
                        break;

                    case DialogResult.No:
                        {
                            isChanged = false;
                            this.Close();
                        }
                        break;                        

                    default:
                        break;
                }
            }
        }

        private TreeNode get_sel_node(TreeView tv)
        {
            return treeView_с.SelectedNode;
        }

        private TreeNode create_node(string name, string text, int indx, object tag)
        {
            TreeNode tn = new TreeNode();
            tn.Name = name;
            tn.Text = text;
            tn.ImageIndex = indx;
            tn.SelectedImageIndex = indx;
            tn.StateImageIndex = indx;
            tn.Tag = tag;
            return tn;
        }

        private TreeNode edit_node(TreeNode tn,string value,string name)
        {
            if (tn.Parent != null)
            {
                tn.Name = name;
                tn.Text = tn.Name + ": " + value;
                tn.Tag = value;
            }
            else
            {
                tn.Text = value;
                tn.Tag = value;
            }
            return tn;
        }

        private void SaveTreeContactsToFile(string filename)
        {
            try
            {
                string[] Contacts = new string[treeView_с.Nodes.Count];
                object[][] PrefContacts = new object[treeView_с.Nodes.Count][];

                for (int i = 0; i < treeView_с.Nodes.Count; i++)
                {
                    Contacts[i] = treeView_с.Nodes[i].Text;

                    PrefContacts[i] = new object[treeView_с.Nodes[i].Nodes.Count];
                    for (int j = 0; j < treeView_с.Nodes[i].Nodes.Count; j++)
                    {
                        PrefContacts[i][j] = (object)new string[] { treeView_с.Nodes[i].Nodes[j].Name, treeView_с.Nodes[i].Nodes[j].Tag.ToString(), treeView_с.Nodes[i].Nodes[j].ImageIndex.ToString() };
                    }

                }
                ct.Contacts = Contacts;
                ct.PrefContacts = PrefContacts;


                XmlSerializer myXmlSer = new XmlSerializer(ct.GetType());
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(ManageSetting.Cached_Pwd, null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512
                byte[] key = pdb.GetBytes(12);

                using (MemoryStream sWriter = new MemoryStream(12))
                {
                    myXmlSer.Serialize(sWriter, ct);
                    new Crypt().encryt_byte_to_file(Encoding.ASCII.GetString(key), 256, sWriter.GetBuffer(), filename, new ProgressBar());
                    sWriter.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void LoadContactsToTree()
        {
            if (File.Exists(default_filename))
            {
                LoadContactsToTree(default_filename);
            }
            //else
            //{
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        default_filename = openFileDialog.FileName;
            //        LoadContactsToTree(default_filename);
            //    }
            //}
        }

        private void LoadContactsToTree(string filename)
        {
            try
            {
                treeView_с.Nodes.Clear();

                XmlSerializer myXmlSer = new XmlSerializer(typeof(contacts));
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(ManageSetting.Cached_Pwd, null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512
                byte[] key = pdb.GetBytes(12);

                byte[] bt = new Crypt().decrypt_file_to_byte(Encoding.ASCII.GetString(key), 256, filename, new ProgressBar());

                using (MemoryStream ms = new MemoryStream(bt, false))
                {
                    ct = (contacts)myXmlSer.Deserialize(ms);
                    ms.Close();
                }

                for (int i = 0; i < ct.Contacts.Length; i++)
                {
                    treeView_с.Nodes.Add(create_node("Контакт", ct.Contacts[i], 0, ct.Contacts[i]));

                    object[] st = ct.PrefContacts[i];

                    for (int j = 0; j < ct.PrefContacts[i].Length; j++)
                    {
                        string[] str = (string[])st[j];
                        treeView_с.Nodes[i].Nodes.Add(create_node(str[0], str[0] + ": " + str[1], int.Parse(str[2]), str[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            TreeNode tn = get_sel_node(treeView_с);
            if (tn != null)
            {
                изменитьToolStripMenuItem.Enabled = true;
                удалитьToolStripMenuItem.Enabled = true;
                копироватьToolStripMenuItem.Enabled = true;
                if (tn.Parent == null)//Чтобы позволить только двухуровневую структуру
                {
                    добавитьСвойствоToolStripMenuItem.Enabled = true;
                    добавитьСвойствоToolStripMenuItem.Text = "Добавить к \"" + tn.Text + "\"";
                }
                else
                {
                    добавитьСвойствоToolStripMenuItem.Enabled = false;
                    добавитьСвойствоToolStripMenuItem.Text = "Добавить свойство";
                }
            }
            else
            {
                добавитьСвойствоToolStripMenuItem.Enabled = false;
                изменитьToolStripMenuItem.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
                копироватьToolStripMenuItem.Enabled = false;
                добавитьСвойствоToolStripMenuItem.Text = "Добавить свойство";
            }
        }

        void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(get_sel_node(treeView_с).Tag.ToString());
        }

        void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить"+ Environment.NewLine + get_sel_node(treeView_с).Text, "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                get_sel_node(treeView_с).Remove();
                isChanged = true;
            }
        }

        void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = get_sel_node(treeView_с);
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (tn != null)
            {
                using (FormPref fp = new FormPref())
                {
                    if (get_sel_node(treeView_с).ImageIndex == 1)
                    {
                        fp.EditType = true;
                    }
                    fp.NewPref = get_sel_node(treeView_с).Tag.ToString();
                    fp.NewPrefName = get_sel_node(treeView_с).Name;
                    fp.MainText = "Изменить \"" + get_sel_node(treeView_с).Name + "\"";
                    if (fp.ShowDialog() == DialogResult.OK)
                    {
                        edit_node(tn, fp.NewPref, fp.NewPrefName);
                        isChanged = true;
                    }
                }
            }
        }

        void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            using (FormPref fp = new FormPref())
            {
                if (int.Parse(tsmi.Tag.ToString()) == 1)
                {
                    fp.EditType = true;
                }
                fp.MainText = "Добавить новое свойство - (" + tsmi.Text + ")";
                fp.NewPrefName = tsmi.Text;
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    TreeNode tn = get_sel_node(treeView_с);
                    if (tn != null)
                    {
                        //ImageIndex ноды берется из Tag соответствующей MenuItem
                        tn.Nodes.Add(create_node(fp.NewPrefName, fp.NewPrefName + ": " + fp.NewPref, int.Parse(tsmi.Tag.ToString()), fp.NewPref));
                        tn.Expand();
                        isChanged = true;
                    }
                }
            }
        }

        void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormPref fp = new FormPref())
            {
                fp.MainText = "Добавить новый контакт";
                fp.NewPrefName = "Контакт";
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    treeView_с.Nodes.Add(create_node("Контакт", fp.NewPref, 0, fp.NewPref));
                    isChanged = true;
                }
            }
        }

        void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTreeContactsToFile(saveFileDialog.FileName);
                isChanged = false;
            }
        }

        void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveTreeContactsToFile(default_filename);
            isChanged = false;
        }

        void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadContactsToTree(openFileDialog.FileName);
            }
        }

        void newToolStripButton_Click(object sender, EventArgs e)
        {
            добавитьToolStripMenuItem_Click(this, null);
        }
    }

    public struct contacts
    {
        public string[] Contacts;
        public object[][] PrefContacts;
    }
}