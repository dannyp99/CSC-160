using UnityEngine;

public class RegenUpgrade : MonoBehaviour
{
   public void Upgrade()
   {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateRegen(1);
            EnemyGenerator.Points--;
        }
   }
}
