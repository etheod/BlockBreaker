using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	private LevelManager levelManager;
	void OnTriggerEnter2D(Collider2D collision){
		levelManager=GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel ("Lose");
	}
}
