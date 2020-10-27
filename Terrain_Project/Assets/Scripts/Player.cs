using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100.0f;

    [SerializeField]
    private int regen = 1;

    [SerializeField]
    private int delay = 5;
    [SerializeField]
    private Vector3 offset;
    private float damage = 10f;
    private float lastDamageTime = -1.0f;
    private float fireRate = 4;
    private float nextTimeToFire = 1f;
    public float health;
    public HealthBar healthBar;
    public GameManager manager;
    private GameObject body;
    private Camera cam;
    public ParticleSystem leftMuzzle;
    public ParticleSystem rightMuzzle;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cam = Camera.main;
        offset = new Vector3(0, -18, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
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
        leftMuzzle.Play();
        rightMuzzle.Play();
        GameObject plyr = this.gameObject;
        Vector3 playerPos = cam.ScreenToWorldPoint(Vector3.zero);
        Vector3 aimTarget = (plyr.transform.position + offset) + plyr.transform.forward * 100;
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
            GameObject impactParticle = Instantiate(impactEffect, aimTarget, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactParticle, 2f);
        }
    }
}
