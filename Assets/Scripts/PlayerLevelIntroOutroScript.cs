using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerLevelIntroOutroScript : MonoBehaviour
{
    Animator anim;

    /* @TODO: Hardcoding these variables is terrible practice */
    float levelIntroTime = 5f;
    string levelIntroBool = "LevelIntroComplete";
    string levelOutroBool = "ExitLevel";

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(LevelIntroRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LevelIntroRoutine()
    {
        yield return new WaitForSeconds(levelIntroTime);

        anim.SetBool(levelIntroBool, true);
    }

    private IEnumerator LevelOutroRoutine()
    {
        GetComponent<NEW_SubMovementScript>().enabled = false;
        GetComponent<NEW_TurretFireScript>().enabled = false;
        GetComponent<NEW_MineDropScript>().enabled = false;
        yield return null;
    }

    public void LevelOutro()
    {
        anim.SetBool(levelOutroBool, true);
    }
}
