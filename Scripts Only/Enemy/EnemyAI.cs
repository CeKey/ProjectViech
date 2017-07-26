using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour
{

    #region Attributes

    private NavMeshAgent nav;
    private EnemySight enemySight;
    private float chaseTimer;
    //private EnemyMovement move;
    private float waitTimer;
    private float slowedTimer = 2f;
    private GameObject fader;
    private bool end;
    private float stunTimer;
    private float maxStun = 2f;
    

    public AudioClip screem;
    public float chaseSpeed = 6f;
    public float patroulSpeed = 3.5f;
    public Transform current;
    public bool isBlind;
    public float blindTimer;
    public float maxBlind = 3;
    public GameObject blood = null;

    #endregion


    #region Properties
    public float WaitTimer
    {
        get { return waitTimer; }
        set { waitTimer = value; }
    }


    private float _patroulTimer;

    public float PatroulTimer
    {
        get { return _patroulTimer; }
        set { _patroulTimer = value; }
    }



    private int _wayPointIndex;

    public int WayPointIndex
    {
        get { return _wayPointIndex; }
        set { _wayPointIndex = value; }
    }



    public Transform[] WayPoints;


    private bool _slowed;

    public bool IsSlowed
    {
        get { return _slowed; }
        set { _slowed = value; }
    }

    private float _slowedTime;

    public float SlowedTime
    {
        get { return _slowedTime; }
        set { _slowedTime = value; }
    }


    private bool _stuned;

    public bool IsStuned
    {
        get { return _stuned; }
        set { _stuned = value; }
    }



    #endregion



    // Use this for initialization
    void Awake()
    {
        end = false;
        isBlind = false;
        fader = GameObject.FindGameObjectWithTag(Tags.fader);
        nav = GetComponent<NavMeshAgent>();
        enemySight = GetComponent<EnemySight>();
        //move = GetComponentInChildren<EnemyMovement>();
        WayPointIndex = 0;
        WaitTimer = 0.5f;
        chaseTimer = 0f;
        PatroulTimer = 0f;
        //patroulSpeed = 2f;
        stunTimer = 0f;
        blindTimer = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!end)
        {
            if (slowedTimer < SlowedTime && IsSlowed)
            {
                SlowedTime += Time.deltaTime;
                nav.speed = patroulSpeed * 0.5f;
            }
            else
            {
                SlowedTime = 0f;
                IsSlowed = false;


                if (IsStuned)
                {
                    stunTimer += Time.deltaTime;
                    if (stunTimer < maxStun)
                    {
                        nav.Stop();
                    }
                    else
                    {
                        stunTimer = 0;
                        IsStuned = false;
                        
                    }
                }
                else
                {
                    /*
                    if (!move.isAnimated())
                    {
                        move.Move();
                    }
                    */
                    if (isBlind)
                    {
                        blindTimer += Time.deltaTime;
                        if (blindTimer > maxBlind)
                        {
                            isBlind = false;
                            blindTimer = 0;
                        }
                        else
                        {

                            Patrouling();
                        }
                    }
                    else
                    {
                        if (enemySight.sightPosition != enemySight.resetPosition)
                        {
                            Chasing();
                        }
                        else
                        {
                            Patrouling();
                        } 
                    }
                }
            }
        }
        else
        {
            fader.GetComponent<SceneFadeInOut>().EndScene(2);
            fader.GetComponent<FadeWhite>().isEnd = true;
        }
    }






    public void Kill()
    {
        nav.Stop();
        //move.Attack();
        enemySight.sightPosition = enemySight.resetPosition;
        end = true;
        AudioSource.PlayClipAtPoint(screem, transform.position);


    }

    void Chasing()
    {



        Vector3 sightingDeltaPos = enemySight.sightPosition - transform.position;
        if (sightingDeltaPos.sqrMagnitude > 4f)
        {
            nav.destination = enemySight.sightPosition;
        }
        if (!IsSlowed)
        {
            nav.speed = chaseSpeed;//chase speed (player sprint speed) 
        }

        if (nav.remainingDistance < nav.stoppingDistance || !enemySight.PlayerInSight)
        {
            chaseTimer += Time.deltaTime;
            if (chaseTimer >= 2f)
            {
                enemySight.sightPosition = enemySight.resetPosition;
                chaseTimer = 0f;
            }
        }
        else
        {
            chaseTimer = 0f;

        }

    }


    void Patrouling()
    {
        NavMeshPath path = new NavMeshPath();
        if (!IsSlowed && !IsStuned)
        {
            nav.speed = patroulSpeed;
        }


        do
        {
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                PatroulTimer += Time.deltaTime;

                if (PatroulTimer >= WaitTimer)
                {

                    /*
                    if (WayPointIndex == wayPoints.Length -1) {
                        WayPointIndex = 0;
                    }else{
                        WayPointIndex++;	
                    }
                    */

                    WayPointIndex = Random.Range(0, WayPoints.Length);

                    PatroulTimer = 0f;
                }

            }
            //else
            //{
            //    patrolTimer = 0;
            //} 
        } while (!isPathReachable(WayPoints[WayPointIndex].position, path));

        current = WayPoints[WayPointIndex];
        nav.destination = WayPoints[WayPointIndex].position;




    }


    private bool isPathReachable(Vector3 target, NavMeshPath path)
    {
        nav.CalculatePath(target, path);

        if (path.status == NavMeshPathStatus.PathPartial)
        {
            return false;
        }

        return true;
    }

    public void Die()
    {
        Instantiate(blood, new Vector3(transform.position.x, 0, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
        SpawnController.ReduceCreatures();
    }


}
