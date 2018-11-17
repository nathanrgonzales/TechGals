using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialog : MonoBehaviour {
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public GameObject continueButton;
    private int index;

    public float typingSpeed;

    void Start()
    {
        StartCoroutine(Type());        
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        //yield return new WaitForSeconds(2f);
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length-1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());   
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }

    }

}
