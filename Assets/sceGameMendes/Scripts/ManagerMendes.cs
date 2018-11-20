using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMendes : MonoBehaviour {

	public int moedas = 0;
	public List<Moeda> listaMoedas;
	public TextMesh kleberTextMesh;
	public ParticleSystem firejobs;
	public TextMesh expectedTextMesh;
	private int expected = 0;


	// Use this for initialization
	void Start () {
		printaBinario ();

		geraAleatorio ();

		firejobs.Stop ();

	}
	
	// Update is called once per frame
	void Update () {
		if (kleberTextMesh.text == expectedTextMesh.text)
		{	
			PlayerPrefs.SetInt("Fase02", 01);
        	var savedSelectStage = SaveLoad.LoadGameSelectStage();       	
        	savedSelectStage.Fase01 = true;
			savedSelectStage.Fase02 = true;
			SaveLoad.SaveGameSelectStage(savedSelectStage);
			LoadScene("sceSelecionarTela");
		}

	}

	public void addCoins (int qtd) {
		moedas += qtd;
	}

	public void printaBinario() {
		
		print ("-----------------------");

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

		print (bitsEmInteger);
		if (bitsEmInteger.Equals (expected)) {
			firejobs.Play ();			
		} else {
			firejobs.Stop ();
		}

		kleberTextMesh.text = "" + bitsEmInteger;
	}

	public void LoadScene(string nomeCena)
	{
		SceneManager.LoadScene(nomeCena);
	}


	public void geraAleatorio() {

		expected = Random.Range (1, 255);
		print (expected);
		expectedTextMesh.text = "" + expected;

	}


}
