using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrSplashFade : MonoBehaviour {
	
	public Image SplashImage;
	public string LoadLevel;
	
	IEnumerator Start()
	{
		SplashImage.canvasRenderer.SetAlpha(0.0f);
		FadeIn();
		yield return new WaitForSeconds(3.5f);
		FadeOut();
		yield return new WaitForSeconds(2.5f);
		if (LoadLevel != "") 
			{SceneManager.LoadScene(LoadLevel);}
	}
	
	void FadeIn()
	{
		SplashImage.CrossFadeAlpha(1.0f, 2.5f, false);
	}

	void FadeOut()
	{
		SplashImage.CrossFadeAlpha(0.0f, 2.5f, false);
	}
	
}
