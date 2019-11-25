using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveRight : MonoBehaviour
{
    private bool isTouchingBarrier=false;

    // Update is called once per frame
    void OnMouseOver()
    {
        if (isTouchingBarrier == false)
        {
            Camera.main.transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }
        else
        {
            //invisible
        }

    }
    void OnCollisionEnter(Collision target)
    {
        Debug.Log("Test 3");
        if (target.gameObject.tag ==  "SubCamBarrier")
        {
            Debug.Log("Test 1");
            isTouchingBarrier = true;
        }
    }
    void OnCollisionExit(Collision target)
    {
        if (target.gameObject.tag == "SubCamBarrier")
        {
            Debug.Log("Test 2");
            isTouchingBarrier = false;
        }
    }
}
