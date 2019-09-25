using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class DestroyOutOfBoundsScript : MonoBehaviour
{
    [SerializeField]
    Vector2 bounds = new Vector2(368, 480);

    int scrollDirection;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        scrollDirection = Globals.ScrollDirection;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollDirection == 1)
        {
            if (rect.localPosition.y > (bounds.y + 128))
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (rect.localPosition.y < (-1 * (bounds.y + 128)))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
