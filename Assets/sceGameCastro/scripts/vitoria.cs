using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vitoria : MonoBehaviour {
    [SerializeField]
    private GameObject pc, codigo;
    public GameObject Jogo;
    private GameObject textoPerdeu;    

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
            //Debug.Log("Ganhou!!!");
            
            //Application.LoadLevel(Application.loadedLevel);

            PlayerPrefs.SetInt("Fase03", 01);
            var savedSelectStage = SaveLoad.LoadGameSelectStage();       	
            savedSelectStage.Fase01 = true;
            savedSelectStage.Fase02 = true;
            SaveLoad.SaveGameSelectStage(savedSelectStage);
            //LoadScene("sceSelecionarTela");            
            textoPerdeu = GameObject.FindWithTag("textEndGame");
            textoPerdeu.GetComponent<Text>().text = "Vitória :D";            
            var Teste = Jogo.GetComponent<RedRunner.GameManager>();
            Teste.ExitGame();


        }
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);                
    }
}
