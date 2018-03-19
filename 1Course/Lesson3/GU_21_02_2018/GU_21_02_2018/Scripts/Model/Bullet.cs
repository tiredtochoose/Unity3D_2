using System;
using Assets.GU_21_02_2018.Scripts.Helpers;
using Assets.GU_21_02_2018.Scripts.Interface;

namespace Assets.GU_21_02_2018
{
	public class Bullet : BaseAmmunition
	{
		private void OnCollisionEnter(UnityEngine.Collision collision)
		{
			SetDamage(collision.gameObject.GetComponent<ISetHp>());
			Destroy(InstanceObject);
		}

		private void SetDamage(ISetHp obj)
		{
			if (obj != null) obj.SetHp(new InfoOfCollision(_currentDamage, transform.forward));
		}
	}
}