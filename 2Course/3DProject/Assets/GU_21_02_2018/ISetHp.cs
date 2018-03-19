using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My3DProject
{
    /// <summary>
    /// Наследуемся от этого интерфейса, если хотим, чтобы объект получал урон
    /// </summary>

    public interface ISetHp
    {
        void SetHp(InfoOfCollision info);
        float Hp { get; }
    }
}
