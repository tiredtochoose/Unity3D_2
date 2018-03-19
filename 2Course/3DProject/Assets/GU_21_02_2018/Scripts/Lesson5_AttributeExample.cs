using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My3DProject
{
    [ExecuteInEditMode]
    public class Lesson5_AttributeExample : MonoBehaviour
    {
        //public Color color = Color.red;
        private void Update()
        {


            GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
        }
    }
}
