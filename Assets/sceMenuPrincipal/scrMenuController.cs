﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class scrMenuController : MonoBehaviour {
	
	[SerializeField] Button btnApagarTudo;

	void Start () {
		Time.timeScale = 1f;		
	}

	public void ApagarTudo()
	{
		PlayerPrefs.DeleteAll();
        //if (EditorUtility.DisplayDialog("Apagar dados salvos do jogo.",
        //        						"Deseja apagar os dados armazenados do jogo?",  
		//								"Apagar", 
		//								"Não apagar"))
        //{
		//	PlayerPrefs.DeleteAll();
        //}		
	}
}
