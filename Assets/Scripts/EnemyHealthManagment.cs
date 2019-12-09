using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagment : MonoBehaviour
{
    public int HP;

    void Start()
    {
        
    }

    void Update()
    {
        // if enemy HP reaches 0 or falls below 0
        // enemy will be destroyed
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // enemy takes damage when hit by mine explosion or turret fire
    private void OnCollisionEnter2D(Collision2D other)
    {

        //if hit by player turret fire
        if (other.gameObject.tag == "PlayerBullet")
        {
            // multiply for marine biologist upgrades
            HP -= 1;

        }

        // if hit by player mine
        if (other.gameObject.tag == "PlayerMineExplosion")
        {
            HP -= 25;

        }
    }
}
