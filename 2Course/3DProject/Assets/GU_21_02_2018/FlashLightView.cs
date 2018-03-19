using UnityEngine;
using UnityEngine.UI;

namespace My3DProject
{
	public class FlashLightView : MonoBehaviour
	{
		[SerializeField] private Text _text;
        private Image _flashlightBar;


        void Start()
        {
            _flashlightBar = GameObject.Find("FlashLight LifeTime").GetComponent<Image>();
            _flashlightBar.enabled = false;
        }

        public void flashlightBarOn(bool value)
        {
            _flashlightBar.enabled = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">flashlight life time left</param>
        public void BarChange(float value)
        {
            _flashlightBar.fillAmount = value;
        }
  //      /// <summary>
  //      /// 
  //      /// </summary>
  //      /// <param name="value">Время в секундах</param>
  //      public void SetText(float value)
		//{
		//	_text.text = value.ToString();
		//}
	}
}