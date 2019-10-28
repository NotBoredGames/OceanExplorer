using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BounceScript : MonoBehaviour
{
    [SerializeField]
    bool inheritScroll = false;

    [SerializeField]
    [Range(0.125f, 16)]
    float scrollRate = 1;

    [SerializeField]
    Vector2 x_y_Speed = Vector2.one;

    RectTransform rect;
    int direction = 1;

    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(x_y_Speed.x, x_y_Speed.y, 0));
    }

    private void LateUpdate()
    {
        if (inheritScroll)
        rect.localPosition += new Vector3(LevelScrollControlScript.ScrollDirection * scrollRate * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad),
            LevelScrollControlScript.ScrollDirection * scrollRate * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad), 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        x_y_Speed *= new Vector2(-1, 0);
    }
}
