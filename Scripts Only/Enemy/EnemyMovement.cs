using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour{
	
	public void Attack(){
		GetComponent<Animation>().CrossFade("attack");
		
	}
	
	public void Move(){
		GetComponent<Animation>().CrossFade("move");
	}
	
	public bool isAnimated(){
		if (GetComponent<Animation>().IsPlaying("walk") || GetComponent<Animation>().IsPlaying("attack")) {
			return true;
		}
		
		return false;
	}
	
}
