using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HexaTest.config
{
    static class Config
    {
        static string configPath = @"config/";
        public static void checkAndCreate()
        {
            checkAndCreate(configPath);
        }

        private static void checkAndCreate(string path)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"/" + path))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"/" + path);
            }
        }
    }
}
