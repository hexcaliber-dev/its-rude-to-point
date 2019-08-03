using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (CurvedText))]
public class CurvedTextEditor : Editor {
    public override void OnInspectorGUI () {
        DrawDefaultInspector ();
    }
}