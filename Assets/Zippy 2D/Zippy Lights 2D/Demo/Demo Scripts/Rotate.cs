using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed = 100;
	
	void FixedUpdate () {
		transform.Rotate(Vector3.forward * speed *Time.deltaTime);
	}
}
