using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrMenuFadeIn : MonoBehaviour {
	
	public Image SplashImage;
	//public string LoadLevel;
	
	IEnumerator Start()
	{		
		SplashImage.canvasRenderer.SetAlpha(1.0f);
		//FadeIn();
		yield return new WaitForSeconds(1.5f);
		FadeOut();		
		//if (LoadLevel != "") 
		//	{SceneManager.LoadScene(LoadLevel);}
	}
	
	void FadeIn()
	{
		SplashImage.CrossFadeAlpha(1.0f, 1.5f, false);
	}

	void FadeOut()
	{
		SplashImage.CrossFadeAlpha(0.0f, 1.5f, false);
	}
	
}
