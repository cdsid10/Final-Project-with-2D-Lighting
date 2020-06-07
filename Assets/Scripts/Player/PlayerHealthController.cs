using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public float damageInvLength = 1f;
    private float invCount;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
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
    }

    public void DamagePlayer()
    {
        if (invCount <= 0)
        {

            currentHealth--;

            invCount = damageInvLength;

            PlayerMovement.instance.body.color = new Color(PlayerMovement.instance.body.color.r, PlayerMovement.instance.body.color.g,
                PlayerMovement.instance.body.color.b, 0.5f);

            if (currentHealth <= 0)
            {
                PlayerMovement.instance.gameObject.SetActive(false);
                UIController.instance.deathScreen.SetActive(true);
            }

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }

    public void MakeInvincible(float length)
    {
        invCount = length;
        PlayerMovement.instance.body.color = new Color(PlayerMovement.instance.body.color.r, PlayerMovement.instance.body.color.g,
                PlayerMovement.instance.body.color.b, 0.5f);
    }
}
