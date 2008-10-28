using System;
using System.Collections.Generic;
using System.Text;
using Remote_DCrypt.Settings;
using System.Windows.Forms;
using Local_DCrypt.Controls;

namespace Remote_DCrypt
{
    public static class PrefSettings
    {
        /// <summary>
        /// Пароль для сетевого входа, не исп.
        /// </summary>
        public static string pwd;
        /// <summary>
        /// Ключ для шифрования имен файлов
        /// </summary>
        public static string key_fname;
        /// <summary>
        /// Ключ-пароль для шифрования файлов
        /// </summary>
        public static string pwd_file_enc; 

        public static string key_size;

        public static string right_init_dir;
        public static string left_init_dir;
        public static string def_name_fcont;

        /// <summary>
        /// Префикс имен файлов
        /// </summary>
        public static string prefix;

        public static string FixDrivePath(string path)
        {
            if (path.Length == 2)
            {
                path += "\\";
            }
            return path;
        }
    }

    /// <summary>
    /// Класс инициализации связи с сервером-хранителем
    /// </summary>
    public static class CryptoConnection
    {
        public static bool InitState = false;

        /// <summary>
        /// Инициализация настроек (крипто коннекта)
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            bool yes = false;
            if (LoadSettings())
            {
                //PrefSettings.server
                //PrefSettings.user
                //Если настройки подтвердились
                yes = true;
            }
            else
            {
                yes = false;
            }
            InitState = yes;
            return yes;
        }

        /// <summary>
        /// Деинициализация настроек (крипто коннекта)
        /// </summary>
        public static void Kill()
        {
            InitState = false;
            PrefSettings.pwd = null;
        }

        /// <summary>
        /// Загрузка настроек в статичный класс PrefSettings.
        /// Только здесь настройки программы сопоставляются
        /// со статичным классом настроек PrefSettings. И только
        /// через него получаем в программе свойства настроек.
        /// Сохранение настроек от него не зависит (после сохранения)
        /// настроки загружаются и перечитываются в него.
        /// </summary>
        /// <returns></returns>
        private static bool LoadSettings()
        {
            bool yes = false;
            try
            {
                Options o = new Options();
                if (System.IO.File.Exists(ManageSetting.path_to_set_file))
                {
                    yes = ManageSetting.LoadSettings(ref o);
                }
                //else
                //{
                //    FormSettings frm_set = new FormSettings();
                //    if (frm_set.ShowDialog() == DialogResult.OK)
                //    {
                //        SaveSetting.LoadSettings(ref o);
                //    }
                //}
                PrefSettings.right_init_dir = TextBoxSelectFolder.get_std_path(o.right_init_dir);
                PrefSettings.key_fname = o.key_fname;
                PrefSettings.key_size = o.key_size;
                PrefSettings.pwd_file_enc = o.pwd_file_enc;
                //SshSettings.local_path = string.Empty;//AppDomain.CurrentDomain.BaseDirectory; 
                PrefSettings.left_init_dir = TextBoxSelectFolder.get_std_path(o.left_init_dir);
                PrefSettings.prefix = o.prefix;
                PrefSettings.def_name_fcont = o.def_name_fcont;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " +ex.Message);
                yes = false;
            }
            return yes;
        }
    }
}
