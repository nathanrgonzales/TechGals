using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxoManager : MonoBehaviour {

	private GameObject[] blocos;
	private GameObject[] destinos;


	// Use this for initialization
	void Start () {

		blocos = GameObject.FindGameObjectsWithTag("bloco");
		destinos = GameObject.FindGameObjectsWithTag("destino");		
	}
	
	// Update is called once per frame
	void Update () {
		/* int numeroCarasTocando = 0;
		for(int i = 0; i < blocos.Length; i++){
			var circleCollider2D = blocos [i].GetComponent<CircleCollider2D> ();
			var boxCollider2D = destinos [i].GetComponent<BoxCollider2D> ();
			if (circleCollider2D.IsTouching (boxCollider2D)) {
				numeroCarasTocando++;
			}
		}

		if (numeroCarasTocando == blocos.Length) {
			print ("AEEEEE PORRA");
		}*/
	}
		
}
