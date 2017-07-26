#pragma strict

var SprintSpeed:float = 30.0f;
var WalkSpeed:float = 6.0f;
var SprintAcceleration:float = 50.0f;
var WalkAcceleration:float = 30.0f;
var SprintSpeedControl:float = 1.0f;
var WalkSpeedControl:float = 1.0f;


private var motor : CharacterMotor;

function Start () 
{
    motor = GetComponent(CharacterMotor);
}

function Update () {

	var SprintHold : boolean = Input.GetButton("Sprint");
    var SprintUp : boolean = Input.GetButtonUp("Sprint");
	
	

	if(SprintHold)
	{
		motor.movement.maxForwardSpeed = SprintSpeed;
        motor.movement.maxSidewaysSpeed = SprintSpeed*1.5;
        motor.movement.maxGroundAcceleration = SprintAcceleration;
        motor.sliding.speedControl = SprintSpeedControl;
     
	}
    if(SprintUp)
    {
        motor.movement.maxForwardSpeed = WalkSpeed;
        motor.movement.maxSidewaysSpeed = WalkSpeed;
        motor.movement.maxGroundAcceleration = WalkAcceleration;
        motor.sliding.speedControl = WalkSpeedControl;
    }
}
