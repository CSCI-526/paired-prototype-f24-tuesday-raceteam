using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    public TextMesh fireballTextMesh; 
    public Inventory playerInventory;  

    void Start()
    {
        if (playerInventory == null)
        {
            Debug.LogError("Player Inventory is not set in FireballManager.");
            return;
        }

        // ensure that the inventory is initialized
        StartCoroutine(InitializeFireballText());
    }

    IEnumerator InitializeFireballText()
    {
        // wait for the end of the frame to make sure that the Inventory is initialized
        yield return new WaitForEndOfFrame();
        UpdateFireballText();  
    }

    void Update()
    {
        if (playerInventory != null)
        {
            UpdateFireballText(); 
        }
    }

    void UpdateFireballText()
    {
        if (playerInventory == null)
        {
            Debug.LogError("Player Inventory is not set in FireballManager.");
            return;
        }

        try
        {
            fireballTextMesh.text = "Fire: " + playerInventory.materials["Fire"] +
                                    "\nWater: " + playerInventory.materials["Water"] +
                                    "\nBall: " + playerInventory.materials["Ball"] +
                                    "\nFireballs: " + playerInventory.powerUps["Fireball"] +
                                    "\nWaterballs: " + playerInventory.powerUps["Waterball"];
        }
        catch (KeyNotFoundException e)
        {
            Debug.LogError("Key not found in dictionary: " + e.Message);
        }
    }
}