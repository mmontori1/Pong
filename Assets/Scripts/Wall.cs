//This game was created by: Mariano Montori
//Solo project started Oct. 11th
//This project is done to showcase 
//and to help anyone who wants to understand
//some of the basics of working with Unity
//https://github.com/mmontori1

using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	//variables
	public GameObject wall;
	public Rigidbody2D rb;
	public BoxCollider2D coll;

	//use this for initialization
	void Start(){
		//sets player to the gameobject the script is attached
		wall = this.gameObject;

		//adds and applies the following to the wall:
		//Rigidbody2D for 2D physics
		//BoxCollider2D for collision detection
		//tag "wall" to define it as a wall
		wall.AddComponent<Rigidbody2D>();
		rb = wall.GetComponent<Rigidbody2D>();
		wall.AddComponent<BoxCollider2D>();
		coll = wall.GetComponent<BoxCollider2D>();
		wall.tag = "wall";

		wallPhysics();
	}
	
	//update is called once per frame
	void Update(){
	
	}

	//function for player physics
	void wallPhysics(){
		//freezes position
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
		rb.isKinematic = false;
	}
}