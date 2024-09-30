using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> powerUps = new List<GameObject>();
    public List<GameObject> materials = new List<GameObject>();
    public Transform powerUpSpawnPoint;  // Generalized spawn point for all power-ups
    public PowerUpManager powerUpManager;  // Reference to the PowerUpManager
    public MaterialManager materialManager;  // Reference to the MaterialManager

    public void AddPowerUp(GameObject powerUp, string powerUpName)
    {
        powerUps.Add(powerUp);
        powerUpManager.AddPowerUp(powerUpName);  // Update the PowerUpManager with the collected power-up
    }

    public void AddMaterial(GameObject material, string materialName)
    {
        Debug.Log("In Inventory addMaterial");
        materials.Add(material);
        Debug.Log("Material added successfully in inventory AddMaterial");
        materialManager.AddMaterial(materialName);  // Update the PowerUpManager with the collected power-up
    }

    public void Update()
    {
        if (powerUps.Count > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the first power-up in the list
            Instantiate(powerUps[0], powerUpSpawnPoint.position, powerUpSpawnPoint.rotation);
            powerUpManager.ReleasePowerUp("Fireball");  // Update the count in PowerUpManager
            powerUps.RemoveAt(0);
        }
    }
}
