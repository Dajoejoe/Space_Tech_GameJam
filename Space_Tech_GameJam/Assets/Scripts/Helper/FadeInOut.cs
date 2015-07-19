/************************************************
 *		Copyright (c) Ben's Weird Games 2014	*
 * 		Created by: Ben Toepke					*
 ***********************************************/
using UnityEngine;
using System.Collections;

//Put on the main Camera
public class FadeInOut : MonoBehaviour {

    public static float fadeTime =1.5f;
    Texture2D t_Black;
	Texture2D t_White;

    [HideInInspector]
    public static bool fade;
    [HideInInspector]
    public static bool fadeIn;
    [HideInInspector]
	public static bool blackTex = true;
    static float a = 1;
	float fadeDelay = 1f;

	// Use this for initialization
	void Start () {
        t_Black = (Texture2D)Resources.Load("Textures/UI/black");
        t_White = (Texture2D)Resources.Load("Textures/UI/white");
        fade = true;
        fadeIn = true;
        fadeTime = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnLevelWasLoaded(int level)
    {
        fade = true;
        fadeIn = true;
		fadeDelay = 1f;
        a = 1;
    }
    void OnGUI()
    {
        GUI.depth = -1000;
        if (fade)
        {
            if (fadeIn)
            {
				if (fadeDelay <=0)
                	FadeIn();
				else 
					fadeDelay -= Time.deltaTime;
                if (a == 0)
                    fade = false;
            }
            else
            {
                FadeOut();

                if (a == 1)
                    fade = false;
            }
			FadeSound();
        }
        GUI.color = new Color(1, 1, 1, a);
		
		if (blackTex ||  t_White==null)
        	GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), t_Black);
		else
        	GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), t_White);
			
    }

    public static float FadeIn()
    {
        a -= Time.deltaTime / fadeTime;
        a = Mathf.Clamp01(a);
        return a;
    }

    public static float FadeOut()
    {

        a += Time.deltaTime / fadeTime;
        a = Mathf.Clamp01(a);

        return a;
    }
	
	public static void FadeSound()
	{
		AudioListener.volume = 1-a;
	}

    public static void SetAlpha(float amt)
    {
        a = Mathf.Clamp01(amt);
    }

    public static float GetAlpha { get { return a; } }
}
