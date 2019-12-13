using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagment : MonoBehaviour
{
    public int HP;

    public string subControllerString = "Submarine Info Controller";

    SubmarineSettingsScript subSettings;

    [SerializeField]
    public AudioClip Enemy_destroy;

    [SerializeField]
    public AudioClip Enemy_damage;

    void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[EnemyHealthManagement]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");
    }

    void Update()
    {
        // if enemy HP reaches 0 or falls below 0
        // enemy will be destroyed
        if(HP <= 0)
        {

            SoundManagerScript.instance.PlaySingle(Enemy_destroy);
            Destroy(gameObject);
        }
    }

    // enemy takes damage when hit by mine explosion or turret fire
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(this.gameObject.name + " had collision with " + other.gameObject.name);
        //if hit by player turret fire
        if (other.gameObject.tag == "PlayerBullet")
        {
            SoundManagerScript.instance.PlaySingle(Enemy_damage);
            HP -= subSettings.GetBulletDamage();
        }
        // if hit by player mine
        else if (other.gameObject.tag == "PlayerMineExplosion")
        {
            HP -= subSettings.GetMineDamage();
        }
    }
}

