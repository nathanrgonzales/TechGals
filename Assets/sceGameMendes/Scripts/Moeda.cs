using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour {

	public Sprite moedaOn; //recebeu por fora o sprite de moeda clara
	public Sprite moedaOff; //recebeu por fora o sprite de moeda escura

	private ManagerMendes manager;
	private SpriteRenderer spriteRenderer;
	private TextMesh labelTextMesh;

	private bool on = false;


	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer> (); //sprite de moeda

		manager = FindObjectOfType<ManagerMendes> ();

		labelTextMesh = GetComponentInChildren<TextMesh> (); //texto em cima da moeda

		on = false;
		spriteRenderer.sprite = moedaOff;
		labelTextMesh.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isOn() {
		return on;
	}

	void OnTriggerEnter2D (Collider2D outro) {

		if (outro.gameObject.CompareTag ("pato")) {

			manager.addCoins (1);

			Vector3 posicaoMoeda = outro.transform.position;

			atualizaMoeda ();


			manager.printaBinario();
		}

	}

	public void atualizaMoeda() {
		
		if (on) {
			on = false;
			spriteRenderer.sprite = moedaOff;
			labelTextMesh.text = "0";
		} else {
			on = true;
			spriteRenderer.sprite = moedaOn;
			labelTextMesh.text = "1";
		}
	}

	public void ZerarMoeda() 
	{		
		on = false;
		spriteRenderer.sprite = moedaOff;
		labelTextMesh.text = "0";
		
	}	
}
