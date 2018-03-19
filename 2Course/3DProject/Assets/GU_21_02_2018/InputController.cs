using UnityEngine;

namespace My3DProject
{
	public sealed class InputController : BaseController
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				Main.Instance.FlashLightController.Swich();
			}

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetWeapon(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetWeapon(1);
            }
        }

        private void SetWeapon(int i)
        {
            
            //выключаем оружие в руках
            Main.Instance.WeaponController.Off();
            var tempWeapon = Main.Instance.ObjectManager.Weapons[i];

            if (tempWeapon)
            {
                Main.Instance.WeaponController.On(tempWeapon);
            }
        }

	}
}