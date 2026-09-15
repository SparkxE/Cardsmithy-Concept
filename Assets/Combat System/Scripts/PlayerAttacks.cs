using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{
    private Animator animator;
    private PlayerActions playerActions; //playerActions action map for reading movement inputs
    [SerializeField] private float startBuffer = 0;
    void Start()
    {
        playerActions = new PlayerActions();
        playerActions.Enable();
        animator = GetComponent<Animator>();
    }
    // ensure attack input(s) happens after start buffer before firing
    public void RangedAttack(InputAction.CallbackContext context)
    {
        if (Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started) {
            Debug.Log("Ranged Attack Fired");
            animator.SetTrigger("RangedTrigger");
        }
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started) {
            Debug.Log("Melee Attack Fired");
            animator.SetTrigger("MeleeTrigger");
        }
    }
}
