using System.IO;
using UnityEngine;

namespace My3DProject
{
    class JsonData : IData<Player>
    {
        private string _path;
        public void Save(Player player)
        {
            var str = JsonUtility.ToJson(player);
            File.WriteAllText(_path, str);
        }
        public Player Load()
        {
            var str = File.ReadAllText(_path); //открываем файл, считываем все строчки и передаем в стринг
            return JsonUtility.FromJson<Player>(str); //str переводим в объект плеер
        }
        public void SetOptions(string path)
        {
            _path = Path.Combine(path, "Data.GeekBrains");
        }
    }
}
