using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 10f;

    [SerializeField]
    SubmarineSettingsScript subSettings;

    void Start()
    {

    }

    void Update()
    {
        //rotate to look at the player
        //transform.LookAt(target.position);
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
        transform.up = (target.position - transform.position).normalized;

        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)

        {//move if distance from target is greater than 1
            //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
            Destroy(this.gameObject);
        }
    }

}
