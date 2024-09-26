using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembox : MonoBehaviour
{
    public GameObject fireballprefeb;
    private bool isCollected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            // Assume the player has an inventory system
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null)
            {

                // Add item to player's inventory
                inventory.AddPowerUp(fireballprefeb);

                // Destroy the item box after use
                Destroy(gameObject);
            }
        }
    }
}
