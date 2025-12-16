using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Reduces HP based on damage number in the enemy's inspector tab
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Injure animation plays
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
            anim.SetTrigger("die");
            GetComponent<PlatformerController>().enabled = false;
            dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    // This is to practice the injure animation and healthbar mechanics
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
    }
}
