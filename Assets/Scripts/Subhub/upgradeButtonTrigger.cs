using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeButtonTrigger : MonoBehaviour
{
    public Dialog dialog;
	
	public int scrapCost;
	private int currUpgradeLevel;
	
	public int currentValue;
	
	public int perLevelScrapCost;
	
	private Color startcolor;
    
      
    
    public void pressUpgrade()
    {
		Debug.Log("Getting a press");
        if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Health"){
			Debug.Log("Test 1");
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().healthAmt;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().engineerLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			if(currUpgradeLevel==3){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="MAX LEVEL";
			}
			else if(scrapCost>GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount){
				
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Not Enough Scrap!";
			}
			else{
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount-=scrapCost;
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Upgrade Purchased!";
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().healthAmt+=2;
			    GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().engineerLevel+=1;
				currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().engineerLevel;
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
		}
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Bombs"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().bombAmt;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().weaponsmithLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			if(currUpgradeLevel==3){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="MAX LEVEL";
			}
			else if(scrapCost>GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Not Enough Scrap!";
			}
			else{
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount-=scrapCost;
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Upgrade Purchased!";
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().bombAmt+=2;
			    GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().weaponsmithLevel+=1;
				currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().weaponsmithLevel;
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
		}
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Speed"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().subSpeed;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().navigatorLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			if(currUpgradeLevel==3){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="MAX LEVEL";
			}
			else if(scrapCost>GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Not Enough Scrap!";
			}
			else{
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount-=scrapCost;
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Upgrade Purchased!";
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().subSpeed+=5;
			    GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().navigatorLevel+=1;
				currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().navigatorLevel;
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
		}
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Scrap"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapMultiplier;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapperLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			if(currUpgradeLevel==3){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="MAX LEVEL";
			}
			else if(scrapCost>GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Not Enough Scrap!";
			}
			else{
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount-=scrapCost;
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Upgrade Purchased!";
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapMultiplier+=1;
			    GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapperLevel+=1;
				currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapperLevel;
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
		}
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Damage"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().damageAmt;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().marineBiologistLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			if(currUpgradeLevel==3){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="MAX LEVEL";
			}
			else if(scrapCost>GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount){
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Not Enough Scrap!";
			}
			else{
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().playerScrapAmount-=scrapCost;
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Upgrade Purchased!";
				GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().damageAmt+=1;
			    GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().marineBiologistLevel+=1;
				currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().marineBiologistLevel;
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
		}
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Doggo Happiness"){
			
				dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
				dialog.sentences=new string[1];
				dialog.sentences[0]="Doggo is just happy to be here!!!";
				
		}
			FindObjectOfType<DialogManager>().StartDialog(dialog);
	}
		
		
    

	
	
	
    public void TriggerDialog()
    {
		if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Health"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().healthAmt;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().engineerLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
			dialog.sentences=new string[1];
			if(currUpgradeLevel==3){
				dialog.sentences[0]="MAX LEVEL";
			}
			else{
				dialog.sentences[0]="Increases maximum health to "+(currentValue+2)+". Cost: "+scrapCost+" Scrap";
			}
			FindObjectOfType<DialogManager>().StartDialog(dialog);
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
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Bombs"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().bombAmt;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().weaponsmithLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
			dialog.sentences=new string[1];
			if(currUpgradeLevel==3){
				dialog.sentences[0]="MAX LEVEL";
			}
			else{
				dialog.sentences[0]="Increases bomb count to "+(currentValue+2)+". Cost: "+scrapCost+" Scrap";
			}
			FindObjectOfType<DialogManager>().StartDialog(dialog);
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
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Speed"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().subSpeed;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().navigatorLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
			dialog.sentences=new string[1];
			if(currUpgradeLevel==3){
				dialog.sentences[0]="MAX LEVEL";
			}
			else{
				dialog.sentences[0]="Increases sub speed by 25%. Cost: "+scrapCost+" Scrap";
			}
			FindObjectOfType<DialogManager>().StartDialog(dialog);
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
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Scrap"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapMultiplier;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().scrapperLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
			dialog.sentences=new string[1];
			if(currUpgradeLevel==3){
				dialog.sentences[0]="MAX LEVEL";
			}
			else{
				dialog.sentences[0]="Muliplies the default amount of scrap recovered by "+(currentValue+1)+". Cost: "+scrapCost+" Scrap";
			}
			FindObjectOfType<DialogManager>().StartDialog(dialog);
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
		else if(GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text == "Increase Damage"){
			currentValue= GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().damageAmt;
			currUpgradeLevel = GameObject.Find("PlayerUpgradeController").GetComponent<playerStatistics>().marineBiologistLevel;
			scrapCost=(currUpgradeLevel+1)*perLevelScrapCost;
			dialog.name=GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text;
			dialog.sentences=new string[1];
			if(currUpgradeLevel==3){
				dialog.sentences[0]="MAX LEVEL";
			}
			else{
				dialog.sentences[0]="Increases damage dealt to "+(currentValue+1)+". Cost: "+scrapCost+" Scrap";
			}
			FindObjectOfType<DialogManager>().StartDialog(dialog);
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
    }

}
