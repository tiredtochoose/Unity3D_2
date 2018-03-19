using UnityEngine;

namespace My3DProject
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