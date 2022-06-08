using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 200;

    public void TakeDamage (int damage)
    {
        health -= damage;
    }


}
