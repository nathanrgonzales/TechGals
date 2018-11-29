using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour {
    [SerializeField]
    GameObject objetivo,pergaminho, ponte;

	// Use this for initialization
	void Start () {
        ponte.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grace")
        {
            if (objetivo.name == "Pergaminho")
            {
                objetivo.SetActive(false);
                ponte.SetActive(true);
            }
            if (objetivo.name == "PC" & !pergaminho.active)
            {
                objetivo.SetActive(false);
            }
        }
           



    }
}
