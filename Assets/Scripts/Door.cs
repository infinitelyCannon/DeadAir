using UnityEngine;
using System.Collections;

public enum Location
{
    bathroom,kitchen
}

public class Door : MonoBehaviour {

    public Location target;

    GameObject player, cam;
    bool isTriggered = false;
    GameObject pause;
    Vector3[] Rooms = new Vector3[] { new Vector3(0.83f,-0.63f,0), new Vector3(0.8f, 4.23f,0), new Vector3(-7.852f,12.336f,0) };
    Vector3[] camRooms = new Vector3[] {new Vector3(0,0,-10), new Vector3(-1.1f,4.86f,-10), new Vector3(-9.66f, 12.93f,-10) };

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        pause = GameObject.FindGameObjectWithTag("PausePanel");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPaused())
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && isTriggered)
            {
                Teleport();
                //Run this object's opening animation
            }
        }
	}

    void Teleport()
    {
        switch (target)
        {
            case Location.bathroom:
                cam.GetComponent<CameraFollow>().JumpToRoom(camRooms[1]);
                player.transform.position = Rooms[1];
                player.GetComponent<Interact>().location = PlayerLocation.bathroom;
                break;
            case Location.kitchen:
                cam.GetComponent<CameraFollow>().JumpToRoom(camRooms[2]);
                player.transform.position = Rooms[2];
                player.GetComponent<Interact>().location = PlayerLocation.kitchen;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Interact>().canLeave = true;
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Interact>().canLeave = false;
            isTriggered = false;
        }
    }

    bool isPaused()
    {
        return pause.GetComponent<PauseMenu>().isPaused;
    }
}
