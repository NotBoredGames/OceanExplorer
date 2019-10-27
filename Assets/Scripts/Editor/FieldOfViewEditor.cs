using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfViewScript))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        FieldOfViewScript fovScript = (FieldOfViewScript)target;
        //Handles.color = Color.white;
        Handles.color = new Color(1, 1, 1, 0.5f);

        // normal hardcoded to (0, 0, -1) because of scene layout - bad form, let's see if it works here
        //Handles.DrawWireArc(fovScript.position, Vector3.forward, fovScript.forward, 360, fovScript.viewRadius);
        Handles.DrawWireArc(fovScript.position, Vector3.forward, Vector3.right, 360, fovScript.viewRadius);

        //Vector3 viewAngleMinus = fovScript.DirFromAngle(-fovScript.viewAngle / 2, false);
        //Vector3 viewAnglePlus = fovScript.DirFromAngle(fovScript.viewAngle / 2, false);
        Vector3 viewAngleMinus = (Quaternion.Euler(0, 0, -fovScript.viewAngle / 2) * fovScript.forward).normalized;
        Vector3 viewAnglePlus = (Quaternion.Euler(0, 0, fovScript.viewAngle / 2) * fovScript.forward).normalized;

        //Handles.DrawLine(fovScript.position, fovScript.position + viewAngleMinus * fovScript.viewRadius);
        //Handles.DrawLine(fovScript.position, fovScript.position + viewAnglePlus * fovScript.viewRadius);
        Handles.DrawAAPolyLine(1, new Vector3[] { fovScript.position, fovScript.position + viewAngleMinus * fovScript.viewRadius});
        Handles.DrawAAPolyLine(1, new Vector3[] { fovScript.position, fovScript.position + viewAnglePlus * fovScript.viewRadius });

        //DrawCircleTargets(fovScript);

        //DrawVisibleTargets(fovScript);
    }

    void DrawCircleTargets(FieldOfViewScript fovScript)
    {
        Handles.color = 0.5f * Color.white;
        foreach (Transform t in fovScript.circleTargets)
        {
            //Handles.DrawLine(fovScript.position, t.position);
            Handles.DrawAAPolyLine(1, new Vector3[] { fovScript.position, t.position });
        }
    }

    void DrawVisibleTargets(FieldOfViewScript fovScript)
    {
        Handles.color = Color.black;
        foreach (Transform t in fovScript.visibleTargets)
        {
            //Handles.DrawLine(fovScript.position, t.position);
            Handles.DrawAAPolyLine(2, new Vector3[] { fovScript.position, t.position });
        }
    }
}
