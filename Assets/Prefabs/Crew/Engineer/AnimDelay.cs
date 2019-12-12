using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDelay : MonoBehaviour
{

    public int startDelay;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DelayedAnimation());
    }

    // The delay coroutine
    IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(startDelay);
        animator.Play("EngineerAnim");
    }

}
