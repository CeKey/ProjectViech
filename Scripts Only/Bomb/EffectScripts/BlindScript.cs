using UnityEngine;
using System.Collections;

public class BlindScript : MonoBehaviour
{

    #region Attributes

    private GameObject player;
    //private float timer;
    //private bool playerIsBlind;
    public GameObject explosion;
    public GameObject fader;
    
    
   
    #endregion


    // Use this for initialization
    void Start()
    {
        //timer = 0;
		//Referenzsetzung auf Gegner
        player = GameObject.FindGameObjectWithTag(Tags.player);
        fader = GameObject.FindGameObjectWithTag("WFader");
        
        
        
    }

    public void Update()
    {
       
    }

	public void Explode(Collider other)
	{
            if (other.gameObject.tag != Tags.player)
            {
                other.transform.root.GetComponent<EnemyAI>().isBlind = true;
                
                
          }
            else
            {
                fader.GetComponent<FadeWhite>().isEnd = false;
                fader.GetComponent<FadeWhite>().FadeToWhite();
                //playerIsBlind = true;
                fader.GetComponent<FadeWhite>().isBlind = true;
            }
            GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//FlashBang
            //Bombe zerstören
            Destroy(gameObject);
            //Effekt zerstören
            Destroy(expl, 0.2f);   
	}


}
