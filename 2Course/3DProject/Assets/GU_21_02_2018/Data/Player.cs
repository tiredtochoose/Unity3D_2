using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    public struct Player
    {
        [SerializeField] private float _hp;
        [SerializeField] private string _name;
        [SerializeField] private bool _isVisible;

        public Player (float hp, string name, bool isVisible)
        {
            _hp = hp;
            _name = name;
            _isVisible = isVisible;
        }

        public float Hp
        {
            get
            {
                return _hp;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
        }

        public override string ToString()
        {
            return "Name {0} Hp {1} IsVisible".MyFormat(Name, Hp, IsVisible);
        }
    }
}