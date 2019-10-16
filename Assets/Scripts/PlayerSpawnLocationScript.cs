using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PlayerSpawnLocationScript : MonoBehaviour
{
    [SerializeField]
    int spawnY = 416;

    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = new Vector3(0, LevelScrollControlScript.ScrollDirection * spawnY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
