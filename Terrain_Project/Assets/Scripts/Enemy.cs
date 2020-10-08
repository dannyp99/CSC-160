
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 10f;
    public int effect = 5;
    public float cooldown = 1f;
    private float nextAttack = 0f;
    private float health = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {   
        if(Time.time > nextAttack)
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            nextAttack = Time.time + cooldown;
        }
    }
    // void OnTriggerExit(Collider other)
    // {
    //     int i = 0;
    //     while(i < effect)
    //     {
    //         if(Time.time > nextAttack)
    //         {
    //             i++;
    //             other.gameObject.GetComponent<Player>().TakeDamage(1f);
    //             nextAttack = Time.time + 0.5f;
    //         }
    //     }
    //     i = 0;
    // }
}
