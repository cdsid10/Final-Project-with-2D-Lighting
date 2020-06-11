using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float damageInvLength = 1f;
    private float invCount;

    public GameObject impactEffect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = numOfHearts;

        //UIController.instance.healthSlider.maxValue = maxHealth;
        //UIController.instance.healthSlider.value = currentHealth;
        //UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invCount > 0)
        {
            invCount -= Time.deltaTime;

            if(invCount <= 0)
            {
                PlayerMovement.instance.body.color = new Color(PlayerMovement.instance.body.color.r, PlayerMovement.instance.body.color.g,
                PlayerMovement.instance.body.color.b, 1f);
            }
        }

        if(currentHealth > numOfHearts)
        {
            currentHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void DamagePlayer()
    {
        if (invCount <= 0)
        {

            currentHealth--;
            AudioManager.instance.PlaySFX(12);
            Instantiate(impactEffect, transform.position, Quaternion.identity);

            invCount = damageInvLength;

            PlayerMovement.instance.body.color = new Color(PlayerMovement.instance.body.color.r, PlayerMovement.instance.body.color.g,
                PlayerMovement.instance.body.color.b, 0.5f);

            if (currentHealth <= 0)
            {
                PlayerMovement.instance.gameObject.SetActive(false);
                UIController.instance.deathScreen.SetActive(true);
                AudioManager.instance.PlayGameOver();
            }

            //UIController.instance.healthSlider.value = currentHealth;
            //UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }

    public void MakeInvincible(float length)
    {
        invCount = length;
        PlayerMovement.instance.body.color = new Color(PlayerMovement.instance.body.color.r, PlayerMovement.instance.body.color.g,
                PlayerMovement.instance.body.color.b, 0.5f);
    }
}
