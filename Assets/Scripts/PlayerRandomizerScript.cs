using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomizerScript : MonoBehaviour
{
    [SerializeField]
    MeshFilter submarinePattern;

    [SerializeField]
    List<Mesh> patternList;

    // Start is called before the first frame update
    void Start()
    {
        if (patternList.Count > 0)
        {
            int index = Random.Range(0, patternList.Count);
            submarinePattern.mesh = patternList[index];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
