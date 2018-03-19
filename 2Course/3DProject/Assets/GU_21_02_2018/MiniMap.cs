using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

namespace My3DProject
{
    class MiniMap : MonoBehaviour
    {
        private Transform _player;
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        private void LateUpdate()
        {
            Vector3 newPosition = _player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}
