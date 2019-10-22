using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    [Range(1, 5)]
    float shotDelay = 3;

    [SerializeField]
    Vector2 bounds = new Vector2(368, 480);

    RectTransform rect;
    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        StartCoroutine(FireBulletCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FireBulletCoroutine()
    {
        while (true)
        {
            if (rect.localPosition.y < bounds.y && rect.localPosition.y > -bounds.y)
            {
                if (Globals.GetScrollSpeedY(Time.timeSinceLevelLoad) != 0)
                {
                    GameObject spawnedBullet = Instantiate(bullet, this.transform.parent);
                    spawnedBullet.GetComponent<RectTransform>().localPosition = rect.localPosition;
                    spawnedBullet.name = this.name + " | Bullet " + index++;
                    spawnedBullet.transform.SetAsFirstSibling();
                    yield return new WaitForSeconds(shotDelay);
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
