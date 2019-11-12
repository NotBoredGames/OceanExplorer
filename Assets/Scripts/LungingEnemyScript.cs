using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungingEnemyScript : MonoBehaviour
{
    [SerializeField]
    LayerMask detectionLayers;

    [SerializeField]
    [Range(0, 5)]
    float setWindUpTime = 4;

    [SerializeField]
    [Range(0.0625f, 2)]
    float setLungeTime = 0.5f;

    [SerializeField]
    [Range(1, 5)]
    int lungeDamage = 1;

    [SerializeField]
    SubmarineSettingsScript subController;

    [SerializeField]
    GameObject player;

    float tripwireDist = 100;
    bool detectedPlayer;
    bool readyToAttack;
    bool hasAttacked;
    
    Vector3 playerPos;
    
    float windUpTime;
    float lungeTime;
    Vector3 vel = Vector3.zero;
    GameObject returnPoint;

    // Awake is called right when the object is instantiated
    void Awake()
    {
        detectedPlayer = false;
        readyToAttack = false;
        hasAttacked = false;
        windUpTime = -1;
        lungeTime = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // This section handles movement of the enemy to detect and target the player
        if (!detectedPlayer)
            Detect();
        if (detectedPlayer && !readyToAttack)
        {
            WindUp();
            SetReturnPoint();
        }
        if (readyToAttack && !hasAttacked)
            Attack();
        if (hasAttacked)
        {
            ResetEnemy();
        }


        // This section handles when the enemy is able to be hit by bullets
        // or when it is able to hit the player
        if (!readyToAttack)
            this.gameObject.layer = LayerMask.NameToLayer("Non-Collidable");
        else
            this.gameObject.layer = LayerMask.NameToLayer("Enemy");

        if (!readyToAttack)
            GetComponent<NEW_InheritScrollScript>().enabled = true;
    }

    void Detect()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, tripwireDist, detectionLayers);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, tripwireDist, detectionLayers);

        if (rightHit)
        {
            if (rightHit.collider.gameObject.layer == player.layer)
            {
                Debug.DrawRay(transform.position, Vector2.right * rightHit.distance, Color.red);
                detectedPlayer = true;
            }
            else
                Debug.DrawRay(transform.position, Vector2.right * tripwireDist, Color.white);
        }

        if (leftHit)
        {
            if (leftHit.collider.gameObject.layer == player.layer)
            {
                Debug.DrawRay(transform.position, Vector2.left * leftHit.distance, Color.red);
                detectedPlayer = true;
            }
            else
                Debug.DrawRay(transform.position, Vector2.left * tripwireDist, Color.white);
        }

    }

    void WindUp()
    {
        if (windUpTime == -1)
            windUpTime = setWindUpTime;

        if (windUpTime > 0)
        {
            //Debug.Log("WindUP: t = " + windUpTime);
            windUpTime -= Time.deltaTime;
            transform.right = player.transform.position - this.transform.position;
        }
        else
        {
            //Debug.Log("ATTACK!");
            readyToAttack = true;
            playerPos = player.transform.position;
            GetComponent<NEW_InheritScrollScript>().enabled = false;
        }
    }

    void Attack()
    {
        Debug.DrawLine(transform.position, playerPos, Color.red);

        if (lungeTime == -1)
            lungeTime = setLungeTime;

        if (lungeTime > 0)
        {
            lungeTime -= Time.deltaTime;
            transform.position = Vector3.Lerp(returnPoint.transform.position, playerPos, 1 - lungeTime / setLungeTime);
        }
        else
        {
            hasAttacked = true;
            lungeTime = -1;
        }
    }

    void ResetEnemy()
    {
        if (lungeTime == -1)
            lungeTime = setLungeTime;

        if (lungeTime > 0)
        {
            lungeTime -= Time.deltaTime;
            transform.position = Vector3.Lerp(playerPos, returnPoint.transform.position, 1 - lungeTime / setLungeTime);
        }
        else
        {
            detectedPlayer = false;
            readyToAttack = false;
            hasAttacked = false;
            windUpTime = -1;
            lungeTime = -1;
            this.transform.right = Vector3.right;
            GetComponent<NEW_InheritScrollScript>().enabled = true;
            Destroy(returnPoint);
        }
    }

    void SetReturnPoint()
    {
        if (returnPoint == null)
        {
            returnPoint = new GameObject();
            returnPoint.name = this.gameObject.name + " Return Point";
            returnPoint.transform.parent = this.transform.parent;
            returnPoint.transform.position = this.transform.position;

            returnPoint.AddComponent<NEW_InheritScrollScript>();
            returnPoint.GetComponent<NEW_InheritScrollScript>().scrollRate = GetComponent<NEW_InheritScrollScript>().scrollRate;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            subController.SetCurrentHP(subController.GetCurrentHP() - lungeDamage);
        }
    }
}
