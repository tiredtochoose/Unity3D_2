using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public class FlashLight : BaseObjectScene
	{
		private Light _light;
		private Transform _goFollow;
		private Vector3 _vecOffset;
		[SerializeField] private float _speed = 10;

		protected override void Awake()
		{
			base.Awake();
			_light = GetComponent<Light>();

			_goFollow = Camera.main.transform;
			_vecOffset = Transform.position - _goFollow.position;

			Switch(false);
		}

		public void Switch(bool value)
		{
			if (!_light) return;

			Transform.position = _goFollow.position + _vecOffset;
			Transform.rotation = _goFollow.rotation;
			_light.enabled = value;
		}

		public void Rotation()
		{
			if (!_light) return;

			Transform.position = _goFollow.position + _vecOffset;
			Transform.rotation = Quaternion.Lerp(Transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
		}
	}
}