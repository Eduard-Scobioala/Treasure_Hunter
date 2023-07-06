using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
	[SerializeField] private float speed = 2.5f;
	[SerializeField] private float attackRange = 3f;
	[SerializeField] private int damange = 2;

	Transform player;
	Rigidbody2D rb;
	Boss boss;

	private float cooldownTimer = Mathf.Infinity;
	[SerializeField] private float attackCooldown = 2f;


	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Boss>();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		boss.LookAtPlayer();

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

		cooldownTimer += Time.deltaTime;
		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			if (cooldownTimer >= attackCooldown)
			{
				cooldownTimer = 0;
				animator.SetTrigger("Attack");
				player.GetComponent<PlayerHealth>().TakeDamage(damange);
			}
			
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Attack");
	}
}