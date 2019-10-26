using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyOnHit : MonoBehaviour
{
  
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit something");
        if (col.transform.tag == "Enemy")
        {
            Debug.Log("Hit Enemy.");
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Debug.Log("Object offscreen, destroying...");
        Destroy(gameObject);
    }
}
