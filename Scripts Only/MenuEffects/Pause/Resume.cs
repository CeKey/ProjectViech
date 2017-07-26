using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

    GameObject menu;

	// Use this for initialization
	void Start () {
	    menu = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		Time.timeScale = 1.0f;
        menu.GetComponent<CallPause>().Continue();
	}
}
