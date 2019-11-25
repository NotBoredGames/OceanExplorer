using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveRight : MonoBehaviour
{


    // Update is called once per frame
    void OnMouseOver()
    {
        Camera.main.transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
    }
       
}
