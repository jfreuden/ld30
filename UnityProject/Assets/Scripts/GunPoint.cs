using UnityEngine;
using System.Collections;

public class GunPoint : MonoBehaviour
{
		void Update ()
		{
				PlayerControl playerScript = ScriptableObject.FindObjectOfType<PlayerControl> ();
				bool mirror = playerScript.mirror;
				Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);//Camera.main.ScreenPointToRay (Input.mousePosition).origin;
				mousePos.z = 0;
		print (mousePos);
				Vector3 relMouse = mousePos - transform.position;
				Vector3 relMouseNorm = relMouse.normalized;
				
				if (mirror) {
						relMouseNorm.x *= -1;
				} 
				
				Quaternion rotateToMouse;
				rotateToMouse = Quaternion.FromToRotation (Vector3.right, relMouseNorm);
				
				
				//transform.rotation = rotateToPlayer;
				transform.rotation = rotateToMouse;
				//transform.Rotate (transform.forward, Mathf.PI);
		}
}
