using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{

    public float fadeSpeed = 1.5f;

    private bool sceneStart = true;
    public bool scenePause = false;
    public bool sceneEnd = false;


    void Awake()
    {
        GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height); // start coordinates(bottemleft), width, height

    }

    // Update is called once per frame
    void Update()
    {
        if (scenePause)
        {
            PauseScene();
        }
        else if (sceneStart)
        {
            StartScene();
        }
        else if(sceneEnd)
        {
            FadeToBlack();
        }

    }

    void FadeToClear()
    {
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        FadeToClear();

        if (GetComponent<GUITexture>().color.a <= 0.05f)
        { //if alpha is very low
            GetComponent<GUITexture>().color = Color.clear; //set color to clear
            GetComponent<GUITexture>().enabled = false; //disable Texture
            sceneStart = false; //scene doesnt start anymore
        }
    }

    public void EndScene(int scene)
    {
        GetComponent<GUITexture>().enabled = true;	//enable Texture


        FadeToBlack();

        if (GetComponent<GUITexture>().color.a >= 0.95f)
        {
            //if (scene == 0)
            //{
            //    Application.LoadLevel(0);
            //}
            //else
            //{
            //    Application.LoadLevel(2);
            //}

            Application.LoadLevel(scene);
        }
    }

    public void PauseScene()
    {
        GetComponent<GUITexture>().enabled = true;
        if (GetComponent<GUITexture>().color.a < 0.3)
        {
            FadeToBlack();
        }
        else
        {
            sceneStart = true;
        }

    }


}
