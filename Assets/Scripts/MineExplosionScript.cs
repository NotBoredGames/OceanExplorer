using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosionScript : MonoBehaviour
{
    [SerializeField]
    LayerMask destructibleTargets;

    int damage = 0;

    // Start is called before the first frame update
    void Awake()
    {
        SubmarineSettingsScript subSettings = GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>();
        damage = subSettings.GetMineDamage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // should probably change to have health/damage taken in objects themselves
    private void OnCollision2D(Collision2D other)
    {

        if (destructibleTargets.ContainsLayer(other.gameObject.layer))
        {

            // Replace with a damage dealing function down the line
            // damage is done within the enemy objects themselves now
            //    Destroy(other.gameObject);
            Debug.Log("Boom");


        }
    }

    public void PlayParticleSystem()
    {
        this.GetComponent<ParticleSystem>().Play();
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
