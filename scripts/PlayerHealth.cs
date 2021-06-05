using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameFail gamefail;

    public static int kills = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) // REMOVE!!! Just for Testing TakeDamage by pressing SPACEBAR
            TakeDamage(10);*/
    }

    public void Heal(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            gamefail.EndGame();
        healthBar.SetHealth(currentHealth);
    }
}
