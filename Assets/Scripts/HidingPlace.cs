using UnityEngine;
using System.Collections;

public class HidingPlace : MonoBehaviour {

    //GameObject player;

    bool isTriggered = false;
    GameObject pause;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //pause = GameObject.FindGameObjectWithTag("PausePanel");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused())
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && isTriggered)
            {
                Debug.Log("You interacted");
                //Run this object's opening animation
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && isTriggered)
            {
                Debug.Log("Byeee!");
                //Run the animation again
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Interact>().canInteract = true;
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Interact>().canInteract = false;
            isTriggered = false;
        }
    }

    bool isPaused()
    {
        return false; //pause.GetComponent<PauseMenu>().isPaused;
    }
}
