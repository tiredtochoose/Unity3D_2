using UnityEngine;

namespace My3DProject
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