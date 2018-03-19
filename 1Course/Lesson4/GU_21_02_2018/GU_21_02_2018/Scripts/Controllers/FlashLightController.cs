namespace Assets.GU_21_02_2018
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class FlashLightController : BaseController
	{
		private FlashLight _flashLight;
		private FlashLightView _flashLightView;

		private void Start()
		{
			_flashLight = FindObjectOfType<FlashLight>();
			_flashLightView = FindObjectOfType<FlashLightView>();
		}
		private void Update()
		{
			if (!Enable) return;
			if (_flashLight != null) _flashLight.Rotation();
		}

		public override void On()
		{
			if(Enable) return;
			base.On();
			if (_flashLight != null) _flashLight.Switch(true);
		}

		public override void Off()
		{
			if (!Enable) return;
			base.Off();
			if (_flashLight != null) _flashLight.Switch(false);
		}

		public void Switch()
		{
			if (Enable)
			{
				Off();
			}
			else
			{
				On();
			}
		}
	}
}