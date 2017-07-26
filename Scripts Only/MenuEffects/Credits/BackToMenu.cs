using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {


    void OnMouseDown()
    {
		Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }
}
