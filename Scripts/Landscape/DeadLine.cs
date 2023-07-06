using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth.TakeDamage(100);
    }
}
