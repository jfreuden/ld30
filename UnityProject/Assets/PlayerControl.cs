using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

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

		if (Input.GetKeyDown(KeyCode.Space) & rigidbody2D.velocity.y == 0) {
			rigidbody2D.AddForce(Vector2.up * 6,ForceMode2D.Impulse);
		}

	}
}
