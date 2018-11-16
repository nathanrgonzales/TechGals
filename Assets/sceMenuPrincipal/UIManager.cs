using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public void DisableBoolInanimator (Animator anim)
	{
		anim.SetBool("isDisplayed", false);
	}

	public void EnableBoolInanimator (Animator anim)
	{
		anim.SetBool("isDisplayed", true);
	}
	
	public void NavigateTo(int scene)
	{
		Application.LoadLevel(scene);
	}

	public void LoadScene(string nomeCena)
	{
		SceneManager.LoadScene(nomeCena);
	}

}
