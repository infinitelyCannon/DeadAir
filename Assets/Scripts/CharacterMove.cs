using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	public float movespeed;

	void Start() {
	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-movespeed, GetComponent<Rigidbody2D>().velocity.x);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (movespeed, GetComponent<Rigidbody2D>().velocity.x);
		}
	}
}
