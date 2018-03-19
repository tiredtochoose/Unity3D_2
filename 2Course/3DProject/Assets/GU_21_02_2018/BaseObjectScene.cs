using UnityEngine;

namespace My3DProject
{
	public abstract class BaseObjectScene : MonoBehaviour
	{
		private int _layer;
		private Color _color;
        private bool _isVisible;
        [HideInInspector] public Transform Transform;
		[HideInInspector] public GameObject InstanceObject;
        [HideInInspector] private Rigidbody _rigidbody;

		public int Layer
		{
			get { return _layer; }
			set
			{
				_layer = value;

				AskLayer(Transform, _layer);
			}
		}

        public Rigidbody Rigidbody
        {
            get
            {
                return _rigidbody;
            }

            set
            {
                _rigidbody = value;
            }
        }

        protected virtual void Awake()
		{
			Transform = transform;
            InstanceObject = gameObject;
            Rigidbody = InstanceObject.GetComponent<Rigidbody>();

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

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                var tempRenderer = InstanceObject.GetComponent<Renderer>();
                if (tempRenderer)
                    tempRenderer.enabled = _isVisible;
                if (Transform.childCount <= 0) return;
                foreach (Transform d in Transform)
                {
                    tempRenderer = d.gameObject.GetComponent<Renderer>();
                    if (tempRenderer)
                        tempRenderer.enabled = _isVisible;
                }
            }
        }

    }
}