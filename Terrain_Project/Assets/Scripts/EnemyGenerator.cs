using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject theEnemy;
    private Transform player;
    public int enemyCount = 0;                                                              
    private int limit = 10;
    private int kills = 0;
    public static int Points{ get; set; }
    private Coroutine generate;
    public static EnemyGenerator Instance{ get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Points = 2;
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(EnemyDrop());
    }

    public void EnemyDeath()
    {
        kills++;
        enemyCount--;
        if(kills % 5 == 0 && kills > 0)
        {
            limit++;
        }
    }
    IEnumerator EnemyDrop()
    {
        while(true)
        {
            if(enemyCount < limit)
            {
                float xPos = Random.Range(player.position.x, player.position.x + 10.0f);
                float zPos = Random.Range(player.position.z, player.position.z + 10.0f);
                Instantiate(theEnemy, new Vector3(xPos,player.position.y + 5,zPos), Quaternion.identity);
                enemyCount++;
            }
            if (kills % 25 == 0 && kills > 0)
            {
                Points+=2;
                yield return new WaitForSeconds(60f);
            
            }else{
                yield return new WaitForSeconds(1f);
            }
        }
    }
    
}
