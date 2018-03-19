using Assets.GU_21_02_2018.Scripts.Helpers;

namespace Assets.GU_21_02_2018.Scripts.Interface
{
	public interface ISetHp
	{
		void SetHp(InfoOfCollision info);
		float Hp { get; }
	}
}