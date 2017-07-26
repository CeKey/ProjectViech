using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour
{


    #region Attributes
    private Rigidbody bomb;
    public Rigidbody slowbomb;
    public Rigidbody stunbomb;
    public Rigidbody blindbomb;
    public Rigidbody ForceBomb;
    public float throwPower = 100f;
    public bool isPaused = false;
    private Weaponarm arm;

    #endregion



    private bool _reject;

    public bool Reject
    {
        get { return _reject; }
        set { _reject = value; }
    }


    // Use this for initialization
    void Start()
    {
        arm = GetComponent<Weaponarm>();
    }

    // Update is called once per frame
    void Update()
    {



        if (!isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Reject = false;
                switch (arm.AktiveBomb)
                {
                    case Bombtypes.Stati.Slow: bomb = slowbomb; Reject = arm.ConsumeEnergy(Bombtypes.Stati.Slow); break;
                    case Bombtypes.Stati.Stun: bomb = stunbomb; Reject = arm.ConsumeEnergy(Bombtypes.Stati.Stun); break;
                    case Bombtypes.Stati.Blind: bomb = blindbomb; Reject = arm.ConsumeEnergy(Bombtypes.Stati.Blind); break;
                    case Bombtypes.Stati.Kill: bomb = ForceBomb; Reject = arm.ConsumeEnergy(Bombtypes.Stati.Kill); break;
                    default: Reject = true; break;
                }

                if (!Reject)
                {

                    Rigidbody clone;
                    clone = (Rigidbody)Instantiate(bomb, transform.position, transform.rotation);
                    clone.velocity = transform.TransformDirection(Vector3.forward * throwPower);

                }

            } 
        }
        else
        {
            isPaused = false;
        }
    }
}
