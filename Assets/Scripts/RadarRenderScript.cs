using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RadarRenderScript : MonoBehaviour
{

    [SerializeField]
    [Range(0, 10)]
    public int renderDelay = 5;

    Camera cam;
    RenderTexture rTex;

    // Start is called before the first frame update
    void Awake()
    {
        cam = this.GetComponent<Camera>();
        rTex = cam.targetTexture;

        Debug.Log(cam.name);
        Debug.Log(rTex.name);

        StartCoroutine(RenderWithDelay(renderDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RenderWithDelay(float t)
    {
        while (true)
        {
            cam.enabled = true;
            cam.Render();
            cam.enabled = false;

            yield return new WaitForSeconds(t);
        }
    }
}
