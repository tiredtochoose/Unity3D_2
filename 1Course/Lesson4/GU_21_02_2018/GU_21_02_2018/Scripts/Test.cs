using UnityEngine;

namespace Assets.GU_21_02_2018.Scripts
{
	public class Test : MonoBehaviour
	{
		//public delegate void Task();
		//private void Start()
		//{
		//	Invoke(MessageConsole, 3);
		//}

		//private void MessageConsole()
		//{
		//	Debug.Log(42);
		//}

		//public void Invoke(Task task, float time)
		//{
		//	Invoke(task.Method.Name, time);
		//}

		public Transform Player;
		public Transform Target;
		private bool _isVision;
		private void Update()
		{
			RaycastHit hit;
			
			
			if (Physics.Linecast(Player.position, Target.position, out hit))
			{
				_isVision = hit.transform == Target;
			}

			if (_isVision)
			{
				Debug.DrawLine(Player.position, Target.position, Color.green);
			}
			else
			{

				Debug.DrawLine(Player.position, Target.position, Color.red);
			}
		}
	}

}