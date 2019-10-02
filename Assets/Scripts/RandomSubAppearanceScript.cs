using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSubAppearanceScript : MonoBehaviour
{
    [SerializeField]
    Color _outlineColor = Color.white;

    [SerializeField]
    Material _outlineMat;

    [SerializeField]
    Camera _outlineCamera;

    [SerializeField]
    Material _paintMat;

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

        _outlineMat.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 1);
        _outlineCamera.backgroundColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0);

        _paintMat.color = new Color(paintR, paintG, paintB, 1);

        if (patternList.Count > 0)
        {
            yield return new WaitForSeconds(1/32);
            int index = Random.Range(0, patternList.Count);
            foreach(MeshFilter pattern in submarinePatterns)
                pattern.mesh = patternList[index];
        }

        yield return new WaitForSeconds(0.125f);
    }
}
