using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW_RandomizeAppearanceScript : MonoBehaviour
{
    [SerializeField]
    Color _outlineColor = Color.white;

    [SerializeField]
    SpriteOutline spriteOutline;

    [SerializeField]
    Material _paintMat;

    [SerializeField]
    bool setSubPattern = true;

    [SerializeField]
    MeshFilter[] submarinePatterns;

    [SerializeField]
    List<Mesh> patternList;

    [SerializeField]
    bool randomizeOutlineColor = false;

    public static Color outlineColor { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (setSubPattern)
            StartCoroutine(Randomize());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backslash))
        {
            StartCoroutine(Randomize());
        }
    }

    public IEnumerator Randomize()
    {
        float paintR = Random.Range(0.5f, 1f);
        float paintG = Random.Range(0.5f, 1f);
        float paintB = Random.Range(0.5f, 1f);

        float outlineR = Random.Range(0.5f, 1f);
        float outlineG = Random.Range(0.5f, 1f);
        float outlineB = Random.Range(0.5f, 1f);

        if (randomizeOutlineColor)
        {
            outlineColor = new Color(outlineR, outlineG, outlineB, _outlineColor.a);
        }
        else
        {
            outlineColor = _outlineColor;
        }

        spriteOutline.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 1);

        _paintMat.color = new Color(paintR, paintG, paintB, 1);

        if (patternList.Count > 0 && setSubPattern)
        {
            yield return new WaitForSeconds(1 / 32);
            int index = Random.Range(0, patternList.Count);
            foreach (MeshFilter pattern in submarinePatterns)
                pattern.mesh = patternList[index];
        }

        yield return new WaitForSeconds(0.125f);
    }
}
