using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public string startLevel;


	public void NewGame()
	{
        SceneManager.LoadScene(startLevel);
	}

	public void QuitGame()
	{
		Debug.Log ("GameEXited");
		Application.Quit();
	}
}
