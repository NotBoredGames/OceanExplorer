using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletCollisionScript : MonoBehaviour
{
    int damage = 0;

    private void Awake()
    {
        SubmarineSettingsScript subSettings = GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>();
        damage = subSettings.GetBulletDamage();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Hit something");
        if (other.transform.tag == "Enemy")
        {
            EnemyHealthScript enemyHP = other.gameObject.GetComponent<EnemyHealthScript>();
            enemyHP.SetHealth(enemyHP.GetHealth() - damage);
        }

        Destroy(this.gameObject);
    }

    public void SetDamage(int i)
    {
        damage = i;
    }
}
