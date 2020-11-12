using UnityEngine;
public class FireSpeedUpgrade : MonoBehaviour
{
   public void Upgrade()
   {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateFireSpeed(2);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
        }
   }
}
