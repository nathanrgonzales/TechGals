using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMendes : MonoBehaviour {

	private float x = 2.5f;
	public SpriteRenderer spriteRenderer;


	public void moverEsquerda (SpriteRenderer pato) {

		pato.flipX = false;
		pato.transform.Translate(new Vector3(-x * Time.deltaTime, 0, 0));


	}

	public void moverDireita (SpriteRenderer pato) {
		pato.flipX = true;
		pato.transform.Translate(new Vector3(x * Time.deltaTime, 0, 0));
	}
}
