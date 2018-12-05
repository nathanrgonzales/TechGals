using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrVerificarVitoria : MonoBehaviour {

	public GameObject Objetivo;
	public bool EstaCerto; 
	// Use this for initialization
	void Start () {
		EstaCerto = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == Objetivo.gameObject.name)
		{
			EstaCerto = true;
		}
		else
		{
			EstaCerto = false;
		}
	}

}
