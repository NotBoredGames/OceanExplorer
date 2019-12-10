using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField]
    string verticalGameplayCanvasString;

    static GameObject verticalGameplayCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        verticalGameplayCanvas = GameObject.Find(verticalGameplayCanvasString);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyUp(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Break();
        }
    }

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

    public static void LevelOutro(int nextLevel)
    {
        UI_LevelIntroOutroScript uiScript = verticalGameplayCanvas.GetComponent<UI_LevelIntroOutroScript>();
        if (uiScript != null)
        {
            uiScript.LevelOutro();
        }
    }
}
