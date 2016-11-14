using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;
	public float minX;
	public float maxX;
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
			Mathf.Clamp (mousePosInBlocks, minX, maxX),
			this.transform.position.y,
			this.transform.position.z
		);
	}
	
	void AutoPlay ()
	{
		this.transform.position = new Vector3 (
			Mathf.Clamp (ball.transform.position.x, minX, maxX),
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
