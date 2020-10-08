using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float health;
    public HealthBar healthBar;
    public GameManager manager;
    private GameObject body;
    public int regen = 1;
    Coroutine stop;
    Coroutine heal;
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        heal = StartCoroutine(Heal());  
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void TakeDamage(float damage)
    {
        if(stop != null) {StopCoroutine(stop);}
        stop = StartCoroutine(StopHeal());
        health -= damage;
        healthBar.SetHealth(health);
        if(health <= 0f) {manager.GameOver();}

    }

    IEnumerator Heal()
    {
        while(health < maxHealth)
        {
            health += regen;
            healthBar.SetHealth(health);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator StopHeal()
    {   
        Debug.Log("STOP!");
        if(heal != null) {StopCoroutine(heal);}
        yield return new WaitForSeconds(5f);
        if(heal == null)
        {
            Debug.Log("Start");
            heal = StartCoroutine(Heal());
        }
    }
}
