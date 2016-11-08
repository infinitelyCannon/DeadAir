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
            anim.SetTrigger("Pause");
            //TODO: Send a "Pause" message to all GameObjects with a pause funtion
            isPaused = true;
        }
	}

	public void Resume()
	{
        //Time.timeScale = 1f;
        anim.SetTrigger("Resume");
        //TODO: Send a "Resume" message to all GameObjects with a pause funtion
        isPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Controls()
	{
		SceneManager.LoadScene(levelSelect);
	}

	public void Quit()
	{
		SceneManager.LoadScene(mainMenu);
	}

    /*
    IEnumerator onPause()
    {
        float i;
        for (i = 0f; i <= 1f; i += 0.05f)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i);
            yield return null;
        }
    }
    */
}
