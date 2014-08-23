using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		public bool running = false;
		public int moveSpeed = 4;
		bool mirror;
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
				if (mirror) {
						this.transform.localScale = new Vector3 (-1, 1, 1);
				} else {
						this.transform.localScale = new Vector3 (1, 1, 1);
				}
				this.transform.Translate (horizont * moveSpeed * Vector2.right * Time.deltaTime);
				
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
