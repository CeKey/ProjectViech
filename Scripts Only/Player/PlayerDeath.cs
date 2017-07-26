using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public bool dead = false;
	SceneFadeInOut sceneFade;
	private GameObject fader;

	// Use this for initialization
	void Start () {
		fader = GameObject.FindGameObjectWithTag(Tags.fader);
		sceneFade = fader.GetComponent<SceneFadeInOut>();
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) 
		{
			sceneFade.EndScene(2);
            fader.GetComponent<FadeWhite>().isEnd = true;
		}
	}
}
