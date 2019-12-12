using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    float t = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Image>()));


    }

    public IEnumerator FadeTextToFullAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        yield return new WaitForSeconds(6);
        while (i.color.a < 1.0f)
        {

            t = 10.0f;
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
