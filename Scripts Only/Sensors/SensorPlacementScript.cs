using UnityEngine;
using System.Collections;
namespace AssemblyCSharp
{
	public class SensorPlacementScript : MonoBehaviour
	{
		GameObject[] houses = new GameObject[20];
		public  float hitdistance = 100;
		int maxcount = 20;
        public float force = 100;
        

		public RaycastHit hit {
			get;
			set;
		}

		public bool mounted {
			get;
			set;
		}

		public float pos {
			get;
			set;
		}

		public Vector3 col {
			get;
			set;
		}

		void Start()
		{

			houses = GameObject.FindGameObjectsWithTag (Tags.house);
           

			int trycount=0;
			int rand=0;
			bool set;
			do{
				RaycastHit l_hit = new RaycastHit();
				trycount++;

                for (int i = 0; i < 5; i++)
                {
                    rand = Random.Range(0, 4); 
                }

				set = false;
						
				switch (rand) {
				case 0: if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.right),out l_hit,hitdistance))set=true;  break;
				case 1: if(Physics.Raycast(transform.position,-transform.TransformDirection(Vector3.right),out l_hit,hitdistance))set=true;  break;
				case 2: if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out l_hit,hitdistance))set=true; break;
				case 3: if(Physics.Raycast(transform.position,-transform.TransformDirection(Vector3.forward),out l_hit,hitdistance))set=true; break;
				default: break;
				}
				hit = l_hit;
			
				 

			}while (!moveCollider(set,rand,trycount)); 


		}




		public void OnCollisionEnter(Collision collision)
		{	

			foreach (var house in houses) 
			{
				if (collision.gameObject == house) {
					GetComponent<Rigidbody>().velocity = Vector3.zero;
					//rigidbody.angularVelocity = Vector3.zero;
					GetComponent<Rigidbody>().isKinematic = true;
					mounted = true;
					setRay();
				}
			}



		}


		public bool moveCollider(bool set, int rand, int trycount)
		{
			if (set) {	
				
				foreach (var house in houses) {
					if ( hit.collider.gameObject == house) {
						switch (rand) {
                        case 2: transform.Rotate(0,-90,0);break; //rigidbody.AddRelativeForce(100,0,0);break;
                        case 3: transform.Rotate(0,90, 0, 0); break;//rigidbody.AddRelativeForce(-100,0,0); break;
                        case 0: transform.Rotate(0, 0, 0, 0); break;//rigidbody.AddRelativeForce(0,0,100); break;
                        case 1: transform.Rotate(0, 180, 0, 0); break; //rigidbody.AddRelativeForce(0,0,-100); break;
						default:break;
						}
                        
                        GetComponent<Rigidbody>().AddRelativeForce(force,0,0);
                        
						

						return true;
					}
					
				}
			}
			else if(trycount > maxcount) {
				Destroy(gameObject);

				Destroy(transform.root.gameObject);
				return true;
			}
			return false;
		}

		public bool setRay()
		{
			if (mounted) 
			{
                transform.rotation.SetFromToRotation(transform.position, GetComponentInParent<Transform>().position);
                GameObject child = transform.GetChild(0).gameObject;
                child.SetActive(true);
			}
			return false;
		}

	}
}

