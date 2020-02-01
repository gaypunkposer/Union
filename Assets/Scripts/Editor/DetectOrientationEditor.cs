using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DetectOrientation))]
public class DetectOrientationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DetectOrientation orientation = (DetectOrientation) target;
        if (GUILayout.Button("Rotate Landscape"))
        {
            orientation.enabled = false;
            orientation.onRotateLandscape.Invoke();
        }

        if (GUILayout.Button("Rotate Portrait"))
        {
            orientation.enabled = false;
            orientation.onRotatePortrait.Invoke();
        }
    }
}