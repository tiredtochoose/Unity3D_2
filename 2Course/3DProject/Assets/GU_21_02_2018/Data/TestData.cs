using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    public class TestData : MonoBehaviour
    {
        private IData<Player> _data; 
        private void Start()
        {
            var savePlayer = new Player(1100, "Nastya", true);

            IData<Player> data = new StreamData();
            //StreamData data = new StreamData(); // чтение из файла
            //XMLData data = new XMLData(); //чтение из xml

            //if(Application.platform == RuntimePlatform.Android)
            //{
            //    _data = new StreamData();
            //}
            //else
            //{
            //    //_data = new XMLData();
            //    _data = new JsonData();

            //}


            if (_data == null) return;
            var path = Application.dataPath; //путь до папки, куда мы хотим сохранять. сам объект указан в StreamData
            _data.SetOptions(path);

            _data.Save(savePlayer);

            var newPlayer = _data.Load();

            Debug.Log(newPlayer);

        }
    }
}
