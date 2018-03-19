using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using My3DProject;

[CustomEditor(typeof(CreateBox))]
public class CreateBoxEditor : Editor
{
    private bool _isPressButtonOk;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CreateBox tar = (CreateBox)target;

        var isPressButton = GUILayout.Button("Создание объектов по кнопке", EditorStyles.miniButton);
        if (isPressButton)
        {
            tar.CreateObj();
            _isPressButtonOk = true;
        }
        if (_isPressButtonOk)
        {
            EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
        }

    }


}
