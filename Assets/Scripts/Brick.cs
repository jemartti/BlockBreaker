using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public int maxHits;
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
		++timesHit;
		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}
	
	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
	}
	
	// TODO: Remove this method once we can actually win!
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
