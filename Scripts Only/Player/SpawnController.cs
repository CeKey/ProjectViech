using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public int maxCreatures;
    public static int currentCreatures;
    

    public GameObject[] aliens;
    

    // Use this for initialization
    void Start()
    {
        int spawnCount = 0;
        //for (int i = 0; i < 5; i++)
        //{
        //    switch (i)
        //    {
        //        case 0: Instantiate(alien,spawnPoint1.transform.position,Quaternion.identity); break;
        //        case 1: Instantiate(alien, spawnPoint2.transform.position, Quaternion.identity); break;
        //        case 2: Instantiate(alien, spawnPoint3.transform.position, Quaternion.identity); break;
        //        case 3: Instantiate(alien, spawnPoint4.transform.position, Quaternion.identity); break;
        //        case 4: Instantiate(alien, spawnPoint5.transform.position, Quaternion.identity); break;
        //        default:
        //            break;
        //    }
            
        //}

        foreach (var alien in aliens)
        {
            Instantiate(alien, spawnPoints[spawnCount].transform.position, Quaternion.identity);

            spawnCount++;
            if (spawnCount >= spawnPoints.Length)
            {
                spawnCount = 0;
            }
        }
        currentCreatures = aliens.Length;
        maxCreatures = currentCreatures;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void ReduceCreatures(int nrCreatures)
    {
        currentCreatures -= nrCreatures;
    }

    public static void ReduceCreatures()
    {
        ReduceCreatures(1);
    }
}
