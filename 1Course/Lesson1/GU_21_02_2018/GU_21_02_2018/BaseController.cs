using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public abstract class BaseController : MonoBehaviour
	{
		public bool Enable { get; private set; }

		public virtual void On()
		{
			Enable = true;
		}

		public virtual void Off()
		{
			Enable = false;
		}
	}
}