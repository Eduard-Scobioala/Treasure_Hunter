using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private CoinsManagement coinManager;
    private bool coinTaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!coinTaken)
        {
            if (collision.transform.tag == "Player")
            {
                coinTaken = true;
                coinManager.ChangeNrOfCoins(1);
                SoundManager.instance.PlaySound(coinSound);
                gameObject.SetActive(false);
            }
        }
    }
}
