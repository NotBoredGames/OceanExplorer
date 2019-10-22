using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurntableScript : MonoBehaviour
{
    [SerializeField]
    AnimationCurve translationX;

    [SerializeField]
    AnimationCurve translationY;

    [SerializeField]
    AnimationCurve translationZ;

    [SerializeField]
    AnimationCurve rotationX;

    [SerializeField]
    AnimationCurve rotationY;

    [SerializeField]
    AnimationCurve rotationZ;

    [SerializeField]
    uint loopTime = 60;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float transX = translationX.Evaluate(Time.timeSinceLevelLoad % loopTime);
        float transY = translationY.Evaluate(Time.timeSinceLevelLoad % loopTime);
        float transZ = translationZ.Evaluate(Time.timeSinceLevelLoad % loopTime);

        this.transform.position = startPos + new Vector3(transX, transY, transZ);

        float rotX = rotationX.Evaluate(Time.timeSinceLevelLoad % loopTime);
        float rotY = rotationY.Evaluate(Time.timeSinceLevelLoad % loopTime);
        float rotZ = rotationZ.Evaluate(Time.timeSinceLevelLoad % loopTime);

        this.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }
}
