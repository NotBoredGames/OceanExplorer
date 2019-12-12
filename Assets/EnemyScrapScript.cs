using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrapScript : MonoBehaviour
{
    [SerializeField]
    GameObject scrap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
            if (gameObject.tag == "PlayerBullet")
            {
                Instantiate(scrap, this.gameObject.transform.position, this.gameObject.transform.rotation);

            }

 
    }
}
