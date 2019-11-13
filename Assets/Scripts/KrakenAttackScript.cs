using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using Sirenix.OdinInspector;


public class KrakenAttackScript : MonoBehaviour
{
    [SerializeField]
    GameObject _rightTentacle1;

    [SerializeField]
    GameObject _leftTentacle1;

    [SerializeField]
    GameObject _rightTentacle2;

    [SerializeField]
    GameObject _leftTentacle2;

    [SerializeField]
    string[] stateNames;

    [SerializeField]
    AnimationClip[] stateClips;

    [SerializeField]
    GameObject nextToAttack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TentacleAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator TentacleAttack()
    {
        while(true)
        {
            if (nextToAttack == null)
            {
                if (Input.GetKeyUp(KeyCode.Keypad3))
                    nextToAttack = _rightTentacle1;
                else if (Input.GetKeyUp(KeyCode.Keypad6))
                    nextToAttack = _rightTentacle2;
                else if (Input.GetKeyUp(KeyCode.Keypad1))
                    nextToAttack = _leftTentacle1;
                else if (Input.GetKeyUp(KeyCode.Keypad4))
                    nextToAttack = _leftTentacle2;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Keypad1))
                {

                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", 1);
                    yield return new WaitForSeconds(stateClips[1].length);
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", -1);
                    nextToAttack = null;
                }
                else if (Input.GetKeyUp(KeyCode.Keypad2))
                {
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", 2);
                    yield return new WaitForSeconds(stateClips[2].length);
                    nextToAttack.GetComponent<Animator>().SetInteger("swipe", -1);
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
