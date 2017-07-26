using UnityEngine;
using System.Collections;

public class SensorSpawnScript : MonoBehaviour{



	public static void Spawn(float position, GameObject bomb, GameObject Sensor)
	{
		GameObject sensor = (GameObject)Instantiate (Sensor, new Vector3 (bomb.transform.position.x, position, bomb.transform.position.z),Quaternion.identity);
		sensor.transform.parent = bomb.transform;
		sensor.GetComponent<Rigidbody>().useGravity = false;
		//sensor.rigidbody.isKinematic = true;
        

	}


}
