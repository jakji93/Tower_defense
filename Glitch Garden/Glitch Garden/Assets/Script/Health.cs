using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] GameObject deathVFX;

    private void CheckHealth()
    {
        if (health <= 0)
        {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        Destroy(gameObject);
        if (!deathVFX)
        {
            return;
        }
        var vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }
}
