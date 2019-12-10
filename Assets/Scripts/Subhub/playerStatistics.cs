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
		//load the values
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
