using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Animator animator;

    public Transform punch1;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int punch1damage = 5;

    void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punch1.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyHealth>().TakeDamage(punch1damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (punch1 == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(punch1.position, attackRange);
    }
}
