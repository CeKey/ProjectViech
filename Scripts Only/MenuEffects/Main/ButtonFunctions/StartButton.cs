﻿using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel(1);
    }
}
