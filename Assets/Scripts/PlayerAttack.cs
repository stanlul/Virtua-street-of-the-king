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

public class PlayerAttack : MonoBehaviour
{
    private PlayerController pControl;

    private bool activateTimeToReset;
    private float defaultComboTimer = 0.8f;
    private float currentComboTimer;
    private ComboState currentComboState;

    [SerializeField]
    private GameObject pAttackerPunch1;

    [SerializeField]
    private GameObject pAttackerPunch2;

    //[SerializeField]
    //private GameObject pAttackerKick1;
    
    //[SerializeField]
    //private GameObject pAttackerKick2;
    
    //[SerializeField]
    //private GameObject pAttackerJumpAttack1;

    //[SerializeField]
    //private GameObject pAttackerJumpAttack2;

    //[SerializeField]
    //private GameObject pAttackerJumpKick;


    private void Awake()
    {
        pControl = GetComponent<PlayerController>();
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
        if (Input.GetKeyDown(KeyCode.I) && pControl.isOnGround)
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
                pControl.anim.SetTrigger("Attack2");
            }
            if (currentComboState == ComboState.Punch2)
            {
                pControl.anim.SetTrigger("Attack2");
            }
            if (currentComboState == ComboState.Punch3)
            {
                pControl.anim.SetTrigger("Attack2");
            }
        }

        if (Input.GetKeyDown(KeyCode.I) && !pControl.isOnGround)
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
                pControl.anim.SetTrigger("jumpPunch");
            }
            if (currentComboState == ComboState.Punch2)
            {
                pControl.anim.SetTrigger("jumpPunch2");
            }
        }


        if (Input.GetKeyDown(KeyCode.U) && pControl.isOnGround)
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
                pControl.anim.SetTrigger("jab1");
            }
            if (currentComboState == ComboState.Punch2)
            {
                pControl.anim.SetTrigger("jab1");
            }
            

        }

        if (Input.GetKeyDown(KeyCode.J) && pControl.isOnGround)
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
                pControl.anim.SetTrigger("midKick");
            }
            if (currentComboState == ComboState.Punch2)
            {
                pControl.anim.SetTrigger("midKick");
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && pControl.isOnGround)
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
                pControl.anim.SetTrigger("D4");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.K) && !pControl.isOnGround)
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
                pControl.anim.SetTrigger("JumpKick");
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

    public void DeactivePunch1()
    {
        pAttackerPunch1.SetActive(false);
    }

    public void DeactivePunch2()
    {
        pAttackerPunch2.SetActive(false);
    }

    public void DeactiveAll (){
        pAttackerPunch1.SetActive(false);
        pAttackerPunch2.SetActive(false);
    }
}
