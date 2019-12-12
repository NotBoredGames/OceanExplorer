using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveLeft : MonoBehaviour
{


    
    void OnMouseOver()
    {
        Camera.main.transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));

    }
    void Update()
    {
        
    }
}
