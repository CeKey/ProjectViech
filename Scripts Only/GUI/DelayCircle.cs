using UnityEngine;
using System.Collections;

public class DelayCircle : MonoBehaviour {

    public bool hasTrail;
    public float trailOffset = 10;
    public bool stepped = false;

    public GameObject Circle3D;

    public bool activated = false;
	public bool finished = false;
    public float delay ; 
	public float percent = 0;
    
    int i = 0;
    float deltaRot;


	// Use this for initialization
	void Start () {
		//Debug.Log(this);
        
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

            if (!activated)
            {
                finished = false;
                i = 0;
                foreach (Transform child in transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                    child.transform.rotation = transform.rotation;
                }
                if (hasTrail)
                {
                    foreach (Transform ParentsChild in transform.parent.transform)
                    {
                        if (ParentsChild.gameObject.name == "UI_DelayCircle3D(Clone)")
                        {
                            Destroy(ParentsChild.gameObject);
                        }
                    }
                }
               
            }
            if (activated)
            {
                foreach (Transform child in transform)
                {
                    if(!stepped)child.GetComponent<MeshRenderer>().enabled = true;
                    
                    if (delay != 0)
                    {
                        if (hasTrail)
                        {
                            if (i == 0)
                            {
                                deltaRot = 0;
                            }
                            deltaRot++;

                            if (deltaRot >= delay / trailOffset)
                            {
                                deltaRot = 0;
                                GameObject trail = Instantiate(Circle3D, child.transform.position, child.transform.rotation) as GameObject;

                                if (trail != null && gameObject.transform != null)
                                {
                                    trail.transform.parent = transform.parent.transform;
                                }
                            }
                        }

                        child.transform.Rotate(Vector3.forward * 360 / delay);
                        i++;
                        if (i >= delay)
                        {
                            finished = true;
                            child.transform.rotation = transform.rotation;

                            foreach (Transform ParentsChild in transform.parent.transform)
                            {
                                if (ParentsChild.gameObject.name == "UI_DelayCircle3D(Clone)")
                                {
                                    Destroy(ParentsChild.gameObject);
                                }
                            }
                        } 
                    }
                }
        }
	
	}

}
