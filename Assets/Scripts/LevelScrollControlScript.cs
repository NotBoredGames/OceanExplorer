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

    public static int ScrollDirection { get; set; }
    public static AnimationCurve ScrollX;
    public static AnimationCurve ScrollY;

    [SerializeField]
    bool setScroll = true;
    public static bool Scroll;

    // Start is called before the first frame update
    void Start()
    {
        if (setScrollDirection == 0)
            setScrollDirection = (Random.Range(-1, 1) == 0) ? 1 : -1;

        ScrollDirection = setScrollDirection;
        ScrollX = setScrollX;
        ScrollY = setScrollY;

        Scroll = true;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll = setScroll;
    }

    public static float GetScrollSpeedX(float t)
    {
        if (Scroll)
            return ScrollX.Evaluate(t);
        else return 0;
    }

    public static float GetScrollSpeedY(float t)
    {
        if (Scroll)
            return ScrollY.Evaluate(t);
        else return 0;
    }

    
}
