using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> materials = new Dictionary<string, int>();
    public Dictionary<string, int> powerUps = new Dictionary<string, int>();
    public Transform fireballSpawnPoint;

    private void Start()
    {
        materials["Fire"] = 0;
        materials["Water"] = 0;
        materials["Ball"] = 0;

        powerUps["Fireball"] = 0;
        powerUps["Waterball"] = 0;

        Debug.Log("Materials initialized: " + string.Join(", ", materials.Keys));
        Debug.Log("PowerUps initialized: " + string.Join(", ", powerUps.Keys));
    }

    public void AddMaterial(string materialType)
    {
        if (materials.ContainsKey(materialType))
        {
            materials[materialType]++;
            Debug.Log(materialType + " collected!");
            CheckForPowerUp();
        }
        else
        {
            Debug.LogError("Material type not found: " + materialType);
        }
    }

    private void CheckForPowerUp()
    {
        // check if we can create a Fireball
        if (materials["Fire"] > 0 && materials["Ball"] > 0)
        {
            materials["Fire"]--;
            materials["Ball"]--;
            powerUps["Fireball"]++;
            Debug.Log("Fireball created!");
        }

        // check if we can create a waterball
        if (materials["Water"] >= 3 && materials["Ball"] >= 3)
        {
            materials["Water"] -= 3;
            materials["Ball"] -= 3;
            powerUps["Waterball"]++;
            Debug.Log("Waterball created!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (powerUps["Fireball"] > 0)
            {
                Instantiate(Resources.Load("Fireball"), fireballSpawnPoint.position, fireballSpawnPoint.rotation);
                powerUps["Fireball"]--;
            }
            else
            {
                Debug.Log("No Fireballs available!");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (powerUps["Waterball"] > 0)
            {
                FireWaterballs();
                powerUps["Waterball"]--;
            }
            else
            {
                Debug.Log("No Waterballs available!");
            }
        }
    }

    private void FireWaterballs()
    {
        float spread = 1.0f; 
        Vector3 leftPosition = fireballSpawnPoint.position + fireballSpawnPoint.right * -spread;
        Vector3 rightPosition = fireballSpawnPoint.position + fireballSpawnPoint.right * spread;

        GameObject centerWaterball = Instantiate(Resources.Load("Waterball"), fireballSpawnPoint.position, fireballSpawnPoint.rotation) as GameObject;
        GameObject leftWaterball = Instantiate(Resources.Load("Waterball"), leftPosition, fireballSpawnPoint.rotation) as GameObject;
        GameObject rightWaterball = Instantiate(Resources.Load("Waterball"), rightPosition, fireballSpawnPoint.rotation) as GameObject;

        // apply forces to move the waterballs
        Rigidbody centerRb = centerWaterball.GetComponent<Rigidbody>();
        Rigidbody leftRb = leftWaterball.GetComponent<Rigidbody>();
        Rigidbody rightRb = rightWaterball.GetComponent<Rigidbody>();

        float force = 10f; 
        centerRb.AddForce(fireballSpawnPoint.forward * force, ForceMode.Impulse);
        leftRb.AddForce((fireballSpawnPoint.forward + fireballSpawnPoint.right * -0.5f) * force, ForceMode.Impulse);
        rightRb.AddForce((fireballSpawnPoint.forward + fireballSpawnPoint.right * 0.5f) * force, ForceMode.Impulse);
    }
}