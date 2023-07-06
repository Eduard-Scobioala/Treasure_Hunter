using UnityEngine;

public class SpikeDamange : MonoBehaviour
{
    [SerializeField] private int damange;

    private float cooldownTimer = Mathf.Infinity;
    private float takeDamangeCooldown = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (cooldownTimer >= takeDamangeCooldown && collision.tag == "Player")
        {
            cooldownTimer = 0;
            collision.GetComponent<PlayerHealth>().TakeDamage(damange);
        }
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
}
