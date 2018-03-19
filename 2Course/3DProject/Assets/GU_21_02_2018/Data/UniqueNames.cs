﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


namespace My3DProject
{
    class UniqueNames
    {
        private static readonly Dictionary<string, int> _nameDictionary = new Dictionary<string, int>();
        [MenuItem("Geekbrains/Проверка на уникальность имен", false, 0)] //создаем кнопку
        private static void NewMenuOption()
        {
            var sceneObj = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; // Находим все объекты на сцене
            if (sceneObj != null)
            {
                foreach (var obj in sceneObj)
                {
                    DataCollection(obj);
                    Debug.Log(obj.name);
                }
            }
            foreach (var i in _nameDictionary)
            {
                for (var j = 0; j < i.Value; j++)
                {
                    var gameObj = GameObject.Find(i.Key);
                    if (gameObj)
                    {
                        gameObj.name += "(" + j + ")";
                    }
                }
            }
            _nameDictionary.Clear(); // Очищаем память
        }
        /// <summary>
        /// Собирает информацию об объекте (имя и индекс)
        /// </summary>
        /// <param name="sceneObj">Объект на сцене</param>
        private static void DataCollection(GameObject sceneObj)
        {
            string[] tempName = sceneObj.name.Split('(');
            tempName[0] = tempName[0].Trim(); // Убираем пробелы
            if (!_nameDictionary.ContainsKey(tempName[0]))
            {
                _nameDictionary.Add(tempName[0], 0);
            }
            else
        {
                _nameDictionary[tempName[0]]++;
            }
            sceneObj.name = tempName[0];
        }
    }

}

