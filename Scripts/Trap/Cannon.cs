using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] cannonBalls;
    private float cooldownTimer;

    [SerializeField] private Animator animator;

    private void Attack()
    {
        cooldownTimer = 0;

        cannonBalls[FindCannonBalls()].transform.position = firePoint.position;
        cannonBalls[FindCannonBalls()].GetComponent<Projectile>().ActivateProjectile();
    }

    private int FindCannonBalls()
    {
        for (int i = 0; i < cannonBalls.Length; i++)
        {
            if (!cannonBalls[i].activeInHierarchy)
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
