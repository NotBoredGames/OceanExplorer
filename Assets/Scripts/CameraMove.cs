using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(0f, -.03f, 0f * Time.deltaTime);

        }
    }
}
