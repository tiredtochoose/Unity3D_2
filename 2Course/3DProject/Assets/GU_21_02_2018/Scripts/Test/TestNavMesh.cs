using UnityEngine;
using UnityEngine.AI;

namespace My3DProject
{
	public class TestNavMesh : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private Transform _target2;
		private NavMeshPath _path;
		private float _elapsed = 0.0f;
		private void Start()
		{
			_path = new NavMeshPath();
			_elapsed = 0.0f;
		}
		private void Update()
		{
			_elapsed += Time.deltaTime;
			if (_elapsed > 1.0f)
			{
				_elapsed -= 1.0f;
				NavMesh.CalculatePath(_target2.position,
					_target.position, NavMesh.AllAreas, _path);
			}
			for (var i = 0; i < _path.corners.Length - 1; i++)
				Debug.DrawLine(_path.corners[i], _path.corners[i + 1], Color.red);
			if (_path.corners.Length >= 2)
			{
				// path.corners[1] Ближайшая точка к нам
			}
		}

	}
}