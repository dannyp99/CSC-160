using UnityEngine;
using UnityEngine.UI;

public class DamageUpgrade : MonoBehaviour
{
    public Text plyrDamage;

    void Start()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null) { plyrDamage.text = "Damage: " + player.Damage.ToString(); }
    }    
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateDamage(3);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
            plyrDamage.text = "Damage: " + player.Damage.ToString();
        }
    }
}
