using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public float speed;                     // Speed of Character (for physics based movement)
    public GameObject candy;

    [HideInInspector]
    public bool canInteract = false;        // Is the player in front of an interactable object (i.e. door, oven, etc.)
    bool isHiding = false;
    GameObject pause;
    Animator anim;
    bool canThrow = true;
    GameObject spawnPoint;
    AudioSource sound;

    float velX, velY;

	// Use this for initialization
	void Start () {
        //pause = GameObject.FindGameObjectWithTag("PausePanel");
        anim = GetComponent<Animator>();
        spawnPoint = transform.Find("SpawnPoint").gameObject;
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // Can only move if the game isn't paused and the Player isn't hiding.
        if (!isPaused() && !isHiding)
        {
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
            if (Input.GetKeyUp(KeyCode.Z) && canThrow)
            {
                anim.SetBool("isThrowing", true);
                canThrow = false;
                //Invoke("throwCandy", 0.5f);
                Invoke("ResetThrow",0.5f);
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && canInteract && !isHiding)
        {
            Debug.Log("Can Interact!");
            isHiding = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && isHiding)
        {
            Debug.Log("And we're out!");
            isHiding = false;
        }
	}

    bool isPaused()
    {
        return false; //pause.GetComponent<PauseMenu>().isPaused;
    }

    void Hide()
    {
        //TODO: Have the Player do the hide animation
    }

    void Show()
    {
        //TODO: Have the Player do the leave animation
    }

    void ResetThrow()
    {
        canThrow = true;
        anim.SetBool("isThrowing", false);
    }

    public void throwCandy()
    {
        //Instantiate(candy, spawnPoint.transform.position, Quaternion.identity);
        Debug.Log("Thrown");
    }

    public void Step()
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }

}
