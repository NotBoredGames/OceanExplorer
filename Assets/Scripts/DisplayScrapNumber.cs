using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScrapNumber : MonoBehaviour
{
    [SerializeField]
    string subControllerString = "Submarine Info Controller";

    SubmarineSettingsScript subSettings;

    private int m_CurrentScrap;
    private string display = "{0:D6}"; // has to be in {} for a number
    private TextMeshProUGUI m_Text;

    
    void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[DisplayScrapNumber]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");

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
