using System;
using System.IO;
using System.Xml.Serialization;


namespace My3DProject
{
    public static class SerializableToXML
    {
        private static XmlSerializer _formatter;

        static SerializableToXML()
        {
            _formatter = new XmlSerializer(typeof(SerializableGameObject[]));
        }

        public static void Save(SerializableGameObject[] levels, string path)
        {
            if (levels == null && !String.IsNullOrEmpty(path)) return;
            if (levels.Length <= 0) return;
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fs, levels);
            }
        }

        public static SerializableGameObject[] Load(string path)
        {
            SerializableGameObject[] result;
            if (!File.Exists(path)) return default(SerializableGameObject[]);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                result = (SerializableGameObject[])_formatter.Deserialize(fs);
            }
            return result;
        }
    }

}
