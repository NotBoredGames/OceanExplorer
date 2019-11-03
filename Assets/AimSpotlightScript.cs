using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSpotlightScript : MonoBehaviour
{
    [SerializeField]
    NEW_TurretAimScript aimTurretScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 projectedAim = Vector3.ProjectOnPlane(aimTurretScript.GetAimVector(), -Vector3.forward);
        //transform.localRotation = Quaternion.LookRotation(aimTurretScript.GetAimVector(), Vector3.up);
        if (aimTurretScript.GetAimVector().x <= 0)
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(Vector3.up, projectedAim));
        else
            transform.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(Vector3.up, projectedAim));
    }
}
