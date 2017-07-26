using UnityEngine;
using System.Collections;

public class StickyExplosion : MonoBehaviour {


    private float timer = 0;
    public float maxTime = 3;
    public GameObject destroyedWall;
    public GameObject explosion;
    public AudioClip boom;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        GetComponent<GUIText>().text = Mathf.Round(timer).ToString();
        if (timer >= maxTime)
        {
            

            GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
            
            Instantiate(destroyedWall, transform.root.position, transform.root.rotation);
            Destroy(transform.root.gameObject);
            Destroy(expl,0.2f);
            AudioSource.PlayClipAtPoint(boom, transform.position);
            
        }

	}
}
