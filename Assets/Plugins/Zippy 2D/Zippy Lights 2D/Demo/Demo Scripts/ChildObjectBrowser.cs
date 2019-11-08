using UnityEngine;
using System.Collections;

public class ChildObjectBrowser : MonoBehaviour {

	int childIndex = 0;
	
	//void Start () {
	//	DisableAll();
	//	EnableChild(childIndex);
	//}
	
	public void NextChild(int next) {
		DisableAll();
		childIndex += next;
		if (childIndex < 0) childIndex = transform.childCount -1;
		else childIndex %= transform.childCount;
		EnableChild(childIndex);
	}

	void EnableChild(int index) {
		transform.GetChild(index).gameObject.SetActive(true);
	}

	void DisableAll() {
		for(int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}
}
