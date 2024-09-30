using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembox : MonoBehaviour
{
    public GameObject fireballPrefab;
    private bool isCollected = false;
    private FireballManager fireballManager;
    void Start()
    {
        // Find the FireballManager in the scene (assuming it exists)
        fireballManager = FindObjectOfType<FireballManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            // Assume the player has an inventory system
            Inventory inventory = other.GetComponent<Inventory>();
            fireballManager.AddFireball();

            if (inventory != null)
            {

                // Add item to player's inventory
                inventory.AddPowerUp(fireballPrefab);

                // Destroy the item box after use
                Destroy(gameObject);
            }
        }
    }
}