using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroying the enemy if health is 0 or below
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void damageEnemy(int damage)
    {
        // Reducing current health by damage amount
        currentHealth -= damage;
    }
}
