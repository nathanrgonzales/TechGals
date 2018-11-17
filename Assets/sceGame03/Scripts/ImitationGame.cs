using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImitationGame : MonoBehaviour
{
    [SerializeField] Text codeDescription;
    [SerializeField] Text codeText;
    [SerializeField] Text teste1;
    [SerializeField] Text teste2;
    [SerializeField] Text teste3;
    [SerializeField] Text teste4;
    [SerializeField] Text teste5;
    [SerializeField] Text teste6;
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
            var nextCypher = cypher.GetNextCypher();
            if (nextCypher != null)
            {
                if (EditorUtility.DisplayDialog("Parabéns!", "Você conseguiu decifrar a mensagem! Clique em Ok para ir ao próximo desafio", "Ok"))
                {
                    answerInput.text = "";
                    var time = scriptCounter.GetComponent<CountTime>().GetTime();
                    times.Add(time);
                    scriptCounter.GetComponent<CountTime>().Reset();
                    SetCypher(nextCypher);
                }
            }
            else
            {
                EndGame();
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Falha!", "Não foi dessa vez! Mas não desista, clique em Ok para continuar tentando", "Ok");
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
        var time = scriptCounter.GetComponent<CountTime>().GetTime();
        times.Add(time);

        teste1.text = "Teste 1: " + cypher.times[0] + " segundos.";
        teste2.text = "Teste 2: " + cypher.times[1] + " segundos.";
        teste3.text = "Teste 3: " + cypher.times[2] + " segundos.";
        teste4.text = "Teste 4: " + cypher.times[3] + " segundos.";
        teste5.text = "Teste 5: " + cypher.times[4] + " segundos.";
        teste6.text = "Teste 6: " + cypher.times[5] + " segundos.";
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
