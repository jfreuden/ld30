using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	Bounds levelBounds;
	GameObject devLevel;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
		levelBounds = GameObject.Find ("dev").renderer.bounds;
		Renderer[] renderers = GameObject.Find ("dev").GetComponentsInChildren<Renderer>();
		
		foreach (var render in renderers) {
			if (render != renderer) levelBounds.Encapsulate(render.bounds);
		}
		//print (combinedBounds);


		//levelBounds = devLevel.renderer.bounds;

				float minCamX = camera.ViewportToWorldPoint (Vector3.zero).x;
				float maxCamX = camera.ViewportToWorldPoint (Vector3.one).x;
				float camWidthHalf = (maxCamX - minCamX)/2;
				float minBorder = levelBounds.min.x + camWidthHalf;
				float maxBorder = levelBounds.max.x - camWidthHalf;
				//print (minCamX.ToString () + " : " + maxCamX.ToString ());

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
