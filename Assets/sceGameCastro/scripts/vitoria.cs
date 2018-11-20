using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vitoria : MonoBehaviour {
    [SerializeField]
    private GameObject pc, codigo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.Wincon();
        
	}
    private void Wincon()
    {
        //print(pc.active);
        //print(codigo.active);
        if (!pc.active && !codigo.active)
        {
            Debug.Log("Ganhou!!!");
            
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);                
    }
}
