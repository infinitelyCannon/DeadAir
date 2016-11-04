using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour
{

    public float launchSpeed;

    Rigidbody2D rigidBody;
    AudioSource sound;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();

        //if (rigidBody.velocity.y < 0)
        {
            rigidBody.AddForce(new Vector2(150 * GameObject.FindGameObjectWithTag("Player").transform.localScale.x, 300));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        rigidBody.AddForce(new Vector2(0, -5));

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
