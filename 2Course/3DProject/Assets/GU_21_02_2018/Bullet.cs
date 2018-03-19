using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My3DProject
{
    public class Bullet : BaseAmmunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            SetDamage(collision.gameObject.GetComponent<ISetHp>());
            Destroy(InstanceObject);
        }

        private void SetDamage(ISetHp obj)
        {
            if (obj != null) obj.SetHp(new InfoOfCollision(_currentDamage, transform.forward));
        }
    }
}
