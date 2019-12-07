using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenMove : MonoBehaviour
{
    Vector3 move = new Vector3(2f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += move;
       if(transform.position.x > 3000)
        {

            transform.position = new Vector3(-777, 109, 0);
           // move = new Vector(0, 0, 0);
        }
        
    }
}
