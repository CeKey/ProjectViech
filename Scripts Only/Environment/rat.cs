using UnityEngine;
using System.Collections;

public class rat : MonoBehaviour {

    public float speed = 2f;
    public float runSpeed = 4;
    public float ChangeDirAfter = 100;
    float ChangeDirAfterOG;
    public float runAwayDistance = 10;
    bool walking = true;
    int i;
    Vector3 Rotation;
    Vector3 PlayerToGO;
    GameObject Threat;
    ContactPoint closestWall;
    bool hitWall = false;
    float speedOG;
    int i2 = 0;

	// Use this for initialization
	void Start () {
        
        Threat = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(GetComponent<Collider>(), Threat.GetComponent<Collider>());
        transform.rotation = Quaternion.Euler(270, 0, 0);
        
        
        ChangeDirAfterOG = ChangeDirAfter;
        speedOG = speed;
        ChangeDirAfter += Random.Range(-5, 5);
	}
	
	// Update is called once per frame
	void Update () {
        if (hitWall)
        {
            i++;
            if (i > 10)
            {
                hitWall = false;
                i = 0;
            }
            if (GetComponent<Rigidbody>().velocity.magnitude < 0.0001)
            {
                transform.Rotate(Rotation);
            }
        }
        if (Threat != null)
        {
            PlayerToGO = new Vector3(transform.position.x - Threat.transform.position.x, 0, transform.position.z - Threat.transform.position.z);
            if (PlayerToGO.magnitude <= runAwayDistance)
            {
                if (!hitWall)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(-PlayerToGO.x, 270, -PlayerToGO.z));
                }
                Debug.DrawRay(transform.position, PlayerToGO);

                walking = true;
                i = 0;
                speed = runSpeed;
            }
            else
            {
                speed = speedOG;
            }
        }
        if (walking)
        {
            i++;
            transform.Translate(transform.forward * speed * Time.deltaTime);
            if (i > ChangeDirAfter)
            {
                walking = false;
                i= 0;
                Rotation = new Vector3 (0,0, Random.Range(-10,10));
            }
            ChangeDirAfter = ChangeDirAfterOG;
            ChangeDirAfter += Random.Range(-10, 10);
        }
        if (!walking)
        {
            transform.Rotate(Rotation);
            i++;
            if (i > 10)
            {
                walking = true;
            }
            
        }
}
  void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];

        if (Vector3.Distance(contact.point, transform.position) < Vector3.Distance(closestWall.point, transform.position))
        {
            closestWall = contact;
            Debug.DrawLine(closestWall.point, transform.position);
            if (closestWall.point.y > transform.position.y)
            {
                float angle = Vector3.Angle(transform.forward, PlayerToGO);
                transform.rotation = Quaternion.LookRotation(new Vector3(-closestWall.normal.x, 270, -closestWall.normal.z));
                hitWall = true;

                if (angle > 90)
                {
                    transform.Rotate(0, 0, 90);
                }
                else
                {
                    transform.Rotate(0, 0, -90);
                }
            }
        }

    }
}
