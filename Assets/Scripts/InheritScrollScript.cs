using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class InheritScrollScript : MonoBehaviour
{
    [SerializeField]
    [Range(0.125f, 16)]
    float scrollRate = 1;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.localPosition += new Vector3(LevelScrollControlScript.ScrollDirection * scrollRate * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad), 
            LevelScrollControlScript.ScrollDirection * scrollRate * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad), 0);
    }
}
