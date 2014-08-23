using UnityEngine;
using System.Collections;

public class GunPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");

		Vector3 relPlayer = player.transform.position - transform.position;
		Vector3 relPlayerNorm = relPlayer.normalized;
		Quaternion rotateToPlayer = Quaternion.FromToRotation(Vector3.right,relPlayerNorm);
		transform.rotation = rotateToPlayer;


	}
}
