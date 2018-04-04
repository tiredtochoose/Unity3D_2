using UnityEngine;

namespace Assets.Scripts
{
	public class Gun : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					var temp = hit.collider.GetComponentInParent<Ragdoll>();
					if (temp)
					{
						temp.Die();
					}
				}
			}
		}
	}
}