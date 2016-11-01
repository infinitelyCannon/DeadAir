using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

    public float launchSpeed;

    Rigidbody2D rigidBody;
    AudioSource sound;
    GameObject player;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
<<<<<<< HEAD
        player = GameObject.FindGameObjectWithTag("Player");
    }
=======

		//if (rigidBody.velocity.y < 0)
		{
			rigidBody.AddForce(new Vector2(150 * GameObject.FindGameObjectWithTag("Player").transform.localScale.x, 300));
		}
	}
>>>>>>> origin/master
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
<<<<<<< HEAD
        if (rigidBody.velocity.y < 0f)
        {
            rigidBody.AddForce(new Vector2(launchSpeed, 0f) * player.transform.localScale.x);
        }
=======
		
		rigidBody.AddForce (new Vector2 (0,-5));
>>>>>>> origin/master

		if (rigidBody.velocity.y == 0)
		{
			Invoke("deSpawn", 1.2f);
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }

    void deSpawn()
    {
        Destroy(gameObject);
    }
}
