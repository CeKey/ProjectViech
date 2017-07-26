using UnityEngine;
using System.Collections;

public class MenuPatrol : MonoBehaviour {
    public Transform[] patrolWayPoints;
    private int wayPointIndex;
    private NavMeshAgent nav; 

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        wayPointIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

            if (transform.position.x - patrolWayPoints[wayPointIndex].transform.position.x < 0.01f && transform.position.z - patrolWayPoints[wayPointIndex].transform.position.z < 0.01f)
            { //if patrol timer greater equal patrol wait timer
                if (wayPointIndex == patrolWayPoints.Length - 1)
                { // if the waypoint index is > the arraylength - 1
                    wayPointIndex = 0; //reset the index
                }
                else
                {
                    wayPointIndex++; //increase the index
                }
         
            }
        
        
        nav.destination = patrolWayPoints[wayPointIndex].position; //set navigation destination to the waypoint at the index position
	}


}
