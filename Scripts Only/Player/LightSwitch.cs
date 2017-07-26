using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {

	public Light BombLight1;
	public Light BombLight2;
	public Light BombLight3;
	public Light BombLight4;
	public GameObject Energy1;
	public GameObject Energy2;
	public GameObject Energy3;
	public GameObject Energy4;

	private Weaponarm arm;
	
	
	// Use this for initialization
	void Start () {
		BombLight1.enabled = true;
		BombLight2.enabled = false;
		BombLight3.enabled = false;
		BombLight4.enabled = false;
		Energy1.SetActive (true);
		Energy2.SetActive (true);
		Energy3.SetActive (true);
		Energy4.SetActive (true);	
		arm = GetComponentInChildren<Weaponarm> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1") && arm.currentEnergy >= arm.slowBombCost) 
		{
			BombLight1.enabled = true;
			BombLight2.enabled = false;
			BombLight3.enabled = false;
			BombLight4.enabled = false;
		}
		
		if (Input.GetKeyDown ("2") && arm.currentEnergy >= arm.stunBombCost) 
		{
			BombLight1.enabled = false;
			BombLight2.enabled = true;
			BombLight3.enabled = false;
			BombLight4.enabled = false;
		}
		
		if (Input.GetKeyDown ("3") && arm.currentEnergy >= arm.blindBombCost) 
		{
			BombLight1.enabled = false;
			BombLight2.enabled = false;
			BombLight3.enabled = true;
			BombLight4.enabled = false;
		}
		
		if (Input.GetKeyDown ("4") && arm.currentEnergy >= arm.deathBombCost) 
		{
			BombLight1.enabled = false;
			BombLight2.enabled = false;
			BombLight3.enabled = false;
			BombLight4.enabled = true;
		}

		if (arm.currentEnergy > 95) {
					Energy1.SetActive (true);
					Energy2.SetActive (true);
					Energy3.SetActive (true);
					Energy4.SetActive (true);

				}
		if (arm.currentEnergy >= arm.slowBombCost) {
					Energy1.SetActive (true);
				} else if (arm.currentEnergy <= arm.slowBombCost) {
					Energy1.SetActive(false);
				}

		if (arm.currentEnergy < arm.slowBombCost) {
			Energy1.SetActive (false);
			Energy2.SetActive (false);
			Energy3.SetActive (false);
			Energy4.SetActive (false);
		}

		if (arm.currentEnergy >= arm.stunBombCost) {
					Energy2.SetActive (true);
				} else if (arm.currentEnergy <= arm.stunBombCost) {
					Energy2.SetActive(false);
				}

		if (arm.currentEnergy >= arm.blindBombCost) {
					Energy3.SetActive (true);
				} else if (arm.currentEnergy <= arm.blindBombCost) {
					Energy3.SetActive(false);
				}
		if (arm.currentEnergy >= arm.deathBombCost) {
					Energy4.SetActive (true);
				} else if (arm.currentEnergy <= arm.deathBombCost) {
					Energy4.SetActive(false);
				}
		
	}

    
}
