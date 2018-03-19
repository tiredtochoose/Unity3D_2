using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;


namespace GeekBrains.Editor
{
    public class MyWindow : EditorWindow
    {        
        public GameObject ObjectInstantiate;
        string _nameObject;
        bool groupEnabled;

        public string[] _shapes = new string[]
        {
            "Линия",
            "Круг"
        };
        public int _index = 0;

        bool _circleShape = false;
        bool _lineShape;

        bool _randomColor = true;
        bool _isStatic;

        int _countObject = 1;
        int _offset = 1;

        float _radius = 10;

        

        [MenuItem("Geekbrains/My First Window")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(MyWindow));
        }
        void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            
            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
                _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
                _isStatic = EditorGUILayout.Toggle("Static", _isStatic);
                _countObject = EditorGUILayout.IntSlider("Количество объектов", _countObject, 1, 100);
                _index = EditorGUILayout.Popup(_index, _shapes);
                SelectShape();
            
            EditorGUILayout.EndToggleGroup();

            if (GUILayout.Button("Создать объекты"))
            {
                if (ObjectInstantiate)
                {
                    Transform root = new GameObject("Root").transform;
                    
                    for (int i = 0; i < _countObject; i++)
                    {
                        GameObject temp;

                        if (_lineShape)
                        {
                            temp = Instantiate(ObjectInstantiate, new Vector3(0, i * _offset, 0), Quaternion.identity);
                        }
                        else if (_circleShape)
                        {
                            float angle = i * Mathf.PI * 2 / _countObject;
                            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
                            temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity) as GameObject;
                        }
                        else return;
                        
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                    
                        if (temp.GetComponent<Renderer>() && _randomColor)
                        {
                            temp.GetComponent<Renderer>().material.color = Random.ColorHSV();
                        }

                        if(_isStatic) temp.isStatic = true;

                    }
                }
            }
            
        }

        void SelectShape()
        {
            switch (_index)
            {
                case 0:
                    _lineShape = true;
                    _circleShape = false;
                    Debug.Log("_lineShape = true");
                    break;
                case 1:
                    _circleShape = true;
                    _lineShape = false;
                    Debug.Log("_circleShape = true");
                    break;
            }
        }

    }
}
