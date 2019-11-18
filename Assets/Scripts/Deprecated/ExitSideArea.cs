using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSideArea : MonoBehaviour
{

    public GameObject UI;


    public void ReturnToLevel()
    {
        //UI.SetActive(true); // turn on UI when exiting Side Area
    //    NEW_InheritScrollScript.scrollRate = 2;
        Destroy(this.gameObject);
    }
}
