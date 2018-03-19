using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



namespace My3DProject
{
    public class StreamData : IData<Player>
    {
        private string _path;
        public void Save(Player player)
        {

            using (var sw = new StreamWriter(_path))
            {
                sw.WriteLine(player.Name);
                sw.WriteLine(player.Hp);
                sw.WriteLine(player.IsVisible);
            }
        }
        public Player Load()
        {
            var result = new Player(); //создаем результирующую переменную
            if (!File.Exists(_path)) return result; //если файл по данному пути не существует, то возвращаем пустой объект
            using (var streamReader = new StreamReader(_path)) //создаем объект с помощью using и по строчно считываем строчки из файла
            {
                //создаем объекты??
                string name = string.Empty; 
                float hp = 0;
                bool isVisible = false;

                //записываем в них,то что будет лежать в каждой строчке
                while (!streamReader.EndOfStream)
                {
                    name = streamReader.ReadLine();
                    hp = System.Convert.ToSingle(streamReader.ReadLine());
                    isVisible = streamReader.ReadLine().TryBool();
                }

                result = new Player(hp, name, isVisible);
            }
            return result;//возвращаем результирующую переменную
        }
        public void SetOptions(string path)
        {
            _path = Path.Combine(path, "Data.GeekBrains"); // "path\Data.GeekBrains"
        }
    }
}
