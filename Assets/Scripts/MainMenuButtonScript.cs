using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**** Takes care of Scene Management in the Main Menu ****/
public class MainMenuButtonScript : MonoBehaviour
{
    //
    public void NewGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    /*** Quits game upon hitting "Quit" button ***/
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
