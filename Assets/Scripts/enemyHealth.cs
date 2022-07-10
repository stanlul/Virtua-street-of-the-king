using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public EnemyHealthBar healthBar;
    public GameObject Win;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void Rematch()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);

    }

    void Die()
    {
        Time.timeScale = 0f;

        Win.SetActive(true);
    }

}
