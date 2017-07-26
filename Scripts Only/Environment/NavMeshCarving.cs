using UnityEngine;
using System.Collections;

public class NavMeshCarving : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NavMeshObstacle nav = GetComponent<NavMeshObstacle>();
        nav.carving = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
