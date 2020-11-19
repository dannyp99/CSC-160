using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject theEnemy;
    private Transform player;
    public Text killText;
    public int enemyCount = 0;                                                              
    private int limit = 10;
    private int kills = 1;
    private int killcounter = 0;
    private int nextLevel = 25;
    private int pointsCap = 2;
    private int level = 1;
    private float mult = 1.0f;
    private float multiRate = 0.5f;
    public PointsBar pointsBar;
    public static int Points{ get; set; }
    private Coroutine generate;
    public static EnemyGenerator Instance{ get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        killText.text = "Kills: 0";
        Points = 2;
        pointsBar.InitPoints(Points);
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(EnemyDrop());
    }

    public void EnemyDeath()
    {
        kills++;
        killcounter++;
        killText.text = "Kills: " + killcounter.ToString();
        enemyCount--;
        if(kills % 5 == 0)
        {
            limit++;
        }
    }
    public void UpdatePoints()
    {
        pointsBar.SetPoints(Points);
    }

    void UpdateLevel()
    {
        pointsCap++;
        nextLevel += 10;
        multiRate += 0.2f;
    }
    IEnumerator EnemyDrop()
    {
        while(true)
        {
            if(enemyCount < limit && (enemyCount+kills) % nextLevel != 0)
            {
                float xPos = Random.Range(player.position.x, player.position.x + 10.0f);
                float zPos = Random.Range(player.position.z, player.position.z + 10.0f);
                GameObject newEnemy = Instantiate(theEnemy, new Vector3(xPos,player.position.y + 5,zPos), Quaternion.identity);
                if(newEnemy != null)
                {
                    enemyCount++;
                    Enemy enemyScript = newEnemy.GetComponent<Enemy>();
                    if(enemyScript != null)
                    {
                        enemyScript.Upgrade(mult);
                    }
                }
            }
            if (kills % nextLevel == 0 && enemyCount == 0)
            {
                level++;
                if(level % 5 == 0) { UpdateLevel(); }
                mult += multiRate;
                Points+=pointsCap;
                pointsBar.AddPoints();
                kills++;
                yield return new WaitForSeconds(60f);
            
            }else{
                yield return new WaitForSeconds(1f);
            }
        }
    }
    
}
