using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class scrMenuController : MonoBehaviour {
	
	[SerializeField] Button btnApagarTudo;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApagarTudo()
	{
        if (EditorUtility.DisplayDialog("Apagar dados salvos do jogo.",
                						"Deseja apagar os dados armazenados do jogo?",  
										"Apagar", 
										"Não apagar"))
        {
			PlayerPrefs.DeleteAll();
        }		
	}
}
