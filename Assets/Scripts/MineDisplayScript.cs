using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class MineDisplayScript : MonoBehaviour
{

    [SerializeField]
    SubmarineSettingsScript subSettings;

    [InfoBox("Leave off final whitepace and any number (ie \"HP\", not \"HP \"")]
    [SerializeField]
    string childPrefixString;

    [SerializeField]
    float padding = 4;

    int maxMines = -1;
    int currentMines = -1;
    float containerWidth = -1;
    Image[] children;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        containerWidth = this.gameObject.GetComponent<RectTransform>().rect.width;
        children = this.transform.GetComponentsInChildren<Image>();

        char[] trimArray = { ' ', ',', '.'};
        childPrefixString = childPrefixString.TrimEnd(trimArray);
    }

    // Set variables here that may change in between levels (ie from upgrade during hub level)
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("[[MineDisplayScript]] Level Loaded: " + scene.name + " [LoadSceneMode = " + mode + "]");

        maxMines = subSettings.GetMaxMines();
        currentMines = subSettings.GetCurrentMines();

        Set_Max_Mine_Display();
    }

    // Update is called once per frame
    void Update()
    {
        currentMines = subSettings.GetCurrentMines();

        Set_Current_Mine_Display();
    }

    void Set_Max_Mine_Display()
    {
        float width = (containerWidth / maxMines) - padding;
        
        foreach (Image child in children)
        {
            string name = child.gameObject.name;
            int i = Convert.ToInt16(name.Substring(childPrefixString.Length));

            if (i > maxMines)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            }
            
        }
    }

    void Set_Current_Mine_Display()
    {
        for(int i = 0; i < maxMines; i++)
        {
            string name = children[i].gameObject.name;
            int num = Convert.ToInt16(name.Substring(childPrefixString.Length));

            if (num <= currentMines)
            {
                children[i].color = new Color(children[i].color.r, children[i].color.g, children[i].color.b, 1);
            }
            else
            {
                children[i].color = new Color(children[i].color.r, children[i].color.g, children[i].color.b, 1/8f);
            }
        }
    }
}
