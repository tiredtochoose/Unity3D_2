using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
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
            //запуск карутины, в ней надо что-то выполнять FlashLightView
            StartCoroutine(Discharge());
            _flashLightView.BarChange(_flashLight.lifeTime);
        }

        public override void On()
		{
			if(Enable) return;
			base.On();
            if (_flashLight != null)
            {
                _flashLight.Swich(true);
                _flashLightView.flashlightBarOn(true);
            }
            
                

            //_flashLightView.SetText(_flashLight.lifeTime);
		}

		public override void Off()
		{
			if (!Enable) return;
			base.Off();
			if (_flashLight != null)
            {
                _flashLight.Swich(false);
                FullCharge();
                _flashLightView.flashlightBarOn(false);
            }
                
        }

		public void Swich()
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
        
        IEnumerator Discharge()
        {
            _flashLight.lifeTime -= 0.001f;
            if (_flashLight.lifeTime <= 0)
                Swich();
            yield return new WaitForSecondsRealtime(5);
        }

        private void FullCharge()
        {
            _flashLight.lifeTime = 1;
        }
    }
}