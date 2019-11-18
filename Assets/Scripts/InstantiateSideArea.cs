using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSideArea : MonoBehaviour
{
    public GameObject sideArea;
    public GameObject UI;
  //  public GameObject Player;

    // function will only be called when player collides with vortex in level 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("plz halp");



            // Changes bool that puts UI on the Invisible layer
            Invisible.isInvisible = true;
            
            // will need to disable enemy movement
            // will need to disable submarine movement
            LevelScrollControlScript.Scroll = false; // disable level scrolling
            Instantiate(sideArea);
            Destroy(this.gameObject); // removes vortex from level
        }

    }

    // function will only be called when button pressed in side area to return to level
    public void ReturnToLevel()
    {


        // this will return the UI back to the UI layer
        Invisible.isInvisible = false;

        // will need to resume enemy movement
        // will need to resume submarine movement
        LevelScrollControlScript.Scroll = true; // resumes level scrolling
        Destroy(this.gameObject);
    }
}
