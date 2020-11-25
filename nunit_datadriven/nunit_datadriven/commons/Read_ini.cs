using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace nunit_datadriven.commons
{
    public class Read_ini
    {
        private IniData read;

        public Read_ini()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"resources\Config.ini");
            if (!File.Exists(fileName))
            {
                throw new IOException("File " + fileName + "does not exist");
            }
            IniParser.FileIniDataParser parser = new FileIniDataParser();
            read = parser.ReadFile(fileName);
        }

        public string GetProperty(string section, string key)
        {
            KeyDataCollection data = read[section];
            return data[key];
        }
    }
}