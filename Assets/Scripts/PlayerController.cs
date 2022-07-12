using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("keycodes")]
    public KeyCode Jump;
    public KeyCode Left;
    public KeyCode Right;


    [Header("Move")]
    public float MoveSpeed;
    private Rigidbody2D myrigidbody;
    private float moveDirection;
    float horizontalMove;
    public Transform target;


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
        myrigidbody = GetComponent <Rigidbody2D>();

    }

    private void FixedUpdate(){
        //myrigidbody.velocity = new Vector2(moveDirection * MoveSpeed, myrigidbody.velocity.y);

        isOnGround  = Physics2D.OverlapCircle (checkGround.position, checkRadius, IsGround);
    }

    void Update()
    {
        
        //if (isOnGround == true)
        //{
        //    Jumps = JumpAmounts;
        //}
        //if (Input.GetKeyDown(Jump) && Jumps > 0)
        //{
        //    myrigidbody.velocity = Vector2.up * JumpForce;
        //    Jumps--;
        //}
        //else if (Input.GetKeyDown(Jump) && Jumps == 0 && isOnGround == true)
        //{
        //    myrigidbody.velocity = Vector2.up * JumpForce;
        //}

        if (Input.GetKey(Left))
        {
            myrigidbody.velocity = new Vector2(-MoveSpeed, myrigidbody.velocity.y);
        }
        else if (Input.GetKey(Right))
        {
            myrigidbody.velocity = new Vector2(MoveSpeed, myrigidbody.velocity.y);
        }
        else
        {
            myrigidbody.velocity = new Vector2(0, myrigidbody.velocity.y);
        }

        if (Input.GetKeyDown(Jump) && isOnGround)
        {
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, JumpForce);
        }

        if (myrigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (myrigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
            {
                anim.SetTrigger("specAttack");
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        anim.SetBool("Grounded", isOnGround);






    }

    public void FlipPlayer(){
        ChangeDirection = !ChangeDirection;
        transform.Rotate(0f, 180f, 0f);
    }

}

