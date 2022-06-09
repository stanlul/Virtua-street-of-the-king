using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public EnemyHealthBar healthBar;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.punch_attack_tag))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
