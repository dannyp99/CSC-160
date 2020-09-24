using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float health;
    public HealthBar healthBar;
    public int regen = 1;
    // Start is called before the first frame update
    void Start()
    {
     health = maxHealth;
     healthBar.SetMaxHealth(maxHealth);
     StartCoroutine(Heal());  
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }

    IEnumerator Heal()
    {
        while(true)
        {
            if (health < maxHealth)
            {
                health += regen;
                healthBar.SetHealth(health);
            }
        yield return new WaitForSeconds(1f);
        }
    }
}
