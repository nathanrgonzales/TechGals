using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Pulo : MonoBehaviour {

	public float forca = 300f;
	public Rigidbody2D pato;
	public bool liberaPulo = false;
	public int duplo = 2;
	public Button puloBtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (duplo > 0) {
			if (Input.GetKeyDown (KeyCode.Space) || puloBtn.GetComponent<ButtonModafoca>().pressed) 
			{
				pato.AddForce (new Vector3 (0, forca * Time.deltaTime), ForceMode2D.Impulse);
				duplo--;
			}
		}
			
		
	}

	void OnCollisionEnter2D(Collision2D outro) {

		if(outro.gameObject.CompareTag("chao") || outro.gameObject.CompareTag("madeira")) 
		{
			duplo = 2;
		}

	}
}
