using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My3DProject
{
    public class WeaponController : BaseController
    {
        private BaseWeapon _weapon;
        private BaseAmmunition _ammunition;
        //private int _mouseButton = (int)MouseButton.LeftButton;
        private int _leftMouseBtn = 0;

        private void Update()
        {
            if (!Enable) return;
            if (Input.GetMouseButton(_leftMouseBtn))
            {
                if (_weapon)
                {
                    _weapon.Fire(_ammunition);                                       
                }
            }
        }

        public void On(BaseWeapon weapon)
        {
            if (Enable) return;
            base.On();

            _weapon = weapon;
            _weapon.IsVisible = true;
            if (weapon.Ammunition != null) _ammunition = _weapon.Ammunition;            
        }

        public override void Off()
        {
            if (!Enable) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            _ammunition = null;
        }
    }
}