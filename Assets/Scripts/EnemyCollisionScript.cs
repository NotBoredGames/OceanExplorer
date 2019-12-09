using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
   
    [SerializeField]
    string subControllerString = "Submarine Info Controller";

    SubmarineSettingsScript subSettings;

    // Start is called before the first frame update
    void Start()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[EnemyCollisionScript]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
            Destroy(other.gameObject);
        }

    }
}
