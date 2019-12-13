using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatistics : MonoBehaviour
{
	public int playerScrapAmount;
	
	public int healthAmt;
	public int engineerLevel;
	
	public int bombAmt;
	public int weaponsmithLevel;
	
	public int subSpeed;
	public int navigatorLevel;
	
	public int scrapMultiplier;
	public int scrapperLevel;
	
	public int damageAmt;
	public int marineBiologistLevel;

    static string subControllerString = "Submarine Info Controller";
    // Start is called before the first frame update
    void Start()
    {
        GameObject subController = GameObject.Find(subControllerString);
		if(GameObject.Find(subControllerString)){
		   playerScrapAmount=SubmarineSettingsScript.currentScrap;
		   
			
		   healthAmt=subController.GetComponent<SubmarineSettingsScript>().maxHP;
		   engineerLevel=subController.GetComponent<SubmarineSettingsScript>().engineerLvl;
		   
		   bombAmt=subController.GetComponent<SubmarineSettingsScript>().maxMines;
		   weaponsmithLevel=subController.GetComponent<SubmarineSettingsScript>().weaponsmithLvl;
		   
		   subSpeed=subController.GetComponent<SubmarineSettingsScript>().subSpeed;
		   navigatorLevel=subController.GetComponent<SubmarineSettingsScript>().navigatorLvl;
		   
		   scrapMultiplier=subController.GetComponent<SubmarineSettingsScript>().scrapCollectionMultiplier;
		   scrapperLevel=subController.GetComponent<SubmarineSettingsScript>().scrapperLvl;
		   
		   damageAmt=subController.GetComponent<SubmarineSettingsScript>().currentBulletDamage;
		   marineBiologistLevel=subController.GetComponent<SubmarineSettingsScript>().biologistLvl;
		}
		else{
		//load default values
       	   healthAmt=3;
		   engineerLevel=0;
		   
		   bombAmt=3;
		   weaponsmithLevel=0;
		   
		   subSpeed=1;
		   navigatorLevel=0;
		   
		   scrapMultiplier=0;
		   scrapperLevel=0;
		   
		   damageAmt=1;
		   marineBiologistLevel=0;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
