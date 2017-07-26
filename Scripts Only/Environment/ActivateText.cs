using UnityEngine;
using System.Collections;

public class ActivateText : MonoBehaviour {
    GameObject main;
	// Use this for initialization
	void Start () {
        main = GameObject.FindGameObjectWithTag(Tags.player);

	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == main.tag)
        {
            //col.GetComponentInChildren<GUIText>().guiText.enabled = true;
            main.transform.FindChild("Main Camera").FindChild("BombText").gameObject.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        main.transform.FindChild("Main Camera").FindChild("BombText").gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (main != null)
        {
            main.transform.FindChild("Main Camera").FindChild("BombText").gameObject.SetActive(false);
        }
    }
}
