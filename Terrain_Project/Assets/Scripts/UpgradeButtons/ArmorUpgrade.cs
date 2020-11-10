using UnityEngine;

public class ArmorUpgrade : MonoBehaviour
{
   public void Upgrade()
   {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateArmor(2);
            EnemyGenerator.Points--;
        }
   }
}
