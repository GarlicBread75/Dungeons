using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate;
    [SerializeField] float spread;
    float atkSpd;
    bool atkPressed;
    bool shooting;

    [Space]

    [SerializeField] GameObject bullet;
    [SerializeField] int damage;
    [SerializeField] float minBulletSpeed;
    [SerializeField] float maxBulletSpeed;
    [SerializeField] int bulletCount;

    void Update()
    {
        if (atkSpd > 0)
        {
            return;
        }

        if (Input.GetMouseButton(0) && !shooting)
        {
            atkPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (atkSpd > 0)
        {
            atkSpd -= Time.fixedDeltaTime;
        }

        if (atkPressed)
        {
            atkPressed = false;
            Shoot();
        }
    }

    void Shoot()
    {
        shooting = true;
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject shotBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = shotBullet.GetComponent<Rigidbody2D>();
            shotBullet.GetComponent<Bullet>().damage = damage;
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pDir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            bulletRb.velocity = (dir + pDir) * Random.Range(minBulletSpeed, maxBulletSpeed);
        }
        atkSpd = fireRate;
        shooting = false;
    }
}
