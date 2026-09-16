using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private float meleeDamage = 80;
    // Start is called before the first frame update
    void Start()
    {
        // DealDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        enemy.Damage(meleeDamage);
        Invoke("SelfDestruct", 0.2f);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
