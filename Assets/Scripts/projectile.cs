using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Transform Fire;
    public GameObject projectilePrefab;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update(){

    if (Time.time >= nextAttackTime)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        
    }
    }

    void Shoot(){
        Instantiate(projectilePrefab,Fire.position,Fire.rotation);
    }

}
