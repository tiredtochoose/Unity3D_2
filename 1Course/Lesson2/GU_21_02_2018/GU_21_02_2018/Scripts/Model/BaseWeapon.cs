using GeekBrains.Helpers;
using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public abstract class BaseWeapon : BaseObjectScene
	{
		[SerializeField] protected Transform _barrel;
		[SerializeField] protected float _force = 9999;
		[SerializeField] protected float _rechergeTime = 0.2f;

		protected Timer _timer = new Timer();
		protected bool _isFire = true;

		public BaseAmmunition Ammunition;

		public abstract void Fire(BaseAmmunition ammunition);

		protected virtual void Update()
		{
			_timer.Update();
			if (_timer.IsEvent())
			{
				_isFire = true;
			}
		}
	}
}