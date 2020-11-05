using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        int points = EnemyGenerator.Points;
        if(points > 0 && player != null)
        {
            Debug.Log(points);
            player.UpdateHealth(5);
            points--;
        }
        EnemyGenerator.Points = points;
    }
}
