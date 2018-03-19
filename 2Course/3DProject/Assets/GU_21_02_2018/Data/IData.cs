using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    public interface IData<T> 
    {
        void Save(T value);
        T Load();

        void SetOptions(string path = null); //путь к файлу
        
    }
}