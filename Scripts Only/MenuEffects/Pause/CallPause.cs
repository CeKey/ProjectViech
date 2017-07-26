using UnityEngine;
using System.Collections;

public class CallPause : MonoBehaviour {

    private GameObject pause;
    private GameObject fader;
    private GameObject player;

	// Use this for initialization
	void Start () {
        pause = GameObject.FindGameObjectWithTag(Tags.pause);
        pause.SetActive(false);
        fader = GameObject.FindGameObjectWithTag(Tags.fader);
        player = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            pause.SetActive(true);
            Cursor.visible = true;
            foreach (var mouseLook in player.GetComponentsInChildren<MouseLook>())
            {
                mouseLook.enabled = false;
            }
            player.GetComponentInChildren<ThrowScript>().isPaused = true;
            player.GetComponentInChildren<ThrowScript>().enabled = false;           
            fader.GetComponent<SceneFadeInOut>().scenePause = true;
            if (fader.GetComponent<SceneFadeInOut>().GetComponent<GUITexture>().color.a >=0.3f)
            {
                Time.timeScale = 0.0f; 
            }
            
        }
	}

    public void Continue()
    {
        foreach (var mouseLook in player.GetComponentsInChildren<MouseLook>())
        {
            mouseLook.enabled = true;
        }
        Cursor.visible = false;

        pause.SetActive(false);
        fader.GetComponent<SceneFadeInOut>().scenePause = false;
        Time.timeScale = 1.0f;
        StartCoroutine(Wait());

        player.GetComponentInChildren<ThrowScript>().enabled = true;
    }

    IEnumerator Wait()
    {

        //returning 0 will make it wait 1 frame
        yield return 0;

        //code goes here


    }

}
