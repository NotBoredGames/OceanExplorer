using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatistics : MonoBehaviour
{
	public int playerScrapAmount;
	
	public int healthAmt;
	public int engineerLevel;
	public bool engineerFound;
	
	public int bombAmt;
	public int weaponsmithLevel;
	public bool weaponsmithFound;
	
	public int subSpeed;
	public int navigatorLevel;
	public bool navigatorFound;
	
	public int scrapIncrease;
	public int scrapperLevel;
	public bool scrapperFound;
	
	public int damageAmt;
	public int marineBiologistLevel;
	public bool marineBiologistFound;
	
	private GameObject Engineer;
	private GameObject Weaponsmith;
	private GameObject Navigator;
	private GameObject Scrapper;
	private GameObject MarineBiologist;
    // Start is called before the first frame update
    void Start()
    {
		//load the values
       	   healthAmt=3;
		   engineerLevel=0;
		   engineerFound=false;
		   
		   bombAmt=3;
		   weaponsmithLevel=0;
		   weaponsmithFound=false;
		   
		   subSpeed=1;
		   navigatorLevel=0;
		   navigatorFound=false;
		   
		   scrapIncrease=0;
		   scrapperLevel=0;
		   scrapperFound=false;
		   
		   damageAmt=1;
		   marineBiologistLevel=0;
		   marineBiologistFound=false;
		   
		   Engineer=GameObject.Find("Engineer");
		   Weaponsmith=GameObject.Find("Weaponsmith");
		   Navigator=GameObject.Find("Navigator");
		   Scrapper=GameObject.Find("Scrapper");
		   MarineBiologist=GameObject.Find("Biologist");
		   
		   
		   
		   
    }

    // Update is called once per frame
    void Update()
    {
        if(engineerFound){
			Engineer.SetActive(true);
		}
		else if(!engineerFound){
			Engineer.SetActive(false);
		}
		
		if(weaponsmithFound){
			Weaponsmith.SetActive(true);
		}
		else if(!weaponsmithFound){
			Weaponsmith.SetActive(false);
		}
		
		if(navigatorFound){
			Navigator.SetActive(true);
		}
		else if(!navigatorFound){
			Navigator.SetActive(false);
		}
		
		if(scrapperFound){
			Scrapper.SetActive(true);
		}
		else if(!scrapperFound){
			Scrapper.SetActive(false);
		}
		
		if(marineBiologistFound){
			MarineBiologist.SetActive(true);
		}
		else if(!marineBiologistFound){
			MarineBiologist.SetActive(false);
		}
    }
}
