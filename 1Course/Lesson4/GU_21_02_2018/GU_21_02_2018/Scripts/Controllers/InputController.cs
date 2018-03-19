using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public sealed class InputController : BaseController
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				Main.Instance.FlashLightController.Switch();
			}

			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				SetWeapon(0);
			}
		}

		private void SetWeapon(int i)
		{
			Main.Instance.WeaponController.Off();
			var tempWeapon = Main.Instance.ObjectManager.Weapons[i];

			if (tempWeapon)
			{
				Main.Instance.WeaponController.On(tempWeapon);
			}
		}
	}
}