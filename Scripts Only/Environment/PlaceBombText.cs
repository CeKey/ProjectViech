using UnityEngine;
using System.Collections;

public class PlaceBombText : MonoBehaviour {

    GUIText text;
    GameObject player;

	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag(Tags.player);
        text = player.GetComponentInChildren<GUIText>();
		//text.active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player.gameObject)
        {
            text.enabled = true;
        }
    }


    void OnTriggerLeave(Collider col)
    {
        text.enabled=false;
    }
}
