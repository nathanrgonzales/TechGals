using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;


public class scrControllerFases : MonoBehaviour {
	
	public int FaseSelecionada;
	[SerializeField] Sprite imaBtnAtivado;
	[SerializeField] Sprite imaBtnDesativado;
	[SerializeField] Button btnFase01;
	[SerializeField] Button btnFase02;
	[SerializeField] Button btnFase03;
	[SerializeField] Button btnFase04;
	[SerializeField] Button btnVoltar;

	// Use this for initialization
	void Start () {
        var savedSelectStage = SaveLoad.LoadGameSelectStage();
        
		btnFase01.image.sprite = imaBtnAtivado;
		//if (savedSelectStage.Fase02 == true)
		if (PlayerPrefs.GetInt("Fase02") > 00)
			{
				btnFase02.image.sprite = imaBtnAtivado; 
				btnFase02.GetComponentInChildren<Text>().text = "Fase" + Environment.NewLine + "02";
				btnFase02.enabled = true;
			}        
		else
			{				
				btnFase02.image.sprite = imaBtnDesativado; 
				btnFase02.GetComponentInChildren<Text>().text = "";
				btnFase02.enabled = false;
			}

		//if (savedSelectStage.FaseHabilitada(3))
		if (PlayerPrefs.GetInt("Fase03") > 00)
			{
				btnFase03.image.sprite = imaBtnAtivado; 
				btnFase03.GetComponentInChildren<Text>().text = "Fase" + Environment.NewLine + "03";
				btnFase03.enabled = true;
			}        
		else
			{				
				btnFase03.image.sprite = imaBtnDesativado; 
				btnFase03.GetComponentInChildren<Text>().text = "";
				btnFase03.enabled = false;
			}	

		//if (savedSelectStage.FaseHabilitada(4))
		if (PlayerPrefs.GetInt("Fase04") > 00)
			{
				btnFase04.image.sprite = imaBtnAtivado; 
				btnFase04.GetComponentInChildren<Text>().text = "Fase" + Environment.NewLine + "04";
				btnFase04.enabled = true;
			}        
		else
			{				
				btnFase04.image.sprite = imaBtnDesativado; 
				btnFase04.GetComponentInChildren<Text>().text = "";
				btnFase04.enabled = false;
			}						
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(string nomeCena)
	{
		SceneManager.LoadScene(nomeCena);
	}

	public void EscolherFase(int FaseEscolhida)
	{
		FaseSelecionada = FaseEscolhida;
	}	

	public void LoadFaseEscolhida()
	{
		switch(FaseSelecionada)
		{
			case 1:
				SceneManager.LoadScene("sceGameMendes01");
				break;
			case 2:
				SceneManager.LoadScene("sceGameVillas01");
				break;					
			case 4:
				SceneManager.LoadScene("sceGameVillas01");
				break;				
			default:	
				SceneManager.LoadScene("sceMenuPrincipal");
				break;
		}		
	}	

}
