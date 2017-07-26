using UnityEngine;
using System.Collections;

public class SprintScript : MonoBehaviour
{

    public float SprintSpeed = 30.0f;
    public float WalkSpeed = 6.0f;
    public float SprintAcceleration = 50.0f;
    public float WalkAcceleration = 30.0f;
    float SprintSpeedControl = 1.0f;
    float WalkSpeedControl = 1.0f;
    public float sprintEnergy = 5;
    public bool isStuned;
    public bool isSlowed;
    



    private CharacterMotor motor;
    private Weaponarm arm;
    private GameObject player;
    private float ccTimer;


    void Start()
    {
        motor = GetComponent<CharacterMotor>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        arm = player.GetComponentInChildren<Weaponarm>();

    }

    void FixedUpdate()
    {

        //bool SprintHold = Input.GetButton("Sprint");
        //bool SprintUp = Input.GetButtonUp("Sprint");




        if (!isSlowed && !isStuned)
        {
            if (Input.GetButton("Sprint") && arm.currentEnergy >= sprintEnergy)
            {
                motor.movement.maxForwardSpeed = SprintSpeed;
                motor.movement.maxSidewaysSpeed = SprintSpeed * 1.5f;
                motor.movement.maxGroundAcceleration = SprintAcceleration;
                motor.sliding.speedControl = SprintSpeedControl;

            }
            else
            {
                motor.movement.maxForwardSpeed = WalkSpeed;
                motor.movement.maxSidewaysSpeed = WalkSpeed;
                motor.movement.maxGroundAcceleration = WalkAcceleration;
                motor.sliding.speedControl = WalkSpeedControl;
            } 
        }
        else
        {
            if (ccTimer < 2)
            {
                ccTimer += Time.deltaTime;
                if (isSlowed)
                {
                    motor.movement.maxForwardSpeed = WalkSpeed / 2;


                }
                else if (isStuned)
                {
                    motor.enabled = false;
                } 
            }
            else
            {
                ccTimer = 0;
                isStuned = false;
                isSlowed = false;
                motor.enabled = true;
            }
        }




    }

}
