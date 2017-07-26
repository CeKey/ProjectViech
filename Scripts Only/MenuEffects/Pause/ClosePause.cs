using UnityEngine;
using System.Collections;

public class ClosePause : MonoBehaviour {

    GameObject menu;

	// Use this for initialization
	void Start () {
        menu = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            menu.GetComponent<CallPause>().Continue();
        }
	}
}
