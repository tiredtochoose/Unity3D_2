using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My3DProject
{
    public class Grenade : BaseAmmunition
    {
        [SerializeField] protected float _detonationTime = 3;
        [SerializeField] protected float _grenadeForce;

        private Rigidbody _enemy;
        private Vector3 _enemyDirection;
        
        private void Start()
        {
            StartCoroutine(GrenadeDetonation());
        }
        
        IEnumerator GrenadeDetonation()
        {
            yield return new WaitForSeconds(_detonationTime);
            GetComponent<SphereCollider>().enabled = true;
            yield return new WaitForSeconds(0.5f); 
            GetComponent<SphereCollider>().enabled = false;
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                _enemy = collider.GetComponent<Rigidbody>();
                _enemyDirection = _enemy.transform.position - transform.position;
                _enemy.AddForce(_enemyDirection * _grenadeForce, ForceMode.Impulse);
                SetDamage(collider.gameObject.GetComponent<ISetHp>());
            }            
        }

        private void SetDamage(ISetHp obj)
        {
            if (obj != null)
                obj.SetHp(new InfoOfCollision(_currentDamage, _enemyDirection));
        }

    }
}
