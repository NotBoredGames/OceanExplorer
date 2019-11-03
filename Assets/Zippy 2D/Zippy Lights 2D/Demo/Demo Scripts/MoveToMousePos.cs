using UnityEngine;
using System.Collections;
public class MoveToMousePos : MonoBehaviour {
	Vector3 newPosition;
	bool canMove = true;
	public Transform spriteTransform;

	float speed;

	void Start() {
		newPosition = transform.position;
	}


	void Update() {

		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				newPosition = hit.point;
				
			}
		}

		float angle = 0;

		Vector3 relative = transform.InverseTransformPoint(newPosition);
		angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
		transform.Rotate(0, 0, -angle* Time.deltaTime * 50);

		var rotation = Quaternion.LookRotation(Vector3.forward);
		spriteTransform.rotation = rotation;

	

		if (canMove && Vector2.Distance(transform.position, newPosition) < 1f) {
			canMove = false;
			
		} else if(!canMove && Vector2.Distance(transform.position, newPosition) > 3f) {
			canMove = true;
			
		}

		transform.position += transform.up * speed *Time.deltaTime *50 *.1f;

		if (canMove) {
			speed = Mathf.Clamp01(speed + .05f * Time.deltaTime * 50);
		} else {
			speed = Mathf.Clamp01(speed - .1f * Time.deltaTime * 50);
		}
		//transform.position =  Vector3.Lerp(transform.position, newPosition, Time.time *.02f %1);
	}
}