using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogGym : MonoBehaviour
{
    public static DialogGym instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject textBG;
    public GameObject textBorder;
    public GameObject catCollider;
    public GameObject textBox;
    public GameObject arrow;

    public GameObject continueButton;
    public bool canTalk = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalk)
        {
            PlayerMovement.instance.canMove = false;
            ShootAnim.instance.canShoot = false;
            StartCoroutine(Type());
            textBox.SetActive(true);
            textBG.SetActive(true);
            textBorder.SetActive(true);
            catCollider.SetActive(true);
            canTalk = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            typingSpeed = 0.02f;
        }

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }


    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTalk = true;
        arrow.SetActive(true);
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        index = 0;
        catCollider.SetActive(false);
        canTalk = false;

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        arrow.SetActive(false);

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
            catCollider.SetActive(false);
            textBG.SetActive(false);
            textBorder.SetActive(false);
            textBox.SetActive(false);
            PlayerMovement.instance.canMove = true;
            ShootAnim.instance.canShoot = true;

        }
    }
}
