using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public sealed class Main : MonoBehaviour
	{
		public FlashLightController FlashLightController { get; private set; }

		public static Main Instance { get; private set; }
		private void Start()
		{
			Instance = this;
			var allControllers = new GameObject("allControllers");

			allControllers.AddComponent<InputController>();
			FlashLightController = allControllers.AddComponent<FlashLightController>();

			DontDestroyOnLoad(gameObject);
		}
	}
}