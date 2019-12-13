using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class onHoverCap : MonoBehaviour
{
    private Color startcolor;
    public GameObject textToShow;
    //public DialogTrigger dialogToPlay;

    static string subControllerString = "Submarine Info Controller";
    static string upgradeControllerString = "PlayerUpgradeController";
       
    void OnMouseEnter()
    {
        
			startcolor = GetComponent<Renderer>().material.color;
			GetComponent<Renderer>().material.color = Color.yellow;
			textToShow.GetComponent<MeshRenderer>().enabled = true;

    }
    void OnMouseExit()
    {
		
			textToShow.GetComponent<MeshRenderer>().enabled = false;
			GetComponent<Renderer>().material.color = startcolor;
		
    }
    void OnMouseDown()
    {

        GameObject subController = GameObject.Find(subControllerString);
        GameObject upgradeController = GameObject.Find(upgradeControllerString);
		if(subController && upgradeController){
		   SubmarineSettingsScript.currentScrap=upgradeController.GetComponent<playerStatistics>().playerScrapAmount;
			
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().maxHP=upgradeController.GetComponent<playerStatistics>().healthAmt;
		   subController.GetComponent<SubmarineSettingsScript>().engineerLvl=upgradeController.GetComponent<playerStatistics>().engineerLevel;
		   
		   subController.GetComponent<SubmarineSettingsScript>().maxMines=upgradeController.GetComponent<playerStatistics>().bombAmt;
		   subController.GetComponent<SubmarineSettingsScript>().weaponsmithLvl=upgradeController.GetComponent<playerStatistics>().weaponsmithLevel;
		   
		   subController.GetComponent<SubmarineSettingsScript>().subSpeed=upgradeController.GetComponent<playerStatistics>().subSpeed;
		   subController.GetComponent<SubmarineSettingsScript>().navigatorLvl=upgradeController.GetComponent<playerStatistics>().navigatorLevel;
		   
		   subController.GetComponent<SubmarineSettingsScript>().scrapCollectionMultiplier =upgradeController.GetComponent<playerStatistics>().scrapMultiplier;
		   subController.GetComponent<SubmarineSettingsScript>().scrapperLvl=upgradeController.GetComponent<playerStatistics>().scrapperLevel;
		   
		   subController.GetComponent<SubmarineSettingsScript>().currentBulletDamage=upgradeController.GetComponent<playerStatistics>().damageAmt;
		   subController.GetComponent<SubmarineSettingsScript>().biologistLvl=upgradeController.GetComponent<playerStatistics>().marineBiologistLevel;

		   SceneManager.LoadScene("Level " + (Globals.lastSubLevelPlayed + 1));
		}
    }
}
