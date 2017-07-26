using UnityEngine;
using System.Collections;

public class DetectionScript : MonoBehaviour {

	GameObject[] houses;

	// Use this for initialization
	void Start () {
		houses = GameObject.FindGameObjectsWithTag (Tags.house);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (!other.isTrigger) 
		{
			foreach (var item in houses) {
				if (other.gameObject==item) {
					return;
				}
			}
			transform.root.GetComponent<ExplosionScript>().Explode(other);
		}

	}

}
