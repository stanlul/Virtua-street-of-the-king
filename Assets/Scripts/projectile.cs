using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private PlayerController pControl;

    public Transform Fire;
    public GameObject projectilePrefab;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        pControl = GetComponent<PlayerController>();
    }

    void Update(){

    if (Time.time >= nextAttackTime)
    {
        if (Input.GetKeyDown(KeyCode.Space) && pControl.isOnGround == true)
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
