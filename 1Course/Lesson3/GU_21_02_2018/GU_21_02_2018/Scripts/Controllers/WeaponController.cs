using GeekBrains.Helpers;
using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public class WeaponController : BaseController
	{
		private BaseWeapon _weapon;
		private BaseAmmunition _ammunition;
		private int _mouseButton = (int) MouseButton.LeftButton;

		private void Update()
		{
			if (!Enable) return;
			if (Input.GetMouseButton(_mouseButton))
			{
				if (_weapon)
				{
					_weapon.Fire(_ammunition);

					Debug.Log(0);
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