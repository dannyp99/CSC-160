using UnityEngine;
using UnityEngine.UI;

public class FireSpeedUpgrade : MonoBehaviour
{
    public Text plyrFireRate;
    
    void Start()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null) { plyrFireRate.text = "Fire Rate: " + player.FireRate.ToString(); }
    }
    public void Upgrade()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(EnemyGenerator.Points > 0 && player != null)
        {
            Debug.Log(EnemyGenerator.Points);
            player.UpdateFireSpeed(2);
            EnemyGenerator.Points--;
            EnemyGenerator.Instance.UpdatePoints();
            plyrFireRate.text = "Fire Rate: " + player.FireRate.ToString();
        }
    }
}
