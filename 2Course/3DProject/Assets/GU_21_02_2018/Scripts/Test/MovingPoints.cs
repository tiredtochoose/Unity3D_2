using System.Collections.Generic;

using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace My3DProject
{
	public class MovingPoints : MonoBehaviour
	{
		[SerializeField] private AICharacterControl _agent;
		[SerializeField] private GameObject _point;
		private Queue<GameObject> _points = new Queue<GameObject>();
		private Camera _mainCamera;
		private Transform _root;
        private int _leftMouseBtn = 0;

        #region LineRenderer

        private readonly Color _c1 = Color.red;
		private readonly Color _c = Color.red;
		private readonly int _lengthOfLineRenderer = 2;
		private LineRenderer _lineRenderer;
		private float _width = 0.2f;

		#endregion

		private void Start()
		{
			_mainCamera = Camera.main;
			_root = new GameObject("RootPoint").transform;
			_lineRenderer = gameObject.AddComponent<LineRenderer>();
			_lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			_lineRenderer.startColor = _c1;
			_lineRenderer.endColor = _c;
			_lineRenderer.startWidth = _width;
			_lineRenderer.endWidth = _width;
			_lineRenderer.positionCount = _lengthOfLineRenderer;
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(_leftMouseBtn))
			{
				RaycastHit hit;
				if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out
					hit))
				{
					DrawPoint(hit.point);
				}
			}

			RaycastHit hitInfo;
			if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out
				hitInfo))
			{
				_lineRenderer.SetPosition(1, hitInfo.point);
			}

		}

		private void DrawPoint(Vector3 position)
		{
			if (_point == null) return;
			var tempPoint = Instantiate(_point, position, Quaternion.identity, _root);
			_points.Enqueue(tempPoint);
			Destroy(_points.Dequeue());
			_lineRenderer.SetPosition(0, tempPoint.transform.position);
		}
	}
}