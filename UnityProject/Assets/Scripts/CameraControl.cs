using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float minCamX = camera.ViewportToWorldPoint (Vector3.zero).x;
				float maxCamX = camera.ViewportToWorldPoint (Vector3.one).x;
				float camWidthHalf = (maxCamX - minCamX)/2;
				float minBorder = 0 + camWidthHalf;
				float maxBorder = 80 - camWidthHalf;
				print (minCamX.ToString () + " : " + maxCamX.ToString ());

				Vector3 playerPosition = GameObject.Find ("Player").transform.position;
				playerPosition.x = Mathf.Clamp (playerPosition.x, minBorder, maxBorder);
				Vector3 relPlayerPosition = playerPosition - transform.position;
				relPlayerPosition.z = 0;
				//relPlayerPosition.x = Mathf.Clamp (relPlayerPosition.x,0 , 80-camWidthHalf);
				//need to ensure that the position to lerp to is WITHIN the bounds
				//if((camera.rect.xMin >= relPlayerPosition.x) & (camera.rect.xMax <= relPlayerPosition.x))

				//if (((0 + camHalfWidth) <= relX) & (relX <= (80 - camHalfWidth)))
				//{
				transform.Translate (Vector3.Lerp (Vector3.zero, relPlayerPosition, Time.deltaTime * 4f));
				//}
		}
}
