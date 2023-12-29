using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f; // Durata del proiettile in secondi

    void Start()
    {
        Destroy(gameObject, lifetime); // Distrugge il proiettile dopo un certo periodo di tempo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            FindObjectOfType<BulletManager>().ReloadBullet(); // Ricarica un proiettile
            FindObjectOfType<GameManager>().TargetHit(collision.gameObject); // Notifica al GameManager
        }

        // Distrugge il proiettile al momento della collisione
        Destroy(gameObject);
    }
}
