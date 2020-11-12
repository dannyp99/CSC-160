using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateHealth(5);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
        }
    }
}
