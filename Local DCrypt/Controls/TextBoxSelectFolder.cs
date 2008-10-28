using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Local_DCrypt.Controls
{
    public partial class TextBoxSelectFolder : UserControl
    {
        const string mydoc = "<Мои документы>";
        const string deskt = "<Рабочий стол>";
        const string basepath = "<Каталог с программой>";

        public TextBoxSelectFolder()
        {
            InitializeComponent();
            button_choose.Click += new EventHandler(button_choose_Click);

            comboBox_path.Items.Add(basepath);
            comboBox_path.Items.Add(mydoc);
            comboBox_path.Items.Add(deskt);
        }

        void button_choose_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selpath = folderBrowserDialog.SelectedPath;
                comboBox_path.Text = selpath;
            }
        }

        public string InputText
        {
            get {
                return comboBox_path.Text;
            }
            set { 
                comboBox_path.Text = value;
            }
        }

        /// <summary>
        /// Для использования портабельнсти программы
        /// организованы стандартные пути папок, таких
        /// как "Рабочий стол", "Мои документы". Функцию
        /// вызывать всегда, когда надо получить значение
        /// пути из настроек программы.
        /// </summary>
        /// <param name="selpath">Записанное значение в настройках</param>
        /// <returns>Переработанное, нормализованное</returns>
        public static string get_std_path(string selpath)
        {
            switch (selpath)
            {
                case basepath:
                    {
                        selpath = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    break;

                case deskt:
                    {
                        selpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    }
                    break;

                case mydoc:
                    {
                        selpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    }
                    break;

                default:
                    break;
            }
            return selpath;
        }
    }
}
