using UnityEngine;
using UnityEngine.UI;

namespace Assets.GU_21_02_2018
{
	public class FlashLightView : MonoBehaviour
	{
		[SerializeField] private Text _text;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Время в секундах</param>
		public void SetTe(float value)
		{
			_text.text = value.ToString();
		}
	}
}