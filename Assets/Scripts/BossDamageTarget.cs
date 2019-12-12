using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageTarget : MonoBehaviour
{
    [SerializeField]
    GameObject parentWithBossHealthScript;

    // Start is called before the first frame update
    void Start()
    {
        if (parentWithBossHealthScript.GetComponent<BossHealthManagement>() == null)
            Debug.LogError("[[BossDamageTarget]] Script on GameObject " + gameObject.name + " encountered error!  Parent " + parentWithBossHealthScript.name + " requires script of type BossHealthManagement!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        parentWithBossHealthScript.GetComponent<BossHealthManagement>().OnChildCollisionEnter2D(other, this.gameObject);
    }
}
