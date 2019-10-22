using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ActivatorTriggerScript : MonoBehaviour
{
    [SerializeField]
    [LabelText("Objects Currently in Trigger")]
    List<GameObject> triggeredOBJs = new List<GameObject>();

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
        triggeredOBJs.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Object '" + collision.gameObject.name + "' w/ tag '" + collision.tag + "' exited '" + this.gameObject.name + "'");
        triggeredOBJs.Remove(collision.gameObject);
    }
}
