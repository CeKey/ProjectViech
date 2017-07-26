using UnityEngine;
using System.Collections;

public class EndButton : MonoBehaviour {

    void OnMouseDown()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
