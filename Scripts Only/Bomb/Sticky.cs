using UnityEngine;
using System.Collections;

public class Sticky : MonoBehaviour {


    void OnCollisionEnter(Collision other)
    {
        if (GetComponent<Rigidbody>() != null)
        {
            Destroy(GetComponent<Rigidbody>());
        }
        
        transform.parent = other.transform;
    }
}
