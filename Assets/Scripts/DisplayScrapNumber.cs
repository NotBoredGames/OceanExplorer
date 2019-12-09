using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScrapNumber : MonoBehaviour
{
    [SerializeField]
    SubmarineSettingsScript subSettings;

    private int m_CurrentScrap;
    private string display = "{0}"; // has to be in {} for a number
    private TextMeshProUGUI m_Text;

    
    void Start()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

   
    void Update()
    {
        // sets the currentScrap int to the total stored in SubmarineSettingsScript
        m_CurrentScrap = SubmarineSettingsScript.currentScrap;
        // converts the int to a string
        m_Text.text = string.Format(display, m_CurrentScrap);


     //   Debug.Log(m_CurrentScrap);
    }
}
