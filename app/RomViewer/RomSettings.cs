using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RomViewer
{
    [Serializable]
    public class RomSettings
    {
        public List<ToonSettings> Toons = new List<ToonSettings>();
        public string MicroMacroPath = "";

        public static RomSettings ReadFromFile(string filename)
        {
            RomSettings result = new RomSettings();

            if (File.Exists(filename))
            {
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(RomSettings));
                    result = (RomSettings) ser.Deserialize(stream);
                }
            }

            return result;
        }

        public static void SaveToFile(string filename, RomSettings settings)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (FileStream stream = new FileStream(filename, FileMode.CreateNew))
            {
                XmlSerializer ser = new XmlSerializer(typeof (RomSettings));
                ser.Serialize(stream, settings);
            }

        }
    }
}