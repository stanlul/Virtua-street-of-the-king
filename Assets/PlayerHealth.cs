using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController pControl;
    public int health = 200;

    private void Awake()
    {
        pControl = GetComponent<PlayerController>();
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        pControl.MoveSpeed = 0;
    }


}
