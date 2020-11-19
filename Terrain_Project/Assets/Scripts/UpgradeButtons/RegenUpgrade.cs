using UnityEngine;
using UnityEngine.UI;

public class RegenUpgrade : MonoBehaviour
{
    public Text plyrRegen;

    void Start()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null) { plyrRegen.text = "Regen: " + player.Regen.ToString(); }
    }
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateRegen(1);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
            plyrRegen.text = "Regen: " + player.Regen.ToString();
        }
    }
}
