using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 20f;
    [SerializeField] private AudioClip jumpSound;

    float horizontalMove = 0f;
    bool jump = false;

    public float jumpRate = 1.0f;
    private float nextJumpTime = 0f;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Time.time >= nextJumpTime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                SoundManager.instance.PlaySound(jumpSound);
                animator.SetBool("isJumping", true);
                nextJumpTime = Time.time + 1f / jumpRate;
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
