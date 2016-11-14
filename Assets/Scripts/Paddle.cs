using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;
	private Ball ball;
	
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update ()
	{
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}
	
	void MoveWithMouse ()
	{
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		this.transform.position = new Vector3 (
			Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f),
			this.transform.position.y,
			this.transform.position.z
		);
	}
	
	void AutoPlay ()
	{
		this.transform.position = new Vector3 (
			ball.transform.position.x,
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
