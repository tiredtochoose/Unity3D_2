using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLineRenderer : MonoBehaviour
{

	[SerializeField] private Color _c1 = Color.yellow;
	[SerializeField] private Color _c2 = Color.red;
	[SerializeField] private float _width = 0.2f;
	[SerializeField] private int _lengthOfLineRenderer = 20;
	private LineRenderer _lineRenderer;

	private void Start()
	{
		_lineRenderer = gameObject.AddComponent<LineRenderer>();
		_lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		_lineRenderer.startColor = _c1;
		_lineRenderer.endColor = _c2;
		_lineRenderer.startWidth = _width;
		_lineRenderer.endWidth = _width;
		_lineRenderer.positionCount = _lengthOfLineRenderer;
	}

	private void Update()
	{
		Vector3[] points = new Vector3[_lengthOfLineRenderer];
		float t = Time.time;
		int i = 0;
		while (i < _lengthOfLineRenderer)
		{
			points[i] = new Vector3(i * 0.5F, Mathf.Sin(i + t), 0);
			i++;
		}

		_lineRenderer.SetPositions(points);
	}
}
