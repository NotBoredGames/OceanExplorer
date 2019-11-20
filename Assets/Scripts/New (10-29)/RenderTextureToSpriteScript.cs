using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class RenderTextureToSpriteScript : MonoBehaviour
{
    [SerializeField]
    RenderTexture renderTexture;

    [InfoBox("Refresh Rate = # of times over a second (ie - 30 frames per second)")]
    [SerializeField, Range(1, 60)]
    int spriteRefreshRate = 10;

    [SerializeField]
    FilterMode spriteFilterMode = FilterMode.Point;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(RenderSprite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.filterMode = spriteFilterMode;
        //tex.wrapMode = TextureWrapMode.Clamp;
        tex.Apply();
        return tex;
    }

    IEnumerator RenderSprite()
    {
        while(true)
        {
            Texture2D newSprite = ToTexture2D(renderTexture);
            //yield return new WaitForEndOfFrame();
            spriteRenderer.sprite = Sprite.Create(newSprite,
                new Rect(0, 0, renderTexture.width, renderTexture.height),
                new Vector2(0.5f, 0.5f), 1, 0, SpriteMeshType.FullRect);
            yield return new WaitForSecondsRealtime(1 / (float)spriteRefreshRate);
        }
    }
}
