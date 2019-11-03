using UnityEngine;
using System.Collections;

public class TextMeshFPS : MonoBehaviour {

	TextMesh _textMesh;
	float updateInterval = 0.5f;
	float accum = 0.0f;
	float frames = 0;
	float timeleft;
	public static TextMeshFPS instance;

	void OnApplicationQuit() {
		instance = null;
	}

	void Start() {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
		}
		timeleft = updateInterval;
		_textMesh = transform.GetComponent<TextMesh>();
	}

	void Update() {
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		++frames;
		if (timeleft <= 0.0f) {
			_textMesh.text = "" + (accum / frames).ToString("f2");
			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}
	}
}
