using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public BulletManager bulletManager;



    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
         bulletManager = FindObjectOfType<BulletManager>();
    }

   
    public void ShootButtonPressed()
{
    if (bulletManager.CanShoot())
    {
        Shoot();
    }
}


void Shoot()
{
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
    rbBullet.gravityScale = 1;
    rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    playerController.AddRecoilAndRotation(bulletForce, firePoint.up);

    bulletManager.ShootBullet(); // Decrementa il conteggio dei proiettili
    FindObjectOfType<GameManager>().ShotFired();
}

}
