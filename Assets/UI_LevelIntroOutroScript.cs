﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void LoadNextLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

}
