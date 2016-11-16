using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreathOmeter : MonoBehaviour {

    Slider slider;
    int SLIDER_MAX = 1000;
    AudioSource sound;
    bool canGasp = true;
    GameObject pause;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        sound = GetComponent<AudioSource>();
        //slider.onValueChanged.AddListener(delegate { valCheck(); });
        pause = GameObject.FindGameObjectWithTag("PausePanel");
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPaused())
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                CancelInvoke("Rise");
                InvokeRepeating("Drain", 0.0f, 0.01f);
            }
            else if (Input.GetKeyUp(KeyCode.X))
            {
                CancelInvoke("Drain");
                InvokeRepeating("Rise", 0.0f, 0.01f);
            }
        }
	}

    void Drain()
    {
        if (slider.value > 0)
        {
            slider.value--;
        }
    }

    void Rise()
    {
        if (slider.value < SLIDER_MAX)
        {
            slider.value++;
        }
    }

    public void valCheck()
    {
        if (slider.value <= 0 && canGasp)
        {
            canGasp = false;
            sound.Play();
        }else if (slider.value > 0)
        {
            canGasp = true;
        }
    }

    bool isPaused()
    {
        return pause.GetComponent<PauseMenu>().isPaused;
    }
}
