using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    int setStartHealth;

    [SerializeField]
    private int currHealth = 1;
    // Start is called before the first frame update
    void Awake()
    {
        currHealth = setStartHealth;
        if (currHealth <= 0)
            currHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            // @TODO: Create scrap, Destroy this.gameObject
            Debug.Log(this.gameObject.name + ": Health is 0, Destroying!");
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(int i)
    {
        currHealth = i;
    }

    public int GetHealth()
    {
        return currHealth;
    }
}
