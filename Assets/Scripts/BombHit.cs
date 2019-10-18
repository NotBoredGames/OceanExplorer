using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombHit : MonoBehaviour
{
	
	
	
	public float attackRange;
	public LayerMask whatIsEnemies;
	public int damage=3;


    void Start()
    {
        // need to set audio source to use singular audio clip
        
    }

    // Start is called before the first frame update
    void Update(){
		
	}
	private void OnTriggerEnter2D(Collider2D c)
    {
		
		if(c.GetComponent<Collider2D>().tag == "Enemy")
         {
		   
			   Debug.Log("Exploding...");
               
               Collider2D[] enemiesToDamage=Physics2D.OverlapCircleAll(gameObject.transform.position,attackRange,whatIsEnemies);
			  for(int i = 0; i<enemiesToDamage.Length;i++)
			  {
				  //enemiesToDamage[i].GetComponent<GenericEnemyScript>().TakeDamage(damage);
			  }
			  Destroy(gameObject);
		}
		   
		   
	   
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color=Color.red;
		Gizmos.DrawWireSphere(gameObject.transform.position,attackRange);
	}
}
