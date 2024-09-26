using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject currentPowerUp;
    public Transform fireballSpawnPoint;

    public void AddPowerUp(GameObject powerUp)
    {
        currentPowerUp = powerUp;
        Debug.Log("Fireball collected!");
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
        }
        if (currentPowerUp != null && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(currentPowerUp, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            currentPowerUp = null;
           
        }
    }
}