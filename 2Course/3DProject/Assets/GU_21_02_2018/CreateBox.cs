using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    public class CreateBox : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _countObj;
        [SerializeField] private int _offset;


        private void Start()
        {
            CreateObj();
        }

        public void CreateObj()
        {
            Transform root = new GameObject("Root").transform;
            for (var i = 0; i < _countObj; i++)
            {
                Instantiate(_prefab, new Vector3(0, i * _offset, 0), Quaternion.identity, root);
            }
        }

    }
}
