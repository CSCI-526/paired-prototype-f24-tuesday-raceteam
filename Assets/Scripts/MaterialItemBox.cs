using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialItemBox : MonoBehaviour
{
   public GameObject materialPrefab;  // Any material prefab can be assigned here
   private bool isCollected = false;

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player") && !isCollected)
      {
         isCollected = true;
         Inventory inventory = other.GetComponent<Inventory>();

         if (inventory != null)
         {
            Debug.Log("Inventory is not null");
            Material material = materialPrefab.GetComponent<Material>();
            if (material != null)
            {
               Debug.Log("Material is not null");
               material.Collect(inventory);  // Add the material to the inventory
               Debug.Log("Material collected");
               Destroy(gameObject);  // Destroy the item box after use
            }
         }
      }
   }
}
