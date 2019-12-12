using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyCollisionScript : MonoBehaviour
{
   
    [SerializeField]
    string subControllerString = "Submarine Info Controller";

    Animator anim;
    SubmarineSettingsScript subSettings;

    float damageTakenTime = 2;
    string damageTakenBool = "DamageTaken";

    public bool canTakeDamage = false;

    // Start is called before the first frame update
    void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[EnemyCollisionScript]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");

        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.LogError("[[EnemyCollisionScript]] Script on GameObject " + this.gameObject.name + " unable to find Animator component!");
    }

    // Update is called once per frame
    void Update()
    {
        canTakeDamage = !anim.GetBool(damageTakenBool);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (canTakeDamage)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
                subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
                StartCoroutine(DamageAnimation());
            }
            else if (other.gameObject.tag == "Tentacle")
            {
                AttackingTentacleScript attackScript = other.gameObject.GetComponent<AttackingTentacleScript>();
                if (attackScript != null && attackScript.isAttacking)
                {
                    StartCoroutine(DamageAnimation());
                }
            }
        }

    }

    IEnumerator DamageAnimation()
    {
        anim.SetBool(damageTakenBool, true);
        this.GetComponentInChildren<Collider2D>().gameObject.layer = LayerMask.NameToLayer("PlayerDamaged");
        yield return new WaitForSeconds(damageTakenTime);
        anim.SetBool(damageTakenBool, false);
        this.GetComponentInChildren<Collider2D>().gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
