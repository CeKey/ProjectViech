using UnityEngine;
using System.Collections;

public class teleportCheatCodeABC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	bool key1 = false;
	bool key2 = false;
	bool key3 = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			key1 = true;
				}
		if (Input.GetKey (KeyCode.B)) {
			key2 = true;
				}
		if (Input.GetKey (KeyCode.C)) {
			key3 = true;
				}
		if(key1 == true && key2 == true && key3 == true)
		   {
			transform.position = new Vector3(-27.67f, 1.06f, -15.98f);
			key1 = false;
			key2 = false;
			key3 = false;
		}
	
	}
}
