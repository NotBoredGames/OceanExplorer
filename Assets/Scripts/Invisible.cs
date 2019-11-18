using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{

    public static bool isInvisible;

    void Update()
    {
        if (isInvisible == true)
        {
            // this is the invisible layer, camera does not render this
            gameObject.layer = 22;
        }

        else
        {
            // returns to UI layer
            gameObject.layer = 5;
        }
    }
}
