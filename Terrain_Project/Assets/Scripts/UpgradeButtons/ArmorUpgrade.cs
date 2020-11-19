using UnityEngine;
using UnityEngine.UI;

public class ArmorUpgrade : MonoBehaviour
{
    public Text plyrArmor;
    void Start()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null) { plyrArmor.text = "Armor: " + player.Armor.ToString(); }
    }
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateArmor(2);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
            plyrArmor.text = "Armor: " + player.Armor.ToString();
        }
    }
}
