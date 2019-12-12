using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getScrapCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = ""+GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount;
    }
}
