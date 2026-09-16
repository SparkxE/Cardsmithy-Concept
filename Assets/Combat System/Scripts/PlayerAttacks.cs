using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{
    private Animator animator;
    private RaycastHit2D hitBox;
    private PlayerMovement movement;
    [SerializeField] private float startBuffer = 0;
    [SerializeField] private GameObject rangedProjectile;
    [SerializeField] private GameObject meleeSwipe;
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
            Invoke("SpawnRanged", 0.1f);
        }
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (movement.AttackDelay == false && Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started)
        {
            animator.SetTrigger("MeleeTrigger");
            Invoke("SpawnMelee", 0.3f);
        }
    }

    private void SpawnMelee()
    {
        Instantiate(meleeSwipe, gameObject.transform);
    }

    private void SpawnRanged()
    {
        Instantiate(rangedProjectile, gameObject.transform);
    }
}
