using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		Vector3 playerPosition =  GameObject.Find ("Player").transform.position;
		Vector3 clampedPosition = playerPosition;
		//clampedPosition.x = Mathf.Clamp(playerPosition.x,0+(Camera.current.rect.width / 2),80-(Camera.current.rect.width / 2));

		Vector3 relPlayerPosition = /*clampedPosition -*/playerPosition - transform.position;
		relPlayerPosition.z = 0;
		float relX = relPlayerPosition.x;
		float camHalfWidth = (this.camera.rect.width /2 );

		//need to ensure that the position to lerp to is WITHIN the bounds
		//if((camera.rect.xMin >= relPlayerPosition.x) & (camera.rect.xMax <= relPlayerPosition.x))

		//if (((0 + camHalfWidth) <= relX) & (relX <= (80 - camHalfWidth)))
		//{
		transform.Translate(Vector3.Lerp(Vector3.zero,relPlayerPosition,Time.deltaTime * 4f));
		
		//}
	}
}
