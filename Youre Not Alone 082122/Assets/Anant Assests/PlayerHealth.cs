using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 0;
    public HealthBar healthBar;

    //[SerializeField] private float maxHealth = 100f;

    public void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(int mod)
    {
        health -= mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0)
        {
            health = 0;
            Debug.Log("Player Respawn");
        }

        healthBar.SetHealth(health);
    }
}
