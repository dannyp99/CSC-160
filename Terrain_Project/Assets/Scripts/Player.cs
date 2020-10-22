using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100.0f;

    [SerializeField]
    private int regen = 1;

    [SerializeField]
    private int delay = 5;
    private float damage = 10f;
    private float lastDamageTime = -1.0f;
    public float health;
    public HealthBar healthBar;
    public GameManager manager;
    private GameObject body;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if(lastDamageTime >=0 && Time.time - lastDamageTime >= delay)
        {
            Heal();
        }
                
    }
    public void Heal()
    {
        delay = 1;
        health += regen;
        healthBar.SetHealth(health);
        lastDamageTime = Time.time;
        if(health == maxHealth)
        {
            lastDamageTime = -1.0f;
        }
    }
    public void TakeDamage(float damage)
    {
        delay = 5;
        health -= damage;
        healthBar.SetHealth(health);
        lastDamageTime = Time.time;
        if(health <= 0f) {manager.GameOver();}

    }

    void Shoot()
    {
        GameObject plyr = this.gameObject;
        Vector3 playerPos = cam.ScreenToWorldPoint(Vector3.zero);
        Vector3 aimTarget = plyr.transform.position + plyr.transform.forward * 100;
        Vector3 dir  = aimTarget - playerPos;

        UnityEngine.Debug.DrawRay(playerPos, dir, Color.yellow, .5f);
        if(Physics.Raycast(new Ray(playerPos, dir), out RaycastHit hitInfo, dir.magnitude))
        {
            Debug.Log(hitInfo.transform.name);
            Enemy target = hitInfo.transform.GetComponent<Enemy>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            aimTarget = hitInfo.point;
        }
    }
}
