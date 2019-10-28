using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSpotlightScript : MonoBehaviour
{

    [SerializeField]
    bool enableSpotlight = true;

    [SerializeField]
    GameObject[] relevantObjects = new GameObject[] { };
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in relevantObjects)
        {
            obj.SetActive(enableSpotlight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
