using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private int healValue;
    [SerializeField] private AudioClip healSound;
    private bool potionUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!potionUsed)
        {
            if (collision.transform.tag == "Player")
            {
                potionUsed = true;
                collision.GetComponent<PlayerHealth>().AddHealth(healValue);
                SoundManager.instance.PlaySound(healSound);
                gameObject.SetActive(false);
            }
        }
    }
}
