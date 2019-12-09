using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour
{
    private Color startcolor;
    public GameObject textToShow;
    public DialogTrigger dialogToPlay;
       
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
		if (!EventSystem.current.IsPointerOverGameObject())
        {
        
        dialogToPlay.TriggerDialog();
		
		if(gameObject.name=="Engineer"){
			
			int currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().engineerLevel;
			GameObject.Find("U1T1Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T2Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T3Box").GetComponent<Image>().enabled=false;
			if(currUpgradeLevel>=1){
				GameObject.Find("U1T1Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel>=2){
				GameObject.Find("U1T2Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel==3){
				GameObject.Find("U1T3Box").GetComponent<Image>().enabled=true;
			}
		}
		else if(gameObject.name=="Weaponsmith"){
			
			int currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().weaponsmithLevel;
			GameObject.Find("U1T1Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T2Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T3Box").GetComponent<Image>().enabled=false;
			if(currUpgradeLevel>=1){
				GameObject.Find("U1T1Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel>=2){
				GameObject.Find("U1T2Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel==3){
				GameObject.Find("U1T3Box").GetComponent<Image>().enabled=true;
			}
		}
		else if(gameObject.name=="Navigator"){
			
			int currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().navigatorLevel;
			GameObject.Find("U1T1Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T2Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T3Box").GetComponent<Image>().enabled=false;
			if(currUpgradeLevel>=1){
				GameObject.Find("U1T1Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel>=2){
				GameObject.Find("U1T2Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel==3){
				GameObject.Find("U1T3Box").GetComponent<Image>().enabled=true;
			}
		}
		else if(gameObject.name=="Scrapper"){
			
			int currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapperLevel;
			GameObject.Find("U1T1Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T2Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T3Box").GetComponent<Image>().enabled=false;
			if(currUpgradeLevel>=1){
				GameObject.Find("U1T1Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel>=2){
				GameObject.Find("U1T2Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel==3){
				GameObject.Find("U1T3Box").GetComponent<Image>().enabled=true;
			}
		}
		else if(gameObject.name=="Biologist"){
			
			int currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().marineBiologistLevel;
			GameObject.Find("U1T1Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T2Box").GetComponent<Image>().enabled=false;
			GameObject.Find("U1T3Box").GetComponent<Image>().enabled=false;
			if(currUpgradeLevel>=1){
				GameObject.Find("U1T1Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel>=2){
				GameObject.Find("U1T2Box").GetComponent<Image>().enabled=true;
			}
			if(currUpgradeLevel==3){
				GameObject.Find("U1T3Box").GetComponent<Image>().enabled=true;
			}
		}
		else if(gameObject.name=="Dog"){
			GameObject.Find("U1T1Box").GetComponent<Image>().enabled=true;
			GameObject.Find("U1T2Box").GetComponent<Image>().enabled=true;
			GameObject.Find("U1T3Box").GetComponent<Image>().enabled=true;
		}
		}
		
    }
}
