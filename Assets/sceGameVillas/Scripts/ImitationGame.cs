using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImitationGame : MonoBehaviour
{

	public Image PlacarStar;
	public Sprite Star00;
	public Sprite Star01;
	public Sprite Star02;
	public Sprite Star03;
    public GameObject Jogo;    

    private int NivelAtual;

    [SerializeField] Text codeDescription;
    [SerializeField] Text codeText;
    [SerializeField] Text teste1;
    [SerializeField] Text teste2;
    [SerializeField] Text teste3;

    [SerializeField] InputField decodeInput;
    [SerializeField] InputField answerInput;
    [SerializeField] Button checkAnswerButton;
    [SerializeField] Button decodeButton;    
    [SerializeField] Dropdown decodeDropdown;    
    [SerializeField] GameObject scriptCounter;

    [SerializeField] Button startButton;

    Cypher cypher;
    public List<int> times = new List<int>();

    // Use this for initialization
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        decodeButton.onClick.AddListener(Decode);
        checkAnswerButton.onClick.AddListener(CheckAnswer);
        //finalButton.onClick.AddListener(ReturnInitialScreen);
        //exitSaveButton.onClick.AddListener(ExitSave);

        CheckIfSavedDataExists();

        PlacarStar.sprite = Star00;
        NivelAtual = 00;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        SetCypher(Resources.Load<Cypher>("Cypher/Cypher1"));
        scriptCounter.gameObject.GetComponent<Text>().text = "0";        
    }

    void ContinueGame()
    {
        var savedCypher = SaveLoad.LoadGameVillas();
        times = savedCypher.times;
        SetCypher(savedCypher);
        scriptCounter.GetComponent<CountTime>().Start();
    }

    void Decode()
    {
        var dropdownValue = decodeDropdown.options[decodeDropdown.value].text;
        var key = Array.Find(cypher.GetKeys(), element => element.key == dropdownValue);
        decodeInput.text = key.value;
    }

    void CheckAnswer()
    {
        if (cypher.CheckAnswer(answerInput.text))
        {
            NivelAtual = NivelAtual + 1;
			if (NivelAtual == 1) {PlacarStar.sprite = Star01;}
			if (NivelAtual == 2) {PlacarStar.sprite = Star02;}		            
            if (NivelAtual == 3) {PlacarStar.sprite = Star03;}	

            if (NivelAtual <= 2)  	                
            {

                var nextCypher = cypher.GetNextCypher();
                
                if (nextCypher != null)
                {
                    answerInput.text = "";
                    var time = scriptCounter.GetComponent<CountTime>().GetTime();
                    times.Add(time);
                    scriptCounter.GetComponent<CountTime>().Reset();
                    SetCypher(nextCypher);

                /*     if (EditorUtility.DisplayDialog("Parabéns!", "Você conseguiu decifrar a mensagem! Clique em Ok para ir ao próximo desafio", "Ok"))
                    {
                        answerInput.text = "";
                        var time = scriptCounter.GetComponent<CountTime>().GetTime();
                        times.Add(time);
                        scriptCounter.GetComponent<CountTime>().Reset();
                        SetCypher(nextCypher);
                    }
                */    
                }
            }
            if (NivelAtual >= 3)
            {
                EndGame();
            }
        }
        else
        {
            //EditorUtility.DisplayDialog("Falha!", "Não foi dessa vez! Mas não desista, clique em Ok para continuar tentando", "Ok");
        }
    }

    void SetCypher(Cypher paramCypher)
    {
        cypher = paramCypher;
        if (cypher.GetCodeType() == "Array")
        {
            decodeDropdown.gameObject.SetActive(true);
            decodeButton.gameObject.SetActive(true);
            decodeInput.gameObject.SetActive(true);
            foreach (var key in cypher.GetKeys())
            {
                decodeDropdown.options.Add(new Dropdown.OptionData()
                {
                    text = key.key

                });
            }
        }
        else
        {
            decodeDropdown.gameObject.SetActive(false);
            decodeButton.gameObject.SetActive(false);
            decodeInput.gameObject.SetActive(false);
            decodeDropdown.ClearOptions();
        }
        codeDescription.text = cypher.GetCodeDescription();
        codeText.text = cypher.EncodedText();
        paramCypher.times = times;
        SaveLoad.SaveGameVillas(paramCypher);
    }

    void EndGame()
    {
        PlayerPrefs.SetInt("Fase03", 01);
        var Teste = Jogo.GetComponent<RedRunner.GameManager>();
        Teste.ExitGame();

        /* var time = scriptCounter.GetComponent<CountTime>().GetTime();
        times.Add(time);
        teste1.text = "Teste 1: " + cypher.times[0] + " segundos.";
        teste2.text = "Teste 2: " + cypher.times[1] + " segundos.";
        teste3.text = "Teste 3: " + cypher.times[2] + " segundos.";*/
    }

    void ExitSave()
    {
        cypher.times = times;
        SaveLoad.SaveGameVillas(cypher);
        scriptCounter.GetComponent<CountTime>().Stop();
        scriptCounter.GetComponent<CountTime>().Reset();
    }

    void ReturnInitialScreen()
    {
        SaveLoad.EraseFile();
        CheckIfSavedDataExists();
    }

    void CheckIfSavedDataExists()
    {
        if (SaveLoad.ContinueFile())
        {
            //continueButton.interactable = true;
            //continueButton.onClick.AddListener(ContinueGame);
        }
        else
        {
            //continueButton.interactable = false;
        }
    }
}
