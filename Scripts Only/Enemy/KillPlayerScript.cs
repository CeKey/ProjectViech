using UnityEngine;
using System.Collections;

public class KillPlayerScript : MonoBehaviour {

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject==player)
        {
            transform.root.GetComponent<EnemyAI>().Kill();
        }
    }
}
