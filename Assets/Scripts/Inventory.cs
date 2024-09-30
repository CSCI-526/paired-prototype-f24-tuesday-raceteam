using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> powerUps = new List<GameObject>();
    public Transform fireballSpawnPoint;

    public void AddPowerUp(GameObject powerUp)
    {
        powerUps.Add(powerUp);
        Debug.Log("Fireball collected!");
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
        }
        if (powerUps.Count > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(powerUps[0], fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            powerUps.RemoveAt(0);
           
        }
    }
}