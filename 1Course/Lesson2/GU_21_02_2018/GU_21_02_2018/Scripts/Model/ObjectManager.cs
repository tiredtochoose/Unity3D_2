using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.GU_21_02_2018
{
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