using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public bool running = false;
	public int moveSpeed = 16;
	public bool mirror;
	// Use this for initialization
	void Start ()
	{
		mirror = false;
	}
	void Update ()
	{
		float horizont = Input.GetAxis ("Horizontal");
		Animator stateAnim = this.GetComponent<Animator> ();
		if (horizont == 0) {
			stateAnim.SetBool ("running", false);
		} else {
			running = true;
			stateAnim.SetBool ("running", true);
		}
		if (horizont < 0) {
			mirror = true;
		} else if (horizont > 0) {
			mirror = false;
		}
		//determine direction of mouse pointing
		Vector3 mousePos = Camera.main.ScreenPointToRay (Input.mousePosition).origin;
		Vector3 relMouse = mousePos - transform.position;
		Vector3 relMouseNorm = relMouse.normalized;
		if (relMouseNorm .x > 0) {
			mirror = false;
		} else {
			mirror = true;
		}
		if (mirror) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			this.transform.localScale = new Vector3 (1, 1, 1);
		}
		this.transform.Translate (horizont * moveSpeed * Vector2.right * Time.deltaTime);
		CameraControl cameraScript = ScriptableObject.FindObjectOfType<CameraControl> ();
		float clampedX = Mathf.Clamp (transform.position.x, cameraScript.levelBounds.min.x, cameraScript.levelBounds.max.x);
		transform.position = new Vector3 (clampedX, transform.position.y, transform.position.z);
				
		if (rigidbody2D.velocity.y == 0) { //If not jumping (or otherwise moving up/down)
			stateAnim.SetBool ("jumping", false);
			stateAnim.SetBool ("falling", false);
			if (Input.GetKeyDown (KeyCode.Space)) {
				rigidbody2D.AddForce (Vector2.up * 6, ForceMode2D.Impulse);
			}
		} else if (rigidbody2D.velocity.y > 0) {
			stateAnim.SetBool ("jumping", true);
			stateAnim.SetBool ("falling", false);
		} else if (rigidbody2D.velocity.y < 0) {
			stateAnim.SetBool ("falling", true);
			stateAnim.SetBool ("jumping", false);
		}
	}
}
