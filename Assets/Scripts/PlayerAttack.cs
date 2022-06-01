using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
    public Animator anim;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform checkGround;
    public float checkRadius;
    public LayerMask IsGround;
    public bool isOnGround;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.U) && isOnGround == true)
            {
                anim.SetTrigger("F1");
                nextAttackTime = Time.time + 1f / attackRate;
            }
            
        }

    }


}
