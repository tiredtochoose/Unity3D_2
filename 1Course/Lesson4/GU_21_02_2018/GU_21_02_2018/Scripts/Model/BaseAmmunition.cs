﻿using UnityEngine;

namespace Assets.GU_21_02_2018
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