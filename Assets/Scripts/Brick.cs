using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int maxHits;
	public Sprite[] hitSprites;
	private int hitTimes;
	private LevelManager levelManager;
	public static int breakableCount=0;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag =="Breakable");
		if (isBreakable){
			breakableCount++;
		}
		hitTimes = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter2D (Collision2D col){
		if (isBreakable) {
			hitTimes++;
			maxHits = hitSprites.Length + 1;
			if (hitTimes == maxHits) {
				breakableCount--;
				print(breakableCount);
				levelManager.BrickDestroyed();
				Destroy (gameObject);
			} else
				LoadSprite ();
		}
	}
	void LoadSprite(){
		int SpriteIndex = hitTimes - 1;
		if (hitSprites[SpriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
		}
	}
	void SimulateWin(){
		levelManager.LoadNextLevel ();
	}
}
