using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scrDialogIntro : MonoBehaviour {
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public GameObject continueButton;
    public GameObject exitButton;
    private int index;

    public float typingSpeed;

	IEnumerator Start()
	{		
        Time.timeScale = 1f;		
		yield return new WaitForSeconds(2.5f);        
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
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        textDisplay.text = "";
             
        if (index < sentences.Length-1)
        {            
            index++; 
            StartCoroutine(Type());   
        }
        else
        {    
            exitButton.SetActive(true);        
            continueButton.SetActive(false);
            PlayerPrefs.SetInt("Fase01", 01);
        }

    }

}
