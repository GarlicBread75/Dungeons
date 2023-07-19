using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] int damage;
    [SerializeField] float fireRate;
    enum ShootingType { Manual, SemiAuto, Automatic }
    [SerializeField] ShootingType firingMode;
    [SerializeField] int bulletsPerShot;
    [SerializeField] float spread;
}
