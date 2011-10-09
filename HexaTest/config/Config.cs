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
            if (!Directory.Exists(Environment.CurrentDirectory + @"/" + configPath))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"/" + configPath);
            }
        }
    }
}
