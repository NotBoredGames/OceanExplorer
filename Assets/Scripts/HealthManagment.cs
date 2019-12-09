using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagment : MonoBehaviour
{

    [SerializeField]
    string subControllerString = "Submarine Info Controller";

    SubmarineSettingsScript subSettings;

    private void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[HealthManagement]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");
    }

    // player takes damage when hit by enemy mine explosion
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Explosion")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
         
        }
    }
 

    

}
