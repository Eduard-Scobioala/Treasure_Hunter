using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoldChest : MonoBehaviour
{
    private bool goldTaken = false;
    [SerializeField] private AudioClip wonSound;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (!goldTaken)
        {
            if (collision.transform.tag == "Player")
            {
                goldTaken = true;
                SoundManager.instance.PlaySound(wonSound);

                yield return new WaitForSeconds(3);

                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
