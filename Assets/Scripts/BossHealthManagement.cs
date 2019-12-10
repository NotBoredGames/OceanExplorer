using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BossHealthManagement : MonoBehaviour
{
    public int HP;

    public string subControllerString = "Submarine Info Controller";
    SubmarineSettingsScript subSettings;

    Animator anim;
    float damageTakenTime = 2;
    string damageTakenBool = "DamageTaken";

    public bool canTakeDamage = false;

    // Start is called before the first frame update
    void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[BossHealthManagement]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");

        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.LogError("[[BossHealthManagement]] Script on GameObject " + this.gameObject.name + " unable to find Animator component!");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            anim.SetBool("isDead", true);

        canTakeDamage = !anim.GetBool(damageTakenBool);
    }

    public void OnChildCollisionEnter2D(Collision2D other, GameObject child)
    {

        //if hit by player turret fire
        if (other.gameObject.tag == "PlayerBullet" && canTakeDamage && anim.GetBool("isOnscreen"))
        {
            HP -= subSettings.GetBulletDamage();
            StartCoroutine(DamageAnimation(child));
        }
        // if hit by player mine
        else if (other.gameObject.tag == "PlayerMineExplosion" && canTakeDamage && anim.GetBool("isOnscreen"))
        {
            HP -= subSettings.GetMineDamage();
            StartCoroutine(DamageAnimation(child));
        }
    }

    IEnumerator DamageAnimation(GameObject obj)
    {
        anim.SetBool(damageTakenBool, true);
        obj.layer = LayerMask.NameToLayer("Non-Collidable");
        yield return new WaitForSeconds(damageTakenTime);
        anim.SetBool(damageTakenBool, false);
        obj.layer = LayerMask.NameToLayer("Enemy");
    }

    public void MakeVulnerable()
    {
        BossDamageTarget[] damageTargets = GetComponentsInChildren<BossDamageTarget>();
        foreach (BossDamageTarget target in damageTargets)
        {
            target.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }

    public IEnumerator DeathActions()
    {
        yield return new WaitForSeconds(0.125f);
        KrakenAttackScript attackScript = GetComponent<KrakenAttackScript>();
        if (attackScript != null)
        {
            attackScript.runCode = false;
            attackScript.enabled = false;
        }

        Rigidbody2D[] bodies = GetComponentsInChildren<Rigidbody2D>();
        if (bodies != null)
        {
            foreach (Rigidbody2D r2d in bodies)
            {
                Debug.Log(r2d.gameObject.name);
                r2d.bodyType = RigidbodyType2D.Dynamic;
                r2d.gravityScale = 1 / 2f;
                r2d.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    public void DestroyKraken()
    {
        Destroy(this.gameObject);
        Globals.LevelOutro(1);
    }
}
