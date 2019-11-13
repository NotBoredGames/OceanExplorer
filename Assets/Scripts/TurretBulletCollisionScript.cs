using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletCollisionScript : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Hit something");
        if (other.transform.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy.");
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
    }
}
