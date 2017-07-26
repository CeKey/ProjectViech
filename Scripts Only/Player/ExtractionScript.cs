using UnityEngine;
using System.Collections;

public class ExtractionScript : MonoBehaviour {

	GameObject player;
    GameObject fader;
    SceneFadeInOut sceneFade;
    bool end = false;
	float smooth = 0.5f;
    public float fadeHeight;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
        fader = GameObject.FindGameObjectWithTag(Tags.fader);
        sceneFade = fader.GetComponent<SceneFadeInOut>();
	}
	
	// Update is called once per frame
	void Update () {
        if (end)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x, 200, player.transform.position.z), smooth * Time.deltaTime);
            if (player.transform.position.y >=fadeHeight)
            {
                sceneFade.sceneEnd = true;
                fader.GetComponent<FadeWhite>().isEnd = true;
				Application.LoadLevel(3);
            } 
        }
	}


	void OnTriggerEnter(Collider other)
	{
        
            if (other.gameObject == player)
            {
                end = true;

            } 
        
	}
}
