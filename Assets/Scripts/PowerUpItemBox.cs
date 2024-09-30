using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItemBox : MonoBehaviour
{
    public GameObject powerUpPrefab;  // Any power-up prefab can be assigned here
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null)
            {
                PowerUp powerUp = powerUpPrefab.GetComponent<PowerUp>();
                if (powerUp != null)
                {
                    powerUp.Collect(inventory);  // Add the power-up to the inventory
                    Destroy(gameObject);  // Destroy the item box after use
                }
            }
        }
    }
}
