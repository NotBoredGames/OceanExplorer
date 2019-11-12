using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class ActivatorTriggerScript : MonoBehaviour
{
    [SerializeField]
    [LabelText("Objects Currently in Trigger")]
    List<GameObject> triggeredOBJs = new List<GameObject>();

    [SerializeField]
    List<string> scriptsToActivate = new List<string>();

    [SerializeField]
    List<string> scriptsToDeactivate = new List<string>();

    [SerializeField]
    LayerMask layersToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        triggeredOBJs.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object '" + collision.gameObject.name + "' w/ tag '" + collision.tag + "' entered '" + this.gameObject.name + "'");
        if (!triggeredOBJs.Contains(collision.gameObject))
            triggeredOBJs.Add(collision.gameObject);

        foreach (string script in scriptsToActivate)
        {
            if (collision.gameObject.GetComponent(script) != null)
            {
                var scriptVar = collision.gameObject.GetComponent(script);
                Behaviour behaviour = scriptVar as Behaviour;

                behaviour.enabled = true;
            }
        }

        foreach (string script in scriptsToDeactivate)
        {
            if (collision.gameObject.GetComponent(script) != null)
            {
                var scriptVar = collision.gameObject.GetComponent(script);
                Behaviour behaviour = scriptVar as Behaviour;

                behaviour.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Object '" + other.gameObject.name + "' w/ tag '" + other.tag + "' exited '" + this.gameObject.name + "'");
        triggeredOBJs.Remove(other.gameObject);

        if(layersToDestroy.ContainsLayer(other.gameObject.layer))
            Destroy(other.gameObject, 0);
    }
}
