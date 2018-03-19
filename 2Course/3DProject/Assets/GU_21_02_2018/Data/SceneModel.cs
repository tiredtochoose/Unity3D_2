using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace My3DProject
{
    public class SceneModel : MonoBehaviour
    {
        public static string _path;
        private static GameObject _botPrefab;
        

        //сначала я написала так, но это получается перемещение объектов, и если какой-то объект
        //был удален со сцены после сохранения, получается беда
        //[MenuItem("Geekbrains/Загрузить уровень", false, 2)]
        //private static void LoadLvl()
        //{
        //    _path = "MyData.xml";
        //    string loadPath = Path.Combine(Application.dataPath, "MyData.xml");
        //    var sceneObj = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; // Находим все объекты на сцене
        //    var loadObj = SerializableToXML.Load(loadPath);


        //    if (sceneObj != null)
        //    {
        //        for (int i = 0; i <= sceneObj.Length-1; i++)
        //        {

        //            sceneObj[i].transform.position = loadObj[i].Pos;
        //            sceneObj[i].transform.rotation = loadObj[i].Rot;
        //            sceneObj[i].transform.localScale = loadObj[i].Scale;

        //        }
        //    }
        //}

        //хотела сделать сохранение и запись только ботов, чтобы можно было префаб указать, но выдает ошибку
        [MenuItem("Geekbrains/Загрузить уровень", false, 2)]
        private static void LoadLvl()
        {
            _path = "MyData.xml";
            _botPrefab = Resources.Load("Bot") as GameObject;
            
            var loadBot = SerializableToXML.Load(_path);

            foreach (var b in loadBot) //на этом месте выдает ошибку nullRefecenceException
                                        //не понимаю почему
            {
                var tempObj = Instantiate(_botPrefab, b.Pos, b.Rot);
                tempObj.name = b.Name;
            }

        }
    }

}
