using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My3DProject
{
    public class Box : BaseObjectScene, ISetHp
    {
        [SerializeField] private float _hp;
        private float _timeDest = 10;

        public float Hp
        {
            get { return _hp; }
            private set { _hp = value; }
        }

        public void SetHp(InfoOfCollision info)
        {
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                Destroy(InstanceObject, _timeDest);
            }
        }
    }
}