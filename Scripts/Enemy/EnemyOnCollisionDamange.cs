using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnCollisionDamange : MonoBehaviour
{
    [SerializeField] protected int damange;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerHealth>().TakeDamage(damange);
    }
}
