using UnityEngine;
using System.Collections;

public class StunScript : MonoBehaviour{


    #region Attributes

    private EnemyAI enemyAI;
    private GameObject player;
    private float stunTime = 2f;
    public GameObject explosion;

    #endregion

    #region Properties

    private float _stunTimer;

    public float StunTimer
    {
        get { return _stunTimer; }
        set { _stunTimer = value; }
    }
    


    #endregion


    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //void OnTriggerEnter(Collider other)
    //{
    //    StunTimer = 0;
    //    if (other.gameObject == enemy)
    //    {
    //        enemyAI = other.GetComponent<EnemyAI>();
    //        GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//stronger static field
    //        Destroy(gameObject);
            
    //        do
    //        {
    //            StunTimer += Time.deltaTime;
    //            enemyAI.IsStuned = true;
    //        } while (StunTimer < stunTime);

    //        Destroy(expl, 0.2f);
    //    }

    //}


	public void Explode(Collider other)
	{
        GameObject expl;
        try
        {
			StunTimer = 0;
            if (other.gameObject != player.gameObject)
           {
               enemyAI = other.transform.root.GetComponent<EnemyAI>();
               expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//stronger static field
                

                do
                {
                    StunTimer += Time.deltaTime;
                    enemyAI.IsStuned = true;

                } while (StunTimer < stunTime);
				
            }
            else
            {
                player.GetComponent<SprintScript>().isStuned = true;
                expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Destroy(expl, 0.2f);
            
        }
        catch (System.Exception)
        {
          
        }
	}


}
