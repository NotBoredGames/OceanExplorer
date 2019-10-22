using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyUp(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);

        if (Input.GetKeyUp(KeyCode.P))
            Debug.Break();
    }

    /// <summary>
    /// FindDeepChild: returns a child that is some descendent of the parent object
    /// </summary>
    /// <param name="aParent">The object the target is a descendent of [Type: Transform]</param>
    /// <param name="aName">The name of the target [Type: string]</param>
    /// <returns>The transform of the target object</returns>

    public static Transform FindDeepChild(Transform aParent, string aName)
    {
        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(aParent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == aName)
                return c;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }
}
