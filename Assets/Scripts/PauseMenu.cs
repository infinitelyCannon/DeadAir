using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;

	public string mainMenu;

    [HideInInspector]
    public bool isPaused = false;

	public GameObject pauseMenuCanvas;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update() 
	{
        /*
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
		} else {
			//pauseMenuCanvas.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	    */
        if (Input.GetButtonUp("Cancel"))
        {
            isPaused = true;
            anim.SetTrigger("Pause");
            //TODO: Send a "Pause" message to all GameObjects with a pause funtion
        }
	}

	public void Resume()
	{
		isPaused = false;
        anim.SetTrigger("Resume");
        //TODO: Send a "Resume" message to all GameObjects with a pause funtion
    }

    public void Controls()
	{
		SceneManager.LoadScene(levelSelect);
	}

	public void Quit()
	{
		SceneManager.LoadScene(mainMenu);
	}
}
