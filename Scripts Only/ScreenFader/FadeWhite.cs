using UnityEngine;
using System.Collections;

public class FadeWhite : MonoBehaviour
{

    public float fadeSpeed = 1.5f;
    public bool isBlind = false;
    public float timer = 0;
    public float maxTime = 3;
    public bool isEnd = false;


    // Update is called once per frame
    void Start()
    {
        isEnd = false;
        GetComponent<GUITexture>().enabled = false;
    }


    void Update()
    {
        if (!isEnd)
        {
            if (isBlind)
            {
                if (GetComponent<GUITexture>().color.a <= 0.95)
                {
                    GetComponent<GUITexture>().enabled = true;
                    FadeToWhite();
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer > maxTime)
                    {
                        timer = 0;
                        isBlind = !isBlind;
                    }
                }
            }
            else
            {
                if (GetComponent<GUITexture>().color.a > 0)
                {
                    FadeToClear();
                }
                else
                {
                    GetComponent<GUITexture>().enabled = false;
                }
            }
        }

    }

    public void FadeToWhite()
    {

        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.white, fadeSpeed * Time.deltaTime);
    }

    public void FadeToClear()
    {
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
