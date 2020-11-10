using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
   public void Upgrade()
   {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateDamage(3);
            EnemyGenerator.Points--;
        }
   }
}
