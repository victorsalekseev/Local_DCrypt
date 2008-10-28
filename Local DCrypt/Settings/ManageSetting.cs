using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using Remote_DCrypt.Action;

namespace Remote_DCrypt.Settings
{
    //структура для хранения сохраняемой в файл инфы
    public struct Options
    {
        public string key_fname;
        public string left_init_dir;
        public string right_init_dir;
        public string prefix;
        public string key_size;
        public string pwd_file_enc;
        public string def_name_fcont;
    }

    /// <summary>
    /// Класс для сериализации объекта в xml-файл 
    /// </summary>
    public class ManageSetting
    {
        //Лишаем возможности создавать объекты этого класса
        private ManageSetting()
        {

        }

        public static string path_to_set_file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keys.key");

        public static string Cached_Pwd = string.Empty;

        private static string GetPwdForKeysFile(bool isLoadSettings)
        {
            //Загрузка
            if (isLoadSettings)
            {
                using (FormPwd frm_pwd = new FormPwd(isLoadSettings))
                {
                    frm_pwd.ShowDialog();
                    return frm_pwd.Password;
                }
            }
            //Сохранение
            else
            {
                using (FormPwd frm_pwd = new FormPwd(isLoadSettings))
                {
                    frm_pwd.MainText = "Задайте пароль на вход";
                    frm_pwd.ShowDialog();
                    return frm_pwd.Password;
                }
            }
        }

        public static bool CreateSettings(object o)
        {
            bool res = false;
            try
            {
                if (string.IsNullOrEmpty(Cached_Pwd))
                {
                    Cached_Pwd = GetPwdForKeysFile(false);
                }
                if (string.IsNullOrEmpty(Cached_Pwd))
                {
                    Application.Exit();
                }

                XmlSerializer myXmlSer = new XmlSerializer(o.GetType());
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Cached_Pwd, null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512
                byte[] key = pdb.GetBytes(12);

                using (MemoryStream sWriter = new MemoryStream(12))
                {
                    myXmlSer.Serialize(sWriter, o);
                    new Crypt().encryt_byte_to_file(Encoding.ASCII.GetString(key), 256, sWriter.GetBuffer(), path_to_set_file, new ProgressBar());
                    sWriter.Close();
                }
                res = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                res = false;
            }
            //XmlSerializer myXmlSer = new XmlSerializer(o.GetType());
            //StreamWriter myWriter = new StreamWriter(path_to_set_file);
            //myXmlSer.Serialize(myWriter, o);
            //myWriter.Close();
            return res;
        }

        public static bool LoadSettings(ref Options o)
        {
            bool res = false;
            try
            {
                if (string.IsNullOrEmpty(Cached_Pwd))
                {
                    Cached_Pwd = GetPwdForKeysFile(true);
                }
                if (string.IsNullOrEmpty(Cached_Pwd))
                {
                    Application.Exit();
                }

                XmlSerializer myXmlSer = new XmlSerializer(typeof(Options));
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Cached_Pwd, null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512
                byte[] key = pdb.GetBytes(12);

                byte[] bt = new Crypt().decrypt_file_to_byte(Encoding.ASCII.GetString(key), 256, path_to_set_file, new ProgressBar());

                using (MemoryStream ms = new MemoryStream(bt, false))
                {
                    o = (Options)myXmlSer.Deserialize(ms);
                    ms.Close();
                }

                res = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                res = false;
            }
            return res;
            //XmlSerializer myXmlSer = new XmlSerializer(typeof(Options));
            //FileStream mySet = new FileStream(path_to_set_file, FileMode.Open);
            //o = (Options)myXmlSer.Deserialize(mySet);
            //mySet.Close();
        }
    }
}
