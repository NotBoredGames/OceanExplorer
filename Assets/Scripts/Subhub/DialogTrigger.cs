using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
	public string upgradeName;
	public int upgradeLevel;
	

    public void TriggerDialog()
    {
        Debug.Log("test");
        FindObjectOfType<DialogManager>().StartDialog(dialog);
		GameObject.Find("U1Name").GetComponent<UnityEngine.UI.Text>().text = upgradeName;
    }

}
