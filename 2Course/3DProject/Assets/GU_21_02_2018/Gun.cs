using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    /// <summary>
    /// Класс определяет поведения оружия "Автомат"
    /// </summary>
    public class Gun : BaseWeapon
    {
        private void Start()
        {
            Ammunition = Resources.Load<Bullet>("Bullet"); //грузит по имени
                                                //(@"FolderName\GOName"
        }

        public override void Fire(BaseAmmunition ammunition)
        {
            if (_fire)
            {
                if (ammunition)
                {
                    var temp = Instantiate(ammunition, _barrel.position, _barrel.localRotation);
                    temp.Rigidbody.AddForce(_barrel.forward * _force);
                    _fire = false;
                    _timer.Start(_rechargeTime);
                    
                }
                else
                {
                    // RayCast
                }

            }
        }
    }
}
