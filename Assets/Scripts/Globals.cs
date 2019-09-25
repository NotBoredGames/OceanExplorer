using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField]
    [Range(-1, 1)]
    int setScrollDirection = 1;

    [SerializeField]
    AnimationCurve setScrollX;

    [SerializeField]
    AnimationCurve setScrollY;

    public static int ScrollDirection { get; set; }
    public static AnimationCurve ScrollX;
    public static AnimationCurve ScrollY;

    // Start is called before the first frame update
    void Start()
    {
        if (setScrollDirection == 0)
            setScrollDirection = (Random.Range(-1, 1) == 0) ? 1 : -1;

        ScrollDirection = setScrollDirection;
        ScrollX = setScrollX;
        ScrollY = setScrollY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyUp(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
    }

    public static float GetScrollSpeedX(float t)
    {
        return ScrollX.Evaluate(t);
    }

    public static float GetScrollSpeedY(float t)
    {
        return ScrollY.Evaluate(t);
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
}
