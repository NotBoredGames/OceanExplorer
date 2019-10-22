using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    Transform parent;

    [SerializeField]
    [Range(10, 100)]
    int numEnemies = 25;

    [SerializeField]
    int maxX = 23;

    [SerializeField]
    int minY = 34;

    [SerializeField]
    int unitSizeX = 64;

    [SerializeField]
    int unitSizeY = 32;

    int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        int scrollDirection = LevelScrollControlScript.ScrollDirection;
        StartCoroutine(GenerateEnemiesRoutine(scrollDirection));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateEnemiesRoutine(int scrollDirection)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            
            int spawnX = (int)(((Random.Range(0, 2) - 0.5f) * 2) * Random.Range(0, maxX + 1) * unitSizeX);
            int spawnY = -scrollDirection * Random.Range(minY, 50 + 1) * unitSizeY;
            GameObject spawnedEnemy = Instantiate(enemy, parent);
            spawnedEnemy.GetComponent<RectTransform>().localPosition = new Vector3(spawnX, spawnY, 0);
            spawnedEnemy.name = "Enemy" + index++;
            spawnedEnemy.transform.SetAsFirstSibling();

            yield return new WaitForSeconds(.125f);
        }
    }
}
