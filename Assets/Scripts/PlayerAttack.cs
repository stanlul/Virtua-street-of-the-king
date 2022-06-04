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
    private float defaultComboTimer = 1f;
    private float currentComboTimer;
    private ComboState currentComboState;

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
        if (Input.GetKeyDown(KeyCode.I) && pControl.isOnGround == true)
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


        if (Input.GetKeyDown(KeyCode.U) && pControl.isOnGround == true)
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

        if (Input.GetKeyDown(KeyCode.J) && pControl.isOnGround == true)
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

        if (Input.GetKeyDown(KeyCode.K) && pControl.isOnGround == true)
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
}
