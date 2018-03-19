using System.IO;
using System.Xml;
using UnityEngine;

namespace My3DProject
{
    class XMLData : IData<Player>
    {
        private string _path;

        public void Save(Player player)
        {
            var xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("Hp");
            element.SetAttribute("value", player.Hp.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsVisible");
            element.SetAttribute("value", player.IsVisible.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDoc.CreateElement("Info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);

            xmlDoc.Save(_path);
        }
        public Player Load()
        {
            var result = new Player();
            if (!File.Exists(_path)) return result;
            using (var reader = new XmlTextReader(_path)) // открываем, считываем данный документ
            {
                

                string name = string.Empty; 
                float hp = 0;
                bool isVisible = false;

                while (reader.Read())
                {
                    var key = "Name";// ключ, по которому находим элементы и берем их значения
                    if (reader.IsStartElement(key))
                    {
                        name = reader.GetAttribute("value");
                    }
                    key = "Hp";
                    if (reader.IsStartElement(key))
                    {
                        hp = System.Convert.ToSingle(reader.GetAttribute("value"));
                    }
                    key = "IsVisible";
                    if (reader.IsStartElement(key))
                    {
                        isVisible = reader.GetAttribute("value").TryBool();
                    }
                }
                result = new Player(hp, name, isVisible); //значения передаем в объект
            }
            return result;
        }
        public void SetOptions(string path)
        {
            _path = Path.Combine(path, "Data.GeekBrains");
        }
    }
}
