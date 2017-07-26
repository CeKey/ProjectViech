using UnityEngine;
using System.Collections;

public class SlowScript : MonoBehaviour
{

    #region Attributes

    private EnemyAI enemyAI;
    private GameObject player;
    public GameObject explosion;

    #endregion


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    // Update is called once per frame
    void Update()
    {

    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == enemy)
    //    {
    //        enemyAI = other.GetComponent<EnemyAI>();
    //        enemyAI.IsSlowed = true;

    //        GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//static field
    //        Destroy(gameObject);
    //        Destroy(expl, 0.2f);
    //    }


    //}

	public void Explode(Collider other)
	{
        try
        {
            if (other.gameObject != player.gameObject)
            {
                enemyAI = other.transform.root.GetComponent<EnemyAI>();
                enemyAI.IsSlowed = true;

                GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//static field
                Destroy(gameObject);
                Destroy(expl, 0.2f);
            }
            else
            {
                player.GetComponent<SprintScript>().isSlowed = true;
                GameObject expl = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);//static field
                Destroy(gameObject);
                Destroy(expl, 0.2f);
            }
            
        }

        catch (System.Exception)
        {
            
           
        }
        
	}

}
