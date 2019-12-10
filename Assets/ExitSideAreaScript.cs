using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSideAreaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function will only be called when button pressed in side area to return to level
    public void ReturnToLevel()
    {


        // this will return the UI back to the UI layer
        //  Invisible.isInvisible = false;

        // will need to resume enemy movement
        // will need to resume submarine movement
        LevelScrollControlScript.Scroll = true; // resumes level scrolling
        Destroy(this.gameObject);
    }
}
