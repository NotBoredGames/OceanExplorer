using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacter : MonoBehaviour
{

    public static bool removeFromScene;

    // Start is called before the first frame update
    void Start()
    {
        removeFromScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        // to remove the instantiated character / scrap pile
        // when leaving side area
        if (removeFromScene == true)
        {
            Destroy(this.gameObject);
        }
    }
}
