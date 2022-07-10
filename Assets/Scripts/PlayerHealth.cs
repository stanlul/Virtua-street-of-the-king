using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController pControl;
    public int maxHealth = 200;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject Lose;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        
    }

    private void Awake()
    {
        pControl = GetComponent<PlayerController>();
    }

    public void TakeDamage (int damage)
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

        Lose.SetActive(true);
    }


}
