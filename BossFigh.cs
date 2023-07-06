using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFigh : MonoBehaviour
{
    private bool bossFight = false;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bossFight)
        {
            if (collision.transform.tag == "Player")
            {
                bossFight = true;
                animator.SetTrigger("Activate");
            }
        }
    }
}
