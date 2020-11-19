using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : MonoBehaviour
{
    public Text plyrHealth;

    void Start()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null) { plyrHealth.text = "Health: " + player.Health.ToString(); }
    }    
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateHealth(5);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
            plyrHealth.text = "Health: " + player.Health.ToString();
        }
    }
}
