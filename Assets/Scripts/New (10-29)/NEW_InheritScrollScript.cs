﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW_InheritScrollScript : MonoBehaviour
{
    [SerializeField]
    [Range(0.125f, 16)]
    float scrollRate = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float scrollX = scrollRate * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad) * Time.deltaTime;
        float scrollY = scrollRate * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad) * Time.deltaTime;
        //Debug.Log(scrollY);

        transform.position += new Vector3(scrollX, scrollY, 0);
    }
}
