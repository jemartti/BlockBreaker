using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public Sprite[] hitSprites;
	private LevelManager levelManager;
	private int timesHit;

	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (this.tag == "Breakable") {
			HandleHits ();
		}
	}
	
	void HandleHits ()
	{
		++timesHit;
		if (timesHit >= hitSprites.Length + 1) {
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}
	
	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
	
	// TODO: Remove this method once we can actually win!
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
