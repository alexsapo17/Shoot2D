using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{  
    
    public Rigidbody2D rb;
    public float maxAngularVelocity = 100f;
    public float bounceForce = 10f;
    public float rotationRecoilForce = 2f; // Per controllare la forza di rotazione
    public float gravityScale = 0.5f; // Per controllare la gravità
    public float maxSpeed = 5f;
    private float lastAbilityUseTime = 0f;
    public float abilityCooldown = 2f; // Tempo di attesa tra l'uso dell'abilità, ora impostato a 2 secondi
public float rotationSpeed = 360f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; // Imposta la gravità qui
    }
    void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (transform.position.y >= screenBounds.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, -bounceForce);
        }

        if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        }
        else if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastAbilityUseTime >= abilityCooldown)
        {
            FlipPlayerInstantly();
            lastAbilityUseTime = Time.time;
        }
        
    }
        void FixedUpdate()
    {
        // Controlla e limita la velocità del player
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // ... altre logiche di movimento ...
    }
    public void FlipButtonPressed()
{
    if (Time.time - lastAbilityUseTime >= abilityCooldown)
    {
        FlipPlayerInstantly();
        lastAbilityUseTime = Time.time;
    }
}

void FlipPlayerInstantly()
{
    // Calcola la nuova rotazione come rotazione attuale + 180 gradi
    float newRotation = rb.rotation + 180f;
    rb.MoveRotation(newRotation);
}

    public void AddRecoilAndRotation(float recoilForce, Vector3 direction)
    {
        rb.AddForce(-direction * recoilForce, ForceMode2D.Impulse);
        AddTorqueBasedOnDirection(direction);
    }
void AddTorqueBasedOnDirection(Vector3 direction)
{
    float rotationDirection = direction.x > 0 ? -1f : 1f;
    float torque = rotationDirection * rotationRecoilForce;
    Debug.Log("Applying torque: " + torque); // Aggiungi questo per debug
    rb.AddTorque(torque, ForceMode2D.Impulse);
    rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    Debug.Log("Angular velocity: " + rb.angularVelocity); // Aggiungi questo per debug
}

}
