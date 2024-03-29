using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    None,
    Punch1,
    Punch2,
    Punch3
}

public class enemyAttack : MonoBehaviour
{
    private enemy eControl;

    private bool activateTimeToReset;
    private float defaultComboTimer = 0.8f;
    private float currentComboTimer;
    private ComboState currentComboState;

    [SerializeField]
    private GameObject pAttackerPunch1;

    [SerializeField]
    private GameObject pAttackerPunch2;

    [SerializeField]
    private GameObject pAttackerKick1;

    [SerializeField]
    private GameObject pAttackerKick2;

    [SerializeField]
    private GameObject pAttackerJumpAttack1;

    [SerializeField]
    private GameObject pAttackerJumpAttack2;

    [SerializeField]
    private GameObject pAttackerJumpKick;


    private void Awake()
    {
        eControl = GetComponent<enemy>();
    }

    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.None;
    }


    void Update()
    {
        ComboAttack();
        ResetComboState();
    }

    void ComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.I) && eControl.isOnGround)
        {
            if (currentComboState == ComboState.Punch3)
            {
                return;
            }
            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.Punch1)
            {

            }
            if (currentComboState == ComboState.Punch2)
            {

            }
            if (currentComboState == ComboState.Punch3)
            {
                eControl.anim.SetTrigger("Attack2");
            }
        }

        if (Input.GetKeyDown(KeyCode.I) && !eControl.isOnGround)
        {
            if (currentComboState == ComboState.Punch2)
            {
                return;
            }
            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.Punch1)
            {
                eControl.anim.SetTrigger("jumpPunch");
            }
            if (currentComboState == ComboState.Punch2)
            {
                eControl.anim.SetTrigger("jumpPunch2");
            }
        }


        if (Input.GetKeyDown(KeyCode.U) && eControl.isOnGround)
        {
            if (currentComboState == ComboState.Punch2)
            {
                return;
            }
            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.Punch1)
            {
                eControl.anim.SetTrigger("jab1");
            }
            if (currentComboState == ComboState.Punch2)
            {
                eControl.anim.SetTrigger("jab1");
            }


        }

        if (Input.GetKeyDown(KeyCode.J) && eControl.isOnGround)
        {
            if (currentComboState == ComboState.Punch2)
            {
                return;
            }
            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.Punch1)
            {
                eControl.anim.SetTrigger("midKick");
            }
            if (currentComboState == ComboState.Punch2)
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.K) && eControl.isOnGround)
        {
            if (currentComboState == ComboState.Punch1)
            {
                return;
            }
            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.Punch1)
            {
                eControl.anim.SetTrigger("D4");
            }

        }

        if (Input.GetKeyDown(KeyCode.K) && !eControl.isOnGround)
        {
            if (currentComboState == ComboState.Punch1)
            {
                return;
            }
            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.Punch1)
            {
                eControl.anim.SetTrigger("JumpKick");
            }

        }

    }

    void ResetComboState()
    {
        if (activateTimeToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.None;
                activateTimeToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }

    public void ActivePunch1()
    {
        pAttackerPunch1.SetActive(true);
    }

    public void ActivePunch2()
    {
        pAttackerPunch2.SetActive(true);
    }

    public void ActiveKick1()
    {
        pAttackerKick1.SetActive(true);
    }

    public void ActiveKick2()
    {
        pAttackerKick2.SetActive(true);
    }

    public void ActivejPunch1()
    {
        pAttackerJumpAttack1.SetActive(true);
    }

    public void ActivejPunch2()
    {
        pAttackerJumpAttack2.SetActive(true);
    }

    public void ActivejKick1()
    {
        pAttackerJumpKick.SetActive(true);
    }

    public void DeactivePunch1()
    {
        pAttackerPunch1.SetActive(false);
    }

    public void DeactivePunch2()
    {
        pAttackerPunch2.SetActive(false);
    }

    public void DeactiveKick1()
    {
        pAttackerKick1.SetActive(false);
    }

    public void DeactiveKick2()
    {
        pAttackerKick2.SetActive(false);
    }

    public void DeActivejPunch1()
    {
        pAttackerJumpAttack1.SetActive(false);
    }

    public void DeActivejPunch2()
    {
        pAttackerJumpAttack2.SetActive(false);
    }

    public void DeActivejKick1()
    {
        pAttackerJumpKick.SetActive(false);
    }

    public void DeactiveAll()
    {
        pAttackerPunch1.SetActive(false);
        pAttackerPunch2.SetActive(false);
        pAttackerKick1.SetActive(false);
        pAttackerKick2.SetActive(false);
        pAttackerJumpAttack1.SetActive(false);
        pAttackerJumpAttack2.SetActive(false);
        pAttackerJumpKick.SetActive(false);
    }
}