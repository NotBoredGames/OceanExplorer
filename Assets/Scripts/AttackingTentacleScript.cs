using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingTentacleScript : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    int attackDamage = 1;

    [SerializeField]
    string subControllerString;
    SubmarineSettingsScript subSettings;

    [SerializeField]
    string playerLayerName;

    public bool isAttacking = false;

    // Start is called before the first frame update
    void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isAttacking)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
            {
                Debug.Log("[[AttackingTentacleScript]] on " + this.gameObject.name + " detected collision with " + other.gameObject.name);
                isAttacking = false;
                subSettings.SetCurrentHP(subSettings.GetCurrentHP() - attackDamage);
            }
        }
    }

    public void SetIsAttackingTrue ()
    {
        isAttacking = true;
    }

    public void SetIsAttackingFalse()
    {
        isAttacking = false;
    }
}
