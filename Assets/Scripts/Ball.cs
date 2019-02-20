using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private paddle paddle;

	private bool hasStarted=false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle=GameObject.FindObjectOfType<paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasStarted) {
			//lock ball position relative to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//wait mouse to launch
			if (Input.GetMouseButtonDown (0))
				hasStarted=true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3f, 10f);
		}
	}
}
