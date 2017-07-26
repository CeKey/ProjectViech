using UnityEngine;
using System.Collections;

public class ScreamScript : MonoBehaviour {

    public AudioClip sound;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Tags.player)
        {
            AudioSource.PlayClipAtPoint(sound, transform.root.position);
            Destroy(transform.root.gameObject);
        }
    }
}
