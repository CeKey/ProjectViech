using UnityEngine;
using System.Collections;

public class Weaponarm : MonoBehaviour
{

    public float maxEnergy = 100;
    public float currentEnergy =50;
    public bool run;
    public float sprinttimer = 0;
    public float sprintenergy = 5;

    public float slowBombCost = 10;
    public float stunBombCost = 20;
    public float blindBombCost = 40;
    public float deathBombCost = 70;



    private Bombtypes bombs;
    private ThrowScript throwS;
    private CharacterMotor cm;
    private GameObject player;
    private float walkspeed;
    


    private Bombtypes.Stati _aktiveBomb;

    public Bombtypes.Stati AktiveBomb
    {
        get { return _aktiveBomb; }
        set { _aktiveBomb = value; }
    }


    // Use this for initialization
    void Start()
    {
        throwS = GetComponent<ThrowScript>();
        AktiveBomb = Bombtypes.Stati.Slow;
        player = GameObject.FindGameObjectWithTag(Tags.player);
        cm = player.GetComponent<CharacterMotor>();
        walkspeed = cm.movement.maxForwardSpeed;
        Cursor.visible = false;
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {   
        throwS.Reject = false;

        if (cm.movement.maxForwardSpeed <= walkspeed)
        {
            if (currentEnergy < 100)
            {
                currentEnergy += Time.deltaTime;
                if (currentEnergy > 100)
                {
                    currentEnergy = 100;
                }
            } 
        }
        else
        {
            if (currentEnergy > sprintenergy)
            {
                sprinttimer += Time.deltaTime;

                if (sprinttimer > 0.5)
                {
                    SprintDrain(sprintenergy);
                    sprinttimer = 0;
                }
            }
            
        }

        if (Input.GetKeyDown("1"))
        {
            if (currentEnergy >=slowBombCost)
            {
                AktiveBomb = Bombtypes.Stati.Slow; 
            }
            else
            {
                throwS.Reject = true;
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            if (currentEnergy >= stunBombCost)
            {
                AktiveBomb = Bombtypes.Stati.Stun;
            }
            else
            {
                throwS.Reject = true;
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            if (currentEnergy >= blindBombCost)
            {
                AktiveBomb = Bombtypes.Stati.Blind;
            }
            else
            {
                throwS.Reject = true;
            }
        }
        else if (Input.GetKeyDown("4"))
        {
            if (currentEnergy >= deathBombCost)
            {
                AktiveBomb = Bombtypes.Stati.Kill;
            }
            else
            {
                throwS.Reject = true;
            }

        }

    }

    public bool ConsumeEnergy(Bombtypes.Stati stati)
    {
        float energy;

        switch (stati)
        {
            case Bombtypes.Stati.Slow: energy = currentEnergy - slowBombCost; break;
            case Bombtypes.Stati.Stun: energy = currentEnergy - stunBombCost; break;
            case Bombtypes.Stati.Blind: energy = currentEnergy - blindBombCost; break;
            case Bombtypes.Stati.Kill: energy = currentEnergy - deathBombCost; break;
            default: energy = currentEnergy - slowBombCost; break;
        }

        if (energy >= 0)
        {
            currentEnergy = energy;
            return false;
        }
        return true;

    }

    public void SprintDrain(float energy)
    {
        currentEnergy -= energy;

    }

    

}
