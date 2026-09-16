using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 40;
    private float currentHealth;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }

    public void Damage(float damageAmount)
    {
        Debug.Log("Hit Detected");
        currentHealth -= damageAmount;
        if (currentHealth > 0)
        {
            animator.SetTrigger("Damage");
        }
        else if(currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            Invoke("SelfDestruct", 0.5f);
        }
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
