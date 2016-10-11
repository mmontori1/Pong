//This game was created by: Mariano Montori
//Solo project started Oct. 11th
//This project is done to showcase 
//and to help anyone who wants to understand
//some of the basics of working with Unity
//https://github.com/mmontori1

using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	//variables
	public GameObject goal;
	public Rigidbody2D rb;
	public BoxCollider2D coll;
	public int playerNumber;
	public LayerMask playerLayer;

	//use this for initialization
	void Start(){
		//sets goal to the gameobject the script is attached
		goal = this.gameObject;

		//adds and applies the following to the wall:
		//Rigidbody2D for 2D physics
		//BoxCollider2D for collision detection
		//tag "wall" to define it as a wall
		goal.AddComponent<Rigidbody2D>();
		rb = goal.GetComponent<Rigidbody2D>();
		goal.AddComponent<BoxCollider2D>();
		coll = goal.GetComponent<BoxCollider2D>();
		goal.tag = "goal";

		goalPhysics();
		playerDetect();
	}

	//update is called once per frame
	void Update(){

	}

	//function for player physics
	void goalPhysics(){
		//freezes position
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
		rb.isKinematic = false;
	}

	int playerDetect(){
		if(goal.name == "Left Goal"){
			playerNumber = 2;
		}
		if(goal.name == "Right Goal"){
			playerNumber = 1;
		}
		return playerNumber;
	}
}