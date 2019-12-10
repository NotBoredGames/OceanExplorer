using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class UI_LevelIntroOutroScript : MonoBehaviour
{
    [SerializeField]
    Image bigBlackPanel;

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

    public void SetLevelIntroComplete()
    {
        anim.SetBool(levelIntroBool, true);
        bigBlackPanel.enabled = false;
    }
}
