using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRanged : MonoBehaviour
{
    [SerializeField] private float rangedDamage = 30;
    [SerializeField] private float projectileSpeed = 15;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("spawned");
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        // rigidBody.AddForce(Vector2.right * projectileSpeed, ForceMode2D.Impulse);
        rigidBody.velocity += Vector2.right * projectileSpeed;
        Destroy(gameObject, 1f);    //self-destruct if no enemy contacted
    }

    // apply damage and self-destruct on enemy contact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        enemy.Damage(rangedDamage);
        Destroy(gameObject, 0.1f);
    }
}
