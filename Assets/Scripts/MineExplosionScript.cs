using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosionScript : MonoBehaviour
{
    [SerializeField]
    LayerMask destructibleTargets;

    [SerializeField]
    SubmarineSettingsScript subSettings;

    public bool isEnemyMine;

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
        if (destructibleTargets.ContainsLayer(other.gameObject.layer))
        {
            // CURRENTLY NOT WORKING
            // if the mine this is attached to is the enemy mine
            //the enemy mine's explosion can damage player
            if(other.gameObject.tag == "Player")
            {
                if (isEnemyMine == true)
                {
                    subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
                }
            }

            else
            {
                // Replace with a damage dealing function down the line
                Destroy(other.gameObject);
            }
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
