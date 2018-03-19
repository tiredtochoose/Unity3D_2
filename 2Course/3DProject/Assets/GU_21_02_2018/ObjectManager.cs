using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


namespace My3DProject
{
    /// <summary>
    /// Класс для хранения ссылок на объекты. Он будет хранить все ссылки на объекты, которые есть у главного героя.
    /// </summary>
    public class ObjectManager : MonoBehaviour
    {
        private BaseWeapon[] _weapons;

        private Transform _player;

        public BaseWeapon[] Weapons
        {
            get { return _weapons; }
        }

        private void Start()
        {
            _player = FindObjectOfType<FirstPersonController>().transform;

            if (!_player) return;

            _weapons = _player.GetComponentsInChildren<BaseWeapon>();
            if (Weapons.Length > 0)
            {
                foreach (var baseWeapon in Weapons)
                {
                    baseWeapon.IsVisible = false;
                }
            }
        }
    }
}
