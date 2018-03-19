using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public class Test : BaseObjectScene
	{
		[HideInInspector] public Rigidbody Rigidbody;
		protected override void Awake()
		{
			base.Awake();

			Rigidbody = GetComponent<Rigidbody>();
		}
	}
}