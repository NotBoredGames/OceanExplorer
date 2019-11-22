using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using Sirenix.OdinInspector;


public class KrakenAttackScript : SerializedMonoBehaviour
{
    [BoxGroup("Tentacles", true, true), SerializeField]
    GameObject _rightTentacle1;

    [BoxGroup("Tentacles"), SerializeField]
    GameObject _leftTentacle1;

    [BoxGroup("Tentacles"), SerializeField]
    GameObject _rightTentacle2;

    [BoxGroup("Tentacles"), SerializeField]
    GameObject _leftTentacle2;

    [BoxGroup("States and Associated Clips", true, true), SerializeField]
    string[] stateNames;

    [BoxGroup("States and Associated Clips"), SerializeField]
    AnimationClip[] stateClips;

    [BoxGroup("Attack Triggers", true, true), SerializeField]
    BoxCollider2D[] playerLocationTriggers;

    [SerializeField]
    string playerString;
    GameObject player;

    [BoxGroup("Attack Frequency", true, true)]
    [InfoBox("Attack Frequency: time between attacks")]
    [SerializeField, Range(1f, 30f)]
    float attackFrequency = 15;

    [SerializeField]
    GameObject nextToAttack;

    public List<TriggerToAttack> TriggersToAttacks;

    [SerializeField]
    bool verbose = true;

    public bool runCode = false;

    // Start is called before the first frame update
    public void Awake()
    {
        player = GameObject.Find(playerString); ;
        if (player == null)
            Debug.LogError("[[KrakenAttackScript]] on " + this.gameObject.name + " failed to properly detect and set Player's Collider2D!");

        if (runCode)
            StartCoroutine(IntelligentTentacleAttack());

        //StartCoroutine(KeyTentacleAttack());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            foreach(Collider2D trigger in playerLocationTriggers)
            {
                if (trigger.bounds.Contains(player.transform.position))
                {
                    Debug.Log("[[KrakenAttackScript]] on " + this.gameObject.name + " detected player in trigger " + trigger.gameObject.name);
                    foreach(TriggerToAttack item in TriggersToAttacks)
                    {
                        if (item.trigger == trigger)
                            Debug.Log("Potential attack: Swipe " + item.attack + " using " + item.tentacle.name);
                    }
                    break;
                }
            }
        }
        */
    }

    IEnumerator IntelligentTentacleAttack()
    {
        while (true)
        {
            Collider2D currTrigger = new Collider2D();
            List<TriggerToAttack> potentialAttacks = new List<TriggerToAttack>();

            foreach (Collider2D trigger in playerLocationTriggers)
                if (trigger.bounds.Contains(player.transform.position))
                {
                    currTrigger = trigger;
                    break;
                }

            foreach (TriggerToAttack item in TriggersToAttacks)
            {
                if (item.trigger == currTrigger)
                    potentialAttacks.Add(item);
            }

            if (potentialAttacks != null && currTrigger != null)
            {
                if (verbose)
                    Debug.Log("There are " + potentialAttacks.Count + " potential attack(s) with the player in trigger " + currTrigger.gameObject.name);

                int randIndex = Random.Range(0, potentialAttacks.Count);
                TriggerToAttack chosenAttack = potentialAttacks[randIndex];
                nextToAttack = chosenAttack.tentacle;

                StartCoroutine(Attack(chosenAttack.attack));
            }

            if (verbose)
                Debug.Log("[[KrakenAttackScript]] ended loop of IntelligentTentacleAttack function");
            yield return new WaitForSeconds(attackFrequency);
        }
    }

    IEnumerator Attack(int attack)
    {
        nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = true;
        nextToAttack.GetComponent<Animator>().SetInteger("swipe", attack);
        yield return new WaitForSeconds(stateClips[attack].length);
        nextToAttack.GetComponent<Animator>().SetInteger("swipe", -1);
        nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = false;
        nextToAttack = null;
    }


    IEnumerator KeyTentacleAttack()
    {
        while(true)
        {
            if (nextToAttack == null)
            {
                if (Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp(KeyCode.Alpha3))
                    nextToAttack = _rightTentacle1;
                else if (Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.Alpha6))
                    nextToAttack = _rightTentacle2;
                else if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1))
                    nextToAttack = _leftTentacle1;
                else if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.Alpha4))
                    nextToAttack = _leftTentacle2;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1))
                {
                    nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = true;
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", 1);
                    yield return new WaitForSeconds(stateClips[1].length);
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", -1);
                    nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = false;
                    nextToAttack = null;
                }
                else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.Alpha2))
                {
                    nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = true;
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", 2);
                    yield return new WaitForSeconds(stateClips[2].length);
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", -1);
                    nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = false;
                    nextToAttack = null;
                }
                else if (Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp(KeyCode.Alpha3))
                {
                    nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = true;
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", 3);
                    yield return new WaitForSeconds(stateClips[2].length);
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", -1);
                    nextToAttack.GetComponent<AttackingTentacleScript>().isAttacking = false;
                    nextToAttack = null;
                }


            }

            yield return null;
        }
    }

    /// <summary>
    /// Returns current state name from the given gameObject and Animator layer
    /// </summary>
    /// <param name="obj">the gameObject to which the Animator is attached</param>
    /// <param name="layer">the layer you want to get state name from</param>
    /// <returns></returns>
    string GetCurrentStateName(GameObject obj, int layer)
    {
        AnimatorStateInfo stateInfo = obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(layer);

        foreach(string name in stateNames)
        {
            if (stateInfo.IsName(name))
                return name;
        }

        return "Current state of Animator for '" + obj.name + "' didn't match any known states!";
    }

    /// <summary>
    /// Returns next state name from the given gameObject and Animator layer
    /// </summary>
    /// <param name="obj">the gameObject to which the Animator is attached</param>
    /// <param name="layer">the layer you want to get state name from</param>
    /// <returns></returns>
    string GetNextStateName(GameObject obj, int layer)
    {
        AnimatorStateInfo stateInfo = obj.GetComponent<Animator>().GetNextAnimatorStateInfo(layer);

        foreach (string name in stateNames)
        {
            if (stateInfo.IsName(name))
                return name;
        }

        return "Next state of Animator for '" + obj.name + "' didn't match any known states!";
    }

    void GetAllAnimatorStates(GameObject obj)
    {
        
    }
}

[InlineProperty()]
public struct TriggerToAttack
{
    public BoxCollider2D trigger;
    public GameObject tentacle;
    public int attack;
}
