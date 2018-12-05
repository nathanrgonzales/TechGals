using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluxoManager : MonoBehaviour {

	public GameObject Jogo;

	public GameObject Fluxo01;
	public GameObject Fluxo02;
	public GameObject Fluxo03;	
	public SlotResposta[] Game01;
	public SlotResposta[] Game02;
	public SlotResposta[] Game03;	

	public Image PlacarStar;
	public Sprite Star00;
	public Sprite Star01;
	public Sprite Star02;
	public Sprite Star03;	

	private int NivelAtual;

	void Start () {
		NivelAtual = 1;
		PlacarStar.sprite = Star00;
	}
	
	void VerificarFase()
	{
		if (NivelAtual == 1) {PlacarStar.sprite = Star00;}
		if (NivelAtual == 2) {PlacarStar.sprite = Star01;}				
		if (NivelAtual == 3) {PlacarStar.sprite = Star02;}				
		if (NivelAtual >  3) {PlacarStar.sprite = Star03;}						

		switch(NivelAtual)
		{
			case 01:
				Fluxo01.gameObject.SetActive(true);
				Fluxo02.gameObject.SetActive(false);
				Fluxo03.gameObject.SetActive(false);
				break;

			case 02:
				Fluxo01.gameObject.SetActive(false);
				Fluxo02.gameObject.SetActive(true);
				Fluxo03.gameObject.SetActive(false);			
				break;

			case 03:
				Fluxo01.gameObject.SetActive(false);
				Fluxo02.gameObject.SetActive(false);
				Fluxo03.gameObject.SetActive(true);			
				break;								
		}
	}

	void AcertouFluxo()
	{
		var totalTrue = 0;
		switch(NivelAtual)
		{
			case 01:
				for(int i = 0; i < Game01.Length -1 ; i++)
				{
					if (Game01[i].EstaCerto == true)
					{
						totalTrue++;
					}
				}

				if (totalTrue == Game01.Length - 1)
				{
					NivelAtual++;
				}
				break;

			case 02:
				for(int i = 0; i < Game02.Length -1 ; i++)
				{
					if (Game02[i].EstaCerto == true)
					{
						totalTrue++;
					}
				}

				if (totalTrue == Game02.Length - 1)
				{
					NivelAtual++;
				}			
				break;

			case 03:
				for(int i = 0; i < Game03.Length -1 ; i++)
				{
					if (Game03[i].EstaCerto == true)
					{
						totalTrue++;
					}
				}

				if (totalTrue == Game03.Length - 1)
				{
					NivelAtual++;
				}			
				break;								
		}
	}

	void VerificarVitoria()
	{
		if (NivelAtual > 3)
		{
			var Teste = Jogo.GetComponent<RedRunner.GameManager>();
			Teste.ExitGame();
		}
	}

	void Update () {

		VerificarFase();	
		
		AcertouFluxo();	

		VerificarVitoria();	

	}
		
}
