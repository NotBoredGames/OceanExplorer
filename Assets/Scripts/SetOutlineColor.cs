using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

[RequireComponent(typeof(NicerOutline))]
public class SetOutlineColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (RandomSubAppearanceScript.outlineColor.Equals(Color.clear))
            GetComponent<NicerOutline>().effectColor = Color.white;
        else
            GetComponent<NicerOutline>().effectColor = new Color (1, 1, 1, RandomSubAppearanceScript.outlineColor.a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
