using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int startingHealth;
    [SerializeField] private HealthSlider healthSlider;
    [SerializeField] private AudioClip getHitSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] public int currentHealth;
    private Animator anim;
    public bool dead = false;

    //[Header("iFrames")]
    //[SerializeField] private float iFramesDuration;
    //[SerializeField] private int numberOfFlashes;
    //private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
        healthSlider.SetMaxHealth(currentHealth);

        anim = GetComponent<Animator>();
        //spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int _damage)
    {
        currentHealth = (int)Mathf.Clamp(currentHealth - _damage, 0f, startingHealth);
        healthSlider.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");

            if (currentHealth > 1)
                SoundManager.instance.PlaySound(getHitSound);

            //StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                SoundManager.instance.PlaySound(deathSound);
                anim.SetBool("isDead", true);

                // Deactivate all attached components
                foreach (Behaviour component in components)
                    component.enabled = false;

                
                GetComponent<Rigidbody2D>().simulated = false;
                GetComponent<SpriteRenderer>().sortingLayerName = "Dead Player";

                dead = true;
            }
        }
    }
    public void AddHealth(int _value)
    {
        currentHealth = (int)Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        //currentHealth = currentHealth + _value;
        healthSlider.SetHealth(currentHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.SetBool("isDead", false);
        anim.Play("PlayerWithSword_Idle");

        // Activate all attached components
        foreach (Behaviour component in components)
            component.enabled = true;

        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<SpriteRenderer>().sortingLayerName = "Actor";
    }

    //private IEnumerator Invunerability()
    //{
    //    Physics2D.IgnoreLayerCollision(3, 6, true);
    //    for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        //spriteRend.color = new Color(1, 0, 0, 0.4f);
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //        spriteRend.color = Color.white;
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //    }
    //    Physics2D.IgnoreLayerCollision(3, 6, false);
    //}
}