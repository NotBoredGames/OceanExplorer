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
	
	public int scrapIncrease;
	public int scrapperLevel;
	
	public int damageAmt;
	public int marineBiologistLevel;
    // Start is called before the first frame update
    void Start()
    {
		//GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>.
		if(GameObject.Find("Submarine Info Controller")){
		   playerScrapAmount=SubmarineSettingsScript.currentScrap;
		   
			
		   healthAmt=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().maxHP;
		   engineerLevel=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().eLvl;
		   
		   bombAmt=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().maxMines;
		   weaponsmithLevel=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().wLvl;
		   
		   subSpeed=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().subSpeed;
		   navigatorLevel=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().nLvl;
		   
		   scrapIncrease=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().scrapIncrease;
		   scrapperLevel=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().sLvl;
		   
		   damageAmt=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().currentBulletDamage;
		   marineBiologistLevel=GameObject.Find("Submarine Info Controller").GetComponent<SubmarineSettingsScript>().mbLvl;
		}
		else{
		//load default values
       	   healthAmt=3;
		   engineerLevel=0;
		   
		   bombAmt=3;
		   weaponsmithLevel=0;
		   
		   subSpeed=1;
		   navigatorLevel=0;
		   
		   scrapIncrease=0;
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
