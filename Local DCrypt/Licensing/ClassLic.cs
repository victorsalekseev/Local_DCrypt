using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Remote_DCrypt
{
    public class Licensing
    {
        public static string license_rus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "License-rus_v" + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + ".txt");
        public static string license_rus_md5 = "78F49B287BF1386BD67C67D371169599";
    }
}
