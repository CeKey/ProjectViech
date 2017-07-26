using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public Bombtypes.Stati type;
    public AudioClip boom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Explode(Collider other)
	{
        
		switch (type) {
		case Bombtypes.Stati.Blind: GetComponent<BlindScript>().Explode(other); break;
		case Bombtypes.Stati.Slow: GetComponent<SlowScript>().Explode(other); break;
		case Bombtypes.Stati.Stun: GetComponent<StunScript>().Explode(other); break;
		case Bombtypes.Stati.Kill: GetComponent<KillScript>().Explode(other); break;
		default: break;
		}
         
        PlayAudio();
        

    }
    protected void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(boom, transform.position);
    }
}
