using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public static Dialog instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject textBG;
    public GameObject textBorder;
    public GameObject interactText;
    public GameObject interactImage;

    public GameObject continueButton;
    public bool isTalking = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTalking)
        {
            StartCoroutine(Type());
            textBG.SetActive(true);
            textBorder.SetActive(true);
            interactImage.SetActive(false);
            interactText.SetActive(false);

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
        interactImage.SetActive(true);
        interactText.SetActive(true);
        isTalking = true;
        PlayerMovement.instance.theRB.Sleep();
        PlayerMovement.instance.anim.SetBool("isWalking", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        index = 0;
        isTalking = false;
        interactImage.SetActive(false);
        interactText.SetActive(false);
        PlayerMovement.instance.theRB.WakeUp();
        PlayerMovement.instance.anim.SetBool("isWalking", true);
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            interactImage.SetActive(false);
            interactText.SetActive(false);
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textBG.SetActive(false);
            textBorder.SetActive(false);
            isTalking = false;
            PlayerMovement.instance.theRB.WakeUp();
            PlayerMovement.instance.anim.SetBool("isWalking", true);
        }
    }
}
