using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

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
