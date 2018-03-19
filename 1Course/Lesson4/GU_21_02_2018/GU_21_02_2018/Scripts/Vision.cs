using UnityEngine;

namespace Assets.GU_21_02_2018.Scripts
{
	[System.Serializable]
	public class Vision
	{
		public float ActiveDist = 15;
		public float ActiveAngle = 70;

		public bool VisionMath(Transform player, Transform target)
		{
			return Dist(player, target) && Angle(player, target) && !CheckBloked(player, target);
		}

		private bool CheckBloked(Transform player, Transform target)
		{
			RaycastHit hit;
			if(!Physics.Linecast(player.position,target.position, out hit))
			return true;
			return hit.transform != target;
		}

		private bool Angle(Transform player, Transform target)
		{
			var angle = Vector3.Angle(player.forward, target.position - player.position);
			return angle <= ActiveAngle;
		}

		private bool Dist(Transform player, Transform target)
		{
			var dist = Vector3.Distance(player.position, target.position);
			return dist <= ActiveDist;
		}
	}
}