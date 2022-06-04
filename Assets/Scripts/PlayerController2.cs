using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [Header("keycodes")]
    public KeyCode Jump = KeyCode.W;
    public KeyCode Defend = KeyCode.O;

    [Header("isWalking")]
    public float MoveSpeed;
    private Rigidbody2D enemyrigidbody;
    private float moveDirection;

    [Header("FaceDirection")]
    public bool ChangeDirection;

    [Header("isJumping")]
    public float JumpForce;
    private float Jumps;
    public float JumpAmounts;
    public Transform checkGround;
    public float checkRadius;
    public LayerMask IsGround;
    public bool isOnGround;
    
    [Header("Animations")]
    public Animator anim;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        Jumps = JumpAmounts;
        enemyrigidbody = GetComponent <Rigidbody2D>();
    }

    private void FixedUpdate(){
        moveDirection = Input.GetAxis("Horizontal");
        enemyrigidbody.velocity = new Vector2(moveDirection * MoveSpeed, enemyrigidbody.velocity.y);

        isOnGround  = Physics2D.OverlapCircle (checkGround.position, checkRadius, IsGround);
    }

    void Update()
    {

        anim.SetBool("isWalking", moveDirection != 0);


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
            {
                anim.SetTrigger("goukihadoken");
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }

        if (Input.GetKeyDown(KeyCode.I) && !isOnGround == true)
        {
            anim.SetTrigger("jumpPunch");
        }
        
        if (Input.GetKeyDown(KeyCode.K) && !isOnGround == true)
        {
            anim.SetTrigger("JumpKick");
        }

        if (Input.GetKeyDown(Jump))
        {
            anim.SetBool("isJumping", true);
        }
        if (!Input.GetKeyDown(Jump))
        {
            anim.SetBool("isJumping", false);
        }


        if (ChangeDirection == false && moveDirection < 0)
        {
            FlipPlayer();
        }else if (ChangeDirection == true && moveDirection > 0 )
        {
            FlipPlayer();
        }

        if (isOnGround == true)
        {
            Jumps = JumpAmounts;
        }
        if (Input.GetKeyDown(Jump) && Jumps > 0)
        {
            enemyrigidbody.velocity = Vector2.up * JumpForce;
            Jumps--;
        }
        else if (Input.GetKeyDown(Jump) && Jumps == 0 &&  isOnGround == true)
        {
            enemyrigidbody.velocity = Vector2.up * JumpForce;
        }

        if (Input.GetKeyDown(Defend))
        {
            MoveSpeed = 0;
            anim.SetBool("isDefending", true);
            JumpForce = 0;
        }else if (Input.GetKeyUp(Defend))
        {
            MoveSpeed = 1;
            JumpForce = 5;
            anim.SetBool("isDefending", false);
        }

    }

    public void FlipPlayer(){
        ChangeDirection = !ChangeDirection;
        transform.Rotate(0f, 180f, 0f);
    }

    }
