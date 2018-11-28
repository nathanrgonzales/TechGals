using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMendes : MonoBehaviour {

	public int moedas = 0;
	public Image PlacarStar;
	public Sprite Star00;
	public Sprite Star01;
	public Sprite Star02;
	public Sprite Star03;

	public GameObject Jogo;

	private int NivelAtual;
	public List<Moeda> listaMoedas;

	public Text textoExpected;	
	public Text textoKleber;		
	private int expected = 0;


	// Use this for initialization
	void Start () {
		
		NivelAtual = 0;

		printaBinario ();

		geraAleatorio ();		

		PlacarStar.sprite = Star00;

	}
	
	// Update is called once per frame
	void Update () {
		if (textoKleber.text == textoExpected.text)
		{
			if (NivelAtual <= 2)	
			{
				NivelAtual = NivelAtual + 1;
				zerarMoedasBinario();	
				printaBinario ();
				geraAleatorio ();		
				if (NivelAtual == 1) {PlacarStar.sprite = Star01;}
				if (NivelAtual == 2) {PlacarStar.sprite = Star02;}				
			}
			if (NivelAtual >= 3)	
			{
				if (NivelAtual == 3) {PlacarStar.sprite = Star03;}
				PlayerPrefs.SetInt("Fase02", 01);
				var savedSelectStage = SaveLoad.LoadGameSelectStage();       	
				savedSelectStage.Fase01 = true;
				savedSelectStage.Fase02 = true;
				SaveLoad.SaveGameSelectStage(savedSelectStage);
				//LoadScene("sceSelecionarTela");
	            var Teste = Jogo.GetComponent<RedRunner.GameManager>();
            	Teste.ExitGame();
			}
		}			

	}

	public void addCoins (int qtd) {
		moedas += qtd;
	}

	public void printaBinario() {

		BitArray bbbb = new BitArray (listaMoedas.Count);

		int i = listaMoedas.Count - 1;
		foreach (Moeda m in listaMoedas) {
			if (m.isOn()) {
				bbbb.Set (i, true);
			} else {
				bbbb.Set (i, false);
			}
			i--;
		}

		int[] intArray = new int[1];
		bbbb.CopyTo (intArray, 0);
		int bitsEmInteger = intArray [0];		
		textoKleber.text = "" + bitsEmInteger;
	}

	public void zerarMoedasBinario() 
	{		
		int i = listaMoedas.Count - 1;
		foreach (Moeda m in listaMoedas) {
			m.GetComponent<Moeda>().ZerarMoeda();
		}
	}

	public void LoadScene(string nomeCena)
	{
		SceneManager.LoadScene(nomeCena);
	}


	public void geraAleatorio() {

		expected = Random.Range (1, 255);		
		textoExpected.text = "" + expected;

	}


}
