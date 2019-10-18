using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombLaunch : MonoBehaviour
{	
	 public GameObject Bomb;
    
    
	void Update(){
		
		
		if(Input.GetKeyDown(KeyCode.X)){
			LaunchBomb();
			
		}
	}
	
	void LaunchBomb(){
		Debug.Log("key is pressed.");
		Instantiate(Bomb,new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
	}
}
