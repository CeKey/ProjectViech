using UnityEngine;
using System.Collections;

public class PlantBomb : MonoBehaviour {

    // plantableBombGhost für projektion, plantableBomb für eigentliche Bombe
    public bool activated = true;
    public GameObject plantableBombGhost;
    public GameObject plantableBomb;
    public float range = 5;
    public int plantDelay = 30;
    public GameObject GUIdelay;

    private GameObject[] dest;
    
   
    GameObject GhostGameObj;
    bool planting = false;
    bool mouseDown = false;
    int i = 0;
    Vector3 ScreenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    DelayCircle UICircleScript;

	RaycastHit RememberHit;

    //  An/Aus
    public void deactivateScript()
    {
        activated = false;
        GetComponent<CharacterMotor>().canControl = true;
        i = 0;
        UICircleScript.activated = false;
        UICircleScript.finished = false;
        if (GhostGameObj != null) Destroy(GhostGameObj);
        planting = false;
        print(activated);
        //GetComponent<PlantBomb>().enabled = false;
    }

    public void activateScript()
    {
        if (GetComponent<PlantBomb>().activated == false)
        {
            GetComponent<PlantBomb>().activated = true;
            //GetComponent<PlantBomb>().enabled = true;
            UICircleScript.activated = false;
            UICircleScript.finished = false;
        }

    }



	// Use this for initialization
	void Start () {
        UICircleScript = (DelayCircle)GUIdelay.GetComponent(typeof(DelayCircle));
        dest = GameObject.FindGameObjectsWithTag(Tags.dest);
        activateScript();
        deactivateScript();
        mouseDown = true;

	}
	
	// Update is called once per frame
	void Update () 
    {

        // AN/ aus
        if (Input.GetButtonDown("PlantBomb"))
        {
            //if (!activated) activateScript();
            //else deactivateScript();
            //mouseDown = false;
			activateScript();
            
        }
        if (Input.GetButtonUp("PlantBomb"))
        {            
            mouseDown = true;
			deactivateScript();
        }

       if (activated)
       {
           // Maussteuerung
           /*
           if (Input.GetMouseButtonDown(0))
           {
               mouseDown = true;
           }
           if (Input.GetMouseButtonUp(0))
           {
               mouseDown = false;
           }*/
           // Raycast von Mitte des Bildschirms

           Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
           RaycastHit hit;


           if (Physics.Raycast(ray, out hit, range))
           {
               foreach (var item in dest)
               {
                   if (hit.collider.gameObject == item)
                   {
                       Debug.DrawLine(ray.origin, hit.point);
                       // Spawnt Ghost Bombe, wenn nicht schon gespawnt
                       if (planting == false)
                       {
                           SpawnGhost(hit);
                           planting = true;
                       }

                       if (planting == true)
                       {
                           // Klicken zum platzieren
                           if (mouseDown)
                           {
                               if (i == 0)
                               {
                                   i++;
                                   RememberHit = hit;
                                   // RememberHit.transform.parent = hit.transform;
                               }

                               UICircleScript.activated = true;
                               UICircleScript.delay = plantDelay;

                               GhostGameObj.transform.position = RememberHit.point;
                               GhostGameObj.transform.rotation = Quaternion.LookRotation(RememberHit.normal);

                               GetComponent<CharacterMotor>().canControl = false;

                               /* // Abstand 
                                if (Vector3.Distance(RememberHit.point, transform.position) >= range && mouseDown)
                                {
                                    print(GhostGameObj);
                                    Destroy(GhostGameObj);
                                    i = 0;
                                    UICircleScript.activated = false;
                                    UICircleScript.finished = false;
                                    mouseDown = false;
                                    planting = false;
                                    SpawnGhost(hit);

                                }*/
                           }
                           if (!mouseDown)
                           {
                               GetComponent<CharacterMotor>().canControl = true;
                               i = 0;
                               UICircleScript.activated = false;
                               UICircleScript.finished = false;

                               // Ghost folgt hit.point wenn Maus nicht geklickt ist

                               GhostGameObj.transform.position = hit.point;
                               GhostGameObj.transform.rotation = Quaternion.LookRotation(hit.normal);
                           }

                       }



                   } 
               }
           }
           // wenn nicht in reichweite -> destroy ghost
           else
           {
               if (planting && !mouseDown)
               {
                   Destroy(GhostGameObj);
                   planting = false;
               }
               if (!mouseDown)
               {
                   GetComponent<CharacterMotor>().canControl = true;
                   i = 0;
                   UICircleScript.activated = false;
                   UICircleScript.finished = false;
               }

           }

           if (UICircleScript.finished)
           {

               SpawnBomb(RememberHit);

               UICircleScript.activated = false;
               UICircleScript.finished = false;

               mouseDown = false;
           }
       }
	}

    void SpawnBomb(RaycastHit hit)
    {
        Object spawnedBomb;
        spawnedBomb = Instantiate(plantableBomb, hit.point, Quaternion.LookRotation(hit.normal));
        if (spawnedBomb != null)
        {
            GameObject spawnedBombGameObj = GameObject.Find(spawnedBomb.name);
            spawnedBombGameObj.transform.parent = hit.transform;
        }

        //"e" Steuerung
        deactivateScript();
        mouseDown = false;
    }

    void SpawnGhost(RaycastHit hit)
    {
        Object Ghost;
        Ghost = Instantiate(plantableBombGhost, hit.point, Quaternion.LookRotation(hit.normal));
        Ghost.GetInstanceID();

        if (Ghost != null)
        {
            GhostGameObj = GameObject.Find(Ghost.name);
        }
    }


}


