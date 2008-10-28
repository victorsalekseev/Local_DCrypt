using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Remote_DCrypt.Action;
using Remote_DCrypt.Settings;

namespace Remote_DCrypt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argc)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(ManageSetting.path_to_set_file))
            {
                FormSettings frm_set = new FormSettings();
                frm_set.ShowDialog();
            }

            if (!CryptoConnection.Init())
            {
                MessageBox.Show("Ошибка загрузки файла настроек. Возможные причины:" + Environment.NewLine + Environment.NewLine +
                    "1. Введен неправильный пароль файла ключей. Введите правильный пароль." + Environment.NewLine + Environment.NewLine +
                    "2. Испорчен файл ключей. Удалите файл " + Environment.NewLine + ManageSetting.path_to_set_file + Environment.NewLine +
                    "или перезапишите из резервной копии" + Environment.NewLine + Environment.NewLine +
                    "Исправьте ошибку и перезапустите программу.");
            }

            if (argc.Length > 0)
            {
                if (File.Exists(argc[0]))
                {
                    if (Directory.Exists(PrefSettings.right_init_dir))
                    {
                        Application.Run(new FormAction(argc[0], PrefSettings.right_init_dir, true));
                    }
                    else
                    {
                        MessageBox.Show("Зашифровать не удалось - непраивильный путь в папке назначения:" + Environment.NewLine + PrefSettings.right_init_dir);
                    }
                }
                else
                {
                    MessageBox.Show("Зашифровать не удалось - не найден файл:" + Environment.NewLine + argc[0]);
                }
                CryptoConnection.Kill();
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
    }
}