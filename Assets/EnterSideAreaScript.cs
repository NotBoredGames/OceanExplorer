using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSideAreaScript : MonoBehaviour
{
    public GameObject sideArea;
    public GameObject engineer;
    public GameObject weaponsmith;
    public GameObject scrapper;
    public GameObject marineBiologist;
    public GameObject scrapPile;

    //  public GameObject Player;

    // function will only be called when player collides with vortex in level 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("plz halp");



            // Changes bool that puts UI on the Invisible layer
          //  Invisible.isInvisible = true;

            // will need to disable enemy movement
            // will need to disable submarine movement
            LevelScrollControlScript.Scroll = false; // disable level scrolling
            Instantiate(sideArea);

            // if the player has not found the engineer yet
            if(SubmarineSettingsScript.foundEngineer == false)
            {
                Instantiate(engineer);
                SubmarineSettingsScript.foundEngineer = true;

                Destroy(this.gameObject); // removes vortex from level
            }

            // if the player has not found the weaponsmith yet
            else if (SubmarineSettingsScript.foundWeaponsmith == false)
            {
                Instantiate(weaponsmith);
                SubmarineSettingsScript.foundWeaponsmith = true;

                Destroy(this.gameObject); // removes vortex from level
            }

            // if the player has not found the scrapper yet
            else if (SubmarineSettingsScript.foundScrapper == false)
            {
                Instantiate(scrapper);
                SubmarineSettingsScript.foundScrapper = true;

                Destroy(this.gameObject); // removes vortex from level
            }

            // if the player has not found the marine biologist yet
            else if (SubmarineSettingsScript.foundMarineBio == false)
            {
                Instantiate(marineBiologist);
                SubmarineSettingsScript.foundMarineBio = true;

                Destroy(this.gameObject); // removes vortex from level
            }

            // if the player has found everyone! They find scrap!
            else if (SubmarineSettingsScript.foundMarineBio == true)
            {
                Instantiate(scrapPile);
                SubmarineSettingsScript.currentScrap += 100;

                Destroy(this.gameObject); // removes vortex from level
            }

        }

    }

    
}
