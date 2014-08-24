using UnityEngine;
using System.Collections;

public class GunPoint : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
			
		}

		// Update is called once per frame
		void Update ()
		{
				PlayerControl playerScript = ScriptableObject.FindObjectOfType<PlayerControl> ();
				bool mirror = playerScript.mirror;
				Vector3 mousePos = Camera.main.ScreenPointToRay (Input.mousePosition).origin;
				mousePos.z = 0;
				Vector3 relMouse = mousePos - transform.position;
				Vector3 relMouseNorm = relMouse.normalized;
				
				if (mirror) {
						relMouseNorm.x *= -1;
				} 
				
				GameObject player = GameObject.Find ("Player");
				Vector3 relPlayer = player.transform.position - transform.position;
				Vector3 relPlayerNorm = relPlayer.normalized;
				Quaternion rotateToMouse;
				rotateToMouse = Quaternion.FromToRotation (Vector3.right, relMouseNorm);
				
				
				//transform.rotation = rotateToPlayer;
				transform.rotation = rotateToMouse;
				//transform.Rotate (transform.forward, Mathf.PI);
		}
}
