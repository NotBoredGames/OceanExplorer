using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagment : MonoBehaviour
{

    [SerializeField]
    SubmarineSettingsScript subSettings;


    // player takes damage when hit by enemy mine explosion
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Explosion")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
         
        }
    }
 

    

}
