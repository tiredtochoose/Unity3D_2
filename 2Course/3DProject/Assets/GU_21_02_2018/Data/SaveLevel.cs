using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;


namespace My3DProject
{
    public class SaveLevel
    {
        private static int _numberScene = 0;
        [MenuItem("Geekbrains/Сохранить уровень", false, 1)]
        private static void NewMenuOption()
        {

            string savePath = Path.Combine(Application.dataPath, "MyData.xml");
            Bot[] bots = GameObject.FindObjectsOfType<Bot>();
            
            List<SerializableGameObject> botsList = new List<SerializableGameObject>();

            GameObject[] levels = GameObject.FindObjectsOfType<GameObject>();
            List<SerializableGameObject> levelsList = new List<SerializableGameObject>();
            foreach (var o in levels)
            {
                var trans = o.transform;
                levelsList.Add(new SerializableGameObject
                {
                    Name = o.name,
                    Pos = trans.position,
                    Rot = trans.rotation,
                    Scale = trans.localScale
                });
            }

            foreach (var bot in bots)
            {
                var trans = bot.transform;
               
                botsList.Add(new SerializableGameObject
                {
                    Name = bot.name,
                    Pos = trans.position,
                    Rot = trans.rotation,
                    Scale = trans.localScale
                });
            }

            SerializableToXML.Save(botsList.ToArray(), savePath);
        }
    }

}
