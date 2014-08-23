using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 relPlayerPosition = GameObject.Find ("Player").transform.position - transform.position;
		relPlayerPosition.z = 0;
		transform.Translate(Vector3.Lerp(Vector3.zero,relPlayerPosition,Time.deltaTime * 2.5f));

	}
}
