using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;


public class scrControllerFases : MonoBehaviour {
	
	public int FaseSelecionada;

	public GameObject Solange;
	public GameObject Relogio;

	[SerializeField] Sprite imaBtnAtivado;
	[SerializeField] Sprite imaBtnDesativado;
	[SerializeField] Button btnFase00;
	[SerializeField] Button btnFase01;
	[SerializeField] Button btnFase02;
	[SerializeField] Button btnFase03;
	[SerializeField] Button btnFase04;
	[SerializeField] Button btnVoltar;

	[SerializeField] TextMeshProUGUI texto01;

	// Use this for initialization
	void Start () {
        var savedSelectStage = SaveLoad.LoadGameSelectStage();

		Time.timeScale = 1.0f;

		btnFase01.image.sprite = imaBtnAtivado;
		//if (savedSelectStage.Fase02 == true)
		PlayerPrefs.SetInt("Fase04", 01);

		if (PlayerPrefs.GetInt("Fase01") > 00)
			{
				btnFase01.image.sprite = imaBtnAtivado; 
				btnFase01.GetComponentInChildren<Text>().text = "Fase" + Environment.NewLine + "01";
				btnFase01.enabled = true;
			}        
		else
			{				
				btnFase01.image.sprite = imaBtnDesativado; 
				btnFase01.GetComponentInChildren<Text>().text = "";
				btnFase01.enabled = false;
			}

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
		Solange.SetActive(true);
		Relogio.SetActive(false);		
		switch (FaseSelecionada)
		{			
			case 00:
				Solange.SetActive(false);
				Relogio.SetActive(true);		
				texto01.text = 	"Intro: TechGals" + "\n" +
								"TechGals é uma experiência de aprendizado, onde vamos aprender um pouco mais sobre a participaçâo das mulheres no desenvolvimento tecnológico, com enfase em TI";
				break;

			case 01:
				texto01.text = 	"Fase 01: Resolvendo binários" + "\n" +
								"Ajude Solange a resolver os casos de números binários";
				break;
			case 02:
				texto01.text = 	"Fase 02: Fuja do Bugs" + "\n" +
								"Solange precisa pegar o código-fonte para poder passar dos bugs! Cuidado com os bugs!!!";
				break;
			case 03:
				texto01.text = 	"Fase 03: Criptografia de mensagens" + "\n" +
								"Mensagem com criptografia! Solange precisa descobrir a chave para quebrar o código e ler a mensagem.";
				break;
			case 04:
				texto01.text = 	"Fase 04: Fluxos" + "\n" +
								"Solange precisa organizar os fluxos para que tudo funcione! ";
				break;
			
			default:
				texto01.text = 	"Erro";
				break;
		}
	}	

	public void LoadFaseEscolhida()
	{
		switch(FaseSelecionada)
		{

			case 0:
				SceneManager.LoadScene("sceGameIntro");
				break;							
			case 1:
				SceneManager.LoadScene("sceGameMendes01");
				break;
			case 2:
				SceneManager.LoadScene("sceGameCastro01");
				break;									
			case 3:
				SceneManager.LoadScene("sceGameVillas01");
				break;									
			case 4:
				SceneManager.LoadScene("sceGameMendes02");
				break;				
			default:	
				SceneManager.LoadScene("sceMenuPrincipal");
				break;
		}		
	}	

}
