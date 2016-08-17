using UnityEngine;
using System.Collections;

public class Playercontrols : MonoBehaviour {
	public float speedForce= 50f; 
	public Vector2 jumpVector;
	public bool isGrounded;

	public Transform grounder;
	public float radiuss;
	public LayerMask ground; 

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		// A and D keys to move sprite left and right
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speedForce, GetComponent<Rigidbody2D> ().velocity.y);
			// transform.localscale will allow sprite to face direction in which it is moving 
			transform.localScale = new Vector3 (-1, 1, 1);
			// Triggers animation to run
			anim.SetInteger ("AnimationState", 1);

		} else if (Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedForce, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
			// Triggers animation to run
			anim.SetInteger ("AnimationState", 1);

		} else {
			// This will make the sprite not move if other buttons are pressed, Sprite in Idle state
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			// Triggers animation to stay idle
			anim.SetInteger ("AnimationState", 0);

			// To see if sprite is on the ground
			isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radiuss, ground);

			// W to make sprite jump
			if (Input.GetKey (KeyCode.W) && isGrounded == true) {
				GetComponent<Rigidbody2D> ().AddForce (jumpVector, ForceMode2D.Force);
			}
		}
	}

	// Ground check object
	// Allows user to see the white circle on sprite
	// The white circle is used to tell if sprite is on ground or not.
    void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (grounder.transform.position, radiuss);
	}
}
