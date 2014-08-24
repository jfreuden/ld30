using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	public Bounds levelBounds;
	void Start ()
	{

		levelBounds = GameObject.FindGameObjectWithTag ("Level").renderer.bounds;
		Renderer[] renderers = GameObject.FindGameObjectWithTag ("Level").GetComponentsInChildren<Renderer> ();

		foreach (var render in renderers) {
			if (render != renderer)
				levelBounds.Encapsulate (render.bounds);
		}
		print (GameObject.FindGameObjectWithTag ("Level").name);
	}
	void Update ()
	{


		float minCamX = camera.ViewportToWorldPoint (Vector3.zero).x;
		float maxCamX = camera.ViewportToWorldPoint (Vector3.one).x;
		float camWidthHalf = (maxCamX - minCamX) / 2;
		float minBorder = levelBounds.min.x + camWidthHalf;
		float maxBorder = levelBounds.max.x - camWidthHalf;

		Vector3 playerPosition = GameObject.Find ("Player").transform.position;
		playerPosition.x = Mathf.Clamp (playerPosition.x, minBorder, maxBorder);
		Vector3 relPlayerPosition = playerPosition - transform.position;
		relPlayerPosition.z = 0;

		transform.Translate (Vector3.Lerp (Vector3.zero, relPlayerPosition, Time.deltaTime * 4f));

	}
}
