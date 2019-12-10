using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelIntroOutroScript : MonoBehaviour
{

    Animator anim;

    string levelIntroBool = "LevelIntroComplete";

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScroll(int i)
    {
        if (i == 1)
            LevelScrollControlScript.Scroll = true;
        else if (i == 0)
            LevelScrollControlScript.Scroll = false;
    }

    public void SetLevelIntroComplete()
    {
        anim.SetBool(levelIntroBool, true);
    }
}
