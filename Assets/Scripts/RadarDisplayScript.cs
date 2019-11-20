using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDisplayScript : MonoBehaviour
{

    [SerializeField]
    RawImage radarTexture;

    [SerializeField]
    RadarRenderScript renderScript;

    float renderDelay;
    float t = -1;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        renderDelay = renderScript.renderDelay;
        t = renderDelay;
        anim = GetComponent<Animator>();

        radarTexture.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (t >= 0)
            t -= Time.deltaTime;
        else
        {
            //anim.Play("RadarPulse", -1, 0);
            t = renderDelay;
        }

        radarTexture.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, t / renderDelay));
    }
    
}
