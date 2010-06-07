using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Remote_DCrypt.Settings;
using Necode.Crypt.Action;
using Netcode.Messages;
using System.Text;

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

            if (!File.Exists(Licensing.license_rus))
            {
                FormLicensing frm_l = new FormLicensing();
                DialogResult dr = frm_l.ShowDialog();

                switch (dr)
                {
                    case DialogResult.Abort:
                        {
                            Application.Exit();
                        }
                        break;
                    case DialogResult.Yes:
                        {
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(Licensing.license_rus, false, Encoding.UTF8))
                                {
                                    sw.Write(frm_l.AssemblyDescription);
                                    sw.Close();
                                }
                            }
                            catch
                            {
                                new CriticalErrors().PrintError("S3", "Не получилось сохранить файл лицензионного соглашения");
                            }
                            finally
                            {
                                InitApp(argc);
                            }
                        }
                        break;
                    default:
                        break;
                }

                frm_l.Dispose();
            }
            else
            {
                InitApp(argc);
            }            
        }

        private static void InitApp(string[] argc)
        {
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
                        Application.Run(new FormAction(argc[0], PrefSettings.right_init_dir, string.Empty, string.Empty, true, PrefSettings.prefix, PrefSettings.pwd_file_enc, Convert.ToUInt16(PrefSettings.key_size), PrefSettings.key_fname));
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