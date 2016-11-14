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
		if (hasStarted) {
			audio.Play ();
		}
	}
}
