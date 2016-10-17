using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public GameObject ball;
	public Rigidbody2D rb;
	public BoxCollider2D coll;
	public bool isGame;
	public int speed;

	// Use this for initialization
	void Start () {
		//sets goal to the gameobject the script is attached
		ball = this.gameObject;

		//adds and applies the following to the wall:
		//Rigidbody2D for 2D physics
		//BoxCollider2D for collision detection
		//tag "wall" to define it as a wall
		ball.AddComponent<Rigidbody2D>();
		rb = ball.GetComponent<Rigidbody2D>();
		ball.AddComponent<BoxCollider2D>();
		coll = ball.GetComponent<BoxCollider2D>();

		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		rb.isKinematic = true;
		rb.gravityScale = 0f;
		speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isGame){
			startBall();
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "wall") {
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * -1);
			Debug.Log ("wo");
		}
		if (coll.gameObject.tag == "1" || coll.gameObject.tag == "2") {
			rb.velocity = new Vector2 (rb.velocity.x * -1, rb.velocity.y);
			Debug.Log ("player");
		}
		if (coll.gameObject.tag == "goal") {
			Debug.Log ("goal");
		}
	}

	void startBall(){
		rb.position = new Vector3 (0, 0.25f, 1);
		if(Input.GetKey(KeyCode.Space)){
			motion();
			isGame = true;
		}
	}

	void motion(){
		rb.velocity = new Vector2 (speed * 1, speed * 1);
	}
}
