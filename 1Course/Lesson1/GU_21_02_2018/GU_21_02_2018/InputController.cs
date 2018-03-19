using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public sealed class InputController : BaseController
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				Main.Instance.FlashLightController.Swich();
			}
		}
	}
}