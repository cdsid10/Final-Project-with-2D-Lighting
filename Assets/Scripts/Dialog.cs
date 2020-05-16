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
    public GameObject Catcollider;

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
        PlayerMovement.instance.theRB.Sleep();
        PlayerMovement.instance.anim.SetBool("isWalking", false);
        Catcollider.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        index = 0;
        isTalking = false;
       
        PlayerMovement.instance.theRB.WakeUp();
        PlayerMovement.instance.anim.SetBool("isWalking", true);
        //Catcollider.SetActive(false);
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
            textBorder.SetActive(false);
            isTalking = false;
            PlayerMovement.instance.theRB.WakeUp();
            PlayerMovement.instance.anim.SetBool("isWalking", true);
            Catcollider.SetActive(false);
        }
    }
}
