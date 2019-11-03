using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletCollisionScript : MonoBehaviour
{
  
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Hit something");
        if (col.transform.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy.");
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if (col.transform.tag == "Environment")
        {
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible()
    {
        //Debug.Log("Object offscreen, destroying...");
        Destroy(gameObject);
    }
}
