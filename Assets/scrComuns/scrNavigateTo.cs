﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;


public class scrNavigateTo : MonoBehaviour {	

	[SerializeField] Button btnVoltar;

	public void LoadScene(string nomeCena)
	{
		SceneManager.LoadScene(nomeCena);
	}

}
