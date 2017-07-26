using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour
{

    
    public GameObject explosion;
    private GameObject player;
    //private GameObject fader;
	private bool end;
    //private GameObject enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        //fader = GameObject.FindGameObjectWithTag(Tags.fader);
        //enemy = GameObject.FindGameObjectWithTag(Tags.enemy);
    }
	
   

	public void Explode(Collider other)
	{
        //Vector3 bombOrigin = transform.position;
        //Collider[] colliders = Physics.OverlapSphere(bombOrigin, radius);
		
        //foreach (Collider hit in colliders)
        //{
        //    //	if (hit.rigidbody && !hit.isTrigger && hit != this.collider) {
        //    foreach (var item in enemys)
        //    {
        //        if (item.gameObject == hit.gameObject)
        //        {
        //            //Kraft auf objekte ausüben
        //            hit.rigidbody.AddExplosionForce(power, transform.position, radius, explosionlift);
        //            hit.transform.root.GetComponent<EnemyAI>().Die();
        //            break;
        //        }
        //        else if (hit.gameObject == player.gameObject)
        //        {
        //            fader.GetComponent<SceneFadeInOut>().EndScene(2);
        //            break;
        //        }
        //        GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
        //        Destroy(gameObject);
        //        Destroy(expl, 0.2f);
        //        Destroy(hit); 
        //    }
			
        //    //	}
        //}



        try
        {
            if (other.gameObject != player.gameObject)
            {
                other.transform.root.GetComponent<EnemyAI>().Die();
            }
            else
            {
                player.GetComponent<PlayerDeath>().dead = true;
            }
            GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//FlashBang
            //Bombe zerstören
            Destroy(gameObject);
            //Effekt zerstören
            Destroy(expl, 0.2f);
        }
        catch (System.Exception)
        {
            
            
        }
        
	}


}
