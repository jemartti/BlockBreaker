﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public AudioClip crack;
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
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.25f);
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
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
		}
	}
}
