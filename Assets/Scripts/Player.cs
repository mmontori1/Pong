//This game was created by: Mariano Montori
//Solo project started Oct. 11th
//This project is done to showcase 
//and to help anyone who wants to understand
//some of the basics of working with Unity
//https://github.com/mmontori1

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public variables
	public GameObject player;
	public Rigidbody2D rb;
	public BoxCollider2D coll;
	public int playerNumber;
	public float accel = 1f;

	// Use this for initialization
	void Start(){
		//sets player to the gameobject the script is attached
		player = this.gameObject;

		//adds and applies the following to the player:
		//Rigidbody2D for 2D physics
		//BoxCollider2D for collision detection
		player.AddComponent<Rigidbody2D>();
		rb = player.GetComponent<Rigidbody2D>();
		player.AddComponent<BoxCollider2D>();
		coll = player.GetComponent<BoxCollider2D>();

		playerPhysics();	
		playerCheck();
	}
	
	// Update is called once per frame
	void Update() {
		movement();
	}

	//Function for player movement
	void movement(){
		//movement variables
		float speed = 8f;
		//KeyCode array ordered by player number
		KeyCode[] upInput = {KeyCode.UpArrow, KeyCode.W};
		KeyCode[] downInput = {KeyCode.DownArrow, KeyCode.S};

		//depending on the player, a different input
		//requires moving the player up and down
		if(Input.GetKey(upInput[playerNumber])){
			rb.velocity = new Vector2(0, speed * accel);
		}
		else if(Input.GetKey(downInput[playerNumber])){
			rb.velocity = new Vector2(0, -(speed * accel));
		}
		else{
			rb.velocity = new Vector2(0, 0);	
		}
	}

	void playerPhysics(){
		rb.isKinematic = true;
	}

	//looks for the GameObjects tag to determine
	//whether its player 1 or player 2
	void playerCheck(){
		if(player == GameObject.FindGameObjectWithTag("1")){
			playerNumber = 0;
		}
		else if(player == GameObject.FindGameObjectWithTag("2")){
			playerNumber = 1;
		}
	}
}
