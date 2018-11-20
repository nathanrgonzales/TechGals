using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {
    
	// Use this for initialization
    public GameObject Jogo;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grace")
        {
            //print("GAME OVER");
            var Teste = Jogo.GetComponent<RedRunner.GameManager>();
            Teste.ExitGame();
            
            //Application.LoadLevel(Application.loadedLevel);            
            //var endScreen = UIManager.Singleton.UISCREENS.Find(el => el.ScreenInfo == UIScreenInfo.END_SCREEN);
            //UIManager.Singleton.OpenScreen(endScreen);
            
            //Jogo.Singleton.StopGame();            
        }
    }
}
