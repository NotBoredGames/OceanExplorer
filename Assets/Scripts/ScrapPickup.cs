using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPickup : MonoBehaviour
{
    [SerializeField]
    public AudioClip scrap_collect;

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

        //if player collides with scrap
        if (other.gameObject.tag == "Player")
        {
            SoundManagerScript.instance.PlaySingle(scrap_collect);
            // adds scrap to total
            SubmarineSettingsScript.currentScrap += 10; // for upgrades can add a multiplier 
            Destroy(this.gameObject);                 // or create other prefab objs that hold more scrap pieces

        }

        // will pickup scrap when bullet hits it, but less...
        if (other.gameObject.tag == "PlayerBullet")
        {
            SoundManagerScript.instance.PlaySingle(scrap_collect);
            // adds scrap to total
            SubmarineSettingsScript.currentScrap += 5;
            Destroy(this.gameObject);

        }
    }
}