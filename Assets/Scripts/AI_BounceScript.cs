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
    [Range(0, 10)]
    float speed = 5;

    [SerializeField]
    SubmarineSettingsScript subSettings;

    Vector2 direction = new Vector2(1, 0);

    Vector3 startPos;

    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yTranslate = 0;

        if (inheritScroll)
            yTranslate = LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad) * scrollRate * Time.deltaTime;

        float xTranslate = speed * direction.x * Time.deltaTime;

        transform.Translate(xTranslate, yTranslate, 0);

    }

    private void LateUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        direction.x *= -1;

        if (other.gameObject.tag == "Player")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
            Destroy(this.gameObject);
        }
    }
}
