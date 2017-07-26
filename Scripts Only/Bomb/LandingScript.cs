using UnityEngine;
using System.Collections;

public class LandingScript : MonoBehaviour {

	public GameObject Sensor;

	private GameObject[] way = new GameObject[20];
	private DetectionScript eDetect;





	void Awake()
	{
		way = GameObject.FindGameObjectsWithTag (Tags.way);
	}

    void OnCollisionEnter(Collision collision)
    {
		bool hitGround = false;
		for (int i = 0; i < way.Length; i++) 
		{
			if (way[i]== collision.gameObject) {
				hitGround = true;
				break;
			}
		}

		if (hitGround) 
		{
			float[] used = {-1,-1,-1};
			
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			GetComponent<Rigidbody>().isKinematic = true;
			    
			for (int i = 0; i < 3; i++) 
			{
				used [i] = DeploySensor (used, i);
			}
		}

    }


	float DeploySensor(float[] usedPositions,int position){


		bool used;
		float spawnPosition;

		do {
			used = false;
			int rand = Random.Range (0, 4);

			switch (rand) {                     //Originalwerte
			case 0:	spawnPosition = 1.5f; break;   //2
			case 1: spawnPosition = 3; break;   //3
			case 2: spawnPosition = 5; break;   //4
			case 3: spawnPosition = 8; break;   //5
			default: spawnPosition = 0; break;
			}
			for (int i = 0; i < position; i++) {
				if (usedPositions [i] == spawnPosition || spawnPosition ==0) {
					used = true;
				}
			}
		} while (used);

		SensorSpawnScript.Spawn(spawnPosition, gameObject,Sensor);



		return spawnPosition;
	}
}
