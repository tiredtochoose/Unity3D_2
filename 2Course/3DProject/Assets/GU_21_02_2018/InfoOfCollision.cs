using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    public struct InfoOfCollision
    {
        private readonly float _damage;
        private readonly Vector3 _direction;

        public InfoOfCollision(float damage, Vector3 direction)
        {
            _damage = damage;
            _direction = direction;
        }

        public float Damage
        {
            get { return _damage; }
        }

        public Vector3 Direction
        {
            get { return _direction; }
        }
    }
}
