using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public class Gun : BaseWeapon
	{
		public override void Fire(BaseAmmunition ammunition)
		{
			if (_isFire)
			{
				Debug.Log(2);
				if (ammunition)
				{
					var temp = Instantiate(ammunition, _barrel.position, _barrel.localRotation);
					temp.Rigidbody.AddForce(_barrel.forward * _force);
					_isFire = false;
					_timer.Start(_rechergeTime);
					Debug.Log(2);
				}
				else
				{
					// RayCast
				}
			}
		}
	}
}