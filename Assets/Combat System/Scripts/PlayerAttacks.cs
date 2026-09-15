using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    [SerializeField] private float startBuffer = 0;
    void Start()
    {
        // grab animator component 
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }
    // ensure attack input(s) happens after start buffer before firing
    public void RangedAttack(InputAction.CallbackContext context)
    {
        if (movement.AttackDelay == false && Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started) {
            animator.SetTrigger("RangedTrigger");
        }
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (movement.AttackDelay == false && Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started) {
            animator.SetTrigger("MeleeTrigger");
        }
    }
}
