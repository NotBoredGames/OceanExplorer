

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemyAI_Script : MonoBehaviour
{
    [SerializeField]
    bool inheritScroll = false;

    [SerializeField]
    [Range(0.125f, 16)]
    float scrollRate = 1;

    [SerializeField]
    [Range(0, 20)]
    float speed = 5;
    

    Vector2 direction = new Vector2(-1, 0);

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

        transform.Translate(xTranslate, yTranslate, 0, Space.World);
    }

    private void LateUpdate()
    {

    }

    // change direction when enemy runs into wall
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag != "PlayerBullet")
        {
            //transform.Rotate(0, 180, 0);
            direction *= new Vector2(-1, 1);
        }
        // REASON REMOVED - Duplicate code to method in EnemyCollisionScript.cs
        // attached to Player GameObject
        /*
        if (other.gameObject.tag == "Player")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
            Destroy(this.gameObject);
        }
        */
    }
}

