using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("keycodes")]
    public KeyCode Jump = KeyCode.W;

    [Header("Move")]
    public float MoveSpeed;
    private Rigidbody2D myrigidbody;
    private float moveDirection;

    [Header("FaceDirection")]
    public bool ChangeDirection;

    [Header("Jump")]
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
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveDirection = Input.GetAxis("Horizontal");
        myrigidbody.velocity = new Vector2(moveDirection * MoveSpeed, myrigidbody.velocity.y);

        isOnGround = Physics2D.OverlapCircle(checkGround.position, checkRadius, IsGround);
    }

    void Update()
    {

        anim.SetBool("move", moveDirection != 0);


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Keypad3) && isOnGround == true)
            {
                anim.SetTrigger("specAttack");
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("jump", true);
        }
        if (!Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("jump", false);
        }


        if (ChangeDirection == false && moveDirection < 0)
        {
            FlipPlayer();
        }
        else if (ChangeDirection == true && moveDirection > 0)
        {
            FlipPlayer();
        }

        if (GameObject.FindGameObjectWithTag("Enemy") && Input.anyKey)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = -MoveSpeed;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = MoveSpeed;
            }
        }

        if (isOnGround == true)
        {
            Jumps = JumpAmounts;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Jumps > 0)
        {
            myrigidbody.velocity = Vector2.up * JumpForce;
            Jumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Jumps == 0 && isOnGround == true)
        {
            myrigidbody.velocity = Vector2.up * JumpForce;
        }

    }

    

    public void FlipPlayer()
    {
        ChangeDirection = !ChangeDirection;
        transform.Rotate(0f, 180f, 0f);
    }

}
