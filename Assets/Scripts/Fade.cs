using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
    Animator anim;
    GameObject[] stairSet;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        stairSet = GameObject.FindGameObjectsWithTag("Stairs");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    public void Teleport()
    {
        int i;

        for (i = 0; i < stairSet.Length; i++)
        {
            stairSet[i].SendMessage("Teleport");
        }
    }
}
