using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onHoverCap : MonoBehaviour
{
    private Color startcolor;
    public GameObject textToShow;
    //public DialogTrigger dialogToPlay;
       
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
		if(GameObject.Find("Submarine Info Controller")){
		   SubmarineSettingsScript.currentScrap=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount;
		   
			
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().maxHP=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().healthAmt;
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().eLvl=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().engineerLevel;
		   
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().maxMines=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().bombAmt;
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().wLvl=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().weaponsmithLevel;
		   
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().subSpeed=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().subSpeed;
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().nLvl=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().navigatorLevel;
		   
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().scrapIncrease=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapIncrease;
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().sLvl=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapperLevel;
		   
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().currentBulletDamage=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().damageAmt;
		   GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().mbLvl=GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().marineBiologistLevel;
		   UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		}
    }
}
