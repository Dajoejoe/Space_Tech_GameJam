/************************************************
 *		Copyright (c) Ben's Weird Games 2014	*
 * 		Created by: Ben Toepke					*
 ***********************************************/
using UnityEngine;
using System.Collections;

public class CallLevelLoad : MonoBehaviour {

    public static int levelToLoad;
	public static string levelToLoadName;
    public static bool load;
	static bool loadLoadingScene;
	static float delay;

	// Use this for initialization
	void Start () {
        load = false;
	}

    void OnLevelWasLoaded(int level)
    {
        load = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (load)
        {
			if (delay <=0)
			{
				SetFade();
	            if (FadeInOut.GetAlpha == 1)
	            {
					//Globals.previousLevel = Application.loadedLevel;
					if (loadLoadingScene)
	                	Application.LoadLevel("Scene_Loading");
					else if (levelToLoad != -1)
						Application.LoadLevel(levelToLoad);
					else
						Application.LoadLevel(levelToLoadName);
	            }
			}
			else
			{
				delay -= Time.deltaTime;
			}
        }
	
	}

    public static void SetLevelLoad(int levelToLoad, float fadeTime, bool blackTex)
    {
        if (!load)
        {
            load = true;
            CallLevelLoad.levelToLoad = levelToLoad;
            FadeInOut.fadeTime = fadeTime;
			SetFade();
			FadeInOut.blackTex = blackTex;
        }

	}
	public static void SetLevelLoad(string levelToLoadName, float fadeTime, bool blackTex)
	{
		if (!load)
		{
			load = true;
			CallLevelLoad.levelToLoad = -1;
			CallLevelLoad.levelToLoadName = levelToLoadName;
			FadeInOut.fadeTime = fadeTime;
			SetFade();
			FadeInOut.blackTex = blackTex;
		}
		
	}

	 public static void SetLevelLoad(int levelToLoad, float fadeTime, bool blackTex, float delay)
    {
        if (!load)
        {
            load = true;
            CallLevelLoad.levelToLoad = levelToLoad;
            FadeInOut.fadeTime = fadeTime;
			FadeInOut.blackTex = blackTex;
			CallLevelLoad.delay = delay;
        }

	}
	public static void SetLevelLoad(string levelToLoadName, float fadeTime, bool blackTex, float delay)
	{
		if (!load)
		{
			load = true;
			CallLevelLoad.levelToLoad = -1;
			CallLevelLoad.levelToLoadName = levelToLoadName;
			FadeInOut.fadeTime = fadeTime;
			FadeInOut.blackTex = blackTex;
			CallLevelLoad.delay = delay;
		}
		
	}

	public static void SetLevelLoad(int levelToLoad, float fadeTime, bool blackTex, bool loadingScene)
    {
        if (!load)
        {
            load = true;
            CallLevelLoad.levelToLoad = levelToLoad;
			FadeInOut.blackTex = blackTex;
			SetFade();
			loadLoadingScene = loadingScene;
        }

	}
	public static void SetLevelLoad(string levelToLoadName, float fadeTime, bool blackTex, bool loadingScene)
	{
		if (!load)
		{
			load = true;
			CallLevelLoad.levelToLoad = -1;
			CallLevelLoad.levelToLoadName = levelToLoadName;
			FadeInOut.blackTex = blackTex;
			SetFade();
			loadLoadingScene = loadingScene;
		}
		
	}

	
	static void SetFade()
	{
        FadeInOut.fade = true;
        FadeInOut.fadeIn = false;
	}
}
