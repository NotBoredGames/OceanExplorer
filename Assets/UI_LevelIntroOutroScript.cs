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
    string levelOutroBool = "StartLevelOutro";


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        bigBlackPanel.enabled = true;

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(this.gameObject);
        //else
            //DontDestroyOnLoad(this.gameObject);
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

    public void LevelOutro()
    {
        bigBlackPanel.enabled = true;
        anim.SetBool(levelOutroBool, true);
    }

    public void LoadSubHub()
    {
        Debug.Log("Running Animation Event LoadSubHub");
        Globals.LoadSubHub();
    }

}
