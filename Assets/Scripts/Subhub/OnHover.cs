using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    private Color startcolor;
    public GameObject textToShow;
    public DialogTrigger dialogToPlay;
       
    void OnMouseEnter()
    {
        
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
        textToShow.GetComponent<MeshRenderer>().enabled = true;
      
        
            
        

    }
    void OnMouseExit()
    {
        textToShow.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Renderer>().material.color = startcolor;
    }
    void OnMouseDown()
    {
        
        dialogToPlay.TriggerDialog();
    }
}
