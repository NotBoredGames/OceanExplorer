using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapBundleScript : MonoBehaviour
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
        // if the player or the turret bullet comes in to contact
        // with the scrap bundle, it will drop 5 scrap pieces at the bundle's location
        // totaling 50 scrap

            if (other.gameObject.tag == "PlayerBullet")
            {
                Instantiate(scrap, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }

            if (other.gameObject.tag == "Player")
            {
                Instantiate(scrap, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
        
    }
}
