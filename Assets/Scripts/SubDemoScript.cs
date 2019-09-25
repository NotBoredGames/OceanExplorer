using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDemoScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] submarines = new GameObject[3];

    [SerializeField]
    GameObject subSpriteCanvas;

    [SerializeField]
    string scale = "1x";

    [SerializeField]
    int index = 0;

    [SerializeField]
    SubMovementScript[] hiddenChildren;
    // Start is called before the first frame update
    void Start()
    {
        hiddenChildren = subSpriteCanvas.gameObject.transform.GetComponentsInChildren<SubMovementScript>(true);

        SetSubSprite();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            StartCoroutine(this.gameObject.GetComponent<RandomSubAppearanceScript>().Randomize());
        }

        if (Input.GetKeyUp(KeyCode.Minus) || Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            if (index == 0)
            {
                index++;
                SetAllInactive();
                submarines[index].SetActive(true);
                SetSubSprite();
            }
            else if (index == 1)
            {
                index++;
                SetAllInactive();
                submarines[index].SetActive(true);
                SetSubSprite();
            }
            else if (index == 2)
            {
                index = 0;
                SetAllInactive();
                submarines[index].SetActive(true);
                SetSubSprite();
            }
        }

        if(Input.GetKeyUp(KeyCode.Equals) || Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            if (scale == "1x")
            {
                scale = "2x";
            }
            else if (scale == "2x")
            {
                scale = "4x";
            }
            else if (scale == "4x")
            {
                scale = "1x";
            }

            SetSubSprite();
        }
    }

    void SetAllInactive()
    {
        foreach (GameObject obj in submarines)
        {
            obj.SetActive(false);
        }
    }

    void SetSpritesInactive()
    {
        for(int i = 0; i < hiddenChildren.Length; i++)
        {
            hiddenChildren[i].gameObject.SetActive(false);
        }
    }

    void SetSubSprite()
    {
        if (submarines[index].GetComponent<LookAtTargetScript>())
        {
            for (int i = 0; i < hiddenChildren.Length; i++)
            {
                string str = scale + " Scale Sub - LookAt";

                if (hiddenChildren[i].name == str)
                {
                    submarines[index].GetComponent<LookAtTargetScript>().SetSubmarineSprite(hiddenChildren[i].gameObject.GetComponent<RectTransform>());
                    SetSpritesInactive();
                    hiddenChildren[i].gameObject.SetActive(true);
                    return;
                }
            }
        }
        else if (submarines[index].GetComponent<SideGunLookAtScript>())
        {
            for (int i = 0; i < hiddenChildren.Length; i++)
            {
                string str = scale + " Scale Sub - Side";

                if (hiddenChildren[i].name == str)
                {
                    submarines[index].GetComponent<SideGunLookAtScript>().SetSubmarineSprite(hiddenChildren[i].gameObject);
                    SetSpritesInactive();
                    hiddenChildren[i].gameObject.SetActive(true);
                    return;
                }
            }
        }
        else if (submarines[index].GetComponent<TopGunLookAtScript>())
        {
            for (int i = 0; i < hiddenChildren.Length; i++)
            {
                string str = scale + " Scale Sub - Top";

                if (hiddenChildren[i].name == str)
                {
                    submarines[index].GetComponent<TopGunLookAtScript>().SetSubmarineSprite(hiddenChildren[i].gameObject);
                    SetSpritesInactive();
                    hiddenChildren[i].gameObject.SetActive(true);
                    return;
                }
            }
        }
    }
}
