using UnityEngine;
using System.Collections;

public class ShowCredits : MonoBehaviour {


    void OnMouseDown()
    {
		Time.timeScale = 1.0f;
        Application.LoadLevel(4);
    }
}
