using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject currentPowerUp;
    public Transform fireballSpawnPoint;

    public void AddPowerUp(GameObject powerUp)
    {
        currentPowerUp = powerUp;
    }

    public void Update(){
        if (currentPowerUp != null && Input.GetKeyDown(KeyCode.Space))
        {
            // Use the item (instantiate it in the world)
            if(currentPowerUp.name == "fireballprefeb")
            {
                Instantiate(currentPowerUp, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
                currentPowerUp = null;
            }
        }
    }
}