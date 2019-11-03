using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, .01f, 0f * Time.deltaTime);
        
    }
}
