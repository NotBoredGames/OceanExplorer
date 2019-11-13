using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrollControlScript : MonoBehaviour
{

    [SerializeField]
    [Range(-1, 1)]
    int setScrollDirection = 1;

    [SerializeField]
    AnimationCurve setScrollX;

    [SerializeField]
    AnimationCurve setScrollY;

    [SerializeField]
    bool scroll = true;

    public static int ScrollDirection { get; set; }
    public static AnimationCurve ScrollX;
    public static AnimationCurve ScrollY;

    public static bool Scroll;

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
        Scroll = scroll;
    }

    public static float GetScrollSpeedX(float t)
    {
        return ScrollX.Evaluate(t);
    }

    public static float GetScrollSpeedY(float t)
    {
        return ScrollY.Evaluate(t);
    }

    
}
