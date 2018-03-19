using System;
using System.Collections.Generic;
using Assets.GU_21_02_2018.Scripts.Helpers;
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
		public void SetBattery(float value)
		{
			_text.text = "Battery " + value + " %";
			_text.text = String.Format("Battery {0} %", value);
			_text.text = "Battery {0} %".Format(value);

			var list = new List<int>();
			var list2 = new List<int>();

			list.Add(42);

			42.Add(list).Add(list2);
		}
	}
}