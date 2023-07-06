using UnityEngine;

public class Seashell : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] seashellPearls;
    private float cooldownTimer;

    [SerializeField] private Animator animator;

    private void Attack()
    {
        cooldownTimer = 0;

        seashellPearls[FindSeeshellPearl()].transform.position = firePoint.position;
        seashellPearls[FindSeeshellPearl()].GetComponent<Projectile>().ActivateProjectile();
    }

    private int FindSeeshellPearl()
    {
        for (int i = 0; i < seashellPearls.Length; i++)
        {
            if (!seashellPearls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
        {
            animator.SetTrigger("Attack");
            Attack();
        }
    }
}
