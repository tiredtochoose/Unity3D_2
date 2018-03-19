using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    /// <summary>
    /// Класс определяет поведение оружия «Автомат»
    /// </summary>
    public abstract class BaseWeapon : BaseObjectScene
    {
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 9999;
        [SerializeField] protected float _rechargeTime = 0.2f;

        protected Timer _timer = new Timer();
        /// <summary>
        /// Флаг, разрешающий выстрел
        /// </summary>
        protected bool _fire = true;

        public BaseAmmunition Ammunition;

        public abstract void Fire(BaseAmmunition ammunition);

        protected virtual void Update()// переделать корутиной, вынести 
            //в отдельный класс
        {
            _timer.Update();
            if (_timer.IsEvent())
            {
                _fire = true;
            }
        }
    }
}
