using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{

#region private Attributes
    private NavMeshAgent nav;
    private SphereCollider col;
    private GameObject player;
    private float sightTime;
    public Vector3 resetPosition;
    public Vector3 sightPosition;
#endregion

#region Prperties
    private float _fieldOfViewAngle = 110f;

    public float FieldOfViewAngle
    {
        get { return _fieldOfViewAngle; }
        set { _fieldOfViewAngle = value; }
    }


    private bool _playerInSight = false;

    public bool PlayerInSight
    {
        get { return _playerInSight; }
        set { _playerInSight = value; }
    }


    private float _sightTimer = 0.5f;

    public float SightTimer
    {
        get { return _sightTimer; }
        set { _sightTimer = value; }
    }
#endregion



    // Use this for initialization
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        resetPosition = new Vector3(1000, 1000, 1000);
        sightPosition = resetPosition;
        sightTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject == player)
        {
            PlayerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < FieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position  /*+ transform.up */, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                    {
                        sightTime += Time.deltaTime;
                        if (sightTime >= SightTimer)
                        {
                            PlayerInSight = true;
                            sightPosition = player.transform.position;
                        }

                    }
                }

            }
            else
            {
                sightTime = 0f;
            }

            //Enemey Hearing
            if (CalculatePathLength(player.transform.position) <= col.radius)
            {
                sightPosition = player.transform.position;
            }

        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerInSight = false;
            sightTime = 0f;
        }
    }


    float CalculatePathLength(Vector3 targetPosition)
    { //PathLength Sound

        NavMeshPath path = new NavMeshPath();
        if (nav.enabled)
        {
            nav.CalculatePath(targetPosition, path);
        }

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;

        allWayPoints[allWayPoints.Length - 1] = targetPosition;


        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0;

        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    }

}
