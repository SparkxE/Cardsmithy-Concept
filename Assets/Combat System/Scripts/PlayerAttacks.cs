using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{
    private Animator animator; //animator to play appropriate animations on attack press
    private PlayerMovement movement; //PlayerMovement object to track the input buffer to prevent spamming
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
        if (movement.AttackDelay == false && Time.fixedTime >= movement.StartBuffer && context.phase == InputActionPhase.Started)
        {
            animator.SetTrigger("RangedTrigger");
            Invoke("SpawnRanged", 0.1f);
        }
    }

    // ensure attack input(s) happens after start buffer before firing
    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (movement.AttackDelay == false && Time.fixedTime >= movement.StartBuffer && context.phase == InputActionPhase.Started)
        {
            animator.SetTrigger("MeleeTrigger");
            Invoke("SpawnMelee", 0.3f);
        }
    }

    // spawn attack objects at proper location based on player's current position
    private void SpawnMelee()
    {
        Instantiate(meleeSwipe, new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z), gameObject.transform.rotation);
    }

    private void SpawnRanged()
    {
        Instantiate(rangedProjectile, new Vector3(gameObject.transform.position.x+1, gameObject.transform.position.y, gameObject.transform.position.z), rangedProjectile.transform.rotation);
    }
}
