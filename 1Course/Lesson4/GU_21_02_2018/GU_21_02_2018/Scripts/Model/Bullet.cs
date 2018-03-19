using Assets.GU_21_02_2018.Scripts.Helpers;
using Assets.GU_21_02_2018.Scripts.Interface;
using GeekBrains.Helpers;
using UnityEngine;

namespace Assets.GU_21_02_2018
{
	public class Bullet : BaseAmmunition
	{
		[SerializeField] private BulletProjector _bulletProjector;
		private void OnCollisionEnter(UnityEngine.Collision collision)
		{
			SetDamage(collision.gameObject.GetComponent<ISetHp>());
			Destroy(InstanceObject);
			var contact = collision.contacts[0];
			CreateDecal(contact, collision.transform);
		}

		private void SetDamage(ISetHp obj)
		{
			if (obj != null) obj.SetHp(new InfoOfCollision(_currentDamage, transform.forward));
		}

		private void CreateDecal(ContactPoint contact, Transform objCollision)
		{
			var projectorRotation = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
			if (_bulletProjector != null)
			{
				var obj = Instantiate(_bulletProjector, contact.point + contact.normal * 0.25f, projectorRotation, objCollision);
				obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
			}
		}
	}
}