using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private HealthSlider healthSlider;
    [SerializeField] private Animator animator;

    public void Respawn()
    {
        // Move player to checkpoint position
        transform.position = currentCheckpoint.position;

        // Restore player health and reset animation
        playerHealth.Respawn();
        healthSlider.SetHealth(playerHealth.currentHealth);
    }

    // Activate checkpoints
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            // Store the checkpoint that have been activated as the current one
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);

            // Deactivate checkpoint collider
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("checkpoint");
        }
    }
}
