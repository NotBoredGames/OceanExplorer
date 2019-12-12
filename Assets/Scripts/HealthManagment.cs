using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagment : MonoBehaviour
{

    [SerializeField]
    string subControllerString = "Submarine Info Controller";

    [SerializeField]
    GameObject playerDeathExplosion;

    SubmarineSettingsScript subSettings;

    private void Awake()
    {
        subSettings = GameObject.Find(subControllerString).GetComponent<SubmarineSettingsScript>();

        if (subSettings == null)
            Debug.LogError("[[HealthManagement]] Script on GameObject " + this.gameObject.name + " unable to find SubmarineSettingsScript!");

        StartCoroutine(PlayerDead());
    }

    // player takes damage when hit by enemy mine explosion
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Explosion")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
         
        }
    }

    IEnumerator PlayerDead()
    {
        while (subSettings.GetCurrentHP() > 0)
            yield return null;

        Debug.Log("DEAD");
        GameObject explosion = Instantiate(playerDeathExplosion);
        explosion.transform.position = transform.position;
        GetComponentInChildren<SpriteRenderer>().color = new Color(1,1,1,0);

        yield return new WaitForSeconds(0.375f);

        GameObject subController = GameObject.Find("Submarine Info Controller");
        if (subController)
        {
            subController.GetComponent<SubmarineSettingsScript>().Reset();
            Destroy(subController);
        }

        SceneManager.LoadScene("TitleScreen");
    }
 

    

}
