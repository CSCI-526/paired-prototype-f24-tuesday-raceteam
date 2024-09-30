using UnityEngine;

public class Fireball : PowerUp
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Start()
    {
        powerUpName = "Fireball";  // Set the power-up name
        Destroy(gameObject, lifeTime);  // Destroy the fireball after a set amount of time
    }

    void Update()
    {
        // Move the fireball forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the obstacle on collision
        if (other.CompareTag("Obstacles"))
        {
            Destroy(other.gameObject); // Destroy the obstacle
            Destroy(gameObject); // Destroy the fireball
        }
    }

    public override void Activate()
    {
        // Define specific activation logic for the fireball if needed
        Debug.Log("Fireball activated");
    }
}
