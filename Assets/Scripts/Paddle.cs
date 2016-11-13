using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	void Update ()
	{
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		this.transform.position = new Vector3 (
			Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f),
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
