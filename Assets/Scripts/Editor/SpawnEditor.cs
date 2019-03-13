using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AISpawner))]
public class SpawnEditor : Editor
{
    AISpawner MySpawner;
    Transform HandleTransform;
    Quaternion HandleRotation;
    int selected = -1;

    private void OnSceneGUI()
    {
        MySpawner = (AISpawner)target;
        HandleTransform = MySpawner.transform;
        HandleRotation = (Tools.pivotRotation == PivotRotation.Local) ? HandleTransform.rotation : Quaternion.identity;

        for (int i = 0; i < MySpawner.SpawnPoints.Count; i++)
        {
            Vector2 point = MySpawner.SpawnPoints[i];

            //If handle is pressed
            if (Handles.Button(MySpawner.SpawnPoints[i], Quaternion.identity, 0.5f, 0.5f, Handles.SphereHandleCap))
            {
                Repaint();
                selected = i;
            }

            if (selected == i)
            {
                EditorGUI.BeginChangeCheck();
                point = Handles.DoPositionHandle(point, HandleRotation);

                if (EditorGUI.EndChangeCheck())
                {
                    EditorUtility.SetDirty(MySpawner);
                    Undo.RecordObject(MySpawner, "Moved point");
                    MySpawner.SpawnPoints[i] = point;
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        MySpawner = (AISpawner)target;
        EditorGUILayout.LabelField("SpawnPoints");


        for (int i = 0; i < MySpawner.SpawnPoints.Count; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector2 Point = EditorGUILayout.Vector2Field("SpawnPoint " + i, MySpawner.SpawnPoints[i]);

            if (EditorGUI.EndChangeCheck())
            {
                MySpawner.SpawnPoints[i] = Point;
                Undo.RecordObject(MySpawner, "Value Changed");

                EditorUtility.SetDirty(MySpawner);
            }
        }

        if (GUILayout.Button("Add SpawnPoint"))
        {
            MySpawner.SpawnPoints.Add(new Vector2());
        }

        if (GUILayout.Button("Remove SpawnPoint"))
        {
            if (MySpawner.SpawnPoints.Count > 0)
                MySpawner.SpawnPoints.RemoveAt(MySpawner.SpawnPoints.Count - 1);

        }
        base.OnInspectorGUI();
    }
}
