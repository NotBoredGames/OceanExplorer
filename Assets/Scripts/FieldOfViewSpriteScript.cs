using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewSpriteScript : MonoBehaviour
{
    [SerializeField]
    RenderTexture renderTexture;

    [SerializeField]
    Sprite renderSprite;

    SpriteRenderer spriteRenderer;
    SpriteMask spriteMask;

    // Start is called before the first frame update
    void Awake()
    {
        //renderTexture.width = 1920;
        //renderTexture.height = 1080;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //spriteRenderer.sprite = Sprite.Create(ToTexture2D(renderTexture), 
            //new Rect(0, 0, renderTexture.width, renderTexture.height),
            //new Vector2(0.5f, 0.5f));
        spriteMask.sprite = Sprite.Create(ToTexture2D(renderTexture),
            new Rect(0, 0, renderTexture.width, renderTexture.height),
            new Vector2(0.5f, 0.5f), 1);
    }

    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, true);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
