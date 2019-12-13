using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeFoundTextScript : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
   
    void Start()
    {
        m_Text.text = "Thank You for Finding Me! \n I can help upgrade your ship.";

    }

    /*
    void Update()
    {
        // once all of the crew members have been found change 
        // the text for finding extra scrap
        if (SubmarineSettingsScript.foundScrap == true)
        {
           
            m_Text.text = "Captain Alden found more Scrap!";
        }

    }
    */
}
