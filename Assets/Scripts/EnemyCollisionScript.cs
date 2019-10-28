using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
   
    [SerializeField]
    GameObject subController;

    // Start is called before the first frame update
    void Start()
    {
        
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
            SubmarineSettingsScript subSettings = subController.GetComponent<SubmarineSettingsScript>();
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
            Destroy(other.gameObject);
        }

    }
}
