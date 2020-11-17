using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 10f;
    public float cooldown = 1f;
    private float nextAttack = 0f;
    private float health = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Upgrade(float multiplier)
    {
        damage *= multiplier;
        health *= multiplier;
    }

    void OnTriggerStay(Collider other)
    {   
        if(Time.time > nextAttack)
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            nextAttack = Time.time + cooldown;
        }
    }
    public void TakeDamage(float amount)
    {
       health -= amount;
       Debug.Log("Ouch");
       if(health <=0f)
       {
         Die();  
       } 
    }
    void Die()
    {
        EnemyGenerator.Instance.EnemyDeath();
        Destroy(gameObject);
    }
}
