using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update ()
	{
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for the a mouse press to launch
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (0f, 0.2f));
	
		// Ball does not trigger sound when brick is destroyed
		// Not 100% sure why, possible because brick isn't there
		if (hasStarted) {
			audio.Play ();
			this.rigidbody2D.velocity += tweak;
		}
	}
}
