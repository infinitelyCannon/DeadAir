using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public float speed;                     // Speed of Character (for physics based movement) 0.03
    public GameObject candy;
    public float sprintSpeed;

    [HideInInspector]
    public PlayerLocation location;
    [HideInInspector]
    public bool canInteract = false;        // Is the player in front of an interactable object (i.e. sink, oven, etc.)
    [HideInInspector]
    public bool canLeave = false;           // Is the player in front of a door he can leave through (DON'T TOUCH. Controlled by the doors themselves)
    bool isHiding = false;
    GameObject pause;
    Animator anim;
    bool canThrow = true;
    GameObject spawnPoint;
    AudioSource sound;
    SpriteRenderer visibility;
    float swapSpeed;

    float velX, velY;

    Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
        pause = GameObject.FindGameObjectWithTag("PausePanel");
        swapSpeed = speed;
        anim = GetComponent<Animator>();
        spawnPoint = transform.Find("SpawnPoint").gameObject;
        sound = GetComponent<AudioSource>();
        visibility = GetComponent<SpriteRenderer>();
        location = PlayerLocation.hall1;
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
        //Ternary Operator to determine the player's speed.
        //TODO: Have the artists create a run animation to implement. (Maybe a new sound effect too?)
        //TODO: Change the script to make the Player move by physics in order to enforce the effect of brick walls and boundaries.
        speed = (Input.GetKey(KeyCode.LeftShift) && canThrow) ? sprintSpeed : swapSpeed;

        // Can only move if the game isn't paused and the Player isn't hiding.
        if (!isPaused() && !isHiding)
        {
            // This if/else gate determines whether the player is moving or not.
            if (Input.GetButton("Horizontal"))
            {
                velX = Input.GetAxisRaw("Horizontal") * speed;
                gameObject.transform.position += new Vector3(velX, 0, 0);
                gameObject.transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1.0f, 1.0f);
                anim.SetBool("isMoving", true);
            }
            else
            {
                gameObject.transform.localScale = Vector3.one;
                anim.SetBool("isMoving", false);
            }

            // This if statement determines when the player throws the candy
            if (Input.GetKeyUp(KeyCode.Z) && canThrow)
            {
                anim.SetBool("isThrowing", true);
                canThrow = false;
                speed = 0;
                //Invoke("throwCandy", 0.5f);
                //Invoke("ResetThrow",0.5f);
            }

            // The next two if statements control when the player can enter or leave a hiding spot
            if (Input.GetKeyUp(KeyCode.UpArrow) && canInteract && !isHiding)
            {
                //Debug.Log("Can Interact!");
                visibility.enabled = false;
                isHiding = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && isHiding)
        {
            //Debug.Log("And we're out!");
            visibility.enabled = true;
            isHiding = false;
        }
        */
    }

    void FixedUpdate()
    {
        speed = (Input.GetKey(KeyCode.LeftShift) && canThrow) ? sprintSpeed : swapSpeed;

        if (!isHiding)
        {
            if (Input.GetButton("Horizontal"))
            {
                float vel = Input.GetAxis("Horizontal") * speed;
                rigidbody2d.velocity = new Vector2(vel, rigidbody2d.velocity.y);
                gameObject.transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
                anim.SetBool("isMoving", true);
            }
            else
            {
                gameObject.transform.localScale = Vector3.one;
                anim.SetBool("isMoving", false);
            }

            if(Input.GetKeyUp(KeyCode.Z) && canThrow)
            {
                anim.SetBool("isThrowing", true);
                canThrow = false;
                speed = 0;
            }

            // The next two if statements control when the player can enter or leave a hiding spot
            if (Input.GetKeyUp(KeyCode.UpArrow) && canInteract && !isHiding)
            {
                //Debug.Log("Can Interact!");
                visibility.enabled = false;
                isHiding = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && isHiding)
        {
            //Debug.Log("And we're out!");
            visibility.enabled = true;
            isHiding = false;
        }
    }

    bool isPaused()
    {
        return pause.GetComponent<PauseMenu>().isPaused;
    }

    void Hide()
    {
        //TODO: Have the Player do the hide animation
    }

    void Show()
    {
        //TODO: Have the Player do the leave animation
    }

    public void ResetThrow()
    {
        canThrow = true;
        anim.SetBool("isThrowing", false);
        speed = swapSpeed;
    }

    public void throwCandy()
    {
        Instantiate(candy, spawnPoint.transform.position, Quaternion.identity);
        //Debug.Log("Thrown");
    }

    public void Step()
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }

    void Pause()
    {
        anim.speed = 0;
    }

    void Resume()
    {
        anim.speed = 1;
    }

}
