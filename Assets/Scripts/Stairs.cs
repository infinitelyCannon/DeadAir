using UnityEngine;
using System.Collections;

public enum Hallway
{
    hall1,hall2,hall3
}

public class Stairs : MonoBehaviour {

    public Hallway hall;

    GameObject player, cam, pause, fade;
    bool isTriggered = false;
    Vector3[] Halls = new Vector3[] { new Vector3(0.83f,-0.63f,0), new Vector3(0.83f, -6.42f,0) };
    Vector3[] CamPos = new Vector3[] { new Vector3(0,0,-10), new Vector3(0.83f,-5.79f,-10) };

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        pause = GameObject.FindGameObjectWithTag("PausePanel");
        fade = GameObject.FindGameObjectWithTag("Fade");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPaused())
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && isTriggered)
            {
                fade.SendMessage("FadeIn");
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }

    void Teleport()
    {
        if (isTriggered)
        {
            switch (hall)
            {
                case Hallway.hall1:
                    cam.GetComponent<CameraFollow>().JumpToHall(CamPos[0]);
                    player.transform.position = Halls[0];
                    player.GetComponent<Interact>().location = PlayerLocation.hall1;
                    fade.SendMessage("FadeOut");
                    break;
                case Hallway.hall2:
                    cam.GetComponent<CameraFollow>().JumpToHall(CamPos[1]);
                    player.transform.position = Halls[1];
                    player.GetComponent<Interact>().location = PlayerLocation.hall2;
                    fade.SendMessage("FadeOut");
                    break;
                case Hallway.hall3:
                    Debug.Log("To be done . . .");
                    break;
                default:
                    break;
            }
        }
    }

    bool isPaused()
    {
        return pause.GetComponent<PauseMenu>().isPaused;
    }
}
