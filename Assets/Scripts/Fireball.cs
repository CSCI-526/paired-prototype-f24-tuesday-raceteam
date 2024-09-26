using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Start()
    {
        // Destroy the fireball after a set amount of time
        Destroy(gameObject, lifeTime);
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
}
