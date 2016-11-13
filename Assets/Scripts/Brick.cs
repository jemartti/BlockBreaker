using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		
		// Keep track of breakable bricks
		if (isBreakable) {
			++breakableCount;
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (isBreakable) {
			HandleHits ();
		}
	}
	
	void HandleHits ()
	{
		++timesHit;
		if (timesHit >= hitSprites.Length + 1) {
			--breakableCount;
			levelManager.BrickDestroyed ();
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
}
