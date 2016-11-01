using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

    public float speed;         // The horizontal velocity of the projectile

    Rigidbody2D rigidBody;
    bool move = true;
    float yVelocity = -0.04f;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = Vector2.one * speed;
        velocity += Physics2D.gravity * Time.fixedDeltaTime;

        if (move)
        {
            transform.position += new Vector3(velocity.x, velocity.y, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        move = false;
    }
    
}
