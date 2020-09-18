using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent nm;
    float dist;
    public float trigger = 20f;
    public Transform target;
    public enum AIState { idle,chasing };
    public AIState aiState = AIState.idle;
    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Think());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Think()
    {
        while(true) 
        {
            dist = Vector3.Distance(target.position, transform.position);
            switch(aiState)
            {
                case AIState.idle:
                    if (dist <= trigger)
                        aiState = AIState.chasing;
                    nm.SetDestination(transform.position);
                    break;
                case AIState.chasing:
                    if (dist > trigger)
                        aiState = AIState.idle;
                    nm.SetDestination(target.position);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}