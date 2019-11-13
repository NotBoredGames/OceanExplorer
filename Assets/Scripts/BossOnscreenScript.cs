using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOnscreenScript : MonoBehaviour
{

    [SerializeField]
    BoxCollider2D activator;

    [SerializeField]
    string scriptActivatorName;

    Collider2D scriptActivator;

    // Start is called before the first frame update
    void Start()
    {
        scriptActivator = GameObject.Find(scriptActivatorName).GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptActivator.bounds.Intersects(activator.bounds))
        {
            Debug.Log("Boss " + this.gameObject.name + " is onscreen!");
            LevelScrollControlScript.Scroll = false;
            this.gameObject.GetComponent<Animator>().SetBool("isOnscreen", true);
            this.gameObject.GetComponent<KrakenAttackScript>().enabled = true;
            
            if (activator.gameObject != this.gameObject)
            {
                activator.gameObject.SetActive(false);
                this.enabled = false;
            }
        }
    }
}
