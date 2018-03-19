using System;
using Assets.GU_21_02_2018.Scripts.Helpers;
using Assets.GU_21_02_2018.Scripts.Interface;

namespace Assets.GU_21_02_2018
{
	public class Box : BaseObjectScene, ISetHp
	{
		private float _hp;
		private float _timeDest = 10;

		public float Hp
		{
			get { return _hp; }
			private set { _hp = value; }
		}

		public void SetHp(InfoOfCollision info)
		{
			if (Hp > 0)
			{
				Hp -= info.Damge;
			}

			if (Hp <= 0)
			{
				Destroy(InstanceObject, _timeDest);
			}
		}
	}
}