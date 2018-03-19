using UnityEngine;

namespace Assets.GU_21_02_2018.Scripts.Helpers
{
	public struct InfoOfCollision
	{
		private readonly float _damge;
		private readonly Vector3 _direction;

		public InfoOfCollision(float damge, Vector3 direction)
		{
			_damge = damge;
			_direction = direction;
		}

		public float Damge
		{
			get { return _damge; }
		}

		public Vector3 Direction
		{
			get { return _direction; }
		}
	}
}