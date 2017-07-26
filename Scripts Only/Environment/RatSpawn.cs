using UnityEngine;
using System.Collections;

public class RatSpawn : MonoBehaviour
{

    public GameObject Rat;
    public GameObject[] spawnPoints;

    // Use this for initialization
    void Start()
    {

        foreach (var point in spawnPoints)
        {
            Instantiate(Rat, point.transform.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
