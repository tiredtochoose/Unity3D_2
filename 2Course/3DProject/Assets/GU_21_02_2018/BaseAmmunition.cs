using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    public abstract class BaseAmmunition : BaseObjectScene
    {
        [SerializeField] protected float _timeToDestruct = 10;
        [SerializeField] protected float _baseDamage = 10;

        protected float _currentDamage;
        protected override void Awake()
        {
            base.Awake();
            Destroy(InstanceObject, _timeToDestruct);
            _currentDamage = _baseDamage;
        }
    }
}
