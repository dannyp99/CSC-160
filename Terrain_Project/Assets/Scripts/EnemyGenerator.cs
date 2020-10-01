using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject theEnemy;
    private Transform player;
    public int enemyCount;
    public int limit = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        float lowerx = player.position.x;
        float lowery = player.position.y;
        float lowerz = player.position.z;
        while(enemyCount < limit)
        {
            
            float xPos = Random.Range(player.position.x, player.position.x + 10.0f);
            float zPos = Random.Range(player.position.z, player.position.z + 10.0f);
            Instantiate(theEnemy, new Vector3(xPos,player.position.y + 5,zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount++;
        }   
    }
    
}
