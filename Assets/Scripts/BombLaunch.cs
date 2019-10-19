using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLaunch : MonoBehaviour
{
    public GameObject bomb;
    public int bombCount;
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && bombCount>0)
        {
            Instantiate(bomb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            bombCount -= 1;
        }
    }
}
