using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject textBG;

    public GameObject continueButton;
    public bool isTalking = false;
    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTalking)
        {
            StartCoroutine(Type());
            textBG.SetActive(true);
            
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        isTalking = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        index = 0;
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textBG.SetActive(false);
        }
    }
}
