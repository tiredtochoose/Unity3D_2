using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public class FlashLight : BaseObjectScene
	{
		private Light _light;
        public float lifeTime;
        
        protected sealed override void Awake()
		{
			base.Awake();

			_light = GetComponent<Light>();
			Swich(false);
		}

		public void Swich(bool value)
		{
			if (_light == null) return;

			_light.enabled = value;
		}
	}
}