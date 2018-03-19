using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My3DProject
{
    class DataManager : IData<Player>
    {
        private IData<Player> _data; // у нас какой-то тип IData
        public void SetData<T>() where T : IData<Player>, new() //классы которые будут участвовать в сохранении данных
                                                        //они обязательно будут реализовывать интерфейс IData и 
                                                        //должны быть оязательно ссылочными типами данных ( new() )
                                                        //то есть реализовывать конструктор по умолчанию, чтобы мы могли их создавать
        {
            _data = new T(); // эта строка не будет работать, если убрать new()
        }
        public void Save(Player player)
        {
            _data.Save(player);
        }
        public Player Load()
        {
            return _data.Load();
        }
        public void SetOptions(string path)
        {
            _data.SetOptions(path);
        }
    }
}
