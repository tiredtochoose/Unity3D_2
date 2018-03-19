using UnityEngine;

namespace My3DProject
{
	public sealed class Main : MonoBehaviour
	{
		public FlashLightController FlashLightController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public ObjectManager ObjectManager { get; private set; }


        public static Main Instance { get; private set; }


		private void Start()
		{
			Instance = this;
			var allControllers = new GameObject("allControllers");

			allControllers.AddComponent<InputController>();
			FlashLightController = allControllers.AddComponent<FlashLightController>();
            WeaponController = allControllers.AddComponent<WeaponController>();
            ObjectManager = allControllers.AddComponent<ObjectManager>();

            DontDestroyOnLoad(gameObject);
            
        }
    }
}