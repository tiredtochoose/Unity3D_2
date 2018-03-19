using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public abstract class BaseObjectScene : MonoBehaviour
	{
		private int _layer;
		private Color _color;

		[HideInInspector] public Transform Transform;
		[HideInInspector] public GameObject GameObject;

		public int Layer
		{
			get { return _layer; }
			set
			{
				_layer = value;

				AskLayer(Transform, _layer);
			}
		}

		protected virtual void Awake()
		{
			Transform = transform;
			GameObject = gameObject;
			Layer = gameObject.layer;
		}

		private void AskLayer(Transform obj, int layer)
		{
			obj.gameObject.layer = layer;

			if(obj.childCount <= 0) return;

			foreach (Transform child in obj)
			{
				AskLayer(child, layer);
			}
		}
	}
}