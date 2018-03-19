using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
#if UNITY_EDITOR
using UnityEditor;
#endif



namespace My3DProject
{
    public class TestFlags : MonoBehaviour
    {
        public float count = 42;
        public int step = 2;
        private void Start()
        {
#if UNITY_EDITOR
            for (var i = 0; i < count; i++)
            {
                EditorUtility.DisplayProgressBar("Загрузка", " проценты {0}".MyFormat(i), i / count);
                Thread.Sleep(step * 100);
            }
            EditorUtility.ClearProgressBar();
            var isPressed = EditorUtility.DisplayDialog("Вопрос", "А оно тебе нужно ? ", "Ага", "Или нет");
        if (isPressed)
            {
                EditorApplication.isPaused = true;
                //EditorApplication.isPlaying = false; //закрывается игра

            }
#endif
        }

    }
}
