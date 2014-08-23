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


		//transform.RotateAround(transform.position,Vector3.back,Quaternion.FromToRotation(this.transform.position, player.transform.position).);
		//transform.rotation = Quaternion.AngleAxis(2f,Vector3.up); //Quaternion.FromToRotation(this.transform.position, player.transform.position);
		//transform.LookAt(GameObject.Find("Player").transform,Vector3.up);
	}
}
