using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

    public float launchSpeed;

    Rigidbody2D rigidBody;
    AudioSource sound;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (rigidBody.velocity.y < 0f)
        {
            rigidBody.AddForce(new Vector2(launchSpeed, 0f));
        }

        if (rigidBody.velocity.y >= 0f)
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
