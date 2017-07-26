using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    void Start()
    {
        Cursor.visible = true;
    }

    void OnMouseDown()
    {
		Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }
}
