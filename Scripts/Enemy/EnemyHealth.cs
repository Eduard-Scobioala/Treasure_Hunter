using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;

    [Header("Health")]
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int currentHealth;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [SerializeField] bool isBoss = false;
    [SerializeField] GameObject hiddenWall;
    [SerializeField] GameObject hiddenGoldChest;

    [SerializeField] private AudioClip deathSound;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamange(int damange)
    {
        currentHealth -= damange;

        // Play hurt animation
        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        // Die animation
        animator.SetBool("isDead", true);

        SoundManager.instance.PlaySound(deathSound);

        // Disable the enemy colider, combat script and patrol component
        foreach (Behaviour component in components)
            component.enabled = false;

        Vector3 newPosition = transform.localPosition;
        newPosition.y -= 0.1f; ;
        transform.localPosition = newPosition;

        if (isBoss)
        {
            hiddenWall.SetActive(false);
            hiddenGoldChest.SetActive(true);
        }
    }
}
